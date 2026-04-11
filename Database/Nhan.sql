/* SCRIPT TỔNG HỢP: CHUẨN HÓA CẤU TRÚC DATABASE (V6.0 - FINAL)
   - Chuyển thông tin định danh về Users.
   - Chuyển Status sang NVARCHAR (Hoạt động / Không hoạt động).
   - Thêm cột WorkingTime (Giờ làm việc) cho bảng Doctors.
   - Nới lỏng ràng buộc NOT NULL bảng Doctors để hỗ trợ Đăng ký nhanh.
*/

-- =============================================================
-- 1. CẬP NHẬT BẢNG USERS (STATUS & ĐỊNH DANH)
-- =============================================================
-- 1.1 Đổi tên cột Id thành UserId nếu cần
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Id')
BEGIN
    EXEC sp_rename 'Users.Id', 'UserId', 'COLUMN';
END
GO

-- 1.2 Xử lý cột Status: Chuyển từ BIT sang NVARCHAR
-- Xóa ràng buộc Default cũ nếu có
DECLARE @DefConstName nvarchar(200);
SELECT @DefConstName = d.name FROM sys.default_constraints d
INNER JOIN sys.columns c ON d.parent_column_id = c.column_id AND d.parent_object_id = c.object_id
WHERE d.parent_object_id = OBJECT_ID('Users') AND c.name = 'Status';
IF @DefConstName IS NOT NULL EXEC('ALTER TABLE Users DROP CONSTRAINT ' + @DefConstName);

-- Đổi kiểu dữ liệu
ALTER TABLE Users ALTER COLUMN Status NVARCHAR(50);
GO

-- Cập nhật dữ liệu cũ
UPDATE Users SET Status = N'Hoạt động' WHERE Status = '1' OR Status = 'True' OR Status IS NULL;
UPDATE Users SET Status = N'Không hoạt động' WHERE Status = '0' OR Status = 'False';

-- Thêm Default mới dạng chữ
ALTER TABLE Users ADD CONSTRAINT DF_Users_Status DEFAULT N'Hoạt động' FOR Status;
GO

-- 1.3 Thêm các cột thông tin chung vào Users
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'FullName') ALTER TABLE Users ADD FullName NVARCHAR(100) NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Dob')      ALTER TABLE Users ADD Dob DATE NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Gender')   ALTER TABLE Users ADD Gender NVARCHAR(10) NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'CCCD')     ALTER TABLE Users ADD CCCD VARCHAR(20) NULL;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'Picture')  ALTER TABLE Users ADD Picture NVARCHAR(MAX) NULL;
GO

-- =============================================================
-- 2. DỌN DẸP RÀNG BUỘC VÀ CỘT DƯ THỪA (LOGIC V3.1)
-- =============================================================
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Doctors_Users') ALTER TABLE Doctors DROP CONSTRAINT FK_Doctors_Users;
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Patients_Users') ALTER TABLE Patients DROP CONSTRAINT FK_Patients_Users;
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Admins_Users') ALTER TABLE Admins DROP CONSTRAINT FK_Admins_Users;
GO

DECLARE @TName NVARCHAR(128), @CName NVARCHAR(128), @DropSql NVARCHAR(MAX);
DECLARE col_cur CURSOR FOR 
SELECT t.name, c.name FROM sys.tables t INNER JOIN sys.columns c ON t.object_id = c.object_id
WHERE t.name IN ('Doctors', 'Patients', 'Admins')
AND c.name IN ('status', 'full_name', 'dob', 'gender', 'cccd', 'picture');

OPEN col_cur;
FETCH NEXT FROM col_cur INTO @TName, @CName;
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Xóa Default Constraints
    DECLARE @DefaultConst NVARCHAR(255);
    SELECT @DefaultConst = d.name FROM sys.default_constraints d
    INNER JOIN sys.columns c ON d.parent_column_id = c.column_id AND d.parent_object_id = c.object_id
    WHERE d.parent_object_id = OBJECT_ID(@TName) AND c.name = @CName;
    IF @DefaultConst IS NOT NULL EXEC('ALTER TABLE ' + @TName + ' DROP CONSTRAINT ' + @DefaultConst);

    -- Xóa Index/Unique
    DECLARE @IndexName NVARCHAR(255);
    DECLARE idx_cur CURSOR FOR
    SELECT i.name FROM sys.indexes i INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
    WHERE i.object_id = OBJECT_ID(@TName) AND c.name = @CName;
    OPEN idx_cur; FETCH NEXT FROM idx_cur INTO @IndexName;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF EXISTS (SELECT 1 FROM sys.objects WHERE name = @IndexName AND type = 'UQ')
            EXEC('ALTER TABLE ' + @TName + ' DROP CONSTRAINT ' + @IndexName);
        ELSE
            EXEC('DROP INDEX ' + @IndexName + ' ON ' + @TName);
        FETCH NEXT FROM idx_cur INTO @IndexName;
    END
    CLOSE idx_cur; DEALLOCATE idx_cur;

    -- Xóa cột
    SET @DropSql = 'ALTER TABLE ' + QUOTENAME(@TName) + ' DROP COLUMN ' + QUOTENAME(@CName);
    BEGIN TRY EXEC sp_executesql @DropSql; END TRY BEGIN CATCH END CATCH
    FETCH NEXT FROM col_cur INTO @TName, @CName;
END
CLOSE col_cur; DEALLOCATE col_cur;
GO

-- =============================================================
-- 3. THIẾT LẬP LẠI BẢNG DOCTORS & ADMINS (CẬP NHẬT MỚI)
-- =============================================================

-- 3.1 Thêm cột WorkingTime (Giờ làm việc)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Doctors') AND name = 'WorkingTime')
    ALTER TABLE Doctors ADD WorkingTime NVARCHAR(255) NULL;
GO

-- 3.2 Sửa cột CCHN và Price thành NULL để không lỗi khi Đăng ký
-- Xóa Unique cũ để cho phép nhiều dòng cùng NULL
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'UQ_Doctors_CCHN') 
    ALTER TABLE Doctors DROP CONSTRAINT UQ_Doctors_CCHN;
GO

ALTER TABLE Doctors ALTER COLUMN cchn VARCHAR(50) NULL;
ALTER TABLE Doctors ALTER COLUMN Price NVARCHAR(50) NULL; -- Đổi sang NVARCHAR để linh hoạt
ALTER TABLE Doctors ALTER COLUMN SpecialtyId INT NULL;
ALTER TABLE Doctors ALTER COLUMN LocationId INT NULL;
GO

-- 3.3 Bảng Admins
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Admins')
    CREATE TABLE Admins (AdminId INT PRIMARY KEY IDENTITY(1,1), UserId INT NOT NULL);
GO

-- =============================================================
-- 4. KHÔI PHỤC RÀNG BUỘC KHÓA NGOẠI
-- =============================================================
ALTER TABLE Doctors ADD CONSTRAINT FK_Doctors_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);
ALTER TABLE Patients ADD CONSTRAINT FK_Patients_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);
ALTER TABLE Admins ADD CONSTRAINT FK_Admins_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);
GO

PRINT 'SUCCESS: Database da duoc chuan hoa! Status dang chu, WorkingTime da them, Doctors cho phep NULL.';