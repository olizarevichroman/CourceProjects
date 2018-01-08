using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    /// <summary>
    /// Class handle user query 
    /// </summary>
    public class CommandHandler
    {
        public readonly ComputerPlayer computerPlayer;
        public readonly Dictionary<char, short> charsValue = new Dictionary<char, short>(10);
        public int ShootsAmount
        {
            get;private set;
        }

        /// <summary>
        /// Get computer player, execute method to initialize dictionary 
        /// </summary>
        /// <param name="computerPlayer"></param>
        public CommandHandler(ComputerPlayer computerPlayer)
        {
            this.computerPlayer = computerPlayer;
            DictionaryInit();
            ShootsAmount = 0;
        }

        /// <summary>
        /// parse string coordinates to field coordinates and transfer to computer player,
        /// increment shoots amount
        /// </summary>
        /// <param name="coordinates">string coordinates from user</param>
        /// <returns>boolean value - is ship destruyed</returns>
        public bool TryToDestroyShip(string coordinates)
        {
            ShootsAmount++;
            if ( coordinates.Length < 2 || coordinates.Length > 3 )
            {
                ShootsAmount--;
                throw new ArgumentException();             
            }
            short X, Y;
            if ( !charsValue.TryGetValue(coordinates[0], out X) ||
                !short.TryParse(coordinates.Substring(1), out Y))
            {
                ShootsAmount--;
                throw new ArgumentException();
            }            
           return computerPlayer.IsShootAccurate(X, Y - 1);
        }
         
        private void DictionaryInit()
        {
            charsValue.Add('a', 0);
            charsValue.Add('b', 1);
            charsValue.Add('c', 2);
            charsValue.Add('d', 3);
            charsValue.Add('e', 4);
            charsValue.Add('f', 5);
            charsValue.Add('g', 6);
            charsValue.Add('h', 7);
            charsValue.Add('i', 8);
            charsValue.Add('j', 9);
        }

    }
}
