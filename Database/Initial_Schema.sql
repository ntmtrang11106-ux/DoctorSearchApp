--IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CNPM')
--BEGIN
    --CREATE DATABASE CNPM;
--END
--GO

USE DoctorSearchDB;
GO

-- XÓA BẢNG CON TRƯỚC (Thứ tự cực kỳ quan trọng)
DROP TABLE IF EXISTS Messages;      -- Trỏ đến Conversations & Users
DROP TABLE IF EXISTS CallLogs;      -- Trỏ đến Users
DROP TABLE IF EXISTS Articles;      -- Trỏ đến Users
DROP TABLE IF EXISTS Conversations; -- Trỏ đến Patients & Doctors
DROP TABLE IF EXISTS Reviews;       -- Trỏ đến Appointments
DROP TABLE IF EXISTS MedicalRecords;-- Trỏ đến Patients & Doctors
DROP TABLE IF EXISTS Appointments;  -- Trỏ đến Patients & TimeSlots
DROP TABLE IF EXISTS TimeSlots;     -- Trỏ đến Doctors
DROP TABLE IF EXISTS Patients;      -- Trỏ đến Users
DROP TABLE IF EXISTS Doctors;       -- Trỏ đến Users, Specialties, Locations

-- XÓA BẢNG CHA SAU CÙNG
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Specialties;
DROP TABLE IF EXISTS Locations;
GO

--ĐỊNH NGHĨA CÁC BẢNG CỐT LỖI
-- 1. Bảng Users (Gốc của mọi tài khoản)
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    phone_number VARCHAR(10) NOT NULL UNIQUE,
    password VARCHAR(MAX) NOT NULL,
    role NVARCHAR(20) NOT NULL, -- 'Admin', 'Doctor', 'Patient'
    created_at DATETIME DEFAULT GETDATE()
);


--ĐỊNH NGHĨA CÁC BẢNG NGHIỆP VỤ
    -- 1. Bảng Chuyên khoa
CREATE TABLE Specialties (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL, -- Ví dụ: Tim mạch, Nhi khoa [cite: 717]
    Description NVARCHAR(MAX)
);

-- 2. Bảng Khu vực
CREATE TABLE Locations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL -- Ví dụ: Liên Chiểu, Hải Châu [cite: 565]
);
-- 3. Bảng Doctors (Thông tin chi tiết Bác sĩ)
CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    SpecialtyId INT, -- Mối quan hệ với Chuyên khoa [MỚI]
    LocationId INT,  -- Mối quan hệ với Khu vực [MỚI]
    full_name NVARCHAR(100) NOT NULL,
    cchn VARCHAR(50) UNIQUE, -- Số Chứng chỉ hành nghề [cite: 549]
    workplace NVARCHAR(255), -- Nơi công tác [cite: 549]
    experience_years INT,
    bio NVARCHAR(MAX),
    status NVARCHAR(20) DEFAULT N'Pending', -- Chờ duyệt bởi Admin [cite: 546]
    CONSTRAINT FK_Doctors_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_Doctors_Spec FOREIGN KEY (SpecialtyId) REFERENCES Specialties(Id),
    CONSTRAINT FK_Doctors_Loc FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);

-- 2. Bảng Patients (Thông tin chi tiết Bệnh nhân)
CREATE TABLE Patients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    dob DATE,
    gender NVARCHAR(10), -- [cite: 542]
    cccd VARCHAR(12) UNIQUE, -- [cite: 542]
    bhyt VARCHAR(15), -- [cite: 542]
    address NVARCHAR(255),
    blood_type VARCHAR(5), -- [cite: 582]
    medical_history NVARCHAR(MAX), -- [cite: 582]
    CONSTRAINT FK_Patients_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- 3. NHÓM BẢNG NGHIỆP VỤ (Phụ thuộc vào Patients và Doctors)
CREATE TABLE MedicalRecords (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    visit_date DATETIME DEFAULT GETDATE(),
    diagnosis NVARCHAR(MAX),
    treatment NVARCHAR(MAX),
    CONSTRAINT FK_Records_Patients FOREIGN KEY (PatientId) REFERENCES Patients(Id),
    CONSTRAINT FK_Records_Doctors FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);
-- 3. Bảng Khung giờ (Bác sĩ tạo lịch)
CREATE TABLE TimeSlots (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DoctorId INT NOT NULL, -- Theo công thức TableNameId 
    Date DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Status NVARCHAR(20) DEFAULT N'Trống',
    -- Lưu ý: Cần có bảng Doctors của Trang để tạo FK này
    CONSTRAINT FK_TimeSlots_Doctors FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);

