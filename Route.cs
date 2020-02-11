using System;
using System.Collections.Generic;
using System.Text;

namespace BaseRiverBridge
{
    class Route
    {
        int[][] middle = new int[4][];
        Bresenhem BresenhemRoute = new Bresenhem();

        public Route()
        {
            for (int i=0;i<4;i++)
            {
                middle[i] = new int[2];
            }
        }
        private double distance(int[] start, int[] finish)
        {
            double x1 = double.Parse(start[0].ToString());
            double y1 = double.Parse(start[1].ToString());
            double x2 = double.Parse(finish[0].ToString());
            double y2 = double.Parse(finish[1].ToString());

            return Math.Sqrt(Math.Pow((x2 - x1),2)+Math.Pow((y2-y1),2));
        }
        public void DrawRoute(int[] coord1, int[] coord2,int[] coord3, int[] coord4)
        {
            int[] tempcoord1 = { 0, 0 };
            int[] tempcoord2 = { 0, 0 };
            for (int i =0; i<2; i++)
            {
                tempcoord1[i] = coord1[i] - 1;
                tempcoord2[i] = coord2[i] + 1;
            }
            #region parity
            int y0;
            if (tempcoord1[1]== tempcoord2[1])
            {
                y0 = tempcoord1[1];
            }
            else
            {
                if((tempcoord2[1]- tempcoord1[1])%2==1)
                {
                    y0 = ((tempcoord2[1] - tempcoord1[1]) / 2) + 1 + tempcoord1[1];
                }
                else
                {
                    y0 = ((tempcoord2[1] - tempcoord1[1]) / 2)+tempcoord1[1];
                }
            }
            middle[0][0] = tempcoord1[0];
            middle[0][1] = y0;
            middle[1][0] = tempcoord2[0];
            middle[1][1] = y0;
            int x0;
            if (tempcoord1[0] == tempcoord2[0])
            {
                x0 = tempcoord1[0];
            }
            else
            {
                if ((tempcoord2[0] - tempcoord1[0]) % 2 == 1)
                {
                    x0 = ((tempcoord2[0] - tempcoord1[0]) / 2) + 1+ tempcoord1[0];
                }
                else
                {
                    x0 = ((tempcoord2[0] - tempcoord1[0]) / 2) + tempcoord1[0];
                }
            }
            middle[2][0] = x0;
            middle[2][1] = tempcoord1[1];
            middle[3][0] = x0;
            middle[3][1] = tempcoord2[1];
            #endregion
            double leastDistance = 1000000.0;
            int middle0 = 0;
            for (int i=0;i<4;i++)
            {
                if (distance(middle[i],coord3)<leastDistance)
                {
                    leastDistance = distance(middle[i], coord3);
                    middle0 = i;
                }
            }
            BresenhemRoute.BresenhemLine(middle[middle0][0], middle[middle0][1], coord3[0], coord3[1], '%');
            BresenhemRoute.BresenhemLine(coord3[0],coord3[1],coord4[0],coord4[1], '%');


        }
    }
}
