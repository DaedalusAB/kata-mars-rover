using System;

namespace MarsRover
{
    public class Direction
    {
        public const int NORTH = 0;
        public const int EAST = 1;
        public const int SOUTH = 2;
        public const int WEST = 3;

        public int Value { get; set; }

        public Direction(int value)
        {
            if (value < 0 || value > 3)
            {
                throw new  ArgumentOutOfRangeException(nameof(value));
            }

            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Direction direction && Value == direction.Value;
        }

        protected bool Equals(Direction other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}