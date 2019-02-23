@echo off
rem -set the name of the dll
set dll_name=Syngenta.GENIE.Automation.Tests.dll
set test_dll_path=bin\Debug\

set current_path=%~dp0
echo %current_path%

set reporting_dir=%current_path%Test.Automation\Reporting
cd %reporting_dir%
echo %cd%

For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a-%%b)
set ReportsFolder=%mydate%-%mytime%
set ReportsFolder=%ReportsFolder: =%
echo %ReportsFolder%
if not exist %ReportsFolder% mkdir %ReportsFolder%
set ReportingDir=%reporting_dir%\%ReportsFolder%

echo %ReportingDir%

set test_dll_path=%current_path%%test_dll_path%
echo %test_dll_path%
rem cd %test_dll_path%

rem --moving up one level
echo %cd%
cd ../../..
echo %cd%

set parent_path=%cd%

set console_runner=\packages\NUnit.ConsoleRunner.3.8.0\tools
set nunit_path=%parent_path%%console_runner%
cd %nunit_path%
nunit3-console.exe %test_dll_path%%dll_name% --where "cat == Test_Automation" --labels=All --out=TestResult.txt --work=%ReportingDir%
Pause
