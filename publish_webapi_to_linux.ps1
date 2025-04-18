# Publish web-API
cd LaerdalSimDesignerThemeToSimPadConverter.WebAPI
dotnet clean -c Release
dotnet publish -c Release -r linux-x64 --no-self-contained
Compress-Archive -Path bin/Release/net8.0/linux-x64/publish -DestinationPath ../LaerdalSimDesignerThemeToSimPadConverter.API.zip -Force

# Publish frontend
cd ../laerdal-theme-converter-frontend
npm run build
Compress-Archive -Path dist -DestinationPath ../LaerdalSimDesignerThemeToSimPadConverter.Frontend.zip -Force
cd ..
