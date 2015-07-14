--DROP VIEW UserActivityToDays
CREATE VIEW UserActivityToDays(
	UserId,
	UserName,
	DateIn,
	DayIn)		--Целочисленный номер дня для удобства вычислений. Считатеся от даты первой регистрации.
AS (
	SELECT
		u.UserId,
		u.UserName,
		ua.DateIn,
		DATEDIFF(dd, (SELECT MIN(RegistrationDate) FROM UserRegistration), ua.DateIn) + 1
	FROM
		Users as u,
		UserActivity as ua
	WHERE
		u.UserId = ua.UserId
)