using System;

namespace MarsRover.Positioning
{
    public class Position
    {
        public Coordinates Coordinates { get; set; }
        public Direction Direction { get; set; }

        public Position(int x, int y, DirectionEnum direction)
        {
            Coordinates = new Coordinates(x, y);
            Direction = new Direction(direction);
        }

        public Coordinates CoordinatesInFront(Grid grid)
        {
            switch (Direction.Value)
            {
                case (DirectionEnum.North):
                    return grid.Height > Coordinates.Y + 1
                            ? new Coordinates(Coordinates.X, Coordinates.Y + 1)
                            : new Coordinates(Coordinates.X, 0);
                case (DirectionEnum.South):
                    return Coordinates.Y - 1 >= 0
                            ? new Coordinates(Coordinates.X, Coordinates.Y - 1)
                            : new Coordinates(Coordinates.X, grid.Height - 1);
                case (DirectionEnum.East):
                    return grid.Width > Coordinates.X + 1
                            ? new Coordinates(Coordinates.X + 1, Coordinates.Y)
                            : new Coordinates(0, Coordinates.Y);
                case (DirectionEnum.West):
                    return Coordinates.X - 1 >= 0
                            ? new Coordinates(Coordinates.X - 1, Coordinates.Y)
                            : new Coordinates(0, Coordinates.Y);
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction.Value));
            }
        }

        public Coordinates CoordinatesBehind(Grid grid)
        {
            switch (Direction.Value)
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
                    throw new ArgumentOutOfRangeException(nameof(Direction.Value));
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