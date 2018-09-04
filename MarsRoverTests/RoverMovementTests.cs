using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class RoverMovementTests
    {
        [Fact]
        public void RoverMovesForwardFacingNorth()
        {
            var initialPosition = new Position(0, 0, Direction.NORTH);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(0, 1, Direction.NORTH);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesForwardFacingSouth()
        {
            var initialPosition = new Position(0, 1, Direction.SOUTH);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(0, 0, Direction.SOUTH);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesForwardFacingEast()
        {
            var initialPosition = new Position(0, 0, Direction.EAST);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(1, 0, Direction.EAST);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesForwardFacingWest()
        {
            var initialPosition = new Position(1, 0, Direction.WEST);
            var rover = new Rover(initialPosition);
            rover.MoveForward();

            var destination = new Position(0, 0, Direction.WEST);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingNorth()
        {
            var initialPosition = new Position(0, 1, Direction.NORTH);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(0, 0, Direction.NORTH);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingSouth()
        {
            var initialPosition = new Position(0, 0, Direction.SOUTH);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(0, 1, Direction.SOUTH);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingEast()
        {
            var initialPosition = new Position(1, 0, Direction.EAST);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(0, 0, Direction.EAST);

            Assert.Equal(destination, rover.Position);
        }

        [Fact]
        public void RoverMovesBackwardsFacingWest()
        {
            var initialPosition = new Position(0, 0, Direction.WEST);
            var rover = new Rover(initialPosition);
            rover.MoveBackwards();

            var destination = new Position(1, 0, Direction.WEST);

            Assert.Equal(destination, rover.Position);
        }
    }
}
