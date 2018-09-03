using System;

namespace MarsRover
{
    public class Position
    {
        public Coordinates Coordinates { get; set; }
        public DirectionEnum Direction { get; set; }

        public Position(int x, int y, DirectionEnum direction)
        {
            Coordinates = new Coordinates(x, y);
            Direction = direction;
        }

        public Coordinates CoordinatesInFront()
        {
            switch (Direction)
            {
                case (DirectionEnum.North):
                    return new Coordinates(Coordinates.X, Coordinates.Y + 1);
                case (DirectionEnum.South):
                    return new Coordinates(Coordinates.X, Coordinates.Y - 1);
                case (DirectionEnum.East):
                    return new Coordinates(Coordinates.X + 1, Coordinates.Y);
                case (DirectionEnum.West):
                    return new Coordinates(Coordinates.X - 1, Coordinates.Y);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Coordinates CoordinatesBehind()
        {
            switch (Direction)
            {
                case (DirectionEnum.North):
                    return new Coordinates(Coordinates.X, Coordinates.Y - 1);
                case (DirectionEnum.South):
                    return new Coordinates(Coordinates.X, Coordinates.Y + 1);
                case (DirectionEnum.East):
                    return new Coordinates(Coordinates.X - 1, Coordinates.Y);
                case (DirectionEnum.West):
                    return new Coordinates(Coordinates.X + 1, Coordinates.Y);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Position position && Coordinates.Equals(position.Coordinates) && Direction == position.Direction;
        }

        protected bool Equals(Position other)
        {
            return Equals(Coordinates, other.Coordinates) && Direction == other.Direction;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Coordinates != null ? Coordinates.GetHashCode() : 0) * 397) ^ (int)Direction;
            }
        }
    }
}