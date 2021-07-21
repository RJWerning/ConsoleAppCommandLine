# ConsoleAppCommandLine
	Allows user to change settings in the appsettings.json via command line
	This version is targeted specifically for Bullhorn RestAPI settings

## Notes
	The Build is specifically targeted towards win64 exe	
	Handles updating the appsettings.json file using commandline params without including any 3p libraries
	Supports encryption of the settings value
	Single file publishing with access to appsettings.json back in original folder:
		- this is an issue as singlefile extracts to a temp folder for win64, so appsettings.json typically isn't accessible from there

## Usage
	commandline execute:
		> ConsoleAppCommandLine --help
		> ConsoleAppCommandLine --p thisisapassword --s thisisasecret

## Build
	Debug:
		Add params to test to the project Properties > Debug > Application Arguements
		ie. --p  newPassword1 --s newSecret123

	Release:
		- change Solution Configuration to Release, then do Build > Publish
		- Publish folder = ./bin/publish
		- Outputs a single exe via PublishProfile.PublishSingleFile = True	
		- Copies the appsettings.json file if it doesn't already exist
 
## References
	ExtensionMethods.cs > https://jasonwatmore.com/post/2020/09/12/c-encode-and-decode-base64-strings
	AppSettingsUpdater.cs > https://stackoverflow.com/a/67917167
