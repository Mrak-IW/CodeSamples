--2. Churn7, Retention 7. Значение текущей даты не учитывается.
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
	SC.DayIn as 'День №',
	SC.TodayIn as 'Юзеров за день',
	SC.TodayIn - SC.NextWeekIn as 'Из них НЕ зашло на следующей неделе',
	STR(100 * (SC.TodayIn - SC.NextWeekIn) / SC.TodayIn) + ' %' as 'Churn 7',
	SC.RegisterWeekBefore as 'Зарегистрировалось неделю назад',
	SC.TodayInFromRWB as 'Из них зашло за день',
	STR(
	CASE SC.RegisterWeekBefore
		WHEN 0 THEN null
		ELSE 100 * SC.TodayInFromRWB / SC.RegisterWeekBefore
	END
	) + ' %' as 'Retention 7'
FROM
	StatisticCalculation as SC