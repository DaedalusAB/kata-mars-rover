namespace MarsRover
{
    public class Rover
    {
        public Position Position { get; set; }

        public Rover()
        {
            Position = new Position(0, 0, DirectionEnum.North);
        }

        public Rover(Position position)
        {
            Position = position;
        }
    }
}
