


using System.Text;
using System.Text.Json;

class program
{
    private static readonly string apiKey = "Api Key";
    private static readonly string imagePath = "C:\\Users\\bhmberkan\\Desktop\\1.jpeg";
   
    static async Task Main(string[] args)
    {
        Console.WriteLine("Google Vision Api ile Görsel Nesne Tespiti Yapılıyor...");
        string response = await DetectObjects(imagePath);

        Console.WriteLine("---Tespit Edilen Nesneler---\n");
        Console.WriteLine(response);



        static async Task<string> DetectObjects(string path)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = $"https://vision.googleapis.com/v1/images:annotate?key={apiKey}";

                // doğrudan fotoğrafı okuyamadığımız için base64 formatına çeviriyoruz.
                byte[] imageBytes = File.ReadAllBytes(path);
                string base64Image = Convert.ToBase64String(imageBytes);

                var requestBody = new
                {
                    requests = new[]
                   {
                    new
                    {
                        image = new {content = base64Image},
                        features = new[] {new {type="LABEL_DETECTION",maxResults=10} }
                    }
                   }
                };

                var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8,"applicaton/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl,jsonContent);
                string responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }
    }


}