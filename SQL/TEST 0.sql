--1. Вычисление непрерывных пследовательностей дней подряд, когда пользователь заходил в приложение.
SELECT
	UserId as 'ID',
	UserName as 'Имя',
	DateIn as 'Дата входа',
	DayIn as 'Дни входа',
	--Rank as 'RANK',
	--SubDays,
	DENSE_RANK() OVER(PARTITION BY UserID, SubDays ORDER BY DayIn) as 'Дней подряд',
	Times as 'Раз за день'
FROM
	UAContinuousGroups
ORDER BY 3

