USE HospitalAppointmentDB1;
GO

INSERT INTO Doctors (DoctorName, Specialization, Email, PhoneNumber, City)
VALUES
('Dr. Samuel Carter', 'Cardiology', 'samuel.carter@hospital.com', '555-0001', 'Seattle'),
('Dr. Alicia Reyes', 'Dermatology', 'alicia.reyes@hospital.com', '555-0002', 'Portland'),
('Dr. Brian Hughes', 'Neurology', 'brian.hughes@hospital.com', '555-0003', 'Denver');

INSERT INTO Patients (PatientName, Email, PhoneNumber, City, Age, Gender)
VALUES
('Maria Johnson', 'maria.johnson@example.com', '555-1001', 'Seattle', 42, 'Female'),
('Daniel Kim', 'daniel.kim@example.com', '555-1002', 'Portland', 30, 'Male'),
('Rebecca Lee', 'rebecca.lee@example.com', '555-1003', 'Denver', 27, 'Female');

INSERT INTO Appointments (DoctorId, PatientId, AppointmentDate, AppointmentTime, AppointmentStatus, Symptoms)
VALUES
(1, 1, '2026-07-10', '09:00', 'Booked', 'Chest pain and shortness of breath'),
(2, 2, '2026-07-11', '10:30', 'Booked', 'Itchy rash on arms'),
(3, 3, '2026-07-12', '14:00', 'Booked', 'Frequent headaches and dizziness');

INSERT INTO Roles (RoleName)
VALUES
('Admin'),
('Doctor'),
('Receptionist'),
('Patient');

INSERT INTO Users (FullName, UserName, PasswordHash, Email)
VALUES
('System Administrator', 'admin', '$2a$12$3gF0N/0bNCO8Z/NSPZj/4u2GQvIoK5QTZBeE62m2wH31P71c3fW2O', 'admin@hospital.com'),
('Doctor User', 'doctor1', '$2a$12$3gF0N/0bNCO8Z/NSPZj/4u2GQvIoK5QTZBeE62m2wH31P71c3fW2O', 'doctor1@hospital.com'),
('Receptionist User', 'reception1', '$2a$12$3gF0N/0bNCO8Z/NSPZj/4u2GQvIoK5QTZBeE62m2wH31P71c3fW2O', 'reception1@hospital.com'),
('Patient User', 'patient1', '$2a$12$3gF0N/0bNCO8Z/NSPZj/4u2GQvIoK5QTZBeE62m2wH31P71c3fW2O', 'patient1@hospital.com');

INSERT INTO UserRoles (UserId, RoleId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
