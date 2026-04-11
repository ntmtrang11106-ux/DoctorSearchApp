/* =============================================================
SCRIPT TỔNG HỢP: CHUẨN HÓA DATABASE (BẢN FULL - FIXED ALL ERRORS)
=============================================================
*/

-- 1. CHUẨN HÓA BẢNG USERS (BẢNG GỐC)
-- -----------------------------------------------------------
-- Đổi tên Id thành UserId
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Id')
BEGIN
    EXEC sp_rename 'Users.Id', 'UserId', 'COLUMN';
END
GO

-- Xử lý cột Status (Chuyển sang NVARCHAR)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Status')
BEGIN
    ALTER TABLE Users ADD Status NVARCHAR(50);
END
ELSE
BEGIN
    -- Xóa Default Constraint bám trên Status để đổi kiểu dữ liệu
    DECLARE @StatusDef NVARCHAR(255);
    SELECT @StatusDef = d.name FROM sys.default_constraints d
    WHERE d.parent_object_id = OBJECT_ID('Users') 
    AND d.parent_column_id = (SELECT column_id FROM sys.columns WHERE name = 'Status' AND object_id = OBJECT_ID('Users'));
    IF @StatusDef IS NOT NULL EXEC('ALTER TABLE Users DROP CONSTRAINT ' + @StatusDef);

    ALTER TABLE Users ALTER COLUMN Status NVARCHAR(50);
END
GO

-- Cập nhật dữ liệu cho Status
UPDATE Users SET Status = N'Hoạt động' WHERE Status IN ('1', 'True') OR Status IS NULL;
UPDATE Users SET Status = N'Không hoạt động' WHERE Status IN ('0', 'False');
GO

-- Thêm các cột thông tin định danh vào Users
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'FullName') ALTER TABLE Users ADD FullName NVARCHAR(100) NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Dob')      ALTER TABLE Users ADD Dob DATE NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Gender')   ALTER TABLE Users ADD Gender NVARCHAR(10) NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'CCCD')     ALTER TABLE Users ADD CCCD VARCHAR(20) NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Picture')  ALTER TABLE Users ADD Picture NVARCHAR(MAX) NULL;
GO


-- 2. DỌN DẸP RÀNG BUỘC VÀ CỘT DƯ THỪA Ở CÁC BẢNG CON
-- -----------------------------------------------------------
-- Xóa tất cả Khóa ngoại cũ để tránh lỗi Msg 2714
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Doctors_Users') ALTER TABLE Doctors DROP CONSTRAINT FK_Doctors_Users;
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Patients_Users') ALTER TABLE Patients DROP CONSTRAINT FK_Patients_Users;
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Admins_Users') ALTER TABLE Admins DROP CONSTRAINT FK_Admins_Users;
GO

DECLARE @TName NVARCHAR(128), @CName NVARCHAR(128), @DropSql NVARCHAR(MAX);
-- Tìm các cột cần xóa trong Doctors, Patients, Admins
DECLARE col_cur CURSOR FOR 
SELECT t.name, c.name FROM sys.tables t INNER JOIN sys.columns c ON t.object_id = c.object_id
WHERE t.name IN ('Doctors', 'Patients', 'Admins')
AND c.name IN ('status', 'full_name', 'dob', 'gender', 'cccd', 'picture');

