set /p key=<nugetapikey.txt



c:\Projects\HlidacStatu.GitHub\Hlidac-Statu\.nuget\nuget.exe  push .\nupkgs\HlidacStatu.Api.V2.Dataset.%1.nupkg %key% -Source https://api.nuget.org/v3/index.json
