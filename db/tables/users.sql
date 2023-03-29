
DROP TABLE IF EXISTS dbo.Users;
CREATE TABLE dbo.Users
(
    ID INT IDENTITY PRIMARY KEY,
    [Role] INT NULL,
    Username VARCHAR(100) NULL,
    Email VARCHAR(255) NOT NULL,
    JobTitle VARCHAR(100) NULL,
    PasswordHash VARCHAR(500) NULL,
    Token VARCHAR(500) NULL,
) 
GO

INSERT INTO dbo.Users
    ([Role], Username, email, JobTitle, PasswordHash)
VALUES
    (0, 'Samuel', 'sammy@gmail.com', 'HR', '$2a$11$jRXMaVLv9WTVrW/FWsA1M.cakCs0fybaKu.d5c.r04ysn78/FPVZy')

SELECT *
FROM dbo.Users;