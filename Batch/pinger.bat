@echo off
:start
	time /T
	ping ya.ru
	ping 127.0.0.1 -n 300 > nul
	goto start