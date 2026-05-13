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
            UIHelper.SetDoubleBuffered(flpList);
        }

        private void ucAdmin_ReviewManagement_Load(object sender, EventArgs e)
        {
            if (cboRatingFilter.SelectedIndex == -1) cboRatingFilter.SelectedIndex = 0;
            if (cboStatusFilter.SelectedIndex == -1) cboStatusFilter.SelectedIndex = 0;
            
            //// Bo góc cho các card và container chính
            //UIHelper.ApplyRoundedRegion(pnlCard1, 15);
            //UIHelper.ApplyRoundedRegion(pnlCard2, 15);
            //UIHelper.ApplyRoundedRegion(pnlCard3, 15);
            //UIHelper.ApplyRoundedRegion(pnlCard4, 15);
            //UIHelper.ApplyRoundedRegion(pnlMainContainer, 20);
            //UIHelper.ApplyRoundedRegion(pnlSearch, 15);

            InitData();
        }

        public void InitData()
        {
            _allReviews = _reviewBUS.GetAllReviewsForAdmin();
            LoadStats();
            ApplyFilters();
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

        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.ToLower().Trim();
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
                                   (statusStr == "Đang hiển thị" && r.IsVisible) ||
                                   (statusStr == "Đang ẩn" && !r.IsVisible);

                return matchKeyword && matchRating && matchStatus;
            }).ToList();

            _currentPage = 1;
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
                item.ReviewEdited += (s, e) => InitData();
                item.ReviewDeleted += (s, e) => InitData();
                item.Width = flpList.Width - 45;
                flpList.Controls.Add(item);
            }

            int totalPages = (int)Math.Ceiling((double)_filteredReviews.Count / _pageSize);
            lblPageInfo.Text = $"Trang {_currentPage} / {Math.Max(1, totalPages)}";
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;

            flpList.ResumeLayout();
        }

        private void flpList_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpList.Controls)
            {
                ctrl.Width = flpList.Width - 45;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1) { _currentPage--; DisplayPage(_currentPage); }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_filteredReviews.Count / _pageSize);
            if (_currentPage < totalPages) { _currentPage++; DisplayPage(_currentPage); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilters();
        private void Filter_Changed(object sender, EventArgs e) => ApplyFilters();
    }
}
