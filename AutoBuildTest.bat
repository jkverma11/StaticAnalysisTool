ECHO off
cd StaticAnalyzerTool\StaticAnalyzerTool\bin\Debug
StaticAnalyzerTool.exe
IF %ERRORLEVEL% == 0 (
    ECHO Successfully Launched the Analyzers
) ELSE (
    ECHO Failure while Launching the Analyzers
)
cd ../../../../
powershell.exe -ExecutionPolicy Bypass -File StaticAnalyzerToolReport.ps1
IF %ERRORLEVEL% == 0 (
    ECHO Successfull write to html file
) ELSE (
    ECHO Error while Writing to html file
)

StaticAnalyzerTool.exe
IF %ERRORLEVEL% == 0 (
    ECHO Successfully Launched the Analyzers
) ELSE (
    ECHO Failure while Launching the Analyzers
)
cmd /k