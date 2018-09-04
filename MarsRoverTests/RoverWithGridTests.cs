﻿using System.Collections.Generic;
using MarsRover;
using MarsRover.Positioning;
using MarsRoverTests.Builders;
using Xunit;

namespace MarsRoverTests
{
    public class RoverWithGridTests
    {
        [Theory]
        [MemberData(nameof(RoverWrapsGridMovingForwardCases))]
        public void RoverWrapsGridMovingForward(Position startingPosition, Position positionAfterWrap)
        {
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();

            roverControl.SendCommands(new List<char>() { 'f' });
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterWrap, rover.Position);
        }

        [Theory]
        [MemberData(nameof(RoverWrapsGridMovingBackwardsCases))]
        public void RoverWrapsGridMovingBackwards(Position startingPosition, Position positionAfterWrap)
        {
            var rover = new RoverBuilder()
                .AtPosition(startingPosition)
                .Build();
            var roverControl = new RoverControlBuilder()
                .ForRover(rover)
                .Build();

            roverControl.SendCommands(new List<char>() { 'b' });
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterWrap, rover.Position);
        }

        public static IEnumerable<object[]> RoverWrapsGridMovingForwardCases()
        {
            yield return new object[] { new Position(0, 4, DirectionEnum.North, new Grid(5, 5)), new Position(0, 0, DirectionEnum.North, new Grid(5, 5)) };
            yield return new object[] { new Position(0, 0, DirectionEnum.South, new Grid(5, 5)), new Position(0, 4, DirectionEnum.South, new Grid(5, 5)) };
            yield return new object[] { new Position(4, 0, DirectionEnum.East, new Grid(5, 5)), new Position(0, 0, DirectionEnum.East, new Grid(5, 5)) };
            yield return new object[] { new Position(0, 0, DirectionEnum.West, new Grid(5, 5)), new Position(4, 0, DirectionEnum.West, new Grid(5, 5)) };
        }

        public static IEnumerable<object[]> RoverWrapsGridMovingBackwardsCases()
        {
            yield return new object[] { new Position(0, 0, DirectionEnum.North, new Grid(5, 5)), new Position(0, 4, DirectionEnum.North, new Grid(5, 5)) };
            yield return new object[] { new Position(0, 4, DirectionEnum.South, new Grid(5, 5)), new Position(0, 0, DirectionEnum.South, new Grid(5, 5)) };
            yield return new object[] { new Position(0, 0, DirectionEnum.East, new Grid(5, 5)), new Position(4, 0, DirectionEnum.East, new Grid(5, 5)) };
            yield return new object[] { new Position(4, 0, DirectionEnum.West, new Grid(5, 5)), new Position(0, 0, DirectionEnum.West, new Grid(5, 5)) };
        }
    }
}
