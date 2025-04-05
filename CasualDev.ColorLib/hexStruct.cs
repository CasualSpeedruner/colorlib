namespace CasualDev.ColorLib
{
    using System;
    public readonly struct Hex
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int A { get; }

        public Hex(int r, int g, int b, int a = 255)
        {
            R = Math.Clamp(r, 0, 255);
            G = Math.Clamp(g, 0, 255);
            B = Math.Clamp(b, 0, 255);
            A = Math.Clamp(a, 0, 255);
        }

        public static implicit operator Hex(int hexValue)
        {
            if ((hexValue & 0xFF000000) != 0)
                return new Hex(
                    (hexValue >> 16) & 0xFF,
                    (hexValue >> 8) & 0xFF,
                    hexValue & 0xFF,
                    (hexValue >> 24) & 0xFF
                );
            return new Hex(
                (hexValue >> 16) & 0xFF,
                (hexValue >> 8) & 0xFF,
                hexValue & 0xFF
            );
        }

        public Hex Blend(Hex other, float alpha)
        {
            return new Hex(
                (int)Math.Round(alpha * other.R + (1 - alpha) * R),
                (int)Math.Round(alpha * other.G + (1 - alpha) * G),
                (int)Math.Round(alpha * other.B + (1 - alpha) * B),
                A
            );
        }

        public Hex Lighten(float percent)
        {
            percent = Math.Clamp(percent, 0, 1);
            return new Hex(
                (int)(R + (255 - R) * percent),
                (int)(G + (255 - G) * percent),
                (int)(B + (255 - B) * percent),
                A
            );
        }

        public Hex Darken(float percent)
        {
            percent = Math.Clamp(percent, 0, 1);
            return new Hex(
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