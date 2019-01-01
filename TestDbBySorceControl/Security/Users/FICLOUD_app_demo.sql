IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'FICLOUD\app_demo')
CREATE LOGIN [FICLOUD\app_demo] FROM WINDOWS
GO
CREATE USER [FICLOUD\app_demo] FOR LOGIN [FICLOUD\app_demo]
GO
