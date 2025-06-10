



using System.Speech.Synthesis;

class program
{
    static void Main(string[] args)
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

        speechSynthesizer.Volume = 100; // ses seviyesi
        speechSynthesizer.Rate = 0; // konuşma hızı

        Console.Write("Metni Girin : ");
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            speechSynthesizer.Speak(input);
        }
        Console.ReadLine();
    }
}