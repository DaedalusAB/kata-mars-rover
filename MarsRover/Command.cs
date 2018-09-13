using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Command : ValueObject
    {
        public static Command ForwardCommand = new Command('f');

        public char Value { get; }

        public Command(char value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}