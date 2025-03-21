using LaerdalSimDesignerThemeToSimPadConverter;

if (args.Length < 1)
{
    Console.WriteLine($"Usage: {nameof(LaerdalSimDesignerThemeToSimPadConverter)}.exe <THX file path> [THM file path]");
    return;
}

var inputFilePath = args[0];
if (Path.GetExtension(inputFilePath).ToLower() != ".thx")
{
    Console.WriteLine("Input file must be a .thx file");
    return;
}

var outputFilePath = args.Length >= 2
    ? args[1]
    : Path.Combine(Path.GetDirectoryName(inputFilePath) ?? ".", Path.GetFileNameWithoutExtension(inputFilePath) + ".thm");
if (Path.GetExtension(outputFilePath).ToLower() != ".thm")
{
    Console.WriteLine("Output file must be a .thm file");
    return;
}

if (outputFilePath == inputFilePath)
{
    Console.WriteLine("Input and output file must be different");
    return;
}

var thxFileReader = new ThxFileReader();
var thmFileWriter = new ThmFileWriter();
var converter = new ThxToThmConverter(thxFileReader, thmFileWriter);
converter.Convert(inputFilePath, outputFilePath);