using System;
using System.Collections.Generic;
using MarsRover.Positioning;

namespace MarsRover
{
    public class Rover
    {
        public Position Position { get; set; }
        
        public Rover(Position position)
        {
            Position = position;
        }

        public bool CanMoveForward() =>
            !Position.HasObstacleInFront();

        public bool CanMoveBackwards() =>
            !Position.HasObstacleBehind();

        public bool MoveForward()
        {
            if (CanMoveForward())
            {
                Position.Coordinates = Position.CoordinatesInFront();
            }

            return CanMoveForward();
        }

        public bool MoveBackwards()
        {
            if (CanMoveBackwards())
            {
                Position.Coordinates = Position.CoordinatesBehind();
            }

            return CanMoveBackwards();
        }

        public bool TurnRight()
        {
            Position.Direction.TurnRight();
            return true;
        }


        public bool TurnLeft()
        {
            Position.Direction.TurnLeft();
            return true;
        }
    }
}
