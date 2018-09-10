using MarsRover.Positioning;

namespace MarsRover
{
    public class Rover
    {
        public Position Position { get; set; }
        
        public Rover(Position position)
        {
            Position = position;
        }

        public bool CanMoveForward() =>
            !Position.HasObstacleInFront();

        public bool CanMoveBackwards() =>
            !Position.HasObstacleBehind();

        public bool MoveForward()
        {
            if (CanMoveForward())
            {
                Position = Position.PositionInFront();
            }

            return CanMoveForward();
        }

        public bool MoveBackwards()
        {
            if (CanMoveBackwards())
            {
                Position = Position.PositionBehind();
            }

            return CanMoveBackwards();
        }

        public bool TurnRight()
        {
            Position = Position.TurnRight();
            return true;
        }


        public bool TurnLeft()
        {
            Position = Position.TurnLeft();
            return true;
        }
    }
}
