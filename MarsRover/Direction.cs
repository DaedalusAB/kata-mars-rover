using System;
using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Direction : ValueObject
    {
        public static Direction North = new Direction(DirectionEnum.North);
        public static Direction East = new Direction(DirectionEnum.East);
        public static Direction South = new Direction(DirectionEnum.South);
        public static Direction West = new Direction(DirectionEnum.West);

        private DirectionEnum Value { get; }

        public Direction(DirectionEnum value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public Direction TurnRight()
        {
            if (Value == DirectionEnum.North)
                return new Direction(DirectionEnum.East);
            if (Value == DirectionEnum.East)
                return new Direction(DirectionEnum.South);
            if (Value == DirectionEnum.South)
                return new Direction(DirectionEnum.West);
            if (Value == DirectionEnum.West)
                return new Direction(DirectionEnum.North);

            throw new ArgumentOutOfRangeException(nameof(Value));
        }

        public Direction TurnLeft()
        {
            if (Value == DirectionEnum.North)
                return new Direction(DirectionEnum.West);
            if (Value == DirectionEnum.West)
                return new Direction(DirectionEnum.South);
            if (Value == DirectionEnum.South)
                return new Direction(DirectionEnum.East);
            if (Value == DirectionEnum.East)
                return new Direction(DirectionEnum.North);

            throw new ArgumentOutOfRangeException(nameof(Value));
        }
    }
}