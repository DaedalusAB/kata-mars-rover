namespace MarsRover
{
    public abstract class RoverCommand
    {
        protected Rover _rover;

        protected RoverCommand(Rover rover)
        {
            _rover = rover;
        }

        public abstract void Execute();
    }
}
