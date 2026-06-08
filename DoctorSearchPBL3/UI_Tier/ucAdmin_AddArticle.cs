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
        
        // Đối tượng chứa thông tin bài viết hiện tại (nếu là chỉnh sửa thì khác null, thêm mới thì là null)
        private ContentDTO _existingArt = null;

        // Định nghĩa các sự kiện để thông báo cho Form cha khi Admin Hủy bỏ hoặc Lưu thành công
        public event EventHandler OnCancel;
        public event EventHandler? OnSuccess;

        /// <summary>
        /// Hàm khởi tạo UserControl
        /// </summary>
        public ucAdmin_AddArticle()
        {
            InitializeComponent();
            
            // Kích hoạt DoubleBuffered qua UIHelper để giảm thiểu hiện tượng nhấp nháy (flicker) khi vẽ lại giao diện
            UIHelper.SetDoubleBuffered(this);
            UIHelper.SetDoubleBuffered(pnlMainBackground);
            
            // Thiết lập các giá trị mặc định cho Combobox và tải danh sách chuyên khoa
            SetupUI();
            
            // Đặt hình dạng con trỏ chuột thành hình bàn tay (Cursors.Hand) khi di chuyển vào khu vực ảnh đại diện
            panel29.Cursor = Cursors.Hand;
            label24.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Thiết lập dữ liệu khởi tạo cho các thành phần điều khiển trên giao diện
        /// </summary>
        private void SetupUI()
        {
            // Thiết lập danh sách Loại bài viết (bằng Tiếng Việt hiển thị cho người dùng)
            cboType.Items.Clear();
            cboType.Items.Add("Thông báo");
            cboType.Items.Add("Quy trình khám");
            cboType.Items.Add("Bài viết chuyên khoa");
            cboType.Items.Add("Thông tin y tế");
            cboType.SelectedIndex = 0; // Mặc định chọn loại đầu tiên

            // Thiết lập danh sách Trạng thái hiển thị bài viết
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Xuất bản ngay");
            cboStatus.Items.Add("Lưu bản nháp");
            cboStatus.Items.Add("Đã ẩn");
            cboStatus.SelectedIndex = 1; // Mặc định chọn "Lưu bản nháp" để an toàn

            // Tải danh sách chuyên khoa từ cơ sở dữ liệu lên ComboBox
            LoadDepartments();
        }

        /// <summary>
        /// Tải danh sách chuyên khoa từ lớp nghiệp vụ DepartmentBUS
        /// </summary>
        private void LoadDepartments()
        {
            // Lấy danh sách chuyên khoa thích hợp cho việc hiển thị UI
            var depts = _deptBus.GetDepartmentsForUI();
            cboDept.DataSource = depts;
            cboDept.DisplayMember = "DepartmentName";
            cboDept.ValueMember = "Id";
            cboDept.SelectedIndex = -1;
        }

        /// <summary>
        /// Sự kiện xảy ra khi UserControl được tải (Load)
        /// </summary>
        private void ucAdmin_AddArticle_Load(object sender, EventArgs e)
        {
            // Thiết kế bo góc 30px cho viền ngoài của UserControl
            UIHelper.ApplyRoundedRegion(this, 30);
            // Thiết kế bo góc 30px cho Panel nền bên trong nhằm khớp với đường viền 3px
            UIHelper.ApplyRoundedRegion(pnlMainBackground, 30);

            // Bo góc cho nhãn tiêu đề nhỏ bên cạnh nút đóng
            UIHelper.ApplyRoundedRegion(label1, 15);
            
            // Liên kết sự kiện nhấn chuột để hỗ trợ kéo thả di chuyển cửa sổ (chỉ áp dụng trên thanh tiêu đề)
            lblHeaderTitle.MouseDown += panelHeader_MouseDown;
            label1.MouseDown += panelHeader_MouseDown;

            // Áp dụng định dạng đường viền màu đen 2px cho các khung chứa ô nhập liệu
            UIHelper.ApplyBorderPanelStyle(pnlTitleBorder);
            UIHelper.ApplyBorderPanelStyle(pnlSummaryBorder);
            UIHelper.ApplyBorderPanelStyle(pnlBodyBorder);
            UIHelper.ApplyBorderPanelStyle(pnlTypeBorder);
            UIHelper.ApplyBorderPanelStyle(pnlDeptBorder);
            UIHelper.ApplyBorderPanelStyle(pnlStatusBorder);
            UIHelper.ApplyBorderPanelStyle(pnlPriorityBorder);
            UIHelper.ApplyBorderPanelStyle(panel29); // Khung chọn hình ảnh đại diện

            // Áp dụng hiệu ứng đổi màu và vẽ gạch dưới khi người dùng Focus vào các ô nhập dữ liệu
            ApplyInternalControlStyle(txtTitle);
            ApplyInternalControlStyle(txtSummary);
            ApplyInternalControlStyle(rtbBody);
            ApplyInternalControlStyle(cboType);
            ApplyInternalControlStyle(cboDept);
            ApplyInternalControlStyle(cboStatus);
            ApplyInternalControlStyle(numPriority);

            // Áp dụng bo góc 12px cho các nút bấm hành động chính (Lưu & Hủy)
            UIHelper.ApplyRoundedRegion(btnSave, 12);
            UIHelper.ApplyRoundedRegion(btnCancel, 12);
        }

        /// Đăng ký hiệu ứng giao diện (đổi màu nền và vẽ thanh trạng thái dưới chân) khi tập trung (Focus) vào Control nhập liệu
        private void ApplyInternalControlStyle(Control ctrl)
        {
            // Khi ô nhập liệu được trỏ vào (Enter Focus)
            ctrl.Enter += (s, e) => {
                // Thay đổi màu nền của Panel bao ngoài và bản thân Control sang màu xanh nhạt dịu mắt
                if (ctrl.Parent is Panel pnl) pnl.BackColor = Color.FromArgb(242, 248, 255);
                ctrl.BackColor = Color.FromArgb(242, 248, 255);
                
                // Đăng ký sự kiện vẽ tùy biến để vẽ một vạch màu xanh dương ở đáy Panel
                if (ctrl.Parent is Panel parent)
                {
                    parent.Paint += Control_Paint_Focus;
                    parent.Invalidate(); // Yêu cầu vẽ lại Panel
                }
            };

            // Khi rời khỏi ô nhập liệu (Leave Focus)
            ctrl.Leave += (s, e) => {
                // Khôi phục màu nền của Panel và Control về lại màu trắng mặc định
                if (ctrl.Parent is Panel pnl) pnl.BackColor = Color.White;
                ctrl.BackColor = Color.White;

                // Hủy đăng ký sự kiện vẽ tùy biến và yêu cầu vẽ lại Panel để xóa vạch màu xanh
                if (ctrl.Parent is Panel parent)
                {
                    parent.Paint -= Control_Paint_Focus;
                    parent.Invalidate();
                }
            };
        }

        /// <summary>
        /// Thực hiện vẽ vạch màu xanh dương dày 4px ở đáy của Panel chứa Control đang được Focus
        /// </summary>
        private void Control_Paint_Focus(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            using (Pen p = new Pen(Color.FromArgb(24, 112, 255), 4))
            {
                // Vẽ đường thẳng màu xanh dương ở sát cạnh đáy Panel để làm nổi bật vùng nhập liệu đang hoạt động
                e.Graphics.DrawLine(p, 10, e.ClipRectangle.Height - 3, e.ClipRectangle.Width - 10, e.ClipRectangle.Height - 3);
            }
        }

        // Lưu đường dẫn/tên file ảnh đại diện của bài viết
        private string _thumbnailPath = "";

        /// Đổ dữ liệu từ một bài viết có sẵn vào giao diện khi Admin muốn chỉnh sửa
        public void SetData(ContentDTO art)
        {
            _existingArt = art;
            if (art != null)
            {
                // Thay đổi tiêu đề và văn bản nút bấm cho phù hợp ngữ cảnh chỉnh sửa
                lblHeaderTitle.Text = "Chỉnh sửa bài viết";
                btnSave.Text = "Cập nhật bài viết";
                
                // Điền thông tin văn bản
                txtTitle.Text = art.Title;
                txtSummary.Text = art.Summary;
                rtbBody.Text = art.Body;
                
                // Tải thông tin ảnh đại diện
                _thumbnailPath = art.Thumbnail;
                if (!string.IsNullOrEmpty(_thumbnailPath))
                {
                    label24.Text = _thumbnailPath;
                    label24.ForeColor = Color.FromArgb(37, 99, 235); // Đổi sang màu xanh dương giống liên kết đang kích hoạt
                }

                // Điền độ ưu tiên và trạng thái ghim bài viết
                numPriority.Value = art.Priority;
                chkPinned.Checked = art.IsPinned;

                // Ánh xạ Loại bài viết từ chuỗi lưu trong database sang Tiếng Việt hiển thị trên ComboBox
                cboType.SelectedItem = art.ContentType switch
                {
                    "HospitalNotice" => "Thông báo",
                    "ProcedureGuide" => "Quy trình khám",
                    "DepartmentGuide" => "Bài viết chuyên khoa",
                    "HealthArticle" => "Thông tin y tế",
                    _ => "Thông báo"
                };

                // Ánh xạ Trạng thái bài viết từ Database sang Tiếng Việt hiển thị trên ComboBox
                cboStatus.SelectedItem = art.Status switch
                {
                    "Published" => "Xuất bản ngay",
                    "Hidden" => "Đã ẩn",
                    _ => "Lưu bản nháp"
                };
                
                // Chọn đúng Chuyên khoa tương ứng với bài viết
                cboDept.SelectedValue = art.DepartmentId;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi bấm nút Lưu hoặc Cập nhật bài viết
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Nếu là sửa bài viết, giữ nguyên đối tượng cũ; nếu là thêm mới, tạo mới một đối tượng DTO
            ContentDTO art = _existingArt ?? new ContentDTO();
            
            // Lấy thông tin đã cắt bỏ khoảng trắng thừa ở hai đầu
            art.Title = txtTitle.Text.Trim();
            art.Summary = txtSummary.Text.Trim();
            art.Body = rtbBody.Text.Trim();
            
            // Ánh xạ ngược lại từ Tiếng Việt trên giao diện sang mã chuỗi chuẩn hóa để lưu xuống database
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
            
            // Gán các thông tin phụ khác
            art.DepartmentId = (int?)cboDept.SelectedValue;
            art.Priority = (int)numPriority.Value;
            art.IsPinned = chkPinned.Checked;
            art.Thumbnail = _thumbnailPath;
            
            // Gọi tầng nghiệp vụ kiểm tra tính hợp lệ của bài viết (tiêu đề không để trống, độ dài tối thiểu,...)
            string validationMsg = _contentBus.ValidateArticle(art);
            if (validationMsg != "OK")
            {
                MessageBox.Show(validationMsg, "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Ngăn không cho lưu nếu dữ liệu không hợp lệ
            }

            // Trường hợp: Thêm bài viết mới hoàn toàn
            if (_existingArt == null)
            {
                // Gán ID Admin của tài khoản đang đăng nhập hiện tại
                art.AuthorAdminId = GlobalAccount.GetProfileId(); 
                if (art.AuthorAdminId <= 0) art.AuthorAdminId = 1; // Giá trị dự phòng (Fallback) khi chạy thử nghiệm
                
                // Gọi lớp BUS để chèn dữ liệu vào DB
                if (_contentBus.AddArticle(art))
                {
                    MessageBox.Show("Thêm bài viết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnSuccess?.Invoke(this, EventArgs.Empty); // Kích hoạt sự kiện lưu thành công để thông báo cho Form cha
                }
                else
                {
                    MessageBox.Show("Thêm bài viết thất bại. Vui lòng kiểm tra lại kết nối cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Trường hợp: Cập nhật bài viết hiện có
            else
            {
                // Gọi lớp BUS thực hiện cập nhật lại dữ liệu bài viết
                if (_contentBus.UpdateArticle(art))
                {
                    MessageBox.Show("Cập nhật bài viết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnSuccess?.Invoke(this, EventArgs.Empty); // Kích hoạt sự kiện cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click vào nhãn chứa tên hình ảnh đại diện để mở cửa sổ chọn tập tin ảnh mới
        /// </summary>
        private void label24_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Chỉ cho phép chọn các loại tệp tin hình ảnh thông dụng
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Lấy tên tệp tin ảnh từ đường dẫn đầy đủ được chọn và hiển thị lên giao diện
                    _thumbnailPath = Path.GetFileName(ofd.FileName);
                    label24.Text = _thumbnailPath;
                    label24.ForeColor = Color.Blue; // Định dạng chữ màu xanh để biểu thị ảnh đã được chọn mới

                    try
                    {
                        // Kiểm tra và tự động tạo thư mục lưu trữ tài nguyên ảnh "Resources_Images" trong thư mục chứa file thực thi của ứng dụng
                        string imageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources_Images");
                        if (!Directory.Exists(imageDir))
                            Directory.CreateDirectory(imageDir);

                        // Thiết lập đường dẫn đích để lưu trữ tệp tin ảnh trong tài nguyên của ứng dụng
                        string destPath = Path.Combine(imageDir, _thumbnailPath);
                        
                        // Nếu tệp ảnh chưa tồn tại trong thư mục tài nguyên đích, thực hiện sao chép tệp đó sang
                        if (!File.Exists(destPath))
                        {
                            File.Copy(ofd.FileName, destPath);
                        }
                    }
                    catch { } // Bỏ qua lỗi sao chép tập tin nếu có sự cố về quyền ghi đè tập tin
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi bấm nút Hủy bỏ
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện hủy bỏ để thông báo cho Form cha xử lý đóng cửa sổ/giao diện
            OnCancel?.Invoke(this, EventArgs.Empty);
        }

        #region Hỗ trợ Kéo thả Di chuyển Giao diện hiệu năng cao thông qua API Win32
        // Import các hàm API Win32 từ thư viện user32.dll để gửi thông điệp hệ thống điều khiển cửa sổ
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Bắt sự kiện nhấn giữ chuột trái trên thanh tiêu đề để kéo và di chuyển giao diện
        /// </summary>
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Giải phóng sự kiểm soát chuột của cửa sổ hiện tại
                ReleaseCapture();
                
                // Gửi thông điệp WM_NCLBUTTONDOWN (0xA1) kèm tham số HTCAPTION (2) đến Windows để thực hiện hành động kéo di chuyển cửa sổ
                SendMessage(this.Handle, 0xA1, 0x2, 0);
                
                // Chuyển Focus ra khỏi các trường nhập liệu khi bắt đầu kéo cửa sổ
                Global_Click(sender, e);
            }
        }

        /// <summary>
        /// Xử lý loại bỏ Focus khỏi các ô nhập liệu bằng cách chuyển quyền hoạt động sang nhãn tiêu đề chính
        /// </summary>
        private void Global_Click(object sender, EventArgs e)
        {
            // Gán ActiveControl về lblHeaderTitle để bỏ dấu nháy soạn thảo ở ô Title hoặc Body
            this.ActiveControl = lblHeaderTitle;
        }
        #endregion
    }
}

