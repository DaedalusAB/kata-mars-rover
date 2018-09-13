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

        private Direction(DirectionEnum value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}