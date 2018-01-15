using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translit
{
    class FromLatinToCyrillicTransliter:Transliter
    {
        public readonly FromLatinToCyrillicDictionary dictionary;

        public FromLatinToCyrillicTransliter()
        {
            dictionary = new FromLatinToCyrillicDictionary();
        }

        public override string Translit(string originalString)
        {
            string translitedString = ReplaceSpecialCombinations(originalString);
            translitedString = ReplaceCommonCombinations(translitedString);
            if (IsValid(translitedString)) return translitedString;
            else throw new ArgumentException();
        }

        private string ReplaceSpecialCombinations(string originalString)
        {
            foreach ( var value in dictionary.specialLatinValues.Keys)
            {
                originalString =originalString.Replace(value, dictionary.specialLatinValues[value].ToString());               
            }
            return originalString;
        }

        private string ReplaceCommonCombinations(string originalString)
        {
            foreach ( var value in dictionary.commonLatinValues.Keys)
            {
                originalString = originalString.Replace(value, dictionary.commonLatinValues[value]);
            }
            return originalString;
        }

        private bool IsValid(string translitedString)
        {
            if (translitedString.IndexOfAny(dictionary.invalidValues) == -1)
            {
                return true;
            }
            else return false;
        }

    }
}
