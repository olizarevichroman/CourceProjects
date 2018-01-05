using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    class XmlDOM
    {
        ChildStruct parent;
        string[] manageSymbols = { "<", ">", "</" };
        const string declarativeString = @"<?xml version=""1.0"" encoding=""utf-8"" ?>";
        string[] separators = { "/r/n", " " };
 
        public XmlDOM()
        {
            parent = new ChildStruct();
            parent.childs = new List<ChildStruct>();
        }
        /// <summary>
        /// method delete spaces and new line symbol from inside data
        /// </summary>
        /// <param name="data">all information from xml file</param>
        /// <returns></returns>
        public void ParseDocument(string data)
        {
            if (data.StartsWith(declarativeString))
            {
                data = data.Replace(declarativeString, string.Empty);
            }
            data = data.Replace(" ", string.Empty);
            data = data.Replace("\r\n", string.Empty);
            parent.Name = "Parent";
            parent = GetChilds(data);
        }


        /// <summary>
        /// method run by recursion and add childs elements in parent's list 
        /// and set tag name
        /// </summary>
        /// <param name="insideData">data for element, which serves as a supplier
        /// childs elements
        /// </param>
        /// <returns>struct with child element</returns>
        private ChildStruct GetChilds(string insideData)
        {
            ChildStruct child = new ChildStruct();
            child.childs = new List<ChildStruct>();
            string closedTag;
            string subElement;
            string remainingInformation = insideData;
            int openTagEndIndex, closeTagStartIndex, closeTagEndIndex;
            int openTagLength;
            /*
             * loop get subelement for recursion method and cut remaining information
             */
            if ( !remainingInformation.StartsWith(manageSymbols[0]) )
            {
                child.Name = insideData;
                return child;
            }
            openTagEndIndex = remainingInformation.IndexOf(manageSymbols[1]);
            child.Name = remainingInformation.Substring(1, openTagEndIndex - 1);
            openTagLength = child.Name.Length + 2;
            closedTag = manageSymbols[2] + child.Name + manageSymbols[1];
            closeTagStartIndex = remainingInformation.IndexOf(closedTag);
            closeTagEndIndex = closeTagStartIndex + closedTag.Length - 1;
            remainingInformation = remainingInformation.Substring(openTagLength, remainingInformation.Length - 2 * openTagLength - 1);
            while (remainingInformation.StartsWith(manageSymbols[0]))
            {                          
                subElement = GetSubelement(remainingInformation);
                remainingInformation = remainingInformation.Substring(subElement.Length);
                child.childs.Add(GetChilds(subElement));
            }
            return child;
        }

        private string GetSubelement(string allTagData)
        {
            if ( !allTagData.StartsWith(manageSymbols[0]) )
            {
                return allTagData;
            }
            int openTagEndIndex, closeTagStartIndex, closeTagEndIndex;        
            string closedTag, subElement;
            openTagEndIndex = allTagData.IndexOf(manageSymbols[1]);
            string name = allTagData.Substring(1, openTagEndIndex - 1);
            closedTag = manageSymbols[2] + name + manageSymbols[1];
            closeTagStartIndex = allTagData.IndexOf(closedTag);
            closeTagEndIndex = closeTagStartIndex + closedTag.Length - 1;
            subElement = allTagData.Substring(0, closeTagEndIndex + 1);
            return subElement;
        }

    }
}
