namespace MarsRover.Commands
{
    public class RoverCommandTurnRight : RoverCommand
    {
        public RoverCommandTurnRight(Rover rover) : base(rover)
        {
        }

        public override bool Execute()
        {
            return Rover.TurnRight();
        }
    }
}
