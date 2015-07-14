--DROP VIEW StatisticCalculation
CREATE VIEW StatisticCalculation(
	DayIn,
	TodayIn,
	NextWeekIn,
	RegisterWeekBefore,
	TodayInFromRWB)
AS(
	SELECT 
		CG.DayIn as '���� �����',
		COUNT(DISTINCT CG.UserId) as '������ �� ����',
		
		(	SELECT COUNT(DISTINCT CG2.UserId)
			FROM UAContinuousGroups as CG2
			WHERE	
				CG2.DayIn <= CG.DayIn + 7 AND
				CG2.DayIn > CG.DayIn AND
				CG2.UserId IN (SELECT DISTINCT UserId FROM UAContinuousGroups WHERE DayIn = CG.DayIn)
		)as '�� ��� �������� � ������� ��������� ������',
		(	SELECT COUNT(DISTINCT ur2.UserId)
			FROM UserRegistrationToDays as ur2
			WHERE 
				ur2.UserId IN 
				(	SELECT DISTINCT UserId
					FROM UserRegistrationToDays
					WHERE CG.DayIn - 6 = RegistrationDay
				)
		) as '���������������� 7 ���� �����',
		(	SELECT COUNT(DISTINCT ur2.UserId)
			FROM UserRegistrationToDays as ur2
			WHERE 
				ur2.UserId IN 
				(	SELECT DISTINCT UserId
					FROM UserRegistrationToDays
					WHERE CG.DayIn - 6 = RegistrationDay
				) AND
				ur2.UserId IN 
				(	SELECT DISTINCT UserId
					FROM UserActivityToDays
					WHERE CG.DayIn = DayIn
				)
		) as '�� ��� ����� �������'	
	FROM
		UserActivityToDays as CG,
		UserRegistrationToDays as ur
	WHERE
		ur.UserId = CG.UserId
	GROUP BY CG.DayIn
)