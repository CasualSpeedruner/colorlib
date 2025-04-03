using Xunit;
using CasualDev.ColorLib;

namespace CasualDev.ColorLib.Tests
{
    public class HexTests
    {
        [Fact]
        public void Hex_Constructor_SetsPropertiesCorrectly()
        {
            hex color = 0x6496C8;

            Assert.InRange(color.R, 100, 102);
            Assert.InRange(color.G, 150, 152);
            Assert.InRange(color.B, 200, 202);
        }

        [Fact]
        public void Hex_ImplicitConversion_FromInt_SetsValuesCorrectly()
        {
            hex color = 0x64C8C8;

            Assert.InRange(color.R, 100, 102);
            Assert.InRange(color.G, 200, 202);
            Assert.InRange(color.B, 200, 202);
        }

        [Fact]
        public void Blend_MergesColorsCorrectly()
        {
            hex color1 = 0x6496C8;
            hex color2 = 0x326496;

            var blended = color1.Blend(color2);

            Assert.InRange(blended.R, 74, 76);
            Assert.InRange(blended.G, 124, 126);
            Assert.InRange(blended.B, 174, 176);
        }

        [Fact]
        public void Lighten_LightensColorCorrectly()
        {
            hex color = 0x6496C8;
            var lightened = color.Lighten(0.5f);

            Assert.InRange(lightened.R, 177, 179);
            Assert.InRange(lightened.G, 202, 204);
            Assert.InRange(lightened.B, 227, 229);
        }

        [Fact]
        public void Darken_DarkensColorCorrectly()
        {
            hex color = 0x6496C8;
            var darkened = color.Darken(0.5f);

            Assert.InRange(darkened.R, 49, 51);
            Assert.InRange(darkened.G, 74, 76);
            Assert.InRange(darkened.B, 99, 101);
        }

        [Fact]
        public void ToString_ReturnsCorrectHexString()
        {
            hex color = 0x6496C8;

            Assert.Equal("#6496C8", color.ToString());
        }
    }
}
