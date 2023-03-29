DROP TABLE IF EXISTS dbo.Employees;
CREATE TABLE dbo.Employees
(
    ID INT IDENTITY PRIMARY KEY,
    EmployeeNumber INT NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Department VARCHAR(100) NOT NULL,
    JobTitle VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    JoinedDate DATE NOT NULL,
    BirthDate DATE NOT NULL,
    MaritalStatus VARCHAR(50) NOT NULL,
    Gender VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(100) NOT NULL,
) 
GO