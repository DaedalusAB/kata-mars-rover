using System;
using System.Collections.Generic;
using MarsRover.Positioning;

namespace MarsRover
{
    public class Rover
    {
        public static Position DefaultRoverPosition = new Position(0, 0, DirectionEnum.North);

        public Position Position { get; set; }
        public Grid Grid { get; set; }

        public Rover(Grid grid) : this(grid, DefaultRoverPosition)
        {
        }

        public Rover(Grid grid, Position position)
        {
            Grid = grid;
            Position = position;
        }

        public void MoveForward()
        {
            Position.Coordinates = Position.CoordinatesInFront(Grid);
        }

        public void MoveBackwards()
        {
            Position.Coordinates = Position.CoordinatesBehind(Grid);
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
