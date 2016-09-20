using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ConsoleApplication
{
    public class Program
    {
        private static Dictionary<string, string> _translations {get;set;}
        public static void Main(string[] args)
        {
            int second = 1000;
            int minute = 60;
            int hour = 60;
            int twelveHours = second * minute * hour * 12;
            try
            {
                Console.WriteLine("Hello, I'm the Dude. So that's what you call me. You know, that or, uh, His Dudeness, or uh, Duder, ");
                Console.WriteLine("or El Duderino if you're not into the whole brevity thing. Let's synchronize your vk music with local backups, but firstly lets choose the language");
                Console.WriteLine("type \"1\" to keep English( 🇬🇧 ) language.");
                Console.WriteLine("type \"2\" to switch to Russian( 🇷🇺 ) language");
                var lang = Console.ReadLine();
                _translations = GetTranslations(lang);
                Console.WriteLine(_translations["Permissions_Url"]);
                var authUrl = Console.ReadLine();
                var token = GetTokenFromUrl(authUrl);
                var userId = GetUserIdFromUrl(authUrl);
                Console.WriteLine(_translations["Save_path"]);
                var path = Console.ReadLine();
                DownloadMusic(path, token, userId);
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine("⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠");
                Console.WriteLine(ex.Message);
                Console.WriteLine("⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠⚠");                
                Console.ReadKey();
            }
        }

        private static Dictionary<string, string> GetTranslations(string key)
        {
            if (!Regex.IsMatch(key, @"^[1-2]$"))
            {
                throw new ArgumentException("You can input only \"1\" or \"2\"");
            }
            switch (key)
            {
                case "1": return EnTranslations.Translations;
                case "2": return RusTranslations.Translations;
                default: return EnTranslations.Translations;
            }
        }

        private static string GetTokenFromUrl(string url)
        {
            var regex = new Regex(@"^(.+access_token=)(.+)(&expires_in=.+)$");
            var match = regex.Match(url);
            if (match.Success){
                return match.Groups[2].Value;
            }
            else
            {
                throw new ArgumentException("Invalid input data, check url that you have pasted");
            }
        }

        private static string GetUserIdFromUrl(string url)
        {
            var regex = new Regex(@"^(.+access_token=)(.+)(&expires_in=.+&user_id=)(.+)$");
            var match = regex.Match(url);
            if (match.Success){
                return match.Groups[4].Value;
            }
            else
            {
                throw new ArgumentException("Invalid input data, check url that you have pasted");
            }
        }

       private static async void DownloadMusic(string path, string token, string userId)
        {
            if (path[path.Length - 1]=='/'){
                path.Remove(path.Length - 1);
            }
             var musicList = RequestCore.GetAudioList(token, userId).Result;     
             foreach(var audio in musicList)
             {
                 var fullName = $"{audio.Artist}-{audio.Title}";
                 fullName = fullName.Replace("/","|");
                 await RequestCore.DownloadFile(path, fullName, audio.Url);
             }
             Console.WriteLine(_translations["Finished"]);
        }
    }
}
