DROP TABLE UserActivity
DROP TABLE UserRegistration
DROP TABLE Users

CREATE TABLE Users(
	UserId	int Primary Key /*IDENTITY(0,1)*/,
	UserName	nvarchar(20) not null,
	)

CREATE TABLE UserActivity(
	UserId	int,
	DateIn	smalldatetime not null,	--Дата входа в приложение
	FOREIGN KEY	(UserId)	REFERENCES	Users(UserId)
		ON UPDATE Cascade
		ON DELETE Cascade,
	)

CREATE TABLE UserRegistration(
	UserId		int,
	RegistrationDate	smalldatetime not null,
	FOREIGN KEY		(UserId)	REFERENCES	Users(UserId)
		ON UPDATE Cascade
		ON DELETE Cascade,
	)