OPEN col_cur; FETCH NEXT FROM col_cur INTO @TName, @CName;
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Xóa Default Constraints động
    DECLARE @DName NVARCHAR(255);
    SELECT @DName = d.name FROM sys.default_constraints d 
    WHERE d.parent_object_id = OBJECT_ID(@TName) 
    AND d.parent_column_id = (SELECT column_id FROM sys.columns WHERE name = @CName AND object_id = OBJECT_ID(@TName));
    IF @DName IS NOT NULL EXEC('ALTER TABLE ' + @TName + ' DROP CONSTRAINT ' + @DName);

    -- Xóa Unique/Index động bám trên cột
    DECLARE @IName NVARCHAR(255);
    DECLARE idx_cur CURSOR FOR
    SELECT i.name FROM sys.indexes i INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
    WHERE i.object_id = OBJECT_ID(@TName) AND c.name = @CName;
    OPEN idx_cur; FETCH NEXT FROM idx_cur INTO @IName;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF EXISTS (SELECT 1 FROM sys.objects WHERE name = @IName AND type = 'UQ')
            EXEC('ALTER TABLE ' + @TName + ' DROP CONSTRAINT ' + @IName);
        ELSE
            EXEC('DROP INDEX ' + @IName + ' ON ' + @TName);
        FETCH NEXT FROM idx_cur INTO @IName;
    END
    CLOSE idx_cur; DEALLOCATE idx_cur;

    -- Xóa cột dư thừa
    SET @DropSql = 'ALTER TABLE ' + QUOTENAME(@TName) + ' DROP COLUMN ' + QUOTENAME(@CName);
    BEGIN TRY EXEC sp_executesql @DropSql; END TRY BEGIN CATCH END CATCH
    
    FETCH NEXT FROM col_cur INTO @TName, @CName;
END
CLOSE col_cur; DEALLOCATE col_cur;
GO


-- 3. ĐIỀU CHỈNH RIÊNG BẢNG DOCTORS & ADMINS
-- -----------------------------------------------------------
-- Xóa Unique cũ trên cchn (nếu có tên lạ) để cho phép sửa cột
DECLARE @CchnUQ NVARCHAR(255);
SELECT @CchnUQ = i.name FROM sys.indexes i
INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE i.object_id = OBJECT_ID('Doctors') AND c.name = 'cchn';
IF @CchnUQ IS NOT NULL 
BEGIN
    IF EXISTS (SELECT 1 FROM sys.objects WHERE name = @CchnUQ AND type = 'UQ') 
        EXEC('ALTER TABLE Doctors DROP CONSTRAINT ' + @CchnUQ);
    ELSE 
        EXEC('DROP INDEX ' + @CchnUQ + ' ON Doctors');
END

-- Nới lỏng các cột bảng Doctors
ALTER TABLE Doctors ALTER COLUMN cchn VARCHAR(50) NULL;
ALTER TABLE Doctors ALTER COLUMN Price NVARCHAR(50) NULL;
ALTER TABLE Doctors ALTER COLUMN SpecialtyId INT NULL;
ALTER TABLE Doctors ALTER COLUMN LocationId INT NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Doctors') AND name = 'WorkingTime')
    ALTER TABLE Doctors ADD WorkingTime NVARCHAR(255) NULL;
GO

-- Đảm bảo bảng Admins tồn tại
IF OBJECT_ID('Admins') IS NULL
    CREATE TABLE Admins (AdminId INT PRIMARY KEY IDENTITY(1,1), UserId INT NOT NULL);
GO


-- 4. KHÔI PHỤC RÀNG BUỘC (FK & UNIQUE)
-- -----------------------------------------------------------
-- Xóa dữ liệu mồ côi (Doctor/Patient không có User tương ứng)
DELETE FROM Doctors WHERE UserId NOT IN (SELECT UserId FROM Users);
DELETE FROM Patients WHERE UserId NOT IN (SELECT UserId FROM Users);
DELETE FROM Admins WHERE UserId NOT IN (SELECT UserId FROM Users);
GO

-- Tạo lại Khóa ngoại (An toàn)
ALTER TABLE Doctors ADD CONSTRAINT FK_Doctors_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);
ALTER TABLE Patients ADD CONSTRAINT FK_Patients_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);
ALTER TABLE Admins ADD CONSTRAINT FK_Admins_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);

-- Tạo lại Unique CCHN với tên rõ ràng
IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = 'UQ_Doctors_CCHN')
    ALTER TABLE Doctors ADD CONSTRAINT UQ_Doctors_CCHN UNIQUE (cchn);
GO

-- HOÀN TẤT
PRINT '-------------------------------------------------------------';
PRINT 'KET QUA: DATABASE DA DUOC FIX LOI VA CHUAN HOA THANH CONG!';
PRINT '-------------------------------------------------------------';