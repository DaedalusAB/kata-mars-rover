using System;
using MarsRover.Commands;

namespace MarsRover
{
    public class RoverCommandFactory
    {
        public const char ForwardCommandCode = 'f';
        public const char BackwardsCommandCode = 'b';
        public const char RightTurnCommandCode = 'r';
        public const char LeftTurnCommandCode = 'l';

        private readonly Rover _rover;

        public RoverCommandFactory(Rover rover)
        {
            _rover = rover;
        }

        public RoverCommand Parse(char code)
        {
            switch (char.ToLower(code))
            {
                case (ForwardCommandCode):
                    return new RoverCommandForward(_rover);
                case (BackwardsCommandCode):
                    return new RoverCommandBackwards(_rover);
                case (RightTurnCommandCode):
                    return new RoverCommandTurnRight(_rover);
                case (LeftTurnCommandCode):
                    return new RoverCommandTurnLeft(_rover);
                default:
                    throw new ArgumentOutOfRangeException(nameof(code));
            }
        }
    }
}
