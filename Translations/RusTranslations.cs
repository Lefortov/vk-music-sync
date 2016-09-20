using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public static class RusTranslations
    {
        public static Dictionary<string, string> Translations{get;set;}

        static RusTranslations(){
            Translations = new Dictionary<string, string>();
            Translations.Add("Permissions_Url","Чтобы синхронизировать Вашу музыку мне нужен доступ к Вашим аудио-файлам. Не волнуйтесь, мне не потребуется пароль или личные данные." +
            Environment.NewLine + "Пожалуйста, скопируйте это ссылку в адресную строку Вашего браузера и нажмите ВВОД " + Environment.NewLine + ProjectConstants.AppAuthUrl + Environment.NewLine +
            "Открылось новое окно. Пожалуйста, скопируйте адрес в консоль и нажмите ВВОД.");
            Translations.Add("Save_path", "Пожалуйста, введите путь для сохранения мызки и нажмите ВВОД.");     
            Translations.Add("Finished", "Выполнено ✅ ");  
        }
    }
}
