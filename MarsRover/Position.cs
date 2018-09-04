using System;

namespace MarsRover
{
    public class Position
    {
        public Coordinates Coordinates { get; set; }
        public Direction Direction { get; set; }

        public Position(int x, int y, int directionValue)
        {
            Coordinates = new Coordinates(x, y);
            Direction = new Direction(directionValue);
        }

        public Coordinates CoordinatesInFront()
        {
            switch (Direction.Value)
            {
                case (Direction.NORTH):
                    return new Coordinates(Coordinates.X, Coordinates.Y + 1);
                case (Direction.SOUTH):
                    return new Coordinates(Coordinates.X, Coordinates.Y - 1);
                case (Direction.EAST):
                    return new Coordinates(Coordinates.X + 1, Coordinates.Y);
                case (Direction.WEST):
                    return new Coordinates(Coordinates.X - 1, Coordinates.Y);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Coordinates CoordinatesBehind()
        {
            switch (Direction.Value)
            {
                case (Direction.NORTH):
                    return new Coordinates(Coordinates.X, Coordinates.Y - 1);
                case (Direction.SOUTH):
                    return new Coordinates(Coordinates.X, Coordinates.Y + 1);
                case (Direction.EAST):
                    return new Coordinates(Coordinates.X - 1, Coordinates.Y);
                case (Direction.WEST):
                    return new Coordinates(Coordinates.X + 1, Coordinates.Y);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Position position && Coordinates.Equals(position.Coordinates) && Direction.Equals(position.Direction);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Coordinates != null ? Coordinates.GetHashCode() : 0) * 397) ^ (Direction != null ? Direction.GetHashCode() : 0);
            }
        }
    }
}