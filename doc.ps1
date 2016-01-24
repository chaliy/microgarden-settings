dnu publish .\src\MicroGarden.Settings\ --no-source --runtime dnx-coreclr-linux-x64.1.0.0-rc1-update1 -o .\deploy

docker build -t mgsapp .\deploy
# docker run -t -d -p 8080:53469 mgsapp
