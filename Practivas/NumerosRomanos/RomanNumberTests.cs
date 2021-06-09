using System;
using Xunit;

namespace Practivas.test.NumerosRomanos
{
    public class RomanNumberTests
    {
        [Fact]
        public void Test001()
        {
            Assert.Equal("I", new RomanNumberTextRepresentation().Of(1));
        }

        [Fact]
        public void Test002()
        {
            Assert.Equal("II", new RomanNumberTextRepresentation().Of(2));
        }

        [Fact]
        public void Test003()
        {
            Assert.Equal("III", new RomanNumberTextRepresentation().Of(3));
        }

        [Fact]
        public void Test004()
        {
            Assert.Equal("IV", new RomanNumberTextRepresentation().Of(4));
        }

        [Fact]
        public void Test005()
        {
            Assert.Equal("V", new RomanNumberTextRepresentation().Of(5));
        }

        [Fact]
        public void Test006()
        {
            Assert.Equal("VI", new RomanNumberTextRepresentation().Of(6));
        }

        [Fact]
        public void Test007()
        {
            Assert.Equal("VII", new RomanNumberTextRepresentation().Of(7));
        }

        [Fact]
        public void Test008()
        {
            Assert.Equal("VIII", new RomanNumberTextRepresentation().Of(8));
        }

        [Fact]
        public void Test009()
        {
            Assert.Equal("IX", new RomanNumberTextRepresentation().Of(9));
        }

        [Fact]
        public void Test0010()
        {
            Assert.Equal("X", new RomanNumberTextRepresentation().Of(10));
        }

        [Fact]
        public void Test0011()
        {
            Assert.Equal("XI", new RomanNumberTextRepresentation().Of(11));
        }

        [Fact]
        public void Test0012()
        {
            Assert.Equal("XII", new RomanNumberTextRepresentation().Of(12));
        }

        [Fact]
        public void Test0013()
        {
            Assert.Equal("XIII", new RomanNumberTextRepresentation().Of(13));
        }

        [Fact]
        public void Test0014()
        {
            Assert.Equal("XIV", new RomanNumberTextRepresentation().Of(14));
        }

        [Fact]
        public void Test0015_TO_0018()
        {
            Assert.Equal("XV", new RomanNumberTextRepresentation().Of(15));
            Assert.Equal("XVI", new RomanNumberTextRepresentation().Of(16));
            Assert.Equal("XVII", new RomanNumberTextRepresentation().Of(17));
            Assert.Equal("XVIII", new RomanNumberTextRepresentation().Of(18));
        }

        [Fact]
        public void Test0019()
        {
            Assert.Equal("XIX", new RomanNumberTextRepresentation().Of(19));
        }

        [Fact]
        public void Test0020_TO_0029()
        {
            Assert.Equal("XX", new RomanNumberTextRepresentation().Of(20));
            Assert.Equal("XXIV", new RomanNumberTextRepresentation().Of(24));
            Assert.Equal("XXIX", new RomanNumberTextRepresentation().Of(29));
        }

        [Fact]
        public void Test0030_TO_0039()
        {
            Assert.Equal("XXX", new RomanNumberTextRepresentation().Of(30));
            Assert.Equal("XXXIV", new RomanNumberTextRepresentation().Of(34));
            Assert.Equal("XXXIX", new RomanNumberTextRepresentation().Of(39));
        }

        [Fact]
        public void Test0040_TO_0049()
        {
            Assert.Equal("XL", new RomanNumberTextRepresentation().Of(40));
            Assert.Equal("XLIV", new RomanNumberTextRepresentation().Of(44));
            Assert.Equal("XLIX", new RomanNumberTextRepresentation().Of(49));
        }

        [Fact]
        public void Test0050_TO_0089()
        {
            Assert.Equal("L", new RomanNumberTextRepresentation().Of(50));
            Assert.Equal("LXXXIX", new RomanNumberTextRepresentation().Of(89));
        }

        [Fact]
        public void Test0090_TO_0099()
        {
            Assert.Equal("XC", new RomanNumberTextRepresentation().Of(90));
            Assert.Equal("XCIX", new RomanNumberTextRepresentation().Of(99));
        }

        [Fact]
        public void Test00100_TO_00999()
        {
            Assert.Equal("C", new RomanNumberTextRepresentation().Of(100));
            Assert.Equal("CXLIX", new RomanNumberTextRepresentation().Of(149));
            Assert.Equal("DCCC", new RomanNumberTextRepresentation().Of(800));
            Assert.Equal("CMXCIX", new RomanNumberTextRepresentation().Of(999));
        }

        [Fact]
        public void Test0()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => new RomanNumberTextRepresentation().Of(0));
            Assert.Equal(RomanNumberTextRepresentation.ROMAN_NUMBER_HAS_NO_ZERO, exception.Message);
        }
    }
}
