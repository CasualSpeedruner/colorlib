namespace CasualDev.ColorLib
{
    using System;
    public readonly struct hex
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int A { get; }

        public hex(int r, int g, int b, int a = 255)
        {
            R = Math.Clamp(r, 0, 255);
            G = Math.Clamp(g, 0, 255);
            B = Math.Clamp(b, 0, 255);
            A = Math.Clamp(a, 0, 255);
        }

        public static implicit operator hex(int hexValue)
        {
            if ((hexValue & 0xFF000000) != 0)
                return new hex(
                    (hexValue >> 16) & 0xFF,
                    (hexValue >> 8) & 0xFF,
                    hexValue & 0xFF,
                    (hexValue >> 24) & 0xFF
                );
            return new hex(
                (hexValue >> 16) & 0xFF,
                (hexValue >> 8) & 0xFF,
                hexValue & 0xFF
            );
        }

        public hex Blend(hex other)
        {
            return new hex(
                (R + other.R) / 2,
                (G + other.G) / 2,
                (B + other.B) / 2,
                (A + other.A) / 2
            );
        }

        public hex Lighten(float percent)
        {
            percent = Math.Clamp(percent, 0, 1);
            return new hex(
                (int)(R + (255 - R) * percent),
                (int)(G + (255 - G) * percent),
                (int)(B + (255 - B) * percent),
                A
            );
        }

        public hex Darken(float percent)
        {
            percent = Math.Clamp(percent, 0, 1);
            return new hex(
                (int)(R * (1 - percent)),
                (int)(G * (1 - percent)),
                (int)(B * (1 - percent)),
                A
            );
        }

        public void SetTextColor()
        {
            Console.Write($"\u001b[38;2;{R};{G};{B}m");
        }

        public void SetBackgroundColor()
        {
            Console.Write($"\u001b[48;2;{R};{G};{B}m");
        }

        public static void Reset()
        {
            Console.Write("\u001b[0m");
        }

        public override string ToString() => A == 255 ? $"#{R:X2}{G:X2}{B:X2}" : $"#{A:X2}{R:X2}{G:X2}{B:X2}";
    }
}