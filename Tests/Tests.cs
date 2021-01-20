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
    }
}
