using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public static class EnTranslations
    {
        public static Dictionary<string, string> Translations {get;set;}

        static EnTranslations(){
            Translations = new Dictionary<string, string>();
            Translations.Add("Permissions_Url","To sync music I need access to your audio files. Don't worry, it doesn't require passwords or personal data" +
            Environment.NewLine + "Please, copy this address in your browser's address string and press ENTER" + Environment.NewLine + ProjectConstants.AppAuthUrl + Environment.NewLine+
            "New window should be opened. Please, copy address of this page in console and press ENTER.");
            Translations.Add("Save_path", "Please, enter the path where music will be stored and press ENTER.");  
            Translations.Add("Finished", "Finished 🏁");     
               
        }
    }
}
