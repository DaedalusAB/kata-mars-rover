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

        public Position Forward()
        {
            if (Direction == new Direction(DirectionEnum.North))
            {
                return  new Position(Coordinates.Translate(0, 1), Direction);
            }

            throw new ArgumentOutOfRangeException(nameof(Direction));
        }
    }
}