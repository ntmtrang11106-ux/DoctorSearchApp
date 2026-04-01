USE DoctorSearchDB;
GO

-- Thêm Chuyên khoa
INSERT INTO Specialties (Name, Description) VALUES 
(N'Nội khoa', N'Chẩn đoán và điều trị các bệnh nội tạng'),
(N'Nhi khoa', N'Chăm sóc sức khỏe cho trẻ em'),
(N'Da liễu', N'Điều trị các bệnh về da và thẩm mỹ');

-- Thêm Địa điểm
INSERT INTO Locations (Name) VALUES 
(N'Liên Chiểu'), (N'Hải Châu'), (N'Thanh Khê');

-- Thêm User (Tài khoản cho bác sĩ)
INSERT INTO [Users] (phone_number, [password], [role]) VALUES 
('0905123456', 'hashed_pass_1', 'Doctor'),
('0905654321', 'hashed_pass_2', 'Doctor'),
('0905999888', 'hashed_pass_3', 'Doctor');
GO
INSERT INTO Doctors (
    UserId, SpecialtyId, LocationId, full_name, cchn, workplace, 
    experience_years, bio, [status], Picture, Price, SpecificAddress
) VALUES 
(
    1, 1, 1, N'Võ Thị Nhân', 'CCHN12345', N'Bệnh viện Đa khoa Đà Nẵng', 
    10, N'Chuyên gia nội khoa với 10 năm kinh nghiệm.', N'Sẵn sàng', 
    'nhan_vo.jpg', N'200.000', N'123 Nguyễn Lương Bằng, Liên Chiểu'
),
(
    2, 2, 2, N'Nguyễn Trần Anh Tuấn', 'CCHN67890', N'Phòng khám Nhi Đồng', 
    5, N'Tận tâm với các bệnh nhi.', N'Sẵn sàng', 
    'tuan_nguyen.png', N'150.000', N'45 Hùng Vương, Hải Châu'
),
(
    3, 3, 1, N'Lê Thị Hồng', 'CCHN55555', N'Bệnh viện Da Liễu', 
    8, N'Chuyên điều trị mụn và sẹo rổ.', N'Bận', 
    'hong_le.jpg', N'300.000', N'88 Tôn Đức Thắng, Liên Chiểu'
);
GO