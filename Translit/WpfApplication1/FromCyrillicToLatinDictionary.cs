using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translit
{
    class FromCyrillicToLatinDictionary
    {
        public readonly Dictionary<string,string> commonCyrillicValues;
        public readonly Dictionary<string, string> specialCyrillicValues;
        public readonly char[] others = { 'е', 'ё', 'Е', 'Ё' };
        //значения в начале или конце слов
        public readonly char[] vowels = { 'а', 'e', 'ё', 'и', 'о', 'у', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                                   'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
                                 };

        public FromCyrillicToLatinDictionary()
        {

            commonCyrillicValues = new Dictionary<string, string>();
            specialCyrillicValues = new Dictionary<string, string>();
            specialCyrillicValues.Add("ья", "ia");
            specialCyrillicValues.Add("ий", "iy");
            specialCyrillicValues.Add("ый", "iy");

            commonCyrillicValues.Add("Щ", "SHCH");
            commonCyrillicValues.Add("щ", "shch");
            commonCyrillicValues.Add("Ш", "SH");
            commonCyrillicValues.Add("Ж", "ZH");
            commonCyrillicValues.Add("Х", "KH");
            commonCyrillicValues.Add("Ц", "TS");
            commonCyrillicValues.Add("Ю", "YU");
            commonCyrillicValues.Add("Ч", "CH");
            commonCyrillicValues.Add("ю", "yu");
            commonCyrillicValues.Add("я", "ya");
            commonCyrillicValues.Add("Я", "YA");
            commonCyrillicValues.Add("х", "kh");
            commonCyrillicValues.Add("ц", "ts");
            commonCyrillicValues.Add("ч", "ch");
            commonCyrillicValues.Add("ш", "sh");
            commonCyrillicValues.Add("ж", "zh");
            commonCyrillicValues.Add("А", "A");
            commonCyrillicValues.Add("Б", "B");
            commonCyrillicValues.Add("В", "V");
            commonCyrillicValues.Add("Г", "G");
            commonCyrillicValues.Add("Д", "D");
            commonCyrillicValues.Add("Е", "E");
            commonCyrillicValues.Add("Ё", "E");
            commonCyrillicValues.Add("З", "Z");
            commonCyrillicValues.Add("И", "I");
            commonCyrillicValues.Add("Й", "Y");
            commonCyrillicValues.Add("К", "K");
            commonCyrillicValues.Add("Л", "L");
            commonCyrillicValues.Add("М", "M");
            commonCyrillicValues.Add("Н", "N");
            commonCyrillicValues.Add("О", "O");
            commonCyrillicValues.Add("П", "P");
            commonCyrillicValues.Add("Р", "R");
            commonCyrillicValues.Add("С", "S");
            commonCyrillicValues.Add("Т", "T");
            commonCyrillicValues.Add("У", "U");
            commonCyrillicValues.Add("Ф", "F");
            commonCyrillicValues.Add("Ъ", "\0");
            commonCyrillicValues.Add("Ы", "Y");
            commonCyrillicValues.Add("Ь", "\0");
            commonCyrillicValues.Add("Э", "E");
            commonCyrillicValues.Add("а", "a");
            commonCyrillicValues.Add("б", "b");
            commonCyrillicValues.Add("в", "v");
            commonCyrillicValues.Add("г", "g");
            commonCyrillicValues.Add("д", "d");
            commonCyrillicValues.Add("е", "e");
            commonCyrillicValues.Add("ё", "e");
            commonCyrillicValues.Add("з", "z");
            commonCyrillicValues.Add("и", "i");
            commonCyrillicValues.Add("й", "y");
            commonCyrillicValues.Add("к", "k");
            commonCyrillicValues.Add("л", "l");
            commonCyrillicValues.Add("м", "m");
            commonCyrillicValues.Add("н", "n");
            commonCyrillicValues.Add("о", "o");
            commonCyrillicValues.Add("п", "p");
            commonCyrillicValues.Add("р", "r");
            commonCyrillicValues.Add("с", "s");
            commonCyrillicValues.Add("т", "t");
            commonCyrillicValues.Add("у", "u");
            commonCyrillicValues.Add("ф", "f");
            commonCyrillicValues.Add("ъ","\0");
            commonCyrillicValues.Add("ь", "\0");
            commonCyrillicValues.Add("ы", "y");
            commonCyrillicValues.Add("э", "e");
            
        }
    }
}
