using MarsRover.Positioning;
using MarsRoverTests.Builders;
using Xunit;

namespace MarsRoverTests
{
    public class RoverGridWithObstaclesTests
    {
        [Fact]
        public void RoverCannotMoveOntoObstacle()
        {
            var grid = new GridBuilder()
                .WithDimensions(2, 2)
                .WithObstacleAt(1, 0)
                .Build();
            var startingPosition = new PositionBuilder()
                .OnGrid(grid)
                .WithCoordinates(new Coordinates(0, 0))
                .Facing(DirectionEnum.West)
                .Build();
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();

            roverControl.SendCommands("f");
            roverControl.InvokeCommands();

            Assert.Equal(startingPosition, rover.Position);
        }

        [Fact]
        public void RoverExecutesCommandSequenceThatLeadsIntoObstacle()
        {
            var grid = new GridBuilder()
                .WithDimensions(2, 2)
                .WithObstacleAt(1, 1)
                .Build();
            var startingPosition = new PositionBuilder()
                .OnGrid(grid)
                .WithCoordinates(new Coordinates(0, 0))
                .Facing(DirectionEnum.North)
                .Build();
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();

            roverControl.SendCommands("frf");
            roverControl.InvokeCommands();

            var endingPosition = new PositionBuilder()
                .OnGrid(grid)
                .WithCoordinates(new Coordinates(0, 1))
                .Facing(DirectionEnum.East)
                .Build();

            Assert.Equal(endingPosition, rover.Position);
        }

        [Fact]
        public void RoverRunsIntoObstacleAndReports()
        {
            var grid = new GridBuilder()
                .WithDimensions(2, 2)
                .WithObstacleAt(1, 0)
                .Build();
            var startingPosition = new PositionBuilder()
                .OnGrid(grid)
                .WithCoordinates(new Coordinates(0, 0))
                .Facing(DirectionEnum.West)
                .Build();
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();

            roverControl.SendCommands("f");
            var detectedObstacle = roverControl.InvokeCommands();

            Assert.Equal(startingPosition, rover.Position);
            Assert.True(detectedObstacle);
            Assert.Empty(roverControl.Commands);
        }
    }
}
