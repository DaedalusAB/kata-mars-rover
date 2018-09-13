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
    }
}