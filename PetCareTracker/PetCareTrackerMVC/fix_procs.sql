ALTER PROCEDURE sp_Report_UpcomingAppointments
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

ALTER PROCEDURE sp_Report_UpcomingVaccinations
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
