﻿using System.Collections.Generic;
using System.Linq;
using MarsRover;
using Xunit;

namespace MarsRoverTests
{
    public class RoverTests
    {
        private PositionBuilder PositionBuilder => new PositionBuilder();

        private RoverBuilder RoverBuilder => new RoverBuilder();

        [Theory]
        [InlineData(0, 0, DirectionEnum.North)]
        [InlineData(1, 2, DirectionEnum.South)]
        public void CreateRoverAtPosition(int x, int y, DirectionEnum direction)
        {
            var initialPosition = PositionBuilder
                .At(x, y)
                .Facing(direction)
                .Build();

            var rover = RoverBuilder
                .AtPosition(initialPosition)
                .Build();

            Assert.Equal(initialPosition, rover.Position);
        }

        [Theory]
        [InlineData("fblr")]
        [InlineData("FBLR")]
        public void RoverReceievesCommands(string commands)
        {
            var rover = RoverBuilder
                .ARover()
                .Build();

            rover.ReceiveCommands(commands);

            Assert.True(commands.GetCommands().SequenceEqual(rover.Commands));
        }

        [Theory]
        [InlineData(0, 0, DirectionEnum.North, 0, 1, DirectionEnum.North)]
        [InlineData(0, 0, DirectionEnum.East, 1, 0, DirectionEnum.East)]
        [InlineData(0, 1, DirectionEnum.South, 0, 0, DirectionEnum.South)]
        [InlineData(1, 0, DirectionEnum.West, 0, 0, DirectionEnum.West)]
        public void RoverMovesForward(
            int xBefore, int yBefore, DirectionEnum directionBefore,
            int xAfter, int yAfter, DirectionEnum directionAfter)
        {
            var positionBefore = PositionBuilder
                .At(xBefore, yBefore)
                .Facing(directionBefore)
                .Build();
            var rover = RoverBuilder
                .AtPosition(positionBefore)
                .Build();

            rover.ReceiveCommands("f");
            var roverAfter = rover.ExecuteCommands();

            var positionAfter = PositionBuilder
                .At(xAfter, yAfter)
                .Facing(directionAfter)
                .Build();

            Assert.Equal(positionAfter, roverAfter.Position);
        }
    }
}
