# DiscordBotTemplate

> Discord bot template code, using the [DSharpPlus](https://github.com/DSharpPlus/DSharpPlus) library.

Aimed to be quick to fork and add your commands with all the overhead done for you.

## Features

* Multiple environments for development and production
* Logging with Serilog + Seq
* Clean startup
* Automatic discovery of commands (thanks to DSharpPlus)
* Automatic discovery of Microservice classes (add to DI + initialize - custom code)
* DI setup with a few singletons for injecting into commands
* Reflection-based `help` command, meaning you never have to change the command when you add new ones (thanks to DSharpPlus)
* Docker Compose implementation, perfect for running in production.

## Setup 

To create the config files, setup the following:
1. Create a `config` folder
3. Create a `config.json` file, and fill it with valid JSON matching the data inside the [Config model file](https://github.com/TheRealHona/DSharpPlusBotTemplate/blob/main/TemplateDiscordBot/Models/Configuration.cs).

The environment folders must be placed in the root directory for Docker in production, otherwise in the build output folder for debugging

### Running in Production

Simply run `docker-compose up --build -d` on Linux (tested on Debian), and it will build + start the Docker container (automatic restarts on crash) in detached mode. 