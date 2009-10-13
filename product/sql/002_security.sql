use [gorilla]
GO
if not exists (select * from dbo.sysusers where name = N'arc\mkhan' and uid < 16382)
	EXEC sp_grantdbaccess N'arc\mkhan', N'arc\mkhan'
GO

if not exists (select * from dbo.sysusers where name = N'WebUser' and uid > 16399)
	EXEC sp_addrole N'WebUser'
GO

exec sp_addrolemember N'WebUser', N'arc\mkhan'
GO
