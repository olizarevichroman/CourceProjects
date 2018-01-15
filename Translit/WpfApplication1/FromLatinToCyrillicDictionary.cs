using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translit
{
    class FromLatinToCyrillicDictionary
    {
        public readonly Dictionary<char, char> commonLatinValues;
        public readonly Dictionary<string, char> specialLatinValues;
        public readonly char[] invalidValues = { 'q', 'w', 'x','h','c','Q','W','X','H','C' };

        public FromLatinToCyrillicDictionary()
        {
            commonLatinValues = new Dictionary<char, char>();
            specialLatinValues = new Dictionary<string, char>();
            specialLatinValues.Add("SHCH", 'Щ');
            specialLatinValues.Add("shch", 'щ');
            specialLatinValues.Add("SH", 'Ш');
            specialLatinValues.Add("ZH", 'Ж');
            specialLatinValues.Add("KH", 'Х');
            specialLatinValues.Add("TS", 'Ц');
            specialLatinValues.Add("YU", 'Ю');
            specialLatinValues.Add("CH", 'Ч');
            specialLatinValues.Add("yu", 'ю');
            specialLatinValues.Add("ya", 'я');
            specialLatinValues.Add("YA", 'Я');
            specialLatinValues.Add("kh", 'х');
            specialLatinValues.Add("ts", 'ц');
            specialLatinValues.Add("ch", 'ч');
            specialLatinValues.Add("sh", 'ш');
            specialLatinValues.Add("zh", 'ж');


            commonLatinValues.Add('A', 'А');
            commonLatinValues.Add('B', 'Б');
            commonLatinValues.Add('V', 'В');
            commonLatinValues.Add('G', 'Г');
            commonLatinValues.Add('D', 'Д');
            commonLatinValues.Add('E', 'Е');
            commonLatinValues.Add('Z', 'З');
            commonLatinValues.Add('I', 'И');
            commonLatinValues.Add('Y', 'Й');
            commonLatinValues.Add('K','К' );
            commonLatinValues.Add('L', 'Л');
            commonLatinValues.Add('M', 'М');
            commonLatinValues.Add('N', 'Н');
            commonLatinValues.Add('O', 'О');
            commonLatinValues.Add('P', 'П');
            commonLatinValues.Add('R', 'Р');
            commonLatinValues.Add('S', 'С');
            commonLatinValues.Add('T', 'Т');
            commonLatinValues.Add('U', 'У');
            commonLatinValues.Add('F', 'Ф');
            commonLatinValues.Add('a', 'а');
            commonLatinValues.Add('b', 'б');
            commonLatinValues.Add('v', 'в');
            commonLatinValues.Add('g', 'г');
            commonLatinValues.Add('d', 'д');
            commonLatinValues.Add('e', 'е');
            commonLatinValues.Add('z', 'з');
            commonLatinValues.Add('i', 'и');
            commonLatinValues.Add('y', 'й');
            commonLatinValues.Add('k', 'к');
            commonLatinValues.Add('l', 'л');
            commonLatinValues.Add('m', 'м');
            commonLatinValues.Add('n', 'н');
            commonLatinValues.Add('o', 'о');
            commonLatinValues.Add('p', 'п');
            commonLatinValues.Add('r', 'р');
            commonLatinValues.Add('s', 'с');
            commonLatinValues.Add('t', 'т');
            commonLatinValues.Add('u', 'у');
            commonLatinValues.Add('f', 'ф');
        } 
    }
}
