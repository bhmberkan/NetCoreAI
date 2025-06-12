


using Newtonsoft.Json;
using System.Text;
using UglyToad.PdfPig;

class program
{
    private static readonly string apiKey = "api Key";

    static async Task Main(string[] args)
    {
        Console.Write("PDF Dosya Yolunu Giriniz : ");
        string pdfPath = Console.ReadLine();
        Console.WriteLine("Pdf Analizi AI tarafından Yapılıyor.");
        Console.WriteLine();
        string pdfText = ExtractTextFromPdf(pdfPath);
        await AnalyzeWithAI(pdfText, "Pdf içeriği");

        static string ExtractTextFromPdf(string filePath)
        {
            StringBuilder text = new StringBuilder();
            using (PdfDocument pdf = PdfDocument.Open(filePath))
            {
                foreach (var page in pdf.GetPages())
                {
                    text.Append(page.Text);
                }
            }
            return text.ToString();
        }

        static async Task AnalyzeWithAI(string text, string sourceType)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                   {
                        new { role="system", content="Sen bir yapay zeka asistanısın. Kullanıcının gönderdiği metni analiz eder ve Türkçe olarak özetlersin. Yanıtları sadece Türkçe ver!" },
                        new { role="user", content= $"Analayze and summerize the fallowing {sourceType} \n \n {text}" }
                    }
                };

                string json = JsonConvert.SerializeObject(requestBody);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage respone = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                string responseJson = await respone.Content.ReadAsStringAsync();


                if (respone.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<dynamic>(responseJson);
                    Console.WriteLine($"\n AI Analizi ({sourceType}) : \n {result.choices[0].message.content}");
                }
                else
                    Console.WriteLine("Hata : " + responseJson);
            }

        }
    }
}