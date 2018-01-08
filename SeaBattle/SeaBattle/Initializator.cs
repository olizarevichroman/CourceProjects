using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{   /*point have 3 conditions:
      value 0 - point is free
      value 1 - it's a ship

    offsets : shows the offset relative to the x and y axes
    */
    public class Initializator
    {
        private readonly short[] offsets = { -1, 0, -1, -1, -1, 1, 0, 1, 0, -1, 1, 1, 1, 0, 1, -1 };
        
        public readonly short[,] field;
        private List<Point> freePoints;
        public int shipsAmount;
        public int actualShipsAmount = 0;

        /// <summary>
        /// initialize expected ship amount field, initialize memory to main field and
        /// execute method to initialize list of free points
        /// </summary>
        /// <param name="expectedShipsAmount">needed ships amount</param>
        public Initializator(int expectedShipsAmount)
        {
            shipsAmount = expectedShipsAmount;
            field = new short[10, 10];
            FreePointsListInit();
        }


        private void FreePointsListInit()
        {
            freePoints = new List<Point>(100);
            Point point;
            for ( int i = 0; i < 10; i++)
            {               
                for ( int j = 0; j < 10; j++)
                {
                    point = new Point();
                    point.X = i;
                    point.Y = j;
                    freePoints.Add(point);
                }
            } 
        }

        /// <summary>
        /// set random ship points from free points list,
        /// actual ship amount - real amount of created ships
        /// </summary>
        public void SetShipsPositions()
        {
            Random random = new Random();
            int shipCoordinates;
            while ( actualShipsAmount < shipsAmount)
            {
                if (freePoints.Count == 0) break;
                shipCoordinates = random.Next(0, freePoints.Count);
                
                ExcludeTheOccupiedPoints(freePoints[shipCoordinates]);
                
            }
            shipsAmount = actualShipsAmount;
        }

        /// <summary>
        /// delete points around the ship for free points list
        /// </summary>
        /// <param name="shipPoint">coordinates of new ship</param>
        public void ExcludeTheOccupiedPoints(Point shipPoint)
        {
            field[shipPoint.Y, shipPoint.X] = 1;
            actualShipsAmount++;
            freePoints.Remove(shipPoint);
            Point excludePoint;
            for ( int i = 0; i < offsets.Length; i += 2)
            {
                excludePoint = shipPoint;
                excludePoint.X += offsets[i];
                excludePoint.Y += offsets[i + 1];
                if (excludePoint.X < 0 || excludePoint.X > 9
                    || excludePoint.Y < 0 || excludePoint.Y > 9)
                {
                    continue;
                }
                freePoints.Remove(excludePoint);
                
            }
        }
    }
}
