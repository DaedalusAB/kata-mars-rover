namespace MarsRover.Commands
{
    public class RoverCommandTurnLeft :RoverCommand
    {
        public RoverCommandTurnLeft(Rover rover) : base(rover)
        {
        }

        public override void Execute()
        {
            _rover.TurnLeft();
        }
    }
}
