using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Position : ValueObject
    {
        private Coordinates Coordinates { get; }
        private Direction Direction { get; }

        public Position(Coordinates coordinates, Direction direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Coordinates;
            yield return Direction;
        }
    }
}