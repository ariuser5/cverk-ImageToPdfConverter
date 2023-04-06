# ImageToPdfConverter
Converts image files to pdf files.


# Usage
Open a command prompt or terminal and navigate to the directory where the ImageToPdfConverter.exe file is located. Then run the following command:

    ImageToPdfConverter.exe <path-to-image> [-fp|--full-page]

Replace <path-to-image> with the path to the image file you want to convert. The -fp or --full-page flag is optional. If it is specified, the image will be scaled and positioned to fit the full page, ignoring the document margins.

After the conversion is complete, the PDF file will be saved in the same directory as the original image file, with the same name but with the .pdf extension.

# Examples
To convert an image file called myimage.jpg to PDF, run:

    ImageToPdfConverter.exe myimage.jpg

To convert an image file called myimage.png to PDF, and scale and position the image to fit the full page, run:

    ImageToPdfConverter.exe myimage.png --full-page
