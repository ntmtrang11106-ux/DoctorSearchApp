using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS_Tier;
using DTO_Tier;

namespace UI_Tier
{
    public partial class ucAdmin_ReviewManagement : UserControl
    {
        private readonly ReviewBUS _reviewBUS = new ReviewBUS();
        private List<ReviewsDTO> _allReviews = new List<ReviewsDTO>();
        private List<ReviewsDTO> _filteredReviews = new List<ReviewsDTO>();
        private int _currentPage = 1;
        private int _pageSize = 6;

        public ucAdmin_ReviewManagement()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMainContainer);
            UIHelper.SetupScrollableContainer(flpList);
            
            this.Resize += (s, e) => UpdateUI();
            
            // Hiệu ứng hover cho các nút phân trang sử dụng Helper
            UIHelper.SetupPaginationLabels(lblPrev, lblNext);
            
            lblPrev.Click += lblPrev_Click;
            lblNext.Click += lblNext_Click;

            // Hiệu ứng Focus và Unfocus sử dụng Helper
            UIHelper.SetupInputFocusEffect(txtSearch, pnlSearch, Color.White, Color.White, Color.FromArgb(24, 112, 255));
            
            // Đảm bảo container chính có thể nhận focus để "cướp" focus khỏi ô tìm kiếm
            pnlMainContainer.TabStop = true;
            UIHelper.RegisterClickToUnfocus(this, pnlMainContainer);
            txtSearch.TabStop = false; // Ngăn phím Tab tự động nhảy vào đây
        }




        private void UpdateUI()
        {
            UIHelper.ApplyRoundedRegion(pnlMainContainer, 25);
            
            // Style cho thanh tìm kiếm (Bo góc và Viền)
            UIHelper.ApplyRoundedRegion(pnlSearch, 15);
            pnlSearch.Paint -= SearchPanel_Paint;
            pnlSearch.Paint += SearchPanel_Paint;
            pnlSearch.Invalidate();

            Panel[] cards = { pnlCard1, pnlCard2, pnlCard3, pnlCard4 };
            Panel[] icons = { pnlIcon1, pnlIcon2, pnlIcon3, pnlIcon4 };

            foreach (var card in cards)
            {
                if (card != null)
                {
                    UIHelper.SetDoubleBuffered(card);
                    UIHelper.ApplyRoundedRegion(card, 25);
                    card.Paint -= StatPanel_Paint; // Tránh đăng ký trùng
                    card.Paint += StatPanel_Paint;
                    card.Invalidate();
                }
            }

            foreach (var icon in icons)
            {
                if (icon != null) UIHelper.ApplyRoundedRegion(icon, 20);
            }

            // Căn giữa label thông báo
            if (lblNoData != null)
            {
                lblNoData.Left = (pnlMainContainer.Width - lblNoData.Width) / 2;
                lblNoData.Top = 350;
            }
        }

        private void StatPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                UIHelper.DrawControlBorder(pnl, e, 25, Color.FromArgb(226, 232, 240), 1);
            }
        }

        private void SearchPanel_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 15, Color.FromArgb(203, 213, 225), 2);
        }

        private void ucAdmin_ReviewManagement_Load(object sender, EventArgs e)
        {
            if (cboRatingFilter.SelectedIndex == -1) cboRatingFilter.SelectedIndex = 0;
            if (cboStatusFilter.SelectedIndex == -1) cboStatusFilter.SelectedIndex = 0;
            
            UIHelper.SetupSearchTextBox(txtSearch, "Tìm kiếm theo bệnh nhân, bác sĩ, nội dung...");
            UIHelper.SetupComboBox(cboRatingFilter);
            UIHelper.SetupComboBox(cboStatusFilter);

            UpdateUI();
            InitData();
        }

        public void InitData(bool keepPage = false)
        {
            _allReviews = _reviewBUS.GetAllReviewsForAdmin();
            LoadStats();
            ApplyFilters(keepPage);
            
            // Ngăn ô tìm kiếm tự động lấy focus và đảm bảo UI cập nhật
            this.BeginInvoke(new Action(() => {
                if (this.IsHandleCreated)
                {
                    pnlMainContainer.Focus();
                    this.ActiveControl = null;
                    flpList.Invalidate();
                    flpList.Update();
                }
            }));
        }

        private void LoadStats()
        {
            int total = _allReviews.Count;
            double avg = total > 0 ? _allReviews.Average(r => r.Rating) : 0;
            int visible = _allReviews.Count(r => r.IsVisible);
            int hidden = _allReviews.Count(r => !r.IsVisible);

            lblStatValue1.Text = total.ToString("N0");
            lblStatValue2.Text = avg.ToString("F1") + " ★";
            lblStatValue3.Text = visible.ToString("N0");
            lblStatValue4.Text = hidden.ToString("N0");
        }

        private void ApplyFilters(bool keepPage = false)
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            if (keyword == "tìm kiếm theo bệnh nhân, bác sĩ, nội dung...") keyword = "";

            string ratingStr = cboRatingFilter.SelectedItem?.ToString() ?? "Tất cả đánh giá";
            string statusStr = cboStatusFilter.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            _filteredReviews = _allReviews.Where(r =>
            {
                bool matchKeyword = string.IsNullOrEmpty(keyword) ||
                                    (r.Comment != null && r.Comment.ToLower().Contains(keyword)) ||
                                    (r.Patient?.User?.FullName != null && r.Patient.User.FullName.ToLower().Contains(keyword)) ||
                                    (r.Doctor?.User?.FullName != null && r.Doctor.User.FullName.ToLower().Contains(keyword));

                bool matchRating = ratingStr == "Tất cả đánh giá" || (ratingStr.Contains(r.Rating.ToString()));
                bool matchStatus = statusStr == "Tất cả trạng thái" ||
                                   (statusStr == "Đang hiển thị" && r.IsVisible && !r.IsDeleted) ||
                                   (statusStr == "Đang ẩn" && !r.IsVisible && !r.IsDeleted) ||
                                   (statusStr == "Đã xóa" && r.IsDeleted);

                return matchKeyword && matchRating && matchStatus;
            }).ToList();

            if (!keepPage) _currentPage = 1;
            
            // Validate current page
            int totalPages = Math.Max(1, (int)Math.Ceiling((double)_filteredReviews.Count / _pageSize));
            if (_currentPage > totalPages) _currentPage = totalPages;

            DisplayPage(_currentPage);
        }

        private void DisplayPage(int pageNumber)
        {
            flpList.SuspendLayout();
            flpList.Controls.Clear();

            int startIndex = (pageNumber - 1) * _pageSize;
            var pageItems = _filteredReviews.Skip(startIndex).Take(_pageSize).ToList();

            foreach (var review in pageItems)
            {
                ucReviewItem item = new ucReviewItem();
                item.SetAdminReviewData(review);
                
                // Đảm bảo cập nhật dữ liệu trên luồng UI chính
                item.ReviewEdited += (s, e) => this.Invoke(new Action(() => InitData(true)));
                item.ReviewDeleted += (s, e) => this.Invoke(new Action(() => InitData(true)));
                
                item.Width = flpList.Width - 45;
                flpList.Controls.Add(item);
            }

            int totalPages = (int)Math.Ceiling((double)_filteredReviews.Count / _pageSize);
            lblPageInfo.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)}";
            
            // Luôn để màu xanh và Enabled để bắt hover theo phong cách Doctor Overview
            lblPrev.Enabled = true;
            lblNext.Enabled = true;
            lblPrev.ForeColor = Color.FromArgb(0, 120, 212);
            lblNext.ForeColor = Color.FromArgb(0, 120, 212);

            lblNoData.Visible = _filteredReviews.Count == 0;
            if (lblNoData.Visible)
            {
                string currentStatus = cboStatusFilter.SelectedItem?.ToString() ?? "";
                lblNoData.Text = (currentStatus == "Đã xóa") ? "Chưa có đánh giá nào bị xóa" : "Không tìm thấy dữ liệu phù hợp";
                lblNoData.ForeColor = Color.FromArgb(156, 163, 175); // Màu xám hiện đại
                lblNoData.Left = (pnlMainContainer.Width - lblNoData.Width) / 2;
                lblNoData.Top = 300; 
                lblNoData.BringToFront();
            }

            pnlPagination.Visible = true;
            flpList.ResumeLayout(true);
            flpList.Refresh();
        }

        private void flpList_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpList.Controls)
            {
                ctrl.Width = flpList.Width - 45;
            }
        }

        private void lblPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1) { _currentPage--; DisplayPage(_currentPage); }
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_filteredReviews.Count / _pageSize);
            if (_currentPage < totalPages) { _currentPage++; DisplayPage(_currentPage); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilters();
        private void Filter_Changed(object sender, EventArgs e) => ApplyFilters();
    }
}
