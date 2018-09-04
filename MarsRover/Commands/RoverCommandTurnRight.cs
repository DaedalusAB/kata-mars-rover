namespace MarsRover.Commands
{
    public class RoverCommandTurnRight : RoverCommand
    {
        public RoverCommandTurnRight(Rover rover) : base(rover)
        {
        }

        public override void Execute()
        {
            _rover.TurnRight();
        }
    }
}
