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
            cboType.Items.Add("Hướng dẫn quy trình");
            cboType.Items.Add("Hướng dẫn chuyên khoa");
            cboType.Items.Add("Kiến thức y khoa");
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
            UIHelper.ApplyRoundedRegion(this, 20);
            // Vẽ viền đen đậm để làm nổi bật form trên nền trắng
            this.Paint += (s, ev) => UIHelper.uc_Paint(s, ev, 20, Color.Black, 3); 

            UIHelper.ApplyRoundedRegion(pnlHeader, 20);
            UIHelper.ApplyRoundedRegion(picIcon, 15);

            // Make children of header draggable too
            lblHeaderTitle.MouseDown += panelHeader_MouseDown;
            lblHeaderTitle.MouseMove += panelHeader_MouseMove;
            picIcon.MouseDown += panelHeader_MouseDown;
            picIcon.MouseMove += panelHeader_MouseMove;
            
            UIHelper.ApplyRoundedRegion(txtTitle, 10);
            UIHelper.ApplyRoundedRegion(txtSummary, 10);
            UIHelper.ApplyRoundedRegion(rtbBody, 10);
            UIHelper.ApplyRoundedRegion(cboType, 8);
            UIHelper.ApplyRoundedRegion(cboDept, 8);
            UIHelper.ApplyRoundedRegion(cboStatus, 8);
            UIHelper.ApplyRoundedRegion(numPriority, 8);
            UIHelper.ApplyRoundedRegion(btnSave, 15);
            UIHelper.ApplyRoundedRegion(btnCancel, 15);
            
            _thumbnailPath = ""; 
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
                    "ProcedureGuide" => "Hướng dẫn quy trình",
                    "DepartmentGuide" => "Hướng dẫn chuyên khoa",
                    "HealthArticle" => "Kiến thức y khoa",
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
                "Hướng dẫn quy trình" => "ProcedureGuide",
                "Hướng dẫn chuyên khoa" => "DepartmentGuide",
                "Kiến thức y khoa" => "HealthArticle",
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
