# Convert Laerdal SimDesigner Themes to Simpad Themes

## Disclaimer
This is project is NOT approved, supported, endorsed or in any way related by Laerdal. This is a hobby project. Please report any errors or issues related to this tool to me (preferably here on GitHub).

## Prerequisites
You must have .NET 8 runtime installed.
- Download: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- Installation instructions: https://learn.microsoft.com/en-us/dotnet/core/install/

Download the [latest release of this converter](https://github.com/mindleaving/laerdal-thx-thm-converter/releases/latest) and unzip it.

## Usage

Two options: 

#### Option 1: Drag-and-drop .thx-file (Windows only)

Drag and drop the SimDesigner Themes file (.thx) onto the ```LaerdalSimDesignerThemeToSimPadConverter.exe``` file. The SimPad Themes file (.thm) will be created next to the .thx file.

#### Option 2: Command line

Open a command prompt, navigate to the directory with LaerdalSimDesignerThemeToSimPadConverter.dll and run
```
dotnet ./LaerdalSimDesignerThemeToSimPadConverter.dll <path to .thx-file> [optional: path to .thm-file]
```
Path to .thm-file is optional. If not specified, the .thm-file will be created next to the .thx file.

## Limitations
Because SimPad doesn't support all features available in SimDesigner, only some vital signs, responses and events will be mapped in the SimPad theme. Check and test the theme after conversion to make sure, it suits your simulation setup.
