using BUS_Tier;
using DTO_Tier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Tier
{
    public partial class ucPatient_SearchDoc : UserControl
    {
        // Khai báo một lần ở cấp độ class để tái sử dụng
        private DoctorBUS _bus = new DoctorBUS();

        public ucPatient_SearchDoc()
        {
            InitializeComponent();
        }

        public void LoadDoctorData()
        {
            // 1. Xóa sạch các control cũ để tránh trùng lặp khi load lại
            UIHelper.SetDoubleBuffered(flpDoctors); // Tăng hiệu suất khi có nhiều control
            flpDoctors.Controls.Clear();

            try
            {
                // 2. Lấy danh sách từ tầng BUS
                List<DoctorDTO> list = _bus.GetListDoctors();

                // Kiểm tra nếu danh sách rỗng thì thoát
                if (list == null || list.Count == 0) return;

                // 3. Duyệt danh sách và thêm vào FlowLayoutPanel
                foreach (var doc in list)
                {
                    // Khởi tạo UserControl Card
                    UCCardDoctor card = new UCCardDoctor();

                    // Truyền dữ liệu vào Card (Hàm này bạn đã viết ở UCCardDoctor)
                    card.SetDoctorData(doc);

                    // Chỉnh khoảng cách giữa các card cho đẹp
                    card.Margin = new Padding(15);

                    // THÊM VÀO flpDoctors
                    flpDoctors.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bác sĩ: " + ex.Message);
            }
        }

        private void ucPatient_SearchDoc_Load(object sender, EventArgs e)
        {
            LoadDoctorData();
        }
    }
}
