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

        public void TurnRight()
        {
            switch (Value)
            {
                case (DirectionEnum.North):
                    Value = DirectionEnum.East;
                    break;
                case (DirectionEnum.East):
                    Value = DirectionEnum.South;
                    break;
                case (DirectionEnum.South):
                    Value = DirectionEnum.West;
                    break;
                case (DirectionEnum.West):
                    Value = DirectionEnum.North;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Value)
            {
                case (DirectionEnum.North):
                    Value = DirectionEnum.West;
                    break;
                case (DirectionEnum.West):
                    Value = DirectionEnum.South;
                    break;
                case (DirectionEnum.South):
                    Value = DirectionEnum.East;
                    break;
                case (DirectionEnum.East):
                    Value = DirectionEnum.North;
                    break;
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