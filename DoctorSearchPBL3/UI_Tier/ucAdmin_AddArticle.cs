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
            SetupUI();
            
            // Register events here to ensure they are always active
            btnSave.Click += btnSave_Click;
            
            // Image selection logic (matching ucDoctorCertificate)
            panel29.Cursor = Cursors.Hand;
            label24.Cursor = Cursors.Hand;
            panel29.Click += label24_Click;
            label24.Click += label24_Click;
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
            lblHeaderTitle.MouseMove += panelHeader_MouseMove;
            label1.MouseDown += panelHeader_MouseDown;
            label1.MouseMove += panelHeader_MouseMove;

            // Áp dụng bo góc 5px và hiệu ứng vạch xanh khi Focus
            ApplyInputStyle(txtTitle);
            ApplyInputStyle(txtSummary);
            ApplyInputStyle(rtbBody);

            // Bo góc cho các nút bấm (15px)
            UIHelper.ApplyRoundedRegion(btnSave, 15);
            UIHelper.ApplyRoundedRegion(btnCancel, 15);

            _thumbnailPath = ""; 
        }

        private void ApplyInputStyle(Control ctrl)
        {
            // Bo góc 5px cố định
            UIHelper.ApplyRoundedRegion(ctrl, 5);

            // Vẽ vạch xanh ở cạnh dưới khi Focus
            ctrl.Paint += (s, e) => {
                if (ctrl.Focused)
                {
                    using (Pen p = new Pen(Color.FromArgb(37, 99, 235), 4)) // Độ dày 4 cho rõ
                    {
                        // Vẽ đường thẳng ở sát đáy, lùi vào 2 bên 5px cho đẹp
                        e.Graphics.DrawLine(p, 5, ctrl.Height - 2, ctrl.Width - 5, ctrl.Height - 2);
                    }
                }
            };

            ctrl.Enter += (s, e) => {
                ctrl.BackColor = Color.FromArgb(242, 248, 255); // Đổi nền xanh cực nhẹ
                ctrl.Invalidate(); 
            };

            ctrl.Leave += (s, e) => {
                ctrl.BackColor = Color.White;
                ctrl.Invalidate();
            };
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

        #region Draggable Logic
        private Point _mouseLoc;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e) => _mouseLoc = e.Location;
        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _mouseLoc.X;
                this.Top += e.Y - _mouseLoc.Y;
            }
        }
        #endregion
    }
}
