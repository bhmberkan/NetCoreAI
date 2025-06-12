


using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

class program
{
    private static readonly string apiKey = "";
    private static readonly string rssFeedUrl = "https://www.sozcu.com.tr/rss/tum-haberler-xml";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Haberler Sistemden Alınıyor");
        List<string> articles = await FetchLatesNews(10);


        foreach (string article in articles)
        {
            Console.WriteLine("Haber özeti oluşturuluyor...");
            string summary = await SummarizeArticle(article);
            Console.WriteLine("--- AI tarafından özetlenen haber--- \n");
            Console.WriteLine(summary);
            Console.WriteLine("-----------------------------------------------\n");
        }


        static async Task<List<string>> FetchLatesNews(int count)
        {
            var client = new HttpClient();
            string rsscontent = await client.GetStringAsync(rssFeedUrl);

            XDocument doc = XDocument.Parse(rsscontent);
            var items = doc.Descendants("item").Take(count);

            List<string> articles = items.Select(item =>
            {
                string title = item.Element("title")?.Value ?? "";
                string description = item.Element("description")?.Value ?? "";
                // description değeri null ise value değerine ulaşma nullreferanceexeption hatası oluşur
                // daha sonra value değeri ?? boş işe boş string değeri atıyoruz.

                return $"{title}. {description}";
            }).ToList();

            return articles;
        }

        static async Task<string> SummarizeArticle(string articleText)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                   {
                        new { role="system", content="You are an expert news summarizer." },
                        new { role="user", content= "Bu haberi 3 cümlede özetle : " + articleText }
                        
                    },
                    max_tokens = 500
                };

                var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);
                string responseContent = await response.Content.ReadAsStringAsync();

                JsonDocument doc = JsonDocument.Parse(responseContent);
                return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            }
        }



    }
}