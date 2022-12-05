using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace UploadExcel
{
    public class Program
    {
        public static void upload(string filePath)
        {
            //var filePath = "path/to/your/excel/file.xlsx";

            // Create a new HttpClient instance
            HttpClient client = new HttpClient();

            // Set the base address for the client (laravel controller link)
            client.BaseAddress = new Uri("laravel-project-here");

            // Set the request content type to multipart/form-data
            var content = new MultipartFormDataContent();

            // Read the Excel file as a byte array
            var fileBytes = File.ReadAllBytes(filePath);

            // Add the Excel file as a byte array to the request
            content.Add(new ByteArrayContent(fileBytes), "file", "file.xlsx");

            // Send the request
            var response = client.PostAsync("/upload-excel-file", content).Result;

            // Check the response status code
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Excel file uploaded successfully!");
            }
            else
            {
                Console.WriteLine("Failed to upload Excel file");
            }
        }
    }
}
