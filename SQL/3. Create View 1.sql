--DROP VIEW UAContinuousGroups
CREATE VIEW UAContinuousGroups(
	UserID,
	UserName,
	DateIn,
	DayIn,	--Целочисленный номер дня для удобства вычислений
	Rank,		--Ранг записи. В начале равен номеру дня входа. Увеличивается с каждым увеличением дня входа, но не имеет пропусков в нумерации. Отдельно не нужен, но оставлен для отладки. %DEL%
	Times,	--Номер входа в течении дня. Может быть, пригодится. %DEL%
	SubDays	--До тех пор, пока значение в этом столбце неизменно, можно считать, что посещения идуд подряд. Либо день за днём, либо в один день.
)
AS (
	SELECT
		UserId,
		UserName,
		DateIn,
		DayIn,
		DENSE_RANK() OVER(PARTITION BY UserId ORDER BY DayIn ASC) as 'Rank',
		ROW_NUMBER() OVER(PARTITION BY UserId, DayIn ORDER BY DateIn ASC) as 'Times',
		-DENSE_RANK() OVER(PARTITION BY UserId ORDER BY DayIn ASC) + DayIn as 'SubDays'	--Минус в начале - для красоты результата. Пусть результат будет положительным.
	FROM
		UserActivityToDays
)