using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    public class PathValidator
    {
        private string path;
        private string subPath;
        static string reservedWordsPath = "../../src/ReservedWords.txt";
        static char[] invalidPathChars = Path.GetInvalidPathChars();
        static char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
        static string[] startsCombinations = { "./", ".\\", "../", "..\\", "\\\\", "//", "/", "\\", };

        public string SetPath
        {
            set
            {
                path = value;
                subPath = null;
            }
        }

        

        public PathValidator(string path)
        {
            this.path = path;
        }

        private bool IsPathContainReservedWords(string[] components)
        {
            FileInfo fileWithReservedWords = new FileInfo(reservedWordsPath);
            string reservedWord;
            using ( StreamReader reader = fileWithReservedWords.OpenText())
            {
                while ( !reader.EndOfStream )
                {
                    reservedWord = reader.ReadLine();
                    foreach ( var component in components)
                    {
                        if (component.Equals(reservedWord,StringComparison.OrdinalIgnoreCase)) return true;
                    }
                }
            }
            return false;
        }

        public bool IsPathValid()
        {
            if (path == string.Empty ) return false;
            bool isPathvalid;
            EjectStartOfPathValid();
                if (!IsPathContainInvalidChars() && IsPathComponentsValid())
                { isPathvalid = true; }
                else isPathvalid = false;

            return isPathvalid;
        }


        private bool IsPathComponentsValid()
        {
            
            string checkedPath = subPath == null ? path : subPath;
            char[] separators = { '/', '\\' };
            string[] components = checkedPath.Split(separators);
            if (IsPathContainReservedWords(components)) return false;
            foreach ( var pathComponent in components)
            {
                foreach ( var value in pathComponent)
                {
                    if (invalidFileNameChars.Contains(value)) return false;
                    
                }
                if ((pathComponent.EndsWith(".") || pathComponent.StartsWith(".")) && pathComponent != "..")
                {
                    return false;
                }
                if (pathComponent.StartsWith(" ") || pathComponent.EndsWith(" "))


                    return false;
            }
            return true;
        }

        private void EjectStartOfPathValid()
        {
         foreach ( var combination in startsCombinations)
            {
                if (path.StartsWith(combination))
                {
                    subPath = path.Substring(combination.Length);
                    return;
                }
            }
         if ( path[0] > 64 && path[0] < 123 )
            {
                if (path.Length > 1 && path[1] == ':' )
                {
                    if (path.Length > 2 && (path[2] == '/' || path[2] == '\\'))
                    {
                        subPath = path.Substring(3);
                    }
                    else subPath = path.Substring(2);

                }
            }
        }

        private bool IsPathContainInvalidChars()
        {
            
            string checkedValue = subPath == null ? path : subPath;
            if (checkedValue == string.Empty) return false;
            if (checkedValue[0] == '/' || checkedValue[0] == '\\') return true;
            foreach( var value in checkedValue)
            {
                if (invalidPathChars.Contains(value)) return true;
                            }
            
            if ( checkedValue.Contains("//") || checkedValue.Contains("\\\\"))
            {
                return true;
            }
            return false;
        }
        
    }
}