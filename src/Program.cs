if (args.Length == 0) {
    Console.WriteLine("Please provide the path to the image file.");
    return;
}

string imagePath = args[0];

if (!File.Exists(imagePath)) {
    Console.WriteLine("The file does not exist.");
    return;
}

bool fullPage = HasFullPageFlag(args);
string pdfPath = Path.ChangeExtension(imagePath, ".pdf");
ImageToPdfConverter.Convert.ImageToPdf(imagePath, pdfPath, fullPage);

Console.WriteLine($"The file has been converted to PDF and saved at {pdfPath}");


// ****************************************************************************************************
// Helper methods
// ****************************************************************************************************

static bool HasFullPageFlag(string[] args)
{
    for (int i = 1; i < args.Length; i++) {
        if (args[i] == "--full-page" || args[i] == "-fp")
            return true;
    }
    return false;
}