
DROP TABLE IF EXISTS dbo.Roles;
CREATE TABLE dbo.Roles
(
    ID INT IDENTITY PRIMARY KEY,
    [Role] VARCHAR(25) NOT NULL,
) 
GO

INSERT INTO dbo.Roles
    ([Role])
VALUES
    ('Secretary')
GO
