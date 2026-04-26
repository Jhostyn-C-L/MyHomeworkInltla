Create database StudentAttendancedb;
use StudentAttendancedb;

Create table Students (
Id int primary key identity(1,1),
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null);

Create table Attendance (
Id int primary key identity(1,1),
Studentid int not null,
Date DATE not null,
Status Nvarchar(20) not null,
Constraint Fk_StudentAttendace Foreign key (StudentId)
References Students(Id),
Constraint UQ_Student_Date Unique (StudentId, Date)
);

Select * From Students;
Select * From Attendance;