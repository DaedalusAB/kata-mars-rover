using System.Collections.Generic;
using MarsRover.Commands;

namespace MarsRover
{
    public class RoverControl
    {
        public List<RoverCommand> Commands { get; set; }
        private readonly RoverCommandParser _commandParser;

        public RoverControl(Rover rover)
        {
            _commandParser = new RoverCommandParser(rover);
            Commands = new List<RoverCommand>();
        }

        public void SendCommands(IEnumerable<char> commands)
        {
            foreach (var command in commands)
            {
                Commands.Add(_commandParser.Parse(command));
            }
        }

        public void InvokeCommands()
        {
            foreach (var roverCommand in Commands)
            {
                roverCommand.Execute();
            }
        }
    }
}
