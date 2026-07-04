CREATE DATABASE PetCareTrackerDB;
GO

USE PetCareTrackerDB;
GO

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT 'User',
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Pets (
    PetId INT IDENTITY(1,1) PRIMARY KEY,
    PetName NVARCHAR(100) NOT NULL,
    Species NVARCHAR(50) NOT NULL,
    Breed NVARCHAR(100) NULL,
    Gender NVARCHAR(10) NULL,
    BirthDate DATE NULL,
    Weight DECIMAL(5,2) NULL,

    UserId INT NOT NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Pets_Users
        FOREIGN KEY (UserId) REFERENCES Users(UserId)
        ON DELETE CASCADE
);

CREATE TABLE Vaccinations (
    VaccinationId INT IDENTITY(1,1) PRIMARY KEY,
    PetId INT NOT NULL,

    VaccineName NVARCHAR(100) NOT NULL,
    VaccinationDate DATE NOT NULL,
    NextDueDate DATE NULL,
    Notes NVARCHAR(255) NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Vaccinations_Pets
        FOREIGN KEY (PetId) REFERENCES Pets(PetId)
        ON DELETE CASCADE
);

CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PetId INT NOT NULL,

    AppointmentDate DATETIME NOT NULL,
    Veterinarian NVARCHAR(100) NOT NULL,
    Notes NVARCHAR(255) NULL,

    Status NVARCHAR(20) NOT NULL DEFAULT 'Bekliyor', 

    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Appointments_Pets
        FOREIGN KEY (PetId) REFERENCES Pets(PetId)
        ON DELETE CASCADE
);

CREATE INDEX IX_Pets_UserId ON Pets(UserId);
CREATE INDEX IX_Vaccinations_PetId ON Vaccinations(PetId);
CREATE INDEX IX_Appointments_PetId ON Appointments(PetId);

CREATE INDEX IX_Vaccinations_NextDueDate ON Vaccinations(NextDueDate);
CREATE INDEX IX_Appointments_Date ON Appointments(AppointmentDate);

INSERT INTO Users (FullName, Email, PasswordHash, Role)
VALUES 
('Ali YÄ±lmaz', 'ali@mail.com', '123', 'User'),
('AyÅŸe Demir', 'ayse@mail.com', '123', 'User');
INSERT INTO Pets (PetName, Species, Breed, Gender, BirthDate, Weight, UserId)
VALUES
('KarabaÅŸ', 'KÃ¶pek', 'Golden Retriever', 'Erkek', '2020-05-10', 28.5, 1),
('Pamuk', 'Kedi', 'British Shorthair', 'DiÅŸi', '2021-08-15', 4.2, 2),
('Zeytin', 'KÃ¶pek', 'Terrier', 'Erkek', '2019-03-20', 10.1, 1);
INSERT INTO Vaccinations (PetId, VaccineName, VaccinationDate, NextDueDate, Notes)
VALUES
(1, 'Kuduz', '2025-01-10', '2026-01-10', 'YÄ±llÄ±k aÅŸÄ±'),
(1, 'Karma AÅŸÄ±', '2025-02-15', '2025-08-15', '6 aylÄ±k tekrar'),
(2, 'Parazit', '2025-03-01', '2025-09-01', 'Damla uygulandÄ±');
INSERT INTO Appointments (PetId, AppointmentDate, Veterinarian, Notes, Status)
VALUES
(1, '2026-07-01 10:00', 'Dr. Mehmet', 'Kontrol', 'Bekliyor'),
(2, '2026-07-03 14:00', 'Dr. Elif', 'AÅŸÄ± kontrolÃ¼', 'Bekliyor'),
(3, '2026-06-20 09:30', 'Dr. Mehmet', 'Genel kontrol', 'TamamlandÄ±');

CREATE PROCEDURE sp_Pet_Add
@PetName NVARCHAR(100),
@Species NVARCHAR(50),
@Breed NVARCHAR(100),
@Gender NVARCHAR(10),
@BirthDate DATE,
@Weight DECIMAL(5,2),
@UserId INT
AS
BEGIN
    INSERT INTO Pets
    (PetName, Species, Breed, Gender, BirthDate, Weight, UserId)
    VALUES
    (@PetName, @Species, @Breed, @Gender, @BirthDate, @Weight, @UserId)
END

CREATE PROCEDURE sp_Pet_List
@UserId INT
AS
BEGIN
    SELECT * FROM Pets
    WHERE UserId = @UserId
