using iTextSharp.text;
using iTextSharp.text.pdf;

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
ConvertImageToPdf(imagePath, pdfPath, fullPage);

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

static void ConvertImageToPdf(string imagePath, string pdfPath, bool fullPage)
{
    using FileStream fs = new(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
    Document document = new();
    SetDocumentMargins(document, fullPage);

    PdfWriter.GetInstance(document, fs);
    document.Open();

    Image image = Image.GetInstance(imagePath);

    float maxWidth = fullPage ? PageSize.A4.Width : PageSize.A4.Width - document.LeftMargin - document.RightMargin;
    float maxHeight = fullPage ? PageSize.A4.Height : PageSize.A4.Height - document.TopMargin - document.BottomMargin;

    float scale = Math.Min(maxWidth / image.Width, maxHeight / image.Height);
    float newWidth = image.Width * scale;
    float newHeight = image.Height * scale;
    float x = fullPage ? 0f : (maxWidth - newWidth) / 2f;

    image.ScaleToFit(newWidth, newHeight);
    float y = fullPage ? PageSize.A4.Height - newHeight : PageSize.A4.Height - document.TopMargin - image.ScaledHeight;
    image.SetAbsolutePosition(fullPage ? 0f : document.LeftMargin + x, y);

    document.Add(image);
    document.Close();
}

static void SetDocumentMargins(Document document, bool fullPage)
{
    if (fullPage) document.SetMargins(0f, 0f, 0f, 0f);
    else document.SetMargins(36f, 36f, 36f, 36f);
}