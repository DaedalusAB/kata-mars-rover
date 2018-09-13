using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Direction : ValueObject
    {
        private DirectionEnum Value { get; }

        public Direction(DirectionEnum value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}