using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace UI_Tier
{
    public partial class ucSimpleChart : UserControl
    {
        public enum ChartType { Line, Area }
        
        [Browsable(true)]
        [Category("Behavior")]
        [Description("The type of chart to display (Line or Area)")]
        [DefaultValue(ChartType.Area)]
        public ChartType Mode { get; set; } = ChartType.Area;
        
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The title of the chart")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("Chart Title")]
        public string Title { get => lblTitle.Text; set { lblTitle.Text = value; } }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The primary theme color of the chart")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ThemeColor { get; set; } = Color.FromArgb(127, 85, 240);

        private List<List<double>> _multiData = new List<List<double>>();
        private List<string> _seriesNames = new List<string>();
        private List<Color> _seriesColors = new List<Color>();
        private List<string> _labels = new List<string>();
        private float _scrollOffset = 0;
        private Point _lastMousePos;
        private bool _isDragging = false;
        private int _minPointWidth = 100;
        private int _hoverIndex = -1;
        private Point _mouseLocation;

        public ucSimpleChart()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlChartArea);
            
            pnlChartArea.Paint += PnlChartArea_Paint;
            pnlChartArea.MouseDown += (s, e) => { _isDragging = true; _lastMousePos = e.Location; };
            pnlChartArea.MouseMove += (s, e) => {
                _mouseLocation = e.Location;
                if (_isDragging) {
                    _scrollOffset += (e.X - _lastMousePos.X);
                    _lastMousePos = e.Location;
                    ConstrainScroll();
                    pnlChartArea.Invalidate();
                } else {
                    UpdateHoverIndex(e.X);
                }
            };
            pnlChartArea.MouseLeave += (s, e) => {
                _hoverIndex = -1;
                pnlChartArea.Invalidate();
            };
            pnlChartArea.MouseUp += (s, e) => { _isDragging = false; };
            pnlChartArea.MouseWheel += (s, e) => {
                _scrollOffset += (e.Delta > 0 ? 50 : -50);
                ConstrainScroll();
                pnlChartArea.Invalidate();
            };
        }

        private void ConstrainScroll()
        {
            if (_multiData == null || _multiData.Count == 0 || _multiData[0].Count < 2) return;
            float chartAreaWidth = pnlChartArea.Width - 80 - 40;
            float totalWidth = (_multiData[0].Count - 1) * _minPointWidth;
            float minScroll = -Math.Max(0, (totalWidth - chartAreaWidth) + 50);
            if (_scrollOffset > 0) _scrollOffset = 0;
            if (_scrollOffset < minScroll) _scrollOffset = minScroll;
        }

        public void SetData(List<double> data, List<string> labels)
        {
            SetMultiData(new List<List<double>> { data }, labels, new List<string> { "Giá trị" }, new List<Color> { ThemeColor });
        }

        public void SetMultiData(List<List<double>> multiData, List<string> labels, List<string> seriesNames, List<Color> seriesColors)
        {
            _multiData = multiData;
            _labels = labels;
            _seriesNames = seriesNames;
            _seriesColors = seriesColors;
            _scrollOffset = 0;
            pnlChartArea.Invalidate();
        }

        private void UpdateHoverIndex(int mouseX)
        {
            if (_multiData == null || _multiData.Count == 0 || _multiData[0].Count < 2) return;

            Padding p = new Padding(60, 20, 40, 40);
            float chartAreaLeft = p.Left;
            float stepX = Math.Max((float)(pnlChartArea.Width - p.Left - p.Right) / (_multiData[0].Count - 1), _minPointWidth);

            float localX = mouseX - (chartAreaLeft + _scrollOffset);
            int index = (int)Math.Round(localX / stepX);

            if (index >= 0 && index < _multiData[0].Count)
            {
                float pointX = index * stepX + chartAreaLeft + _scrollOffset;
                if (Math.Abs(mouseX - pointX) < 30)
                {
                    if (_hoverIndex != index)
                    {
                        _hoverIndex = index;
                        pnlChartArea.Invalidate();
                    }
                    return;
                }
            }

            if (_hoverIndex != -1)
            {
                _hoverIndex = -1;
                pnlChartArea.Invalidate();
            }
        }


        private void PnlChartArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_multiData == null || _multiData.Count == 0 || _multiData[0].Count < 2) return;

            Padding p = new Padding(60, 20, 40, 40);
            Rectangle chartArea = new Rectangle(p.Left, p.Top, pnlChartArea.Width - p.Left - p.Right, pnlChartArea.Height - p.Top - p.Bottom);

            double max = 0;
            foreach (var series in _multiData)
            {
                if (series.Count > 0) {
                    double seriesMax = series.Max();
                    if (seriesMax > max) max = seriesMax;
                }
            }
            if (max == 0) max = 1;
            max = Math.Ceiling(max / 10.0) * 10.0;

            float stepX = Math.Max((float)chartArea.Width / (_multiData[0].Count - 1), _minPointWidth);

            // Draw Y-Axis Grid
            using (Pen gridPen = new Pen(Color.FromArgb(240, 240, 240), 1) { DashStyle = DashStyle.Dash })
            {
                for (int i = 0; i <= 4; i++)
                {
                    float y = chartArea.Bottom - (i * (float)chartArea.Height / 4);
                    g.DrawLine(gridPen, chartArea.Left, y, chartArea.Right, y);
                    g.DrawString(((max / 4) * i).ToString("N0"), new Font("Segoe UI", 8), Brushes.Gray, p.Left - 55, y - 8);
                }
            }

            // Draw Series
            var oldClip = g.Clip;
            g.SetClip(new Rectangle(chartArea.Left, 0, chartArea.Width + 40, pnlChartArea.Height));
            
            List<PointF[]> allPoints = new List<PointF[]>();

            for (int s = 0; s < _multiData.Count; s++)
            {
                var data = _multiData[s];
                var color = s < _seriesColors.Count ? _seriesColors[s] : ThemeColor;
                PointF[] points = new PointF[data.Count];

                g.ResetTransform();
                g.TranslateTransform(chartArea.Left + _scrollOffset, 0);

                for (int i = 0; i < data.Count; i++)
                {
                    float x = i * stepX;
                    float y = chartArea.Bottom - (float)((data[i] / max) * chartArea.Height);
                    points[i] = new PointF(x, y);

                    // Vẽ nhãn tháng ở hàng cuối cùng
                    if (s == 0 && _labels != null && i < _labels.Count)
                    {
                        SizeF sz = g.MeasureString(_labels[i], new Font("Segoe UI", 9));
                        g.DrawString(_labels[i], new Font("Segoe UI", 9), Brushes.Gray, x - (sz.Width / 2), chartArea.Bottom + 10);
                    }
                }
                allPoints.Add(points);

                // Vẽ Area
                if (Mode == ChartType.Area)
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddCurve(points);
                        path.AddLine(points.Last(), new PointF(points.Last().X, chartArea.Bottom));
                        path.AddLine(new PointF(points.Last().X, chartArea.Bottom), new PointF(points.First().X, chartArea.Bottom));
                        path.CloseFigure();
                        using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, chartArea.Top), new Point(0, chartArea.Bottom), Color.FromArgb(80, color), Color.FromArgb(0, color)))
                            g.FillPath(brush, path);
                    }
                }

                // Vẽ Line
                using (Pen curvePen = new Pen(color, 3) { LineJoin = LineJoin.Round }) g.DrawCurve(curvePen, points);

                // Vẽ Points
                for (int i = 0; i < points.Length; i++)
                {
                    if (i == _hoverIndex)
                    {
                        g.FillEllipse(new SolidBrush(color), points[i].X - 6, points[i].Y - 6, 12, 12);
                        g.DrawEllipse(Pens.White, points[i].X - 6, points[i].Y - 6, 12, 12);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.White, points[i].X - 4, points[i].Y - 4, 8, 8);
                        using (Pen dotPen = new Pen(color, 2)) g.DrawEllipse(dotPen, points[i].X - 4, points[i].Y - 4, 8, 8);
                    }
                }
            }

            // Draw Tooltip (Multi-line)
            if (_hoverIndex != -1 && _hoverIndex < _multiData[0].Count)
            {
                string title = _labels[_hoverIndex];
                Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                Font valFont = new Font("Segoe UI", 10);
                
                float maxTextWidth = g.MeasureString(title, titleFont).Width;
                float totalHeight = g.MeasureString(title, titleFont).Height + 15;

                for (int s = 0; s < _multiData.Count; s++)
                {
                    string text = $"{_seriesNames[s]} : {_multiData[s][_hoverIndex]:N0}";
                    float w = g.MeasureString(text, valFont).Width;
                    if (w > maxTextWidth) maxTextWidth = w;
                    totalHeight += g.MeasureString(text, valFont).Height + 5;
                }

                float tw = maxTextWidth + 30;
                float th = totalHeight + 15;
                float tx = allPoints[0][_hoverIndex].X + 15;
                float ty = allPoints[0][_hoverIndex].Y - th / 2;

                // 1. Căn chỉnh để không tràn lề phải
                if (tx + tw > pnlChartArea.Width - _scrollOffset) tx = allPoints[0][_hoverIndex].X - tw - 15;
                
                // 2. Căn chỉnh để không tràn lề dưới (Quan trọng nhất cho trường hợp giá trị 0)
                if (ty + th > pnlChartArea.Height - 5) ty = pnlChartArea.Height - th - 5;
                
                // 3. Căn chỉnh để không tràn lề trên
                if (ty < 5) ty = 5;

                g.ResetTransform();
                g.TranslateTransform(chartArea.Left + _scrollOffset, 0);

                RectangleF tooltipRect = new RectangleF(tx, ty, tw, th);
                using (GraphicsPath shadowPath = UIHelper.GetRoundedPath(new RectangleF(tx + 2, ty + 2, tw, th), 8))
                    g.FillPath(new SolidBrush(Color.FromArgb(30, Color.Black)), shadowPath);
                
                using (GraphicsPath tipPath = UIHelper.GetRoundedPath(tooltipRect, 8))
                {
                    g.FillPath(Brushes.White, tipPath);
                    g.DrawPath(new Pen(Color.FromArgb(230, 230, 230)), tipPath);
                }

                g.DrawString(title, titleFont, Brushes.Black, tx + 10, ty + 10);
                float currentY = ty + 10 + g.MeasureString(title, titleFont).Height + 5;

                for (int s = 0; s < _multiData.Count; s++)
                {
                    string text = $"{_seriesNames[s]} : {_multiData[s][_hoverIndex]:N0}";
                    g.DrawString(text, valFont, new SolidBrush(_seriesColors[s]), tx + 10, currentY);
                    currentY += g.MeasureString(text, valFont).Height + 5;
                }
            }

            g.ResetTransform();
            g.Clip = oldClip;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UIHelper.ApplyRoundedRegion(this, 25);
        }
    }
}