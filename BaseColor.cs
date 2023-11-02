using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fukicycle.Blazor.Neumorphism.Design.Base
{
    public class BaseColor
    {
        public BaseColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }

        public static BaseColor Parse(string color)
        {
            if (string.IsNullOrWhiteSpace(color) || string.IsNullOrEmpty(color)) throw new ArgumentNullException(nameof(color));
            if (color.Contains("#")) color = color.Replace("#", "");
            int red = 0;
            int green = 0;
            int blue = 0;
            if (color.Length == 3)
            {
                red = Convert.ToInt32(color[0].ToString(), 16);
                green = Convert.ToInt32(color[1].ToString(), 16);
                blue = Convert.ToInt32(color[2].ToString(), 16);
            }
            else if (color.Length == 6)
            {
                red = Convert.ToInt32(color.Substring(0, 2), 16);
                green = Convert.ToInt32(color.Substring(2, 2), 16);
                blue = Convert.ToInt32(color.Substring(4, 2), 16);
            }
            else
            {
                throw new ArgumentException("Invalid color string length.");
            }
            return new BaseColor((byte)red, (byte)green, (byte)blue);
        }

        public string GetBaseColor()
        {
            return "#" + Red.ToString("X2") + Green.ToString("X2") + Blue.ToString("X2");
        }

        public string GetLightColor()
        {
            Color color = Color.FromArgb(Red, Green, Blue);
            HslColor hsl = HslColor.FromRgb(color);
            hsl.L = hsl.L + 0.08f;
            if (hsl.L > 1) hsl.L = 1;
            Color lightColor = HslColor.ToRgb(hsl);
            return "#" + lightColor.R.ToString("X2")
                + lightColor.G.ToString("X2")
                + lightColor.B.ToString("X2")
                + 153.ToString("X2");

        }

        public string GetDarkColor()
        {
            Color color = Color.FromArgb(Red, Green, Blue);
            HslColor hsl = HslColor.FromRgb(color);
            hsl.L = hsl.L - 0.15f;
            if (hsl.L < 0) hsl.L = 0;
            Color darkColor = HslColor.ToRgb(hsl);
            return "#" + darkColor.R.ToString("X2")
                + darkColor.G.ToString("X2")
                + darkColor.B.ToString("X2")
                + 153.ToString("X2");
        }
    }
}
