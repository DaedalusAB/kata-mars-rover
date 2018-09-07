using System.Collections.Generic;
using MarsRover;
using MarsRover.Positioning;

namespace MarsRoverConsole
{
    class ConsoleRover : Rover
    {
        public List<Coordinates> DiscoveredObstacles = new List<Coordinates>();

        public ConsoleRover(Position position) : base(position)
        {
        }

        public override bool MoveForward()
        {
            foreach (var coordinates in this.Position.CoordinatesesAround())
            {
                if (Position.Grid.HasObstacle(coordinates))
                {
                    DiscoveredObstacles.Add(coordinates);
                }
            }

            return base.MoveForward();
        }

        public string DisplaySensorData()
        {
            return Position.DisplayAsString(DiscoveredObstacles);
        }
    }
}
