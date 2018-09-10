using System;

namespace MarsRover.Positioning
{
    public class Position : IEquatable<Position>
    {
        public Coordinates Coordinates { get; set; }
        public Direction Direction { get; set; }
        private Grid Grid { get; }

        public Position(Coordinates coordinates, Direction direction, Grid grid)
        {
            Grid = grid;
            Coordinates = coordinates;
            Direction = direction;
        }

        public bool HasObstacleInFront() =>
            Grid.HasObstacle(CoordinatesInFront());

        public bool HasObstacleBehind() =>
            Grid.HasObstacle(CoordinatesBehind());

        public Coordinates CoordinatesInFront()
        {
            switch (Direction.Value)
            {
                case (DirectionEnum.North):
                    return CoordinatesNorth();
                case (DirectionEnum.South):
                    return CoordinatesSouth();
                case (DirectionEnum.East):
                    return CoordinatesEast();
                case (DirectionEnum.West):
                    return CoordinatesWest();
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction.Value));
            }
        }

        public Coordinates CoordinatesBehind()
        {
            switch (Direction.Value)
            {
                case (DirectionEnum.North):
                    return CoordinatesSouth();
                case (DirectionEnum.South):
                    return CoordinatesNorth();
                case (DirectionEnum.East):
                    return CoordinatesWest();
                case (DirectionEnum.West):
                    return CoordinatesEast();
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction.Value));
            }
        }
        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Coordinates.Equals(other.Coordinates) && Direction.Equals(other.Direction) && Grid.Equals(other.Grid);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Coordinates != null ? Coordinates.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Direction != null ? Direction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Grid != null ? Grid.GetHashCode() : 0);
                return hashCode;
            }
        }

        private Coordinates CoordinatesNorth() =>
            Grid.Height > Coordinates.Y + 1
                ? new Coordinates(Coordinates.X, Coordinates.Y + 1)
                : new Coordinates(Coordinates.X, 0);

        private Coordinates CoordinatesSouth() =>
            Coordinates.Y - 1 >= 0
                ? new Coordinates(Coordinates.X, Coordinates.Y - 1)
                : new Coordinates(Coordinates.X, Grid.Height - 1);

        private Coordinates CoordinatesEast() =>
            Grid.Width > Coordinates.X + 1
                ? new Coordinates(Coordinates.X + 1, Coordinates.Y)
                : new Coordinates(0, Coordinates.Y);

        private Coordinates CoordinatesWest() =>
            Coordinates.X - 1 >= 0
                ? new Coordinates(Coordinates.X - 1, Coordinates.Y)
                : new Coordinates(Grid.Width - 1, Coordinates.Y);
    }
}