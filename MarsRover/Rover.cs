﻿using System.Collections.Generic;

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
    }
}
