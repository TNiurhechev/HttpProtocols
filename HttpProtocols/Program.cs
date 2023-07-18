using Newtonsoft.Json;
namespace HttpProtocols
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            MyHttpClient httpClient = new MyHttpClient();
            Console.Write("Enter the text to translate: ");
            string text = Console.ReadLine();
            Console.Write("Choose a target language\nUse the API language codes(e.g. ukrainian -> uk): ");
            string language = Console.ReadLine();
            string request = $"https://translation.googleapis.com/language/translate/v2?key=AIzaSyBDhCDZQmq7c3Y3iYFcP2ZeaCHqwUb3szs" +
                $"&q={text}&target={language}";
            var res = await httpClient.GET(request);
            var response = JsonConvert.DeserializeObject<Response>(res);
            Console.WriteLine($"Source language: {response.Data.Translations.ElementAt(0).DetectedSourceLanguage}");
            Console.WriteLine($"Translated text: {response.Data.Translations.ElementAt(0).TranslatedText}");
            httpClient.Dispose();
        }
    }
}