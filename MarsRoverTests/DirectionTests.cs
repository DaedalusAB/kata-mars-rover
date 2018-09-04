
using System;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class DirectionTests
    {
        [Fact]
        public void CannotCreateInvalidDirection()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Direction(5));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Direction(-1));
        }
    }
}
