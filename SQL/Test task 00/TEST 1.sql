--2. Churn7, Retention 7. �������� ������� ���� �� �����������.
SELECT
	ur.UserId,
	u.UserName,
	ur.RegistrationDate,
	ur.RegistrationDay
FROM
	UserRegistrationToDays as ur,
	Users as u
WHERE
	u.UserId = ur.UserId

SELECT 
	SC.DayIn as '���� �',
	SC.TodayIn as '������ �� ����',
	SC.TodayIn - SC.NextWeekIn as '�� ��� �� ����� �� ��������� ������',
	STR(100 * (SC.TodayIn - SC.NextWeekIn) / SC.TodayIn) + ' %' as 'Churn 7',
	SC.RegisterWeekBefore as '������������������ ������ �����',
	SC.TodayInFromRWB as '�� ��� ����� �� ����',
	STR(
	CASE SC.RegisterWeekBefore
		WHEN 0 THEN null
		ELSE 100 * SC.TodayInFromRWB / SC.RegisterWeekBefore
	END
	) + ' %' as 'Retention 7'
FROM
	StatisticCalculation as SC