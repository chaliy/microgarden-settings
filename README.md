# Microgarden Settings

Microservice to handle settings in your system

# Publish

## Ubuntu

    cd /src/MicroGarden.Settings/
    sudo env "PATH=$PATH" dnu publish --no-source
    docker build -t mgsapp .
