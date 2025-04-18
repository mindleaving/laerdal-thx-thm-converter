# Convert Laerdal SimDesigner Themes to SimPad Themes

**This project is not associated with Laerdal. This is a spare time project. Use at your own risk.**

## Online conversion

I provide an online conversion service. No guarantees made. See terms and conditions on conversion page.

Converts .thx file to .thm by drag-n-drop. 

[<h3>Go to online conversion service</h3>](https://laerdal.janscholtyssek.dk)

## How to use

Project is written in C#/.NET.

Build the main project ```LaerdalSimDesignerThemeToSimPadConverter```. Either drag a file onto ```LaerdalSimDesignerThemeToSimPadConverter.exe``` or use command line:

```powershell
dotnet LaerdalSimDesignerThemeToSimPadConverter.dll <.thx-file> [(optional).thm-file]
```

You can also use the project as a library. Then create and call the converter this way:

```csharp
var thxFileReader = new ThxFileReader();
var thmFileWriter = new ThmFileWriter();
var converter = new ThxToThmConverter(thxFileReader, thmFileWriter);
converter.ConvertAndWrite(inputFilePath, outputFilePath);
```

## License

Released under MIT license
