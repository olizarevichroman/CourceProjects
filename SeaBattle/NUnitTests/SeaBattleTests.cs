using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeaBattle;

namespace NUnitTests
{
    [TestFixture]
    public class SeaBattleTests
    {
        private CommandHandler commandHandler;
        private Initializator initializator;


        [SetUp]
        public void Init()
        {
            initializator = new Initializator(4);
            initializator.ExcludeTheOccupiedPoints(new Point(0, 1));
            initializator.ExcludeTheOccupiedPoints(new Point(9, 3));
            initializator.ExcludeTheOccupiedPoints(new Point(9, 1));
            initializator.ExcludeTheOccupiedPoints(new Point(9, 5));
            commandHandler = new CommandHandler(new ComputerPlayer(initializator.field, 4));
        }



        private static object[] dataSource =
        {
           new object[]{ new string[] { "a1", "j2", "a7", "b5" }, 3},
           new object[] {new string[] { "j2", "j4", "j6", "h1" }, 1},
        };

        [Test,TestCaseSource("dataSource")]
        public void TestRemainingShipsAmount(string[] coordinatesArray, int remainingShipsAmount )
        {
            foreach ( var coordinates in coordinatesArray)
            {
                commandHandler.TryToDestroyShip(coordinates);
            }
            int a = commandHandler.computerPlayer.ShipsAmount;
            Assert.AreEqual(commandHandler.computerPlayer.ShipsAmount, remainingShipsAmount);
        }

        private static object[] shootsDataSource =
        {
            new object[] { new string[] { "c1","c2","c3","c4","d3" },5 },
            new object[] { new string[] { "c1","c2","c3","c4","d3","c1","c2","c3"}, 8},
            new object[] { new string[] { "c1","c2","c3","c4","d3","c1","c2","c3","c4","d3","c1","c2","c3"}, 13}
        };

        [Test,TestCaseSource("shootsDataSource")]
        public void TestShootsAmount(string[] shootsArray, int expected)
        {
            foreach (var shoot in shootsArray) {
                commandHandler.TryToDestroyShip(shoot);
                    }
            Assert.AreEqual(commandHandler.ShootsAmount, expected);
        }

    }
}
