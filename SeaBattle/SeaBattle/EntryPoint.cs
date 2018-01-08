using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class EntryPoint
    {
        public static void Main()
        {
            Random random = new Random();
            int shipsAmount = random.Next(1, 26);
            Initializator initializator = new Initializator(shipsAmount);
            initializator.SetShipsPositions();
            ComputerPlayer computerPlayer = new ComputerPlayer(initializator.field, initializator.actualShipsAmount);
            CommandHandler commandHandler = new CommandHandler(computerPlayer);
            UserInputInterface userInput = new UserInput();
            
            Console.WriteLine("Horizontal coordinates [a-j] Vertical coordinates [1-10]");
            Session session = new Session(commandHandler, userInput);
            session.StartSession();
            Console.WriteLine("Shoots amount = {0} Destroyed ships = {1}", 
                session.ShootsAmount, session.DestroyedShips);
        }
    }
}
