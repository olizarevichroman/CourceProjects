using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Translit
{
    abstract class Transliter
    {
        public abstract string Translit(string originalString);  
        public static Transliter GetTransliter(Language transliterLanguage)
        {
            if (transliterLanguage == Language.Cyrillic)
            {
                return new FromCyrillicToLatinTransliter();
            }
            else return new FromLatinToCyrillicTransliter();
        }     
    }
}
