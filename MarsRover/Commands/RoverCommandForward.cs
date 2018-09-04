namespace MarsRover.Commands
{
    public class RoverCommandForward : RoverCommand
    {
        public RoverCommandForward(Rover rover) : base(rover)
        {
        }

        public override bool Execute()
        {
            return _rover.MoveForward();
        }
    }
}
