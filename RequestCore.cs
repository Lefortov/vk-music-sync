using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ConsoleApplication
{
    public class RequestCore
    {
        private const string _apiBaseUrl = "https://api.vk.com/method/";

        public static async Task<List<Audio>> GetAudioList(string token, string userId)
        {
            var fullUrl = $"{_apiBaseUrl}audio.get?owner_id={userId}&access_token={token}&v=5.53";

            //I know that it should not be used with using
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(fullUrl);
                    response.EnsureSuccessStatusCode();

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(stringResponse);
                    var audioResponse = jobject["response"].ToObject<AudioResponse>();
                    return audioResponse.Audios;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                    throw e;
                }
        }
    }

    public static async Task DownloadFile(string path, string name, string url)
    {
        var fullpath = $"{path}/{name}.mp3";
        using(var httpClient = new HttpClient())
        {
            Stream response = await httpClient.GetStreamAsync(url);
            if (!File.Exists(fullpath))
            {
                using (Stream file = File.Create(fullpath))
                {
                    CopyStream(response, file);
                }
            }
        }
        Console.WriteLine($"{name} ✅");
    }

    private static void CopyStream(Stream input, Stream output)
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ( (len = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, len);
        }    
    }
}
}