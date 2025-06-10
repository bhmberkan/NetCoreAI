

using Google.Cloud.Vision.V1;

class program
{
    public static async Task Main(string[] args)
    {
        Console.Write("Resim yolunu giriniz :");

        string imagePath = Console.ReadLine();

        string credentialPath = @"C:\Users\bhmberkan\Desktop\my-could-project-462413-4aad4fa6aae1.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);

        try
        {
            var client = ImageAnnotatorClient.Create();

            var image = Image.FromFile(imagePath);
            var response = client.DetectText(image);
            Console.WriteLine("Resimdeki Metin :");
            Console.WriteLine();
            foreach (var annotation in response)
            {
                if (!string.IsNullOrEmpty(annotation.Description))
                {
                    Console.WriteLine(annotation.Description);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir Hata oluştu! {ex.Message}");
        }
    }
}