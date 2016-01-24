# Microgarden Settings

Microservice to handle settings in your system

# Publish

## Ubuntu

    cd /src/MicroGarden.Settings/
    sudo env "PATH=$PATH" dnu publish --no-source
    docker build -t mgsapp .

## Windows

    cd /src/MicroGarden.Settings/
    docker-machine env default | iex
    docker build -t mgsapp .

    docker run -t -d -p 8080:53469 mgsapp
