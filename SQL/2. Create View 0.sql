--DROP VIEW UserActivityToDays
CREATE VIEW UserActivityToDays(
	UserId,
	UserName,
	DateIn,
	DayIn)		--������������� ����� ��� ��� �������� ����������. ��������� �� ���� ������ �����������.
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