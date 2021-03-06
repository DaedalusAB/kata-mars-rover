﻿using System.Collections.Generic;
using Xunit;

using MarsRover.Positioning;
using MarsRoverTests.Builders;

namespace MarsRoverTests
{
    public class RoverGridWrappingTests
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

            roverControl.SendCommands("f");
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

            roverControl.SendCommands("b");
            roverControl.InvokeCommands();

            Assert.Equal(positionAfterWrap, rover.Position);
        }

        public static IEnumerable<object[]> RoverWrapsGridMovingForwardCases()
        {
            yield return new object[]
            {
                new Position(new Coordinates(0, 4),  new Direction(DirectionEnum.North), new Grid(5, 5)),
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.North), new Grid(5, 5))
            };
            yield return new object[]
            {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.South), new Grid(5, 5)),
                new Position(new Coordinates(0, 4),  new Direction(DirectionEnum.South), new Grid(5, 5))
            };
            yield return new object[]
            {
                new Position(new Coordinates(4, 0),  new Direction(DirectionEnum.East), new Grid(5, 5)),
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.East), new Grid(5, 5))
            };
            yield return new object[]
            {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.West), new Grid(5, 5)),
                new Position(new Coordinates(4, 0),  new Direction(DirectionEnum.West), new Grid(5, 5))
            };
        }

        public static IEnumerable<object[]> RoverWrapsGridMovingBackwardsCases()
        {
            yield return new object[]
            {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.North), new Grid(5, 5)),
                new Position(new Coordinates(0, 4),  new Direction(DirectionEnum.North), new Grid(5, 5))
            };
            yield return new object[]
            {
                new Position(new Coordinates(0, 4),  new Direction(DirectionEnum.South), new Grid(5, 5)),
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.South), new Grid(5, 5))
            };
            yield return new object[]
            {
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.East), new Grid(5, 5)),
                new Position(new Coordinates(4, 0),  new Direction(DirectionEnum.East), new Grid(5, 5))
            };
            yield return new object[]
            {
                new Position(new Coordinates(4, 0),  new Direction(DirectionEnum.West), new Grid(5, 5)),
                new Position(new Coordinates(0, 0),  new Direction(DirectionEnum.West), new Grid(5, 5))
            };
        }
    }
}
