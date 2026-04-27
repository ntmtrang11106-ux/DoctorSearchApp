//using BUS_Tier;
//using DTO_Tier;

//namespace UI_Tier
//{
//    public partial class Form1 : Form
//    {
//        // Khai báo một lần ở cấp độ class để tái sử dụng
//        private DoctorBUS _bus = new DoctorBUS();

//        public Form1()
//        {
//            InitializeComponent();
//            // Đăng ký sự kiện Load của Form
//            this.Load += Form1_Load;
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            // Chỉ gọi load dữ liệu một lần duy nhất khi Form vừa mở lên
//            LoadDoctorData();
//        }

//        public void LoadDoctorData()
//        {
//            // 1. Xóa sạch các control cũ để tránh trùng lặp khi load lại
//            flpDoctors.Controls.Clear();

//            try
//            {
//                // 2. Lấy danh sách từ tầng BUS
//                List<DoctorDTO> list = _bus.GetListDoctors();

//                // Kiểm tra nếu danh sách rỗng thì thoát
//                if (list == null || list.Count == 0) return;

//                // 3. Duyệt danh sách và thêm vào FlowLayoutPanel
//                foreach (var doc in list)
//                {
//                    // Khởi tạo UserControl Card
//                    UCCardDoctor card = new UCCardDoctor();

//                    // Truyền dữ liệu vào Card (Hàm này bạn đã viết ở UCCardDoctor)
//                    card.SetDoctorData(doc);

//                    // Chỉnh khoảng cách giữa các card cho đẹp
//                    card.Margin = new Padding(15);

//                    // THÊM VÀO flpDoctors
//                    flpDoctors.Controls.Add(card);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi tải danh sách bác sĩ: " + ex.Message);
//            }
//        }
//    }
//}