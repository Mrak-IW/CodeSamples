--1. ���������� ����������� ������������������ ���� ������, ����� ������������ ������� � ����������.
SELECT
	UserId as 'ID',
	UserName as '���',
	DateIn as '���� �����',
	DayIn as '��� �����',
	--Rank as 'RANK',
	--SubDays,
	DENSE_RANK() OVER(PARTITION BY UserID, SubDays ORDER BY DayIn) as '���� ������',
	Times as '��� �� ����'
FROM
	UAContinuousGroups
ORDER BY 3

