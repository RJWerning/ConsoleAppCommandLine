# ConsoleAppCommandLine
	Allows user to change settings in the appsettings.json via command line
	This version is targeted specifically for Bullhorn RestAPI settings

## Usage
	commandline execute: 
		

## Build

Release - change Solution Configuration to Release, then do Build > Publish
	Publish folder = ./bin/publish
	Outputs a single exe via PublishProfile.PublishSingleFile = True	
	Copies the appsettings.json file if it doesn't already exist
 