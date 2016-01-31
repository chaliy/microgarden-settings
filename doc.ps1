#--runtime dnx-coreclr-linux-x64.1.0.0-rc1-update1

dnu publish "$PSScriptRoot\src\MicroGarden.Settings\" --no-source -o "$PSScriptRoot\deploy"

docker build -t mgsapp "$PSScriptRoot\deploy"
# docker run -t -d -p 8080:53469 mgsapp
