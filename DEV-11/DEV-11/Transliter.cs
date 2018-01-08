namespace Translit
{
    /// <summary>
    /// Abstract class for all transliters
    /// </summary>
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
