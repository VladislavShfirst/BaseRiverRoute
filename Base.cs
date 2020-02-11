using System;
using System.Collections.Generic;
using System.Text;

namespace BaseRiverBridge
{
    class Base
    {
        public int[] coordinate1 = new int[2];
        public int[] coordinate2 = new int[2];
        public string WithoutSpaces;
        public Base(string enteredString)
        {
            //enteredString = enteredString.Replace(" ", string.Empty);
            enteredString = enteredString.Trim().Replace(" ", string.Empty).Replace("(",string.Empty).Replace(")",string.Empty).Replace("BASE",string.Empty);
            WithoutSpaces = enteredString;
            string[] TempCoordinate = WithoutSpaces.Split(new char[] {',',':'});
            coordinate1[0] = int.Parse(TempCoordinate[0]);
            coordinate1[1] = int.Parse(TempCoordinate[1]);
            coordinate2[0] = int.Parse(TempCoordinate[2]);
            coordinate2[1] = int.Parse(TempCoordinate[3]);
        }

        public void PrintBase()
        {
            for (int y=coordinate1[1]; y<=coordinate2[1];y++)
            {
                for (int x=coordinate1[0]; x<=coordinate2[0];x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('@');
                }
            }
        }
    }
}
