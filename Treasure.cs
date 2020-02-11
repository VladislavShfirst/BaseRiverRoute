using System;
using System.Collections.Generic;
using System.Text;

namespace BaseRiverBridge
{
    class Treasure
    {
        public int[] coordinate = new int[2];
        public string WithoutSpaces;
        public Treasure(string enteredString)
        {
            enteredString = enteredString.Trim().Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("Treasure", string.Empty);
            WithoutSpaces = enteredString;
            string[] TempCoordinate = WithoutSpaces.Split(new char[] { ',', ':' });
            coordinate[0] = int.Parse(TempCoordinate[0]);
            coordinate[1] = int.Parse(TempCoordinate[1]);
        }
        public void PrintTreasure()
        {
            Console.SetCursorPosition(coordinate[0], coordinate[1]);
            Console.Write('+');
        }
    }
}
