namespace MarsRover.Commands
{
    public abstract class RoverCommand
    {
        protected Rover Rover { get; }

        protected RoverCommand(Rover rover)
        {
            Rover = rover;
        }

        public abstract bool Execute();
    }
}
