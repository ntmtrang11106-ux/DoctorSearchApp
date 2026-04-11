/* SCRIPT TỔNG HỢP: CHUẨN HÓA CẤU TRÚC DATABASE (V1.0)
   - Chuyển FullName và Status về bảng Users (quản lý tập trung).
   - Xóa dữ liệu dư thừa ở bảng Doctors, Patients, Admins.
   - Đồng bộ tên cột khóa chính là UserId.
*/

-- =============================================================
-- 1. CHUẨN HÓA BẢNG USERS (Bảng Cha)
-- =============================================================
-- Đổi tên Id thành UserId nếu bảng Users đang dùng tên Id
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Id')
BEGIN
    EXEC sp_rename 'Users.Id', 'UserId', 'COLUMN';
END
GO

-- Thêm trường FullName và Status (BIT) nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'FullName')
    ALTER TABLE Users ADD FullName NVARCHAR(100) NOT NULL DEFAULT N'Chưa cập nhật';

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Status')
    ALTER TABLE Users ADD Status BIT NOT NULL DEFAULT 1;
GO

-- =============================================================
-- 2. DỌN DẸP RÀNG BUỘC CŨ (Để tháo khóa cho việc sửa bảng)
-- =============================================================
-- Xóa các Unique và Default cũ trên bảng Doctors
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'UQ__Doctors__37DF2F264306F622')
    ALTER TABLE Doctors DROP CONSTRAINT UQ__Doctors__37DF2F264306F622;

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'DF__Doctors__status__787EE5A0')
    ALTER TABLE Doctors DROP CONSTRAINT DF__Doctors__status__787EE5A0;

-- Tháo các Foreign Key cũ để tránh lỗi "invalid column" khi tái cấu trúc
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Doctors_Users') ALTER TABLE Doctors DROP CONSTRAINT FK_Doctors_Users;
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Patients_Users') ALTER TABLE Patients DROP CONSTRAINT FK_Patients_Users;
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Admins_Users') ALTER TABLE Admins DROP CONSTRAINT FK_Admins_Users;
GO

-- =============================================================
-- 3. LOẠI BỎ DƯ THỪA VÀ CẬP NHẬT CÁC BẢNG CON
-- =============================================================

-- A. Bảng DOCTORS (Xóa full_name, status - Giữ lại chuyên môn)
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Doctors') AND name = 'status')
    ALTER TABLE Doctors DROP COLUMN status;

IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Doctors') AND name = 'full_name')
    ALTER TABLE Doctors DROP COLUMN full_name;

ALTER TABLE Doctors ALTER COLUMN cchn VARCHAR(50) NOT NULL;
ALTER TABLE Doctors ALTER COLUMN Price NCHAR(10) NOT NULL;

-- B. Bảng PATIENTS (Xóa full_name, status - Giữ lại thông tin y tế)
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Patients') AND name = 'full_name')
    ALTER TABLE Patients DROP COLUMN full_name;

IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Patients') AND name = 'status')
    ALTER TABLE Patients DROP COLUMN status;

ALTER TABLE Patients ALTER COLUMN dob DATE NOT NULL;
ALTER TABLE Patients ALTER COLUMN gender NVARCHAR(10) NOT NULL;

-- C. Bảng ADMINS (Chỉ giữ UserId làm liên kết)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Admins')
BEGIN
    CREATE TABLE Admins (
        Id INT PRIMARY KEY IDENTITY(1,1),
        UserId INT NOT NULL
    );
END
ELSE
BEGIN
    -- Nếu bảng Admins đã có, xóa full_name/status nếu lỡ tay thêm vào
    IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Admins') AND name = 'full_name')
        ALTER TABLE Admins DROP COLUMN full_name;
    IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Admins') AND name = 'status')
        ALTER TABLE Admins DROP COLUMN status;
END
GO

-- =============================================================
-- 4. THIẾT LẬP LẠI TOÀN BỘ LIÊN KẾT (FOREIGN KEYS & UNIQUE)
-- =============================================================

-- Tạo lại Unique cho cchn để đảm bảo không trùng số chứng chỉ
IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = 'UQ_Doctors_CCHN')
    ALTER TABLE Doctors ADD CONSTRAINT UQ_Doctors_CCHN UNIQUE (cchn);

-- Tạo lại Khóa ngoại tham chiếu chính xác đến Users.UserId
ALTER TABLE Doctors ADD CONSTRAINT FK_Doctors_Users 
    FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE Patients ADD CONSTRAINT FK_Patients_Users 
    FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE Admins ADD CONSTRAINT FK_Admins_Users 
    FOREIGN KEY (UserId) REFERENCES Users(UserId);
GO

PRINT 'SUCCESS: Database đã sạch sẽ! FullName và Status chỉ còn nằm ở bảng Users.';