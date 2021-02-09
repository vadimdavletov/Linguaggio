Param ([string]$name)
[System.Console]::OutputEncoding = [System.Text.Encoding]::UTF8

if ([string]::IsNullOrEmpty($name))
{
    $name = Read-Host -Prompt 'Название миграции?'
}

$serviceName = 'Editor'

dotnet tool update --global dotnet-ef

dotnet ef migrations add $name --startup-project src/$serviceName.Api/$serviceName.Api.csproj --project src/$serviceName.Data/$serviceName.Data.csproj --verbose

dotnet ef migrations script --startup-project src/$serviceName.Api/$serviceName.Api.csproj --project src/$serviceName.Data/$serviceName.Data.csproj --idempotent --no-transactions 

pause