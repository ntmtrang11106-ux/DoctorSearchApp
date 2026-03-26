USE DoctorSearchDB;
GO

-- Xóa bảng cũ theo thứ tự từ con đến cha để không bị lỗi ràng buộc
IF OBJECT_ID('MedicalRecords', 'U') IS NOT NULL DROP TABLE MedicalRecords;
IF OBJECT_ID('Doctors', 'U') IS NOT NULL DROP TABLE Doctors;
IF OBJECT_ID('Patients', 'U') IS NOT NULL DROP TABLE Patients;
IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;
GO

-- 1. Bảng Users (Gốc của mọi tài khoản)
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    phone_number VARCHAR(10) NOT NULL UNIQUE,
    password VARCHAR(MAX) NOT NULL,
    role NVARCHAR(20) NOT NULL, -- 'Admin', 'Doctor', 'Patient'
    created_at DATETIME DEFAULT GETDATE()
);

-- 2. Bảng Patients (Thông tin chi tiết Bệnh nhân)
CREATE TABLE Patients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    user_Id INT NOT NULL, -- Nối với Users
    full_name NVARCHAR(100) NOT NULL,
    dob DATE,
    address NVARCHAR(255),
    CONSTRAINT FK_Patients_Users FOREIGN KEY (user_id) REFERENCES Users(id)
);

-- 3. Bảng Doctors (Thông tin chi tiết Bác sĩ)
CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    user_Id INT NOT NULL, -- Nối với Users
    full_name NVARCHAR(100) NOT NULL,
    specialty NVARCHAR(100), -- Chuyên khoa
    experience_years INT,
    bio NVARCHAR(MAX),
    CONSTRAINT FK_Doctors_Users FOREIGN KEY (user_id) REFERENCES Users(id)
);

-- 4. Bảng MedicalRecords (Hồ sơ bệnh án - Nối Bệnh nhân và Bác sĩ)
CREATE TABLE MedicalRecords (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    patient_Id INT NOT NULL,
    doctor_Id INT NOT NULL,
    visit_date DATETIME DEFAULT GETDATE(),
    diagnosis NVARCHAR(MAX), -- Chẩn đoán
    treatment NVARCHAR(MAX), -- Hướng điều trị
    CONSTRAINT FK_Records_Patients FOREIGN KEY (patient_id) REFERENCES Patients(id),
    CONSTRAINT FK_Records_Doctors FOREIGN KEY (doctor_id) REFERENCES Doctors(id)
);
GO