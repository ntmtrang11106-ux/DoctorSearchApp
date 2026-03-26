-- 1. Bảng Chuyên khoa
CREATE TABLE Specialties (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chuẩn hóa Id 
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX)
);

-- 2. Bảng Khu vực
CREATE TABLE Locations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
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
    -- CONSTRAINT FK_TimeSlots_Doctors FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
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
