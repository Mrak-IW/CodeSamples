REM ��� �ਯ� 㤠��� �� 䠩�� *.md5 � ���୨� ��⠫���� ����� ����᪠. 
@echo off
REM ���� ������ ������� ��� ����� *.md5 � �������� ��������� ����� �������.
:: ��� - ���� �����������

for /d %%d in (*) do ^
del %%d\*.md5 &&^
echo %%d\*.MD5 deleted

:: ������, ����� �������� "del /s *.md5", �� ��� �� ��� ������������ :)

pause