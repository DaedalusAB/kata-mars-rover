using System;

namespace MarsRover.Positioning
{
    public class Position
    {
        public Coordinates Coordinates { get; set; }
        public Direction Direction { get; set; }

        public Grid Grid { get; }

        public Position(int x, int y, DirectionEnum direction, Grid grid)
        {
            Grid = grid;
            Coordinates = new Coordinates(x, y);
            Direction = new Direction(direction);
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

        public override bool Equals(object obj) => 
            obj is Position position && Coordinates.Equals(position.Coordinates) && Direction.Equals(position.Direction);
        
        public override int GetHashCode() =>
            throw new NotImplementedException();

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