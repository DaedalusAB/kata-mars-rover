using System;
using System.Collections.Generic;
using MarsRover.Positioning;

namespace MarsRover
{
    public class Rover
    {
        public static Position DefaultRoverPosition = new Position(0, 0, DirectionEnum.North);

        public Position Position { get; set; }

        public Rover() : this(DefaultRoverPosition)
        {
        }

        public Rover(Position position)
        {
            Position = position;
        }

        public void MoveForward()
        {
            Position.Coordinates = Position.CoordinatesInFront();
        }

        public void MoveBackwards()
        {
            Position.Coordinates = Position.CoordinatesBehind();
        }

        public void TurnRight()
        {
            Position.Direction.TurnRight();
        }

        public void TurnLeft()
        {
            Position.Direction.TurnLeft();
        }
    }
}
