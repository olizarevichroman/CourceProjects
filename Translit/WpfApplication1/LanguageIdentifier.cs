using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translit
{
    class LanguageIdentifier
    {
        private bool IsCyrillic(string originalLine)
        {
            FromCyrillicToLatinDictionary cyrillicDictionary = new FromCyrillicToLatinDictionary();
            bool isCyrillic = true;
            for ( int i = 0; i < originalLine.Length; i++)//checking for cyrillic
            {
                if (char.IsLetter(originalLine[i])) {
                    if (!cyrillicDictionary.commonCyrillicValues.ContainsKey(originalLine[i].ToString()))
                    {
                        isCyrillic = false;
                        break;
                    }
                }
            }
            return isCyrillic;    
        }

        private bool IsLatin(string originalLine)
        {
            FromLatinToCyrillicDictionary latinDictionary = new FromLatinToCyrillicDictionary();
            bool isLatin = true;
            for ( int i = 0; i < originalLine.Length; i++)
            {
                if ( char.IsLetter(originalLine[i]) ){
                    if ( !latinDictionary.commonLatinValues.ContainsKey(originalLine[i]) && !latinDictionary.invalidValues.Contains(originalLine[i])){
                        isLatin = false;
                        break;
                    }
                }
            }
            return isLatin;
        }

        public Language GetLanguage(string originalLine)
        {
            if (IsLatin(originalLine)) return Language.Latin;
            else if (IsCyrillic(originalLine)) return Language.Cyrillic;
            else throw new ArgumentException();
        }


    }
}
