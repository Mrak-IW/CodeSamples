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
		u.UserName as '���',
		ua.DateIn as '���� �����',
		ROW_NUMBER() OVER(ORDER BY ua.DateIn DESC) AS '�� ��������',
		ROW_NUMBER() OVER(ORDER BY ua.DateIn ASC) AS '�� �����������',
		ROW_NUMBER() OVER(PARTITION BY u.UserName ORDER BY ua.DateIn ASC) AS '�� �������',
		ROW_NUMBER() OVER(ORDER BY ua.DateIn ASC) - ROW_NUMBER() OVER(PARTITION BY u.UserName ORDER BY ua.DateIn ASC) AS '��������'
	FROM
		Users as u,
		UserActivity as ua
	WHERE
		u.UserId = ua.UserId
)