namespace MarsRover.Commands
{
    public class RoverCommandForward : RoverCommand
    {
        public RoverCommandForward(Rover rover) : base(rover)
        {
        }

        public override void Execute()
        {
            _rover.MoveForward();
        }
    }
}
