using System;

namespace MarsRover.Positioning
{
    public class Direction : IEquatable<Direction>
    {
        public DirectionEnum Value { get; set; }

        public Direction(DirectionEnum value)
        {
            Value = value;
        }

        public Direction TurnRight()
        {
            switch (Value)
            {
                case (DirectionEnum.North):
                    return new Direction(DirectionEnum.East);
                case (DirectionEnum.East):
                    return new Direction(DirectionEnum.South);
                case (DirectionEnum.South):
                    return new Direction(DirectionEnum.West);
                case (DirectionEnum.West):
                    return new Direction(DirectionEnum.North);
                default:
                    throw new ArgumentException(nameof(Value));
            }
        }

        public Direction TurnLeft()
        {
            switch (Value)
            {
                case (DirectionEnum.North):
                    return new Direction(DirectionEnum.West);
                case (DirectionEnum.West):
                    return new Direction(DirectionEnum.South);
                case (DirectionEnum.South):
                    return new Direction(DirectionEnum.East);
                case (DirectionEnum.East):
                    return new Direction(DirectionEnum.North);
                default:
                    throw new ArgumentException(nameof(Value));
            }
        }

        public bool Equals(Direction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return (int) Value;
        }
    }
}