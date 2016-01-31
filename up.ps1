start powershell "npm install; npm install microgarden-ui-sdk" -wo "$PSScriptRoot\src\MicroGarden.Manage\"
start powershell "dnu restore; dnx ef database update" -wo "$PSScriptRoot\src\MicroGarden.Manage\"
