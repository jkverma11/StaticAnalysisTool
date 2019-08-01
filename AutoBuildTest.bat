
cd StaticAnalyzerTool\StaticAnalyzerTool\bin\Debug
StaticAnalyzerTool.exe
cd ../../../../
powershell.exe -ExecutionPolicy Bypass -File C:\Users\320050491\StaticAnalysisTool\StaticAnalyzerToolReport.ps1
IF %ERRORLEVEL% == 0 (
    ECHO Success
) ELSE (
    ECHO Failure
)
cmd /k