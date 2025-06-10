

using Newtonsoft.Json;
using System.Text;

class program
{
    private static readonly string apiKey = "api key";

    static async Task Main(string[] args)
    {
        Console.Write("Lüfen metni giriniz : ");
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            Console.WriteLine();
            Console.Write("Duygu analizi Yapılıyor...");
            Console.WriteLine();
            string sentiment = await AnalyzeSentiment(input);

            Console.WriteLine($"Sonuç : {sentiment}");
        }

        static async Task<string> AnalyzeSentiment(string text)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role="system", content="You are an AI that analyzes sentiment. You categorize text as Positive,Negative or Netural." },
                        new { role="user", content= $"Analayze the sentiment of this text : \"{text}\" and return onyl Positive, Negative or Netural" },
                    }
                };

                string json = JsonConvert.SerializeObject(requestBody);
                HttpContent content = new StringContent(json,Encoding.UTF8,"application/json");

                HttpResponseMessage respone = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                string responseJson = await respone.Content.ReadAsStringAsync();
                if (respone.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<dynamic>(responseJson);
                    return result.choices[0].message.content.ToString();
                }
                else
                    Console.WriteLine("Bir hata oluştu" + responseJson);
                return "Hata";
            }
        }
    }

  
}