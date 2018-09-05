namespace MarsRover.Commands
{
    public class RoverCommandBackwards : RoverCommand
    {
        public RoverCommandBackwards(Rover rover) : base(rover)
        {
        }

        public override bool Execute()
        {            
           return Rover.MoveBackwards();
        }
    }
}
