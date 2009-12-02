CREATE LOGIN [admin] WITH PASSWORD=N'hpéÝCO-!é¿º²+¬ºcÆ÷^_QaGp', DEFAULT_DATABASE=[eTronDB], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [admin] DISABLE

USE [eTronDB]
GO
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]\

ALTER AUTHORIZATION ON SCHEMA::[db_accessadmin] TO [admin]
ALTER AUTHORIZATION ON SCHEMA::[db_securityadmin] TO [admin]
ALTER AUTHORIZATION ON SCHEMA::[db_owner] TO [admin]
ALTER AUTHORIZATION ON SCHEMA::[db_ddladmin] TO [admin]
ALTER AUTHORIZATION ON SCHEMA::[db_datareader] TO [admin]
ALTER AUTHORIZATION ON SCHEMA::[db_datawriter] TO [admin]
EXEC sp_addrolemember N'db_ddladmin', N'admin'
EXEC sp_addrolemember N'db_securityadmin', N'admin'
EXEC sp_addrolemember N'db_accessadmin', N'admin'
EXEC sp_addrolemember N'db_owner', N'admin'
EXEC sp_addrolemember N'db_datareader', N'admin'
EXEC sp_addrolemember N'db_datawriter', N'admin'
GO
