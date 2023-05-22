using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string BASE_URL = "http://localhost:52028/api";
                var httpClient = new HttpClient();
                var content = new MultipartFormDataContent();
                httpClient.BaseAddress = new Uri(BASE_URL);

                //Add File
                var fileContent1 = new ByteArrayContent(File.ReadAllBytes(@"C:\Users\v-abhprasad\Downloads\incident (47).xlsx"));
                fileContent1.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue
                    ("attachment")
                {
                    FileName = "incident (47).xlsx"
                };

                //Add another File
                var fileContent2 = new ByteArrayContent(File.ReadAllBytes(@"C:\Users\v-abhprasad\Downloads\incident (47).xlsx"));
                fileContent1.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue
                    ("attachment")
                {
                    FileName = "incident (47).xlsx"
                };

                content.Add(fileContent1);
                content.Add(fileContent2);
                var result = httpClient.PostAsync("file/upload", content).Result;
                Console.WriteLine("Status: " + result.StatusCode);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.ReadLine();
        }
    }
}
