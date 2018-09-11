param (
    [string]$clientsPath
)

(Get-Content $clientsPath).replace('moment(', 'moment.utc(').replace('.toString()','') | Set-Content -Path $clientsPath