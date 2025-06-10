

using Newtonsoft.Json;
using System.Text;

class program
{
    public static async Task Main(string[] args)
    {
        Console.Write("Lütfen çevirmek istediğiniz cümleyi giriniz :");

        string inputText = Console.ReadLine();

        string apiKey = "Api Key";

        string translatedText = await TranslateTextEngilish(inputText, apiKey);

        if (!string.IsNullOrEmpty(translatedText))
        {
            Console.WriteLine();
            Console.WriteLine($"Çeviri (ingilizce): {translatedText}");
        }
        else
            Console.Write("Beklenmeyen bir hata oluştu");

    }

    private static async Task<string> TranslateTextEngilish(string text, string apiKey)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "system", content = "You are a helpful translator." },
                 new { role = "user", content = $"Please translate this text to English: {text}" },
                }
            };

            string jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                string responseString = await response.Content.ReadAsStringAsync();

                dynamic responseObject = JsonConvert.DeserializeObject(responseString);
                string translation = responseObject.choices[0].message.content;

                return translation;
            }
            catch (Exception hata)
            {
                Console.WriteLine($" Bir hata oluştu!.. {hata.Message}");
                return null;
            }
        }
    }
}