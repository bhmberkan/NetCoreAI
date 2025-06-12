
using System.Text.Json;
using System.Text;

class program
{
    private static readonly string apiKey = "";

    static async Task Main()
    {
        Console.WriteLine("Hikaye Türünü Seçiniz (Macera,Korku,Bilim Kurgu, Fantastik, Komedi)");
        string genre = Console.ReadLine();

        Console.WriteLine("Ana karakteriniz kim : ");
        string character = Console.ReadLine();

        Console.WriteLine("Hikaye Nerede Geçiyor : ");
        string setting = Console.ReadLine();

        Console.WriteLine("Hikayenin uzunluğu (kısa/orta/uzun) : ");
        string lenght = Console.ReadLine();

        string promt = $"{genre} türünde bir hikaye yaz. Baş karakterin adı {character}. Hikaye {setting} bölgesinde geçiyor. {lenght} bir hikaye olsun. Giriş, gelişme ve sonuç içermeli.";

        string stroy = "";
        Console.WriteLine();
        Console.WriteLine("---AI tarafından oluşturulan hikaye--- \n");
        Console.WriteLine(stroy);


        static async Task<string> GenereteStory(string promt)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                   {
                        new { role="system", content="You are a creative story writer." },
                        new { role="user", content= promt }

                    },
                    max_tokens = 1000
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