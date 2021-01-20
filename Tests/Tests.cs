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
        [Fact]
        public void ShouldFindOneLivingAdjacentCell()
        {
            string testString = "5 5";
            Program.VerifyGridSize(testString).Should().BeTrue();

            Program.InitializeGridWithDeadCells();

            Program.SetLivingCell(1, 1);
            Program.CountLivingCells().Should().Be(1);
            Program.CountAdjacentLivingCells(2, 1).Should().Be(1);

        }
        [Fact]
        public void ShouldFindMultipleLivingAdjacentCell()
        {
            string testString = "5 5";
            Program.VerifyGridSize(testString).Should().BeTrue();

            Program.InitializeGridWithDeadCells();

            Program.SetLivingCell(1, 1);
            Program.SetLivingCell(2, 2);
            Program.CountLivingCells().Should().Be(2);
            Program.CountAdjacentLivingCells(2, 1).Should().Be(2);
            Program.CountAdjacentLivingCells(0, 1).Should().Be(1);

        }
    }
}
