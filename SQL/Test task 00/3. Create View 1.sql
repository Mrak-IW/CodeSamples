--DROP VIEW UAContinuousGroups
CREATE VIEW UAContinuousGroups(
	UserID,
	UserName,
	DateIn,
	DayIn,	--������������� ����� ��� ��� �������� ����������
	Rank,		--���� ������. � ������ ����� ������ ��� �����. ������������� � ������ ����������� ��� �����, �� �� ����� ��������� � ���������. �������� �� �����, �� �������� ��� �������. %DEL%
	Times,	--����� ����� � ������� ���. ����� ����, ����������. %DEL%
	SubDays	--�� ��� ���, ���� �������� � ���� ������� ���������, ����� �������, ��� ��������� ���� ������. ���� ���� �� ���, ���� � ���� ����.
)
AS (
	SELECT
		UserId,
		UserName,
		DateIn,
		DayIn,
		DENSE_RANK() OVER(PARTITION BY UserId ORDER BY DayIn ASC) as 'Rank',
		ROW_NUMBER() OVER(PARTITION BY UserId, DayIn ORDER BY DateIn ASC) as 'Times',
		-DENSE_RANK() OVER(PARTITION BY UserId ORDER BY DayIn ASC) + DayIn as 'SubDays'	--����� � ������ - ��� ������� ����������. ����� ��������� ����� �������������.
	FROM
		UserActivityToDays
)