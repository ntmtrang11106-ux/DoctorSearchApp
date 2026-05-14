using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace UI_Tier
{
    public partial class ucPieChart : UserControl
    {
        private List<double> _values = new List<double>();
        private List<string> _labels = new List<string>();
        private List<Color> _colors = new List<Color>();
        private int _hoveredIndex = -1;
        private Rectangle _chartRect;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The title of the pie chart")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("Phân bổ chuyên khoa")]
        public string Title { get => lblTitle.Text; set { lblTitle.Text = value; } }

        public ucPieChart()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlPieArea);
            pnlPieArea.Paint += PnlPieArea_Paint;
            pnlPieArea.MouseMove += PnlPieArea_MouseMove;
            pnlPieArea.MouseLeave += PnlPieArea_MouseLeave;
        }

        public void SetData(List<double> values, List<string> labels, List<Color> colors)
        {
            _values = values;
            _labels = labels;
            _colors = colors;
            pnlPieArea.Invalidate();
        }

        private void PnlPieArea_MouseLeave(object sender, EventArgs e)
        {
            _hoveredIndex = -1;
            pnlPieArea.Invalidate();
        }

        private void PnlPieArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (_values == null || _values.Count == 0) return;

            Point center = new Point(_chartRect.X + _chartRect.Width / 2, _chartRect.Y + _chartRect.Height / 2);
            double dx = e.X - center.X;
            double dy = e.Y - center.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            int newHoveredIndex = -1;
            if (dist <= _chartRect.Width / 2)
            {
                double angle = Math.Atan2(dy, dx) * 180 / Math.PI;
                if (angle < -90) angle += 360;
                
                float currentAngle = -90;
                float total = (float)_values.Sum();

                for (int i = 0; i < _values.Count; i++)
                {
                    float sweepAngle = (float)(_values[i] / total * 360f);
                    if (angle >= currentAngle && angle < currentAngle + sweepAngle)
                    {
                        newHoveredIndex = i;
                        break;
                    }
                    currentAngle += sweepAngle;
                }
            }

            if (newHoveredIndex != _hoveredIndex)
            {
                _hoveredIndex = newHoveredIndex;
                pnlPieArea.Invalidate();
            }
        }

        private void PnlPieArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            if (_values == null || _values.Count == 0)
            {
                using (Font f = new Font("Outfit", 12))
                {
                    string noData = "Không có dữ liệu";
                    SizeF sz = g.MeasureString(noData, f);
                    g.DrawString(noData, f, Brushes.Gray, (pnlPieArea.Width - sz.Width) / 2, (pnlPieArea.Height - sz.Height) / 2);
                }
                return;
            }

            float total = (float)_values.Sum();
            if (total == 0) total = 1; // Tránh lỗi chia cho 0

            int margin = 80;
            int size = Math.Min(pnlPieArea.Width - (margin * 2), pnlPieArea.Height - 100);
            if (size <= 0) return;

            _chartRect = new Rectangle((pnlPieArea.Width - size) / 2, (pnlPieArea.Height - size) / 2 + 10, size, size);

            float startAngle = -90;
            for (int i = 0; i < _values.Count; i++)
            {
                if (_values[i] <= 0) continue; // Không vẽ các phần tử bằng 0

                float sweepAngle = (float)(_values[i] / total * 360f);
                Color color = i < _colors.Count ? _colors[i] : Color.Gray;

                // Hiệu ứng hover: phóng to nhẹ miếng pie
                Rectangle sliceRect = _chartRect;
                if (i == _hoveredIndex)
                {
                    sliceRect.Inflate(5, 5);
                }

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillPie(brush, sliceRect, startAngle, sweepAngle);
                }

                // Vẽ nhãn và đường kẻ dẫn
                float midAngle = startAngle + (sweepAngle / 2);
                double rad = midAngle * Math.PI / 180;
                
                float lineStartDist = size / 2 - 10;
                float lineEndDist = size / 2 + 30;
                float labelDist = size / 2 + 40;

                PointF pStart = new PointF(
                    (float)(_chartRect.X + _chartRect.Width / 2 + Math.Cos(rad) * lineStartDist),
                    (float)(_chartRect.Y + _chartRect.Height / 2 + Math.Sin(rad) * lineStartDist)
                );
                PointF pEnd = new PointF(
                    (float)(_chartRect.X + _chartRect.Width / 2 + Math.Cos(rad) * lineEndDist),
                    (float)(_chartRect.Y + _chartRect.Height / 2 + Math.Sin(rad) * lineEndDist)
                );

                using (Pen linePen = new Pen(color, 1.5f))
                {
                    g.DrawLine(linePen, pStart, pEnd);
                }

                string labelText = $"{_labels[i]}: {_values[i]}";
                using (Font labelFont = new Font("Outfit", 9, FontStyle.Bold))
                {
                    SizeF sz = g.MeasureString(labelText, labelFont);
                    float lx = (float)(_chartRect.X + _chartRect.Width / 2 + Math.Cos(rad) * labelDist);
                    float ly = (float)(_chartRect.Y + _chartRect.Height / 2 + Math.Sin(rad) * labelDist) - sz.Height / 2;

                    if (Math.Cos(rad) < -0.1) lx -= sz.Width;
                    else if (Math.Cos(rad) < 0.1) lx -= sz.Width / 2;

                    g.DrawString(labelText, labelFont, new SolidBrush(color), lx, ly);
                }

                startAngle += sweepAngle;
            }

            // Vẽ lỗ ở giữa để thành Doughnut Chart (Hiện đại hơn)
            int holeSize = (int)(size * 0.6);
            Rectangle holeRect = new Rectangle(
                _chartRect.X + (_chartRect.Width - holeSize) / 2,
                _chartRect.Y + (_chartRect.Height - holeSize) / 2,
                holeSize, holeSize
            );
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            {
                g.FillEllipse(whiteBrush, holeRect);
            }

            // Vẽ viền nhạt cho lỗ
            using (Pen holePen = new Pen(Color.FromArgb(240, 240, 240), 1))
            {
                g.DrawEllipse(holePen, holeRect);
            }

            // Tooltip ở giữa khi hover
            if (_hoveredIndex != -1)
            {
                string tooltipTitle = _labels[_hoveredIndex];
                string tooltipVal = _values[_hoveredIndex].ToString();

                using (Font titleFont = new Font("Outfit", 10, FontStyle.Regular))
                using (Font valFont = new Font("Outfit", 16, FontStyle.Bold))
                {
                    SizeF szTitle = g.MeasureString(tooltipTitle, titleFont);
                    SizeF szVal = g.MeasureString(tooltipVal, valFont);

                    float tx = holeRect.X + (holeRect.Width - szTitle.Width) / 2;
                    float ty = holeRect.Y + (holeRect.Height - (szTitle.Height + szVal.Height)) / 2;

                    g.DrawString(tooltipTitle, titleFont, Brushes.Gray, tx, ty);
                    g.DrawString(tooltipVal, valFont, new SolidBrush(Color.FromArgb(17, 34, 71)), 
                        holeRect.X + (holeRect.Width - szVal.Width) / 2, ty + szTitle.Height);
                }
            }
            else
            {
                // Mặc định hiển thị tổng số
                string totalTitle = "Tổng số";
                string totalVal = _values.Sum().ToString();
                using (Font titleFont = new Font("Outfit", 10, FontStyle.Regular))
                using (Font valFont = new Font("Outfit", 16, FontStyle.Bold))
                {
                    SizeF szTitle = g.MeasureString(totalTitle, titleFont);
                    SizeF szVal = g.MeasureString(totalVal, valFont);
                    float tx = holeRect.X + (holeRect.Width - szTitle.Width) / 2;
                    float ty = holeRect.Y + (holeRect.Height - (szTitle.Height + szVal.Height)) / 2;
                    g.DrawString(totalTitle, titleFont, Brushes.Gray, tx, ty);
                    g.DrawString(totalVal, valFont, new SolidBrush(Color.FromArgb(17, 34, 71)), 
                        holeRect.X + (holeRect.Width - szVal.Width) / 2, ty + szTitle.Height);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UIHelper.ApplyRoundedRegion(this, 25);
        }
    }
}

