# ConsoleAppCommandLine
	Allows user to change settings in the appsettings.json via command line
	This version is targeted specifically for Bullhorn RestAPI settings

## Notes
	The Build is specifically targeted towards win64 exe	
	Handles updating the appsettings.json file using commandline params without including any 3rd party libraries
    - Opted to go this way over using something like McMaster CommandLineUtils 
	Supports base64 encoding of the settings value
	Single file publishing with access to appsettings.json back in original folder:
		- this is an issue as singlefile extracts to a temp folder for win64 exe,
      so appsettings.json typically isn't accessible from there
  To get appsettings.json moved during Publish step, update the .csproj with the following:
    <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
    <ExcludeFromSingleFile>true</ExcludeFromSingleFile>

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
  McMaster CommandLineUtils ? https://natemcmaster.github.io/CommandLineUtils/docs/intro.html
  