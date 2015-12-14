using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Helper
{
    public static class CollisionHelper
    {
        public static bool IntersecsPixel(Rectangle rectangle1, Color[] colorData1, Rectangle rectangle2, Color[] colorData2)
        {
            int top = Math.Max(rectangle1.Top, rectangle2.Top);
            int bottom = Math.Min(rectangle1.Bottom, rectangle2.Bottom);
            int left = Math.Max(rectangle1.Left, rectangle2.Left);
            int right = Math.Min(rectangle1.Right, rectangle2.Right);

            for(int y = top; y < bottom; y++)
            {
                for(int x = left; x < right; x++)
                {
                    Color color1 = colorData1[(x - rectangle1.Left) + (y - rectangle1.Top) * rectangle1.Width];
                    Color color2 = colorData2[(x - rectangle2.Left) + (y - rectangle2.Top) * rectangle2.Width];

                    if(color1.A != 0 && color2.A != 0)
                        return true;
                }
            }

            return false;
        }
    }
}
