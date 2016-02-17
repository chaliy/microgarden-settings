start powershell "dnx-watch web" -wo "$PSScriptRoot\src\MicroGarden.Settings\"
start powershell "npm run dev" -wo "$PSScriptRoot\src\MicroGarden.Settings.UI\"
start "http://localhost:53469/"
