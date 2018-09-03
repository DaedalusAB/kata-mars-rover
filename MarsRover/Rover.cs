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
            switch (Position.Direction)
            {
                case DirectionEnum.North:
                    Position = new Position(Position.X, Position.Y + 1, Position.Direction);
                    break;
                case DirectionEnum.South:
                    Position = new Position(Position.X, Position.Y - 1, Position.Direction);
                    break;
                case DirectionEnum.West:
                    Position = new Position(Position.X - 1, Position.Y, Position.Direction);
                    break;
                case DirectionEnum.East:
                    Position = new Position(Position.X + 1, Position.Y, Position.Direction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void MoveBackward()
        {
            switch (Position.Direction)
            {
                case DirectionEnum.North:
                    Position = new Position(Position.X, Position.Y - 1, Position.Direction);
                    break;
                case DirectionEnum.South:
                    Position = new Position(Position.X, Position.Y + 1, Position.Direction);
                    break;
                case DirectionEnum.West:
                    Position = new Position(Position.X + 1, Position.Y, Position.Direction);
                    break;
                case DirectionEnum.East:
                    Position = new Position(Position.X - 1, Position.Y, Position.Direction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
