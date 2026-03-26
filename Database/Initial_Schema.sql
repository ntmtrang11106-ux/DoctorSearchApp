-- Create Table Users
CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    phone_number VARCHAR(10) NOT NULL UNIQUE,
    password VARCHAR(MAX) NOT NULL,
    role NVARCHAR(20) NOT NULL, -- Admin, Doctor, Patient
    is_active BIT DEFAULT 1
);

-- Create Table Patients
CREATE TABLE Patients (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT FOREIGN KEY REFERENCES Users(id),
    full_name NVARCHAR(100) NOT NULL,
    dob DATE,
    cccd VARCHAR(12) UNIQUE,
    bhyt VARCHAR(15),
    address NVARCHAR(255)
);
