using System;
using System.Text;

namespace MarsRover.Positioning
{
    public class Position : IEquatable<Position>
    {
        private Coordinates Coordinates { get; }
        private Direction Direction { get; }
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

        public Position PositionInFront()
        {
            return new Position(CoordinatesInFront(), Direction, Grid);
        }

        public Position PositionBehind()
        {
            return new Position(CoordinatesBehind(), Direction, Grid);
        }

        public Position TurnRight()
        {
            return new Position(Coordinates, Direction.TurnRight(), Grid);
        }

        public Position TurnLeft()
        {
            return new Position(Coordinates, Direction.TurnLeft(), Grid);
        }

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

        public string ToDisplayFormat()
        {
            var gridDisplay = Grid.ToDisplayFormat();
            gridDisplay[Coordinates.Y][Coordinates.X] = DisplayRover();

            var sb = new StringBuilder();

            for (var i = gridDisplay.Length - 1; i >= 0; i--)
            {
                sb.Append(gridDisplay[i]);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
        private char DisplayRover()
        {
            switch (Direction.Value)
            {
                case (DirectionEnum.North): return '↑';
                case (DirectionEnum.South): return '↓';
                case (DirectionEnum.East): return '→';
                case (DirectionEnum.West): return '←';
                default: return '?';
            }
        }

        private Coordinates CoordinatesNorth() =>
            new Coordinates(Coordinates.X, (Coordinates.Y + 1 + Grid.Height) % Grid.Height);

        private Coordinates CoordinatesSouth() =>
            new Coordinates(Coordinates.X, (Coordinates.Y - 1 + Grid.Height) % Grid.Height);

        private Coordinates CoordinatesEast() =>
            new Coordinates((Coordinates.X + 1 + Grid.Width) % Grid.Width, Coordinates.Y);

        private Coordinates CoordinatesWest() =>
                new Coordinates((Coordinates.X - 1 + Grid.Width) % Grid.Width, Coordinates.Y);
    }
}