END
CREATE PROCEDURE sp_Pet_Search
@Keyword NVARCHAR(100),
@UserId INT
AS
BEGIN
    SELECT * FROM Pets
    WHERE UserId = @UserId
    AND (
        PetName LIKE '%' + @Keyword + '%'
        OR Species LIKE '%' + @Keyword + '%'
        OR Breed LIKE '%' + @Keyword + '%'
    )
END

CREATE PROCEDURE sp_Pet_Update
@PetId INT,
@PetName NVARCHAR(100),
@Species NVARCHAR(50),
@Breed NVARCHAR(100),
@Gender NVARCHAR(10),
@BirthDate DATE,
@Weight DECIMAL(5,2)
AS
BEGIN
    UPDATE Pets
    SET 
        PetName = @PetName,
        Species = @Species,
        Breed = @Breed,
        Gender = @Gender,
        BirthDate = @BirthDate,
        Weight = @Weight
    WHERE PetId = @PetId
END

CREATE PROCEDURE sp_Pet_Delete
@PetId INT
AS
BEGIN
    DELETE FROM Pets WHERE PetId = @PetId
END


CREATE PROCEDURE sp_Vaccination_Add
@PetId INT,
@VaccineName NVARCHAR(100),
@VaccinationDate DATE,
@NextDueDate DATE,
@Notes NVARCHAR(255)
AS
BEGIN
    INSERT INTO Vaccinations
    (PetId, VaccineName, VaccinationDate, NextDueDate, Notes)
    VALUES
    (@PetId, @VaccineName, @VaccinationDate, @NextDueDate, @Notes)
END
GO


CREATE PROCEDURE sp_Vaccination_ListByPet
@PetId INT
AS
BEGIN
    SELECT 
        v.VaccinationId,
        v.VaccineName,
        v.VaccinationDate,
        v.NextDueDate,
        v.Notes,
        p.PetName
    FROM Vaccinations v
    INNER JOIN Pets p ON p.PetId = v.PetId
    WHERE v.PetId = @PetId
END
GO


CREATE PROCEDURE sp_Vaccination_Search
@Keyword NVARCHAR(100)
AS
BEGIN
    SELECT 
        v.*,
        p.PetName
    FROM Vaccinations v
    INNER JOIN Pets p ON p.PetId = v.PetId
    WHERE v.VaccineName LIKE '%' + @Keyword + '%'
       OR p.PetName LIKE '%' + @Keyword + '%'
END
GO




CREATE PROCEDURE sp_Appointment_Add
@PetId INT,
@AppointmentDate DATETIME,
@Veterinarian NVARCHAR(100),
@Notes NVARCHAR(255)
AS
BEGIN
    INSERT INTO Appointments
    (PetId, AppointmentDate, Veterinarian, Notes, Status)
    VALUES
    (@PetId, @AppointmentDate, @Veterinarian, @Notes, 'Bekliyor')
END
GO


CREATE PROCEDURE sp_Appointment_ListByPet
@PetId INT
AS
BEGIN
    SELECT 
        a.AppointmentId,
        a.AppointmentDate,
        a.Veterinarian,
        a.Notes,
        a.Status,
        p.PetName
    FROM Appointments a
    INNER JOIN Pets p ON p.PetId = a.PetId
    WHERE a.PetId = @PetId
END
GO


CREATE PROCEDURE sp_Appointment_UpdateStatus
@AppointmentId INT,
@Status NVARCHAR(20)
AS
BEGIN
    UPDATE Appointments
    SET Status = @Status
    WHERE AppointmentId = @AppointmentId
END
GO


CREATE PROCEDURE sp_Appointment_Search
@Keyword NVARCHAR(100)
AS
BEGIN
    SELECT 
        a.*,
        p.PetName
    FROM Appointments a
    INNER JOIN Pets p ON p.PetId = a.PetId
    WHERE a.Veterinarian LIKE '%' + @Keyword + '%'
       OR p.PetName LIKE '%' + @Keyword + '%'
END
GO

