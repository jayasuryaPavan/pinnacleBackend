using System.Drawing;
using Tesseract;
using static System.Net.Mime.MediaTypeNames;

namespace Pinnacle.PIS.Server.Services
{
    public class PdfFileHandler : IPdfFileHandler
    {
        public PdfFileHandler()
        {
                
        }
        public async Task<string> pdfText(string path)
        {
            //string text = string.Empty;
            //Document pdfDocument = new Document(path);
            //int imageCounter = 1;
            //foreach (var page in pdfDocument.Pages)
            //{
            //    // Loop through all images
            //    foreach (XImage image in page.Resources.Images)
            //    {
            //        // Create file stream for image
            //        FileStream outputImage = new FileStream(String.Format("Page{0}_Image{1}.Jpeg", page.Number, imageCounter), FileMode.Create);
            //        text = text + ExtractTextFromImage(Directory.GetCurrentDirectory()+ "//IMG_1097.JPG");
            //        // Save output image
            //        image.Save(outputImage, System.Drawing.Imaging.ImageFormat.Jpeg);

                   
            //        // Close stream
            //        outputImage.Close();

            //        imageCounter++;
            //    }

            //    // Reset counter
            //    imageCounter = 1;
            //}
            

            return string.Empty;
        }

        private static string ExtractTextFromImage(string filePath)
        {
            try
            {
                string extractedText = string.Empty;
                string tessdataPath = Directory.GetCurrentDirectory()+ "//TrainedData";
                using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                {
                    // Load the image
                    using (var img = Pix.LoadFromFile(filePath))
                    {
                        // Perform OCR
                        using (var page = engine.Process(img))
                        {
                            // Output the recognized text
                            extractedText = page.GetText();
                            Console.WriteLine("Recognized Text:");
                            Console.WriteLine(extractedText);
                            Console.WriteLine("Confidence: " + page.GetMeanConfidence());
                        }
                    }
                }
                return string.Empty;
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
