
using System;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class DirectionTests
    {
        [Fact]
        public void NorthTurnRightShouldFaceEast()
        {
            var direction = new Direction(DirectionEnum.North);

            direction.TurnRight();
           
            var newDirection = new Direction(DirectionEnum.East);
            
            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void EastTurnRightShouldFaceSouth()
        {
            var direction = new Direction(DirectionEnum.East);

            direction.TurnRight();

            var newDirection = new Direction(DirectionEnum.South);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void SouthTurnRightShouldFaceWest()
        {
            var direction = new Direction(DirectionEnum.South);

            direction.TurnRight();

            var newDirection = new Direction(DirectionEnum.West);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void WestTurnRightShouldFaceNorth()
        {
            var direction = new Direction(DirectionEnum.West);

            direction.TurnRight();

            var newDirection = new Direction(DirectionEnum.North);

            Assert.Equal(newDirection, direction);
        }



        [Fact]
        public void NorthTurnLeftShouldFaceWest()
        {
            var direction = new Direction(DirectionEnum.North);

            direction.TurnLeft();

            var newDirection = new Direction(DirectionEnum.West);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void EastTurnLeftShouldFaceNorth()
        {
            var direction = new Direction(DirectionEnum.East);

            direction.TurnLeft();

            var newDirection = new Direction(DirectionEnum.North);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void SouthTurnLeftShouldFaceEast()
        {
            var direction = new Direction(DirectionEnum.South);

            direction.TurnLeft();

            var newDirection = new Direction(DirectionEnum.East);

            Assert.Equal(newDirection, direction);
        }

        [Fact]
        public void WestTurnLeftShouldFaceSouth()
        {
            var direction = new Direction(DirectionEnum.West);

            direction.TurnLeft();

            var newDirection = new Direction(DirectionEnum.South);

            Assert.Equal(newDirection, direction);
        }
    }
}
