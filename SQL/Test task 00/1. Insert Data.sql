TRUNCATE TABLE UserActivity
TRUNCATE TABLE UserRegistration

--Наполняем таблицу пользователей
INSERT INTO Users
	(UserId, UserName)
VALUES
	(0, 'Майрон')

INSERT INTO Users
	(UserId, UserName)
VALUES
	(1, 'Олорин')

INSERT INTO Users
	(UserId, UserName)
VALUES
	(2, 'Курунир')

INSERT INTO Users
	(UserId, UserName)
VALUES
	(3, 'Айвендил')

--Наполняем таблицу регистрации
INSERT INTO UserRegistration
	(UserId, RegistrationDate)
VALUES
	(0, '2014-09-25 12:35:29')

INSERT INTO UserRegistration
	(UserId, RegistrationDate)
VALUES
	(1, '2014-09-25 13:35:29')

INSERT INTO UserRegistration
	(UserId, RegistrationDate)
VALUES
	(2, '2014-09-26 14:35:29')

INSERT INTO UserRegistration
	(UserId, RegistrationDate)
VALUES
	(3, '2014-09-27 15:35:29')

--Наполняем таблицу входов в приложение
INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-01 12:35:29')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(2,'2014-10-01 17:50:03')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-02 10:10:19')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(3,'2014-10-02 12:01:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-03 18:55:41')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-05 19:37:18')

--Теперь допустим, что пользователь заходил в прилодение несколько раз за день:
INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-05 20:10:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-05 21:20:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-06 03:25:00')	--Ну, бывает... Не спится.

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(3,'2014-10-02 12:03:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(3,'2014-10-03 12:00:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(2,'2014-10-07 12:01:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(2,'2014-10-08 12:01:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-09 20:10:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-10 21:20:00')

INSERT INTO UserActivity
	(UserId, DateIn)
VALUES
	(1,'2014-10-11 03:25:00')