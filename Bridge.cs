using System;
using System.Collections.Generic;
using System.Text;

namespace BaseRiverBridge
{
    class Bridge
    {
        public int[] coordinate = new int[2];
        public string WithoutSpaces;
        public Bridge(string enteredString)
        {
            enteredString = enteredString.Trim().Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("bridge", string.Empty);
            WithoutSpaces = enteredString;
            string[] TempCoordinate = WithoutSpaces.Split(new char[] { ',', ':' });
            coordinate[0] = int.Parse(TempCoordinate[0]);
            coordinate[1] = int.Parse(TempCoordinate[1]);
        }
        public void PrintBridge()
        {
            Console.SetCursorPosition(coordinate[0], coordinate[1]);
            Console.Write('#');
        }
    }
}
