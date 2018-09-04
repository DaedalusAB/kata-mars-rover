using System;

namespace MarsRover
{
    public class Direction
    {
        public DirectionEnum Value { get; set; }

        public Direction(DirectionEnum value)
        {
            Value = value;
        }

        public void TurnRight()
        {
            Value = (DirectionEnum)(((int)Value + 1) % 4);
        }

        public void TurnLeft()
        {
            if (Value == DirectionEnum.North)
            {
                Value = DirectionEnum.West;
                return;
            }

            Value = (DirectionEnum)(((int)Value - 1) % 4);
        }

        public override bool Equals(object obj)
        {
            return obj is Direction direction && Value == direction.Value;
        }

        public override int GetHashCode()
        {
            return (int) Value;
        }

        protected bool Equals(Direction other)
        {
            return Value == other.Value;
        }
    }
}