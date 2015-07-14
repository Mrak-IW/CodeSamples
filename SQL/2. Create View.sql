--DROP VIEW ContinuousGroups
CREATE VIEW ContinuousGroups(
	UserId,
	UserName,
	DateIn,
	Desc_,
	Asc_,
	Sect,
	Sub)
AS (
	SELECT
		u.UserId,
		u.UserName as 'Имя',
		ua.DateIn as 'Дата входа',
		ROW_NUMBER() OVER(ORDER BY ua.DateIn DESC) AS 'По убыванию',
		ROW_NUMBER() OVER(ORDER BY ua.DateIn ASC) AS 'По возрастанию',
		ROW_NUMBER() OVER(PARTITION BY u.UserName ORDER BY ua.DateIn ASC) AS 'По секциям',
		ROW_NUMBER() OVER(ORDER BY ua.DateIn ASC) - ROW_NUMBER() OVER(PARTITION BY u.UserName ORDER BY ua.DateIn ASC) AS 'Разность'
	FROM
		Users as u,
		UserActivity as ua
	WHERE
		u.UserId = ua.UserId
)