REM �������� MD5-�� ��� ������� 䠩�� �� ��� ���୨� ��⠫���� ⥪�饩 �����.
@echo off
REM �������� MD5-���� ��� ������� ����� �� ���� �������� ��������� ������� �����.
:: ��� - ���� �����������. OEM 866 - ��������� ��� bat-�����

for /d %%d in (*) do for %%f in (%%d\*) do ^
md5sums.exe -u %%f > %%f.md5 && ^
echo %%f MD5 created

pause