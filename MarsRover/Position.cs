namespace MarsRover
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }
        public DirectionEnum Direction { get; }

        public Position(int x, int y, DirectionEnum direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position && (X == position.X && Y == position.Y && Direction == position.Direction);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ (int)Direction;
                return hashCode;
            }
        }
    }
}