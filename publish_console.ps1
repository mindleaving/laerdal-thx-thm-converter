# Publish console
cd LaerdalSimDesignerThemeToSimPadConverter
dotnet clean -c Release
dotnet publish -c Release --no-self-contained
Compress-Archive -Path bin/Release/net8.0/publish -DestinationPath ../LaerdalSimDesignerThemeToSimPadConverter.Console.zip -Force
cd..