-- 4. Bảng Lịch hẹn
CREATE TABLE Appointments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL, -- FK trỏ về Patients.Id 
    TimeSlotId INT NOT NULL, -- FK trỏ về TimeSlots.Id 
    Symptoms NVARCHAR(500),
    Status NVARCHAR(20) DEFAULT N'Chờ duyệt',
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_App_Patient FOREIGN KEY (PatientId) REFERENCES Patients(Id),
    CONSTRAINT FK_App_TimeSlot FOREIGN KEY (TimeSlotId) REFERENCES TimeSlots(Id)
);

--ĐỊNH NGHĨA CÁC BẢNG BỔ TRỢ
-- 1. Đặc tả cho Reviews (Đánh giá)
CREATE TABLE Reviews (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AppointmentId INT NOT NULL UNIQUE,                   -- Liên kết 1-1 tới lần khám
    Rating INT CHECK (Rating >= 1 AND Rating <= 5), -- Số sao (1-5)
    Comment NVARCHAR(MAX),                       -- Nhận xét của bệnh nhân
    CreatedAt DATETIME DEFAULT GETDATE(),        -- Ngày tạo đánh giá
    CONSTRAINT FK_Reviews_App FOREIGN KEY (AppointmentId) REFERENCES Appointments(Id)
);

-- 2. Đặc tả cho Conversations (Hội thoại)
CREATE TABLE Conversations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PatientID INT NOT NULL,                      -- FK trỏ về Patients
    DoctorID INT NOT NULL,                       -- FK trỏ về Doctors
    LastActive DATETIME DEFAULT GETDATE(),       -- Thời điểm tương tác cuối
    CONSTRAINT FK_Conv_Patient FOREIGN KEY (PatientID) REFERENCES Patients(Id),
    CONSTRAINT FK_Conv_Doctor FOREIGN KEY (DoctorID) REFERENCES Doctors(Id)
);

-- 3. Đặc tả cho Messages (Tin nhắn)
CREATE TABLE Messages (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ConversationId INT NOT NULL,                         -- Thuộc đoạn chat nào
    SenderID INT NOT NULL,                       -- ID của người gửi (Trỏ về Users)
    Content NVARCHAR(MAX) NOT NULL,               -- Nội dung tin nhắn
    SentAt DATETIME DEFAULT GETDATE(),           -- Thời điểm gửi tin
    IsRead BIT DEFAULT 0,                        -- 0: chưa đọc, 1: đã xem
    CONSTRAINT FK_Msg_Conv FOREIGN KEY (ConversationId) REFERENCES Conversations(Id),
    CONSTRAINT FK_Msg_Sender FOREIGN KEY (SenderID) REFERENCES Users(Id)
);

-- 4. Đặc tả cho CallLogs (Nhật ký cuộc gọi)
CREATE TABLE CallLogs (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CallerID INT NOT NULL,                       -- ID người gọi
    ReceiverID INT NOT NULL,                     -- ID người nhận
    StartTime DATETIME NOT NULL,                 -- Thời điểm bắt đầu
    EndTime DATETIME NOT NULL,                   -- Thời điểm kết thúc
    Duration INT DEFAULT 0,                      -- Thời lượng (giây)
    Status NVARCHAR(50) NOT NULL,                -- Missed, Completed, Declined
    CONSTRAINT FK_Call_Caller FOREIGN KEY (CallerID) REFERENCES Users(Id),
    CONSTRAINT FK_Call_Receiver FOREIGN KEY (ReceiverID) REFERENCES Users(Id)
);

-- 5. Đặc tả cho Articles (Bài viết y khoa)
-- Lưu ý: AdminID trỏ về Users.UserID
CREATE TABLE Articles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AdminID INT NOT NULL,                        -- FK trỏ về Users.UserID
    Title NVARCHAR(255) NOT NULL,                -- Tiêu đề bài viết
    Content NVARCHAR(MAX) NOT NULL,               -- Nội dung chi tiết
    Thumbnail VARCHAR(255),                      -- Ảnh đại diện (đường dẫn file)
    Views INT DEFAULT 0,                         -- Tổng lượt xem
    CreatedAt DATETIME DEFAULT GETDATE(),        -- Ngày xuất bản
    CONSTRAINT FK_Articles_Admin FOREIGN KEY (AdminID) REFERENCES Users(Id)
);
GO
