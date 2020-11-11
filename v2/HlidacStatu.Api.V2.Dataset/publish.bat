set /p key=<nugetapikey.txt



nuget push .\nupkgs\HlidacStatu.Api.V2.Dataset.%1.nupkg %key% -Source https://api.nuget.org/v3/index.json
