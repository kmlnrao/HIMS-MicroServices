-- Create database
CREATE DATABASE PatientDB;
GO

Use PatientDB
GO

-- Patients Table
CREATE TABLE Patients (
    PatientId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    DateOfBirth DATE,
    Gender CHAR(1),
    Phone NVARCHAR(20)
);

-- Sample Patients
INSERT INTO Patients (FullName, DateOfBirth, Gender, Phone) VALUES
('Ravi Kumar', '1990-05-12', 'M', '9876543210'),
('Anita Sharma', '1985-08-30', 'F', '9123456780'),
('Suresh Verma', '1978-01-15', 'M', '9998765432'),
('Neha Mehta', '1992-07-25', 'F', '9821346790');

CREATE DATABASE DoctorDB;
GO

Use DoctorDB
GO

-- Doctors Table
CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Specialty NVARCHAR(100)
);

-- Sample Doctors
INSERT INTO Doctors (FullName, Specialty) VALUES
('Dr. Ajay Singh', 'Cardiology'),
('Dr. Meena Patel', 'Neurology'),
('Dr. Vikram Rao', 'Orthopedics');


CREATE DATABASE ServicesDB;
GO

Use ServicesDB
GO


-- Services Master
CREATE TABLE ServiceMasters (
    ServiceId INT PRIMARY KEY IDENTITY(1,1),
    ServiceName NVARCHAR(100),
    Description NVARCHAR(200),
    UnitPrice DECIMAL(10,2)
);

-- Sample Services
INSERT INTO ServiceMasters (ServiceName, Description, UnitPrice) VALUES
('Consultation', 'General physician consultation', 300.00),
('X-Ray', 'X-Ray imaging service', 500.00),
('Blood Test', 'Comprehensive blood test', 200.00);



CREATE DATABASE BillingDB;
GO

Use BillingDB
GO

-- Bills
CREATE TABLE Bills (
    BillId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT,
    DoctorId INT,
    BillDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

-- Bill Services
CREATE TABLE BillServices (
    BillServiceId INT PRIMARY KEY IDENTITY(1,1),
    BillId INT,
    ServiceId INT,
    Quantity INT,
    UnitPrice DECIMAL(10,2),
    TotalPrice AS (Quantity * UnitPrice) PERSISTED,
    FOREIGN KEY (BillId) REFERENCES Bills(BillId),
    FOREIGN KEY (ServiceId) REFERENCES ServiceMasters(ServiceId)
);


CREATE DATABASE PaymentDB;
GO

Use PaymentDB
GO


-- Payments
CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT,
    PaymentDate DATETIME DEFAULT GETDATE(),
    TotalPaidAmount DECIMAL(10,2),
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId)
);

-- Payment Details
CREATE TABLE PaymentDetails (
    PaymentDetailId INT PRIMARY KEY IDENTITY(1,1),
    PaymentId INT,
    BillId INT,
    PaidAmount DECIMAL(10,2),
    PayMode NVARCHAR(50),
    ReferenceNo NVARCHAR(100),
    FOREIGN KEY (PaymentId) REFERENCES Payments(PaymentId),
    FOREIGN KEY (BillId) REFERENCES Bills(BillId)
);
