using MarsRover;
using MarsRover.Positioning;

namespace MarsRoverConsole
{
    class ConsoleRover : Rover
    {
        public ConsoleRover(Position position) : base(position)
        {
        }

        public string DisplaySensorData()
        {
            return Position.DisplayAsString();
        }
    }
}
