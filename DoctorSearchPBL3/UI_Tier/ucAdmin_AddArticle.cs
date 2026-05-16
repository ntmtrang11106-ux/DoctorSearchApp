using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace UI_Tier
{
    public partial class ucAdmin_AddArticle : UserControl
    {
        private DepartmentBUS _deptBus = new DepartmentBUS();
        private ContentBUS _contentBus = new ContentBUS();
        private ContentDTO _existingArt = null;

        public event EventHandler OnCancel;
        public event EventHandler? OnSuccess;

        public ucAdmin_AddArticle()
        {
            InitializeComponent();
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMainBackground);
            SetupUI();
            
            // Register events here to ensure they are always active
            btnSave.Click += btnSave_Click;
            
            // Image selection logic (matching ucDoctorCertificate)
            panel29.Cursor = Cursors.Hand;
            label24.Cursor = Cursors.Hand;
            panel29.Click += label24_Click;
            label24.Click += label24_Click;

            // Đăng ký sự kiện Click ra ngoài để thoát focus (giống ucWriteReview)
            pnlMainBackground.Click += Global_Click;
            pnlHeader.Click += Global_Click;
            lblHeaderTitle.Click += Global_Click;
            label1.Click += Global_Click;
            lblTitleLabel.Click += Global_Click;
            lblSummaryLabel.Click += Global_Click;
            lblBodyLabel.Click += Global_Click;
            lblTypeLabel.Click += Global_Click;
            lblDeptLabel.Click += Global_Click;
            lblStatusLabel.Click += Global_Click;
            lblPriorityLabel.Click += Global_Click;
            lblThumbnailLabel.Click += Global_Click;

            this.Paint += ucAdmin_AddArticle_Paint;
            this.Padding = new Padding(3);
        }

        private void ucAdmin_AddArticle_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DrawControlBorder(sender, e, 30, Color.Black, 3);
        }

        private void SetupUI()
        {
            // Populate Content Type (Vietnamese Labels)
            cboType.Items.Clear();
            cboType.Items.Add("Thông báo");
            cboType.Items.Add("Quy trình khám");
            cboType.Items.Add("Bài viết chuyên khoa");
            cboType.Items.Add("Thông tin y tế");
            cboType.SelectedIndex = 0;

            // Populate Status (Vietnamese Labels)
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Xuất bản ngay");
            cboStatus.Items.Add("Lưu bản nháp");
            cboStatus.Items.Add("Đã ẩn");
            cboStatus.SelectedIndex = 1; // Mặc định là bản nháp

            LoadDepartments();
        }

        private void LoadDepartments()
        {
            var depts = _deptBus.GetDepartmentsForUI();
            cboDept.DataSource = depts;
            cboDept.DisplayMember = "DepartmentName";
            cboDept.ValueMember = "Id";
            cboDept.SelectedIndex = -1;
        }

        private void ucAdmin_AddArticle_Load(object sender, EventArgs e)
        {
            // Styling
            // Bo góc cho khung Đen ngoài cùng
            UIHelper.ApplyRoundedRegion(this, 30);
            // Bo góc cho khung Trắng bên trong (khớp với viền 3px)
            UIHelper.ApplyRoundedRegion(pnlMainBackground, 27);

            UIHelper.ApplyRoundedRegion(label1, 15);
            
            // Chỉ giữ lại kéo thả cho thanh tiêu đề
            lblHeaderTitle.MouseDown += panelHeader_MouseDown;
            label1.MouseDown += panelHeader_MouseDown;

            // Áp dụng bo góc và viền đen 2px cho các khung bao quanh
            ApplyBorderPanelStyle(pnlTitleBorder);
            ApplyBorderPanelStyle(pnlSummaryBorder);
            ApplyBorderPanelStyle(pnlBodyBorder);
            ApplyBorderPanelStyle(pnlTypeBorder);
            ApplyBorderPanelStyle(pnlDeptBorder);
            ApplyBorderPanelStyle(pnlStatusBorder);
            ApplyBorderPanelStyle(pnlPriorityBorder);
            ApplyBorderPanelStyle(panel29); // Khung hình ảnh

            // Áp dụng hiệu ứng Focus cho các control bên trong
            ApplyInternalControlStyle(txtTitle);
            ApplyInternalControlStyle(txtSummary);
            ApplyInternalControlStyle(rtbBody);
            ApplyInternalControlStyle(cboType);
            ApplyInternalControlStyle(cboDept);
            ApplyInternalControlStyle(cboStatus);
            ApplyInternalControlStyle(numPriority);

            // Bo góc cho các nút bấm (12px)
            UIHelper.ApplyRoundedRegion(btnSave, 12);
            UIHelper.ApplyRoundedRegion(btnCancel, 12);

            // Font sizes
            lblHeaderTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            txtTitle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtSummary.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            rtbBody.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            _thumbnailPath = ""; 
        }

        private void ApplyBorderPanelStyle(Panel pnl)
        {
            UIHelper.ApplyRoundedRegion(pnl, 10);
            pnl.Paint += (s, e) => {
                // Vẽ viền đen độ dày 2px
                UIHelper.DrawControlBorder(s, e, 10, Color.Black, 2);
            };
        }

        private void ApplyInternalControlStyle(Control ctrl)
        {
            ctrl.Enter += (s, e) => {
                // Đổi nền panel cha khi focus
                if (ctrl.Parent is Panel pnl) pnl.BackColor = Color.FromArgb(242, 248, 255);
                ctrl.BackColor = Color.FromArgb(242, 248, 255);
                
                // Vẽ vạch xanh dưới đáy của panel cha
                if (ctrl.Parent is Panel parent)
                {
                    parent.Paint += Control_Paint_Focus;
                    parent.Invalidate();
                }
            };

            ctrl.Leave += (s, e) => {
                if (ctrl.Parent is Panel pnl) pnl.BackColor = Color.White;
                ctrl.BackColor = Color.White;

                if (ctrl.Parent is Panel parent)
                {
                    parent.Paint -= Control_Paint_Focus;
                    parent.Invalidate();
                }
            };
        }

        private void Control_Paint_Focus(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            using (Pen p = new Pen(Color.FromArgb(24, 112, 255), 4))
            {
                // Vẽ ở sát đáy panel cha
                e.Graphics.DrawLine(p, 10, e.ClipRectangle.Height - 3, e.ClipRectangle.Width - 10, e.ClipRectangle.Height - 3);
            }
        }

        private string _thumbnailPath = "";

        public void SetData(ContentDTO art)
        {
            _existingArt = art;
            if (art != null)
            {
                lblHeaderTitle.Text = "Chỉnh sửa bài viết";
                btnSave.Text = "Cập nhật bài viết";
                
                txtTitle.Text = art.Title;
                txtSummary.Text = art.Summary;
                rtbBody.Text = art.Body;
                
                _thumbnailPath = art.Thumbnail;
                if (!string.IsNullOrEmpty(_thumbnailPath))
                {
                    label24.Text = _thumbnailPath;
                    label24.ForeColor = Color.FromArgb(37, 99, 235); // Blue for active link
                }

                numPriority.Value = art.Priority;
                chkPinned.Checked = art.IsPinned;

                // Select in combos with mapping
                cboType.SelectedItem = art.ContentType switch
                {
                    "HospitalNotice" => "Thông báo",
                    "ProcedureGuide" => "Quy trình khám",
                    "DepartmentGuide" => "Bài viết chuyên khoa",
                    "HealthArticle" => "Thông tin y tế",
                    _ => "Thông báo"
                };

                cboStatus.SelectedItem = art.Status switch
                {
                    "Published" => "Xuất bản ngay",
                    "Hidden" => "Đã ẩn",
                    _ => "Lưu bản nháp"
                };
                cboDept.SelectedValue = art.DepartmentId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ContentDTO art = _existingArt ?? new ContentDTO();
            
            art.Title = txtTitle.Text.Trim();
            art.Summary = txtSummary.Text.Trim();
            art.Body = rtbBody.Text.Trim();
            
            // Map back to internal Enum strings
            art.ContentType = cboType.SelectedItem?.ToString() switch
            {
                "Thông báo" => "HospitalNotice",
                "Quy trình khám" => "ProcedureGuide",
                "Bài viết chuyên khoa" => "DepartmentGuide",
                "Thông tin y tế" => "HealthArticle",
                _ => "HospitalNotice"
            };

            art.Status = cboStatus.SelectedItem?.ToString() switch
            {
                "Xuất bản ngay" => "Published",
                "Đã ẩn" => "Hidden",
                _ => "Draft"
            };
            
            art.DepartmentId = (int?)cboDept.SelectedValue;
            art.Priority = (int)numPriority.Value;
            art.IsPinned = chkPinned.Checked;
            art.Thumbnail = _thumbnailPath;
            
            // Validation from BUS
            string validationMsg = _contentBus.ValidateArticle(art);
            if (validationMsg != "OK")
            {
                MessageBox.Show(validationMsg, "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // For new article
            if (_existingArt == null)
            {
                // Assign current admin ID
                art.AuthorAdminId = GlobalAccount.GetProfileId(); 
                if (art.AuthorAdminId <= 0) art.AuthorAdminId = 1; // Fallback for dev
                
                if (_contentBus.AddArticle(art))
                {
                    MessageBox.Show("Thêm bài viết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnSuccess?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Thêm bài viết thất bại. Vui lòng kiểm tra lại kết nối cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (_contentBus.UpdateArticle(art))
                {
                    MessageBox.Show("Cập nhật bài viết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnSuccess?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Lưu đường dẫn gốc vào Tag để lúc lưu database thì Copy file đi
                    _thumbnailPath = Path.GetFileName(ofd.FileName);
                    label24.Text = _thumbnailPath;
                    label24.ForeColor = Color.Blue;

                    try
                    {
                        string imageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
                        if (!Directory.Exists(imageDir))
                            Directory.CreateDirectory(imageDir);

                        string destPath = Path.Combine(imageDir, _thumbnailPath);
                        if (!File.Exists(destPath))
                        {
                            File.Copy(ofd.FileName, destPath);
                        }
                    }
                    catch { }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(this, EventArgs.Empty);
        }

        #region High-Performance Draggable Logic (Win32)
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
                
                // Khi bắt đầu kéo form cũng nên xóa focus
                Global_Click(sender, e);
            }
        }

        private void Global_Click(object sender, EventArgs e)
        {
            // Chuyển ActiveControl về tiêu đề để xóa focus khỏi các ô nhập liệu
            this.ActiveControl = lblHeaderTitle;
        }
        #endregion
    }
}
