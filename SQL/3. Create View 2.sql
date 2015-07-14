--DROP VIEW UserRegistrationToDays
CREATE VIEW UserRegistrationToDays(
	UserId,
	RegistrationDate,
	RegistrationDay)		--Целочисленный номер дня для удобства вычислений. Считатеся от даты первой регистрации.
AS (
	SELECT
		UserId,
		RegistrationDate,
		DATEDIFF(dd, (SELECT MIN(RegistrationDate) FROM UserRegistration), RegistrationDate) + 1
	FROM
		UserRegistration
)