using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover
    {
        public Position Position { get; }
        public List<Command> Commands { get; private set; }

        public Rover(Position position)
        {
            Position = position;
        }

        public void ReceiveCommands(IEnumerable<char> commands)
        {
            Commands = commands.GetCommands();
        }

        public Rover ExecuteCommands()
        {
            Rover rover = this;
            foreach (var command in Commands)
            {
                rover = ExecuteSingleCommand(command);
            }

            return rover;
        }

        private Rover ExecuteSingleCommand(Command command)
        {
            if (command == Command.ForwardCommand)
            {
                return new Rover(Position.Forward());
            }

            throw new ArgumentOutOfRangeException(nameof(command));
        }
    }
}