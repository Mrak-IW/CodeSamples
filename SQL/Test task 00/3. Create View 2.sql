--DROP VIEW UserRegistrationToDays
CREATE VIEW UserRegistrationToDays(
	UserId,
	RegistrationDate,
	RegistrationDay)		--������������� ����� ��� ��� �������� ����������. ��������� �� ���� ������ �����������.
AS (
	SELECT
		UserId,
		RegistrationDate,
		DATEDIFF(dd, (SELECT MIN(RegistrationDate) FROM UserRegistration), RegistrationDate) + 1
	FROM
		UserRegistration
)