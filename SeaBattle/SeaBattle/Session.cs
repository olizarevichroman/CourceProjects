using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Session
    {

        private CommandHandler commandHandler;
        private UserInputInterface userInput;

        public int ShootsAmount
        {
            get; private set;
        }

        public int DestroyedShips
        {
            get; private set;
        }

        public int RemainingShips
        {
            get { return commandHandler.computerPlayer.ShipsAmount; }
        }


        public Session(CommandHandler commandHandler, UserInputInterface userInput)
        {
            this.commandHandler = commandHandler;
            this.userInput = userInput;
            DestroyedShips = 0;
        }

        public void StartSession()
        {
            string coordinates;
            while ( RemainingShips!= 0 )
            {
                coordinates = userInput.SetCoordinates();
                ShootsAmount++;
                try
                {
                    if (commandHandler.TryToDestroyShip(coordinates))
                    {
                        Console.WriteLine("To the point! Ship was destroyed");
                        DestroyedShips++;
                    }
                    else
                    {
                        Console.WriteLine("Oops...");
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Coordinates is not valid, try again");
                    ShootsAmount--;
                }


            }
        }
    }
}
