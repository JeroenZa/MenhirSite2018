param (
    [string]$clientsPath
)

(Get-Content $clientsPath).replace('moment(', 'moment.utc(').replace('.toString()','') | Set-Content -Path $clientsPath
(Get-Content $clientsPath).replace('GenericController`1Client', 'GenericControllerClient') | Set-Content -Path $clientsPath
(Get-Content $clientsPath).replace('GenericController`1Client', 'GenericControllerClient') | Set-Content -Path $clientsPath