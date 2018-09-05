namespace MarsRover.Commands
{
    public class RoverCommandTurnLeft :RoverCommand
    {
        public RoverCommandTurnLeft(Rover rover) : base(rover)
        {
        }

        public override bool Execute()
        {
            return Rover.TurnLeft();
        }
    }
}
