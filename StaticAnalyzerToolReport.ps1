#############################################################################################################################
#
# +===========================================================+
# | Copyright (C) 2019 Philips Medical Systems Nederland B.V. |
# +===========================================================+
#
# File               : StaticAnalyzerToolReport.ps1
#
# Description        : Write the Results of different static analyzers to a html file
#
#
#############################################################################################################################


#Gloal Variables
$ReportName        = "IntegratedAnalysisReport.html"
$ststicAnalyzer    = ''
$errorMessage      = ''
$errorType         = ''
$certainity        = ''
$error_count       = ''
$file_path         = ''
$file_name         = ''
$line_number       = ''

$destination = Get-Location
#$destination = $destination.ToString()
#$destination       = "C:\Users\320050491\StaticAnalysisTool"



New-Item $destination\$ReportName -Force -ItemType File
$file = "$destination\FinalOutput.txt"
$content = Get-Content -Path $file



##------------------------------------------------------------------------------
## Write_to_html_file
##
## arg1: ststicAnalyzer
## arg2: errorMessage
## arg3: errorType
## arg4: certainity
## arg5: error_count
##
## Return : Write the combined report of all the static analyzers to a html file
##------------------------------------------------------------------------------
function Write_to_html_file
{
    param(
      [parameter(mandatory=$true)][string]$ststicAnalyzer,
      [parameter(mandatory=$true)][string]$errorMessage,
      [string]$errorType,
      [string]$certainity,
      [string]$error_count,
      [string]$file_path,
      [string]$file_name,
      [string]$line_number
    )

    Add-Content -Path $destination\IntegratedAnalysisReport.html @"
<tr>
<td>$ststicAnalyzer</td>
<td>$errorMessage</th>
<td>$errorType</th> 
<td>$certainity</th>
<td>$error_count</th>
<td>$file_path</th> 
<td>$file_name</th>
<td>$line_number</th>

</tr>
"@    
}

##############################################################################################

Add-Content -Path $destination\IntegratedAnalysisReport.html @"
<html>
<head>
    <title>INTEGRATED OUTPUT OF ALL STATIC TOOL ANALYZERS </title>
    
</head>
<style>
table, th, td {
  border: 1px solid black;
  align: centre;
}
</style>
<body>
 <table style="width:70%">
   <tr>
    <th>Static Analyzer Tool</th>
    <th>Error Message</th> 
    <th>Error Type</th>
    <th>Error Certainity</th>
    <th>Error Count</th>
    <th>File Path</th>
    <th>File Name</th>
    <th>Line Number</th> 
   </tr>
"@

foreach ($line in $content)
{

    if($line -match "Error_Message\s*=\s*(.*)\s*Error_Type\s*=\s*(.*)\s*Certainity_Level\s*=\s*(.*)\s*Path\s*=\s*(.*)\s*File_Name\s*=\s*(.*)\s*Line\s*=\s*(.*)\s*")
    {
        $ststicAnalyzer = "FxCop"
        $errorMessage = $Matches[1]
        $errorType = $Matches[2]
        $certainity = $Matches[3]
        $file_path = $Matches[4]
        $file_name = $Matches[5]
        $line_number = $Matches[6]
        $error_count = ''
        Write_to_html_file $ststicAnalyzer $errorMessage $errorType $certainity $error_count $file_path $file_name $line_number
        
    }

    elseif($line -match "ErrorMessage_parameter\s*=\s*(.*)\s*Error_Count\s*=\s*(.*)\s*")
    {
        $ststicAnalyzer = "NDepend"
        $errorMessage = $Matches[1]
        $error_count = $Matches[2]
        #$errorType = ''
        #$certainity = ''
        Write_to_html_file $ststicAnalyzer $errorMessage $error_count
        
   } 
    
}

Add-Content -Path $destination\IntegratedAnalysisReport.html @"
 </table>
</body>
</html> 
"@

exit $LASTEXITCODE


#***********************************************************************************************************************
# MODIFICATION HISTORY
#***********************************************************************************************************************
# 01-08-2019  Jitendra Kumar
#              Initial Version
#***********************************************************************************************************************
