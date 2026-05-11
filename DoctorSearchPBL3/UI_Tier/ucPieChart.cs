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

            if (_values == null || _values.Count == 0) return;

            float total = (float)_values.Sum();
            float startAngle = -90;

            int margin = 60;
            int size = Math.Min(pnlPieArea.Width - (margin * 2), pnlPieArea.Height - 100);
            if (size <= 0) return;

            _chartRect = new Rectangle((pnlPieArea.Width - size) / 2, (pnlPieArea.Height - size) / 2 - 10, size, size);

            // Draw shadow/background for pie area if needed (optional)

            for (int i = 0; i < _values.Count; i++)
            {
                float sweepAngle = (float)(_values[i] / total * 360f);
                Color color = i < _colors.Count ? _colors[i] : Color.Gray;

                // Slightly expand the hovered slice
                Rectangle sliceRect = _chartRect;
                if (i == _hoveredIndex)
                {
                    // sliceRect.Inflate(3, 3);
                }

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillPie(brush, sliceRect, startAngle, sweepAngle);
                }

                // Draw Label
                float midAngle = startAngle + (sweepAngle / 2);
                double rad = midAngle * Math.PI / 180;
                
                // Increase distance for labels to avoid "sticking"
                float labelDistance = size / 2 + 35; 
                float labelX = (float)(_chartRect.X + _chartRect.Width / 2 + Math.Cos(rad) * labelDistance);
                float labelY = (float)(_chartRect.Y + _chartRect.Height / 2 + Math.Sin(rad) * labelDistance);

                string labelText = $"{_labels[i]}: {_values[i]}";
                using (Font labelFont = new Font("Outfit", 10, FontStyle.Regular))
                {
                    SizeF sz = g.MeasureString(labelText, labelFont);
                    
                    // Adjust position based on quadrant to keep it tidy
                    float drawX = labelX;
                    float drawY = labelY - sz.Height / 2;

                    if (Math.Cos(rad) > 0.1) drawX = labelX; // Right side
                    else if (Math.Cos(rad) < -0.1) drawX = labelX - sz.Width; // Left side
                    else drawX = labelX - sz.Width / 2; // Center top/bottom

                    g.DrawString(labelText, labelFont, new SolidBrush(color), drawX, drawY);
                }

                startAngle += sweepAngle;
            }

            // Draw center tooltip if hovered
            if (_hoveredIndex != -1)
            {
                string tooltipText = $"{_labels[_hoveredIndex]} : {_values[_hoveredIndex]}";
                using (Font tooltipFont = new Font("Outfit", 11, FontStyle.Bold))
                {
                    SizeF sz = g.MeasureString(tooltipText, tooltipFont);
                    int boxW = (int)sz.Width + 40;
                    int boxH = (int)sz.Height + 20;
                    Rectangle boxRect = new Rectangle(
                        _chartRect.X + (_chartRect.Width - boxW) / 2,
                        _chartRect.Y + (_chartRect.Height - boxH) / 2,
                        boxW, boxH
                    );

                    // Draw box with rounded corners and subtle shadow/border
                    using (GraphicsPath path = UIHelper.GetRoundedPath(boxRect, 8))
                    {
                        // Background
                        using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                        {
                            g.FillPath(whiteBrush, path);
                        }
                        
                        // Border
                        using (Pen p = new Pen(Color.FromArgb(230, 230, 230), 1))
                        {
                            g.DrawPath(p, path);
                        }
                    }

                    // Text
                    g.DrawString(tooltipText, tooltipFont, new SolidBrush(Color.FromArgb(33, 33, 33)), 
                        boxRect.X + (boxRect.Width - sz.Width) / 2, 
                        boxRect.Y + (boxRect.Height - sz.Height) / 2);
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