CREATE PROCEDURE sp_Dashboard_Get
AS
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM Pets) AS TotalPets,
        (SELECT COUNT(*) FROM Vaccinations) AS TotalVaccinations,
        (SELECT COUNT(*) FROM Appointments) AS TotalAppointments,
        (SELECT COUNT(*) FROM Appointments WHERE Status = 'Bekliyor') AS PendingAppointments,
        (SELECT COUNT(*) FROM Appointments WHERE Status = 'TamamlandÄ±') AS CompletedAppointments,
        (SELECT COUNT(*) FROM Vaccinations WHERE NextDueDate <= DATEADD(DAY, 7, GETDATE())) AS UpcomingVaccinations,
        (SELECT COUNT(*) FROM Appointments WHERE AppointmentDate <= DATEADD(DAY, 7, GETDATE())) AS UpcomingAppointments
END
GO




CREATE PROCEDURE sp_Report_UpcomingVaccinations
AS
BEGIN
    SELECT 
        v.VaccinationId,
        p.PetName,
        p.Species,
        v.VaccineName,
        v.VaccinationDate,
        v.NextDueDate,
        DATEDIFF(DAY, GETDATE(), v.NextDueDate) AS DaysLeft
    FROM Vaccinations v
    INNER JOIN Pets p ON p.PetId = v.PetId
    WHERE v.NextDueDate IS NOT NULL
      AND v.NextDueDate <= DATEADD(DAY, 30, GETDATE())
    ORDER BY v.NextDueDate ASC
END
GO




CREATE PROCEDURE sp_Report_UpcomingAppointments
AS
BEGIN
    SELECT 
        a.AppointmentId,
        p.PetName,
        a.Veterinarian,
        a.AppointmentDate,
        a.Status,
        DATEDIFF(DAY, GETDATE(), a.AppointmentDate) AS DaysLeft
    FROM Appointments a
    INNER JOIN Pets p ON p.PetId = a.PetId
    WHERE a.AppointmentDate BETWEEN GETDATE()
    AND DATEADD(DAY, 30, GETDATE())
    ORDER BY a.AppointmentDate ASC
END
GO




CREATE PROCEDURE sp_Report_PetDetail
@PetId INT
AS
BEGIN
    SELECT 
        p.PetName,
        p.Species,
        p.Breed,
        p.Gender,
        p.BirthDate,
        p.Weight,

        u.FullName AS OwnerName,

        v.VaccineName,
        v.VaccinationDate,
        v.NextDueDate,

        a.AppointmentDate,
        a.Veterinarian,
        a.Status
    FROM Pets p
    INNER JOIN Users u ON u.UserId = p.UserId
    LEFT JOIN Vaccinations v ON v.PetId = p.PetId
    LEFT JOIN Appointments a ON a.PetId = p.PetId
    WHERE p.PetId = @PetId
END
GO

CREATE PROCEDURE sp_Vaccination_Delete
@VaccinationId INT
AS
BEGIN
    DELETE FROM Vaccinations
    WHERE VaccinationId = @VaccinationId
END
GO

CREATE PROCEDURE sp_Appointment_Delete
@AppointmentId INT
AS
BEGIN
    DELETE FROM Appointments
    WHERE AppointmentId = @AppointmentId
END
GO

CREATE PROCEDURE sp_User_Register
@FullName NVARCHAR(100),
@Email NVARCHAR(150),
@PasswordHash NVARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN
        RAISERROR('Email already exists', 16, 1)
        RETURN
    END

    INSERT INTO Users (FullName, Email, PasswordHash, Role)
    VALUES (@FullName, @Email, @PasswordHash, 'User')
END
GO

CREATE PROCEDURE sp_User_Login
@Email NVARCHAR(150),
@PasswordHash NVARCHAR(255)
AS
BEGIN
    SELECT TOP 1 *
    FROM Users
    WHERE Email = @Email
      AND PasswordHash = @PasswordHash
END
GO

ALTER PROCEDURE sp_User_Login
@Email NVARCHAR(150)
AS
BEGIN
    SELECT TOP 1 *
    FROM Users
    WHERE Email = @Email
END
GO

alter PROCEDURE sp_User_Register
@FullName NVARCHAR(100),
@Email NVARCHAR(150),
@PasswordHash NVARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN
        RAISERROR('Email already exists', 16, 1)
        RETURN
    END

    INSERT INTO Users (FullName, Email, PasswordHash, Role)
    VALUES (@FullName, @Email, @PasswordHash, 'User')
END
GO

ALTER PROCEDURE sp_User_Login
@Email NVARCHAR(150)
AS
BEGIN
    SELECT TOP 1
        UserId,
        FullName,
        Email,
        PasswordHash,
        Role
    FROM Users
    WHERE Email = @Email
END
GO
