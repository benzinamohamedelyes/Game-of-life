using System;
using Xunit;
using GameOfLife;
using FluentAssertions;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void ShouldAcceptOnlyTwoIntsSepareatedByOneSpace()
        {
            string testString = "78";
            Program.VerifyGridSize(testString).Should().BeFalse();
            testString = "7 g";
            Program.VerifyGridSize(testString).Should().BeFalse();
            testString = "7 8";
            Program.VerifyGridSize(testString).Should().BeTrue();
            testString = "7 8 8";
            Program.VerifyGridSize(testString).Should().BeFalse();

        }

        [Fact]
        public void ShouldAcceptOnlydotsAndAsterisksPerSeedLine()
        {
            string testString = "4 4";
            Program.VerifyGridSize(testString).Should().BeTrue();

            testString = "..A.";
            Program.ValidateSeedLine(testString).Should().BeFalse();
            testString = "..*";
            Program.ValidateSeedLine(testString).Should().BeFalse();
            testString = "..**";
            Program.ValidateSeedLine(testString).Should().BeTrue();
        }

        [Fact]
        public void InitializedGridShoulBeAllDeadCells()
        {
            string testString = "4 4";
            Program.VerifyGridSize(testString).Should().BeTrue();

            Program.InitializeGridWithDeadCells();
            
            Program.CountLivingCells().Should().Be(0);
        }
    }
}
