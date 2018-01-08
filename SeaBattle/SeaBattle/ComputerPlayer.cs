using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class ComputerPlayer
    {
        private readonly short[,] field;  

        public int ShipsAmount
        {
            get; private set;
        }

        public ComputerPlayer(short[,] field,int shipsAmount)
        {
            ShipsAmount = shipsAmount;
            this.field = field;
        }

        public bool IsShootAccurate(short X, int Y)
        {
            if (field[Y,X] == 1)
            {
                ShipsAmount--;
                field[Y,X] = 0;
                return true;
            }
            else return false;
        }
    }
}
