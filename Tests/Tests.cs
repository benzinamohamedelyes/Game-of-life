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
        [Fact]
        public void ALiveCellWithLessThanTwoAdjacentCellsDies()
        {
            string testString = "5 5";
            Program.VerifyGridSize(testString).Should().BeTrue();

            Program.InitializeGridWithDeadCells();

            Program.SetLivingCell(1, 1);
            Program.SetLivingCell(2, 2);
            Program.CountLivingCells().Should().Be(2);
            Program.GenerateNextGeneration();
            Program.CountLivingCells().Should().Be(0);
        }
        [Fact]
        public void ALiveCellWithMoreThanThreeAdjacentCellsDies()
        {
            string testString = "5 5";
            Program.VerifyGridSize(testString).Should().BeTrue();

            Program.InitializeGridWithDeadCells();

            Program.SetLivingCell(1, 1);
            Program.SetLivingCell(2, 0);
            Program.SetLivingCell(2, 1);
            Program.SetLivingCell(2, 2);
            Program.SetLivingCell(3, 1);

            Program.CountLivingCells().Should().Be(5);

            Program.GenerateNextGeneration();

            Program.CountLivingCells().Should().Be(4);

            Program.IsAlive(1, 1).Should().BeTrue();
            Program.IsDead(2, 1).Should().BeTrue();
            Program.IsAlive(2, 0).Should().BeTrue();
            Program.IsAlive(2, 2).Should().BeTrue();
            Program.IsAlive(3, 1).Should().BeTrue();
        }
        [Fact]
        public void ALiveCellWithTwoOrThreeAdjacentCellsLives()
        {
            string testString = "5 5";
            Program.VerifyGridSize(testString).Should().BeTrue();

            Program.InitializeGridWithDeadCells();

            Program.SetLivingCell(1, 1);
            Program.SetLivingCell(1, 2);
            Program.SetLivingCell(2, 1);
            Program.SetLivingCell(3, 0);

            Program.CountLivingCells().Should().Be(4);

            Program.GenerateNextGeneration();

            Program.CountLivingCells().Should().Be(3);

            Program.IsDead(3, 0).Should().BeTrue();

            Program.IsAlive(1, 1).Should().BeTrue();
            Program.IsAlive(1, 2).Should().BeTrue();
            Program.IsAlive(2, 1).Should().BeTrue();
        }
        [Fact]
        public void ADeadCellWithExactlyThreeAdjacentCellsBecomeAlive()
        {
            string testString = "5 5";
            Program.VerifyGridSize(testString).Should().BeTrue();

            Program.InitializeGridWithDeadCells();

            Program.SetLivingCell(1, 1);
            Program.SetLivingCell(1, 2);
            Program.SetLivingCell(2, 1);

            Program.IsDead(2, 2).Should().BeTrue();
            Program.CountLivingCells().Should().Be(3);

            Program.GenerateNextGeneration();

            Program.CountLivingCells().Should().Be(4);

            Program.IsAlive(2, 2).Should().BeTrue();

            Program.IsAlive(1, 1).Should().BeTrue();
            Program.IsAlive(1, 2).Should().BeTrue();
            Program.IsAlive(2, 1).Should().BeTrue();
        }
    }
}
