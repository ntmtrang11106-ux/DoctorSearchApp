USE DoctorSearchDB;
GO

-- 1. Thêm cột Picture nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Doctors') AND name = 'Picture')
BEGIN
    ALTER TABLE dbo.Doctors ADD Picture nvarchar(255) NULL;
END
GO

-- 2. Thêm cột Price nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Doctors') AND name = 'Price')
BEGIN
    ALTER TABLE dbo.Doctors ADD Price nchar(10) NULL;
END
GO

-- 3. Thêm cột SpecificAddress nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Doctors') AND name = 'SpecificAddress')
BEGIN
    ALTER TABLE dbo.Doctors ADD SpecificAddress nvarchar(255) NULL;
END
GO