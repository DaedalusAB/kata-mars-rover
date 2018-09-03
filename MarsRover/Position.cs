namespace MarsRover
{
    public class Position
    {
        private readonly int _x;
        private readonly int _y;
        private readonly DirectionEnum _direction;

        public Position(int x, int y, DirectionEnum direction)
        {
            _x = x;
            _y = y;
            _direction = direction;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position && (_x == position._x && _y == position._y && _direction == position._direction);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _x;
                hashCode = (hashCode * 397) ^ _y;
                hashCode = (hashCode * 397) ^ (int) _direction;
                return hashCode;
            }
        }
    }
}