



using System.Text;
using System.Text.Json;

class program
{
    static async Task Main(string[] args)
    {
        
        var apiKey = "buraya key gelecek";
        Console.WriteLine("Lüften sorunuzu yazınız : (örnek : 'Merhaba bügün hava istanbulda kaç derece')");

        var promt = Console.ReadLine();
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Autohorization", $"Bearer{apiKey}");

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = promt }
            },
            max_tokens = 100
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json,Encoding.UTF8,"application/json");

        try
        {
            var response = await httpClient.PostAsync("https://api.com/v1/chat/completions",content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<JsonElement>(responseString);
                var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                Console.WriteLine("Open AI'nin Cevabı :");
                Console.WriteLine(answer);
            }
            else
            {
               Console.WriteLine($"Bir hata oluştu: {responseString}");
                Console.WriteLine(responseString);
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}