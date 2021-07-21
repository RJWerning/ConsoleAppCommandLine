# ConsoleAppCommandLine
	Allows user to change settings in the appsettings.json via command line
	This version is targeted specifically for Bullhorn RestAPI settings

Handles updating the appsettings.json file using commandline params without including any 3p libraries

Code for AppSettingsUpdater.cs comes from: https://stackoverflow.com/a/67917167


## Usage
	commandline execute: 
		

## Build

Release - change Solution Configuration to Release, then do Build > Publish
	Publish folder = ./bin/publish
	Outputs a single exe via PublishProfile.PublishSingleFile = True	
	Copies the appsettings.json file if it doesn't already exist
 