using System;
using System.Collections.Generic;
using System.Text;

namespace BaseRiverBridge
{
    class Water
    {
        public int[][] coordinates;
        public string WithoutSpaces;
        Bresenhem BresenhemTest = new Bresenhem();
        public Water(string enteredString)
        {
            enteredString = enteredString.Trim().Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("WATER", string.Empty).Replace("->",",");
            WithoutSpaces = enteredString;
            string[] TempCoordinate = WithoutSpaces.Split(',');
            coordinates = new int[(TempCoordinate.Length)/2][];
            for (int i = 0; i < (TempCoordinate.Length)/2; i++)
            {
                coordinates[i] = new int[2];
            }
            //Console.Write(TempCoordinate[0]);

             for (int i = 0, j = 0; i < TempCoordinate.Length; i = i + 2, j++)
             {
                    coordinates[j][0] = int.Parse(TempCoordinate[i]);
                    coordinates[j][1] = int.Parse(TempCoordinate[i + 1]);
             }
            

        }
        public void PrintWater()
        {
            for (int i=0; i<coordinates.Length-1;i++)
            {
                BresenhemTest.BresenhemLine(coordinates[i][0], coordinates[i][1], coordinates[i + 1][0], coordinates[i + 1][1], '`');
            }
        }

    }
}
