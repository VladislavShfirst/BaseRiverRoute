using System;
using System.IO;

namespace BaseRiverBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            string GivenString1 = "";
            string GivenString2 = "";
            string GivenString3 = "";
            string GivenString4 = "";
            string path = @"D:\VisualStudioProjects\BaseRiverBridge\Files\dotnet.course\Task1\TestData\Map5.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.ToLower().Contains("base"))
                    {
                        GivenString1 = line;
                    }
                    if (line.ToLower().Contains("bridge"))
                    {
                        GivenString2 = line;
                    }
                    if (line.ToLower().Contains("treasure"))
                    {
                        GivenString3 = line;
                    }
                    if (line.ToLower().Contains("water"))
                    {
                        GivenString4 = line;
                    }
                }
            }

            //string GivenString1 = "BASE (4, 5 :9,7 )";
            //string GivenString2 = "bridge (15 , 1 )";
            //string GivenString3 = "Treasure(34, 11)";
            //string GivenString4 = "WATER (19,0 ->19, 7 -> 23 ,11-> 19, 15 -> 16 , 15 -> 12, 19)";
            try
            {
                Base Base1 = new Base(GivenString1);
                Bridge Bridge1 = new Bridge(GivenString2);
                Treasure Treasure1 = new Treasure(GivenString3);
                Bresenhem Bresenhem1 = new Bresenhem();
                Water Water1 = new Water(GivenString4);
                Route Route1 = new Route();

                #region maxX and maxY
                int maxX = 0;
                int maxY = 0;
                for (int i=0; i<2;i++)
                {
                    if (i==0)
                    {
                        if (Base1.coordinate1[0]>maxX)
                        {
                            maxX = Base1.coordinate1[0];
                        }
                        if (Base1.coordinate2[0]>maxX)
                        {
                            maxX = Base1.coordinate2[0];
                        }
                        if (Bridge1.coordinate[0]>maxX)
                        {
                            maxX = Bridge1.coordinate[0];
                        }
                        if (Treasure1.coordinate[0] > maxX)
                        {
                            maxX = Treasure1.coordinate[0];
                        }
                    }
                    else if (i==1)
                    {
                        if (Base1.coordinate1[1] > maxX)
                        {
                            maxY = Base1.coordinate1[1];
                        }
                        if (Base1.coordinate2[1] > maxX)
                        {
                            maxY = Base1.coordinate2[1];
                        }
                        if (Bridge1.coordinate[1] > maxX)
                        {
                            maxY = Bridge1.coordinate[1];
                        }
                        if (Treasure1.coordinate[1] > maxX)
                        {
                            maxY = Treasure1.coordinate[1];
                        }
                    }
                }
                for (int i=0; i<Water1.coordinates.Length;i++)
                {
                    if (Water1.coordinates[i][0]>maxX)
                    {
                        maxX = Water1.coordinates[i][0];
                    }
                    if (Water1.coordinates[i][1] > maxY)
                    {
                        maxY = Water1.coordinates[i][1];
                    }
                }
                #endregion


                //Console.WriteLine($"{Base1.WithoutSpaces} {Base1.coordinate1string}");
                //foreach (int i in Base1.coordinate1)
                //    Console.WriteLine(i);
                //foreach (int i in Base1.coordinate2)
                //    Console.WriteLine(i);
                //Console.SetBufferSize(101, 51);
                Console.SetWindowSize(maxX+2,maxY+2);
                Console.CursorVisible = false;



                Route1.DrawRoute(Base1.coordinate1, Base1.coordinate2, Bridge1.coordinate, Treasure1.coordinate);
                Base1.PrintBase();
                Water1.PrintWater();
                Bridge1.PrintBridge();
                Treasure1.PrintTreasure();
                //Bresenhem1.BresenhemLine(23,11,15,5,'%');
                Console.SetCursorPosition(1, 60);
                Console.WriteLine($"BufferHeight={Console.BufferHeight},BufferWidth={Console.BufferWidth},WindowHeight={Console.WindowHeight},WindowWidth={Console.WindowWidth}");
            }
            catch
            {
                Console.WriteLine("Something is going wrong. Propably incoming file is invalid.");
            }



        }
    }
}
