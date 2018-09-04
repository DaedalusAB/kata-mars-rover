namespace MarsRover.Commands
{
    public class RoverCommandBackwards : RoverCommand
    {
        public RoverCommandBackwards(Rover rover) : base(rover)
        {
        }

        public override void Execute()
        {
           _rover.MoveBackwards();
        }
    }
}
