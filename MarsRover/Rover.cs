using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        public Position Position { get; set; }
        public List<char> Commands { get; set; }

        public Rover()
        {
            Position = new Position(0, 0, DirectionEnum.North);
            Commands = new List<char>();
        }

        public Rover(Position position)
        {
            Position = position;
        }

        public void SendCommands(List<char> commands)
        {
            Commands.AddRange(commands);
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
