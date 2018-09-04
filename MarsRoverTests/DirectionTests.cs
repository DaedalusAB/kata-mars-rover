
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

        [Fact]
        public void NorthTurnRightShouldFaceEast()
        {
            var direction = new Direction(Direction.NORTH);

            direction.TurnRight();
           
            var newDirection = new Direction(Direction.EAST);
            
            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void EastTurnRightShouldFaceSouth()
        {
            var direction = new Direction(Direction.EAST);

            direction.TurnRight();

            var newDirection = new Direction(Direction.SOUTH);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void SouthTurnRightShouldFaceWest()
        {
            var direction = new Direction(Direction.SOUTH);

            direction.TurnRight();

            var newDirection = new Direction(Direction.WEST);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void WestTurnRightShouldFaceNorth()
        {
            var direction = new Direction(Direction.WEST);

            direction.TurnRight();

            var newDirection = new Direction(Direction.NORTH);

            Assert.Equal(newDirection, direction);
        }



        [Fact]
        public void NorthTurnLeftShouldFaceWest()
        {
            var direction = new Direction(Direction.NORTH);

            direction.TurnLeft();

            var newDirection = new Direction(Direction.WEST);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void EastTurnLeftShouldFaceNorth()
        {
            var direction = new Direction(Direction.EAST);

            direction.TurnLeft();

            var newDirection = new Direction(Direction.NORTH);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void SouthTurnLeftShouldFaceEast()
        {
            var direction = new Direction(Direction.SOUTH);

            direction.TurnLeft();

            var newDirection = new Direction(Direction.EAST);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void WestTurnLeftShouldFaceSouth()
        {
            var direction = new Direction(Direction.WEST);

            direction.TurnLeft();

            var newDirection = new Direction(Direction.SOUTH);

            Assert.Equal(newDirection, direction);
        }
    }
}
