

using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

class program
{
    private static readonly string apiKey = "api Key";

    static async Task Main(string[] args)
    {
        Console.Write("Lütfen Analiz yapmak istediğiniz web sayfa URL'ini giriniz : ");
        string inputUrl = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Web sayfası içeriği");
        string webContent = ExtraxctTextFromWeb(inputUrl);
        await AnalyzeWithAI(webContent, "Web sayfası içeriği"); 

        static string ExtraxctTextFromWeb(string Url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(Url);

            var bodyText = doc.DocumentNode.SelectSingleNode("//body")?.InnerText; // sayfadaki body kısmındaki düz metinleri çekiyoruz.
            return bodyText ?? "Sayfa içeriği okunamadı.";
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