using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translit
{
    class FromCyrillicToLatinTransliter:Transliter

    {
        private FromCyrillicToLatinDictionary dictionary;
        public FromCyrillicToLatinTransliter()
        {
            dictionary = new FromCyrillicToLatinDictionary();
        }

        private string ReplaceSpecialCombinations(string originalString)
        {
            string[] words = originalString.Split();
            bool isLower;
            for ( int i = 0; i < words.Length; i++)
            {
                int index = words[i].IndexOfAny(dictionary.others);
                while ( index != -1)
                {
                    isLower = char.IsLower(words[i][index]);
                    if (index == 0 || dictionary.vowels.Contains(words[i][index - 1]))
                    {
                        
                        words[i] = words[i].Remove(index, 1);
                        if (isLower)
                        {
                            words[i] = words[i].Insert(index, "ye");
                        }
                        else words[i] = words[i].Insert(index, "YE");
                    }
                    else
                    {
                        words[i] = words[i].Remove(index, 1);
                        if (isLower)
                        {
                            words[i] = words[i].Insert(index, "e");
                        }
                        else words[i] = words[i].Insert(index, "E");
                    }
                    index = words[i].IndexOfAny(dictionary.others);
                }
               
            }
            return string.Join(" ", words);
        }

        private string ReplaceCommonElements(string originalString)
        {
            string translitedString = originalString;
            foreach (var value in dictionary.specialCyrillicValues.Keys)//replace symbols which has no combinations
            {
                translitedString = translitedString.Replace(value, dictionary.specialCyrillicValues[value]);

            }
            foreach (var value in dictionary.commonCyrillicValues.Keys)
            {
                translitedString = translitedString.Replace(value, dictionary.commonCyrillicValues[value]);

            }
            return translitedString;
        }

        public override string Translit(string originalString)
        {
            string translatedString;
            translatedString = ReplaceSpecialCombinations(originalString);
            translatedString = ReplaceCommonElements(translatedString);
            return translatedString;
        }

    }
}
