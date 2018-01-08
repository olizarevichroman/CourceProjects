using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Console.Write("Enter line int cyrillic or latin: ");
            string line = Console.ReadLine();
            LanguageIdentifier languageIndentifier = new LanguageIdentifier();

            try
            {
                Language translitLanguage = languageIndentifier.GetLanguage(line);
                Transliter transliter = Transliter.GetTransliter(translitLanguage);
                Console.WriteLine(transliter.Translit(line));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Введена неверная строка");
            }
        }
    }
}
