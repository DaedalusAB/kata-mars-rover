using System;
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

        public Position InFront()
        {
            return Translate(CoordinatesChangeByDirection().Item1, CoordinatesChangeByDirection().Item2);
        }

        public Position Behind()
        {
            return Translate(CoordinatesChangeByDirection().Item1 * -1, CoordinatesChangeByDirection().Item2 * -1);
        }

        private Position Translate(int dx, int dy)
        {
            return new Position(Coordinates.Translate(dx, dy), Direction);
        }

        private (int, int) CoordinatesChangeByDirection()
        {
            if (Direction == Direction.North)
                return (0, 1);
            if (Direction == Direction.East)
                return (1, 0);
            if (Direction == Direction.South)
                return (0, -1);
            if (Direction == Direction.West)
                return (-1, 0);

            throw new ArgumentOutOfRangeException(nameof(Direction));
        }
    }
}