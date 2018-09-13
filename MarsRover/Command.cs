using System;
using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Command : ValueObject
    {
        public static Command ForwardCommand = new Command('f');
        public static Command BackwardCommand = new Command('b');
        public static Command TurnRight = new Command('r');
        public static Command TurnLeft = new Command('l');

        public char Value { get; }

        public Command(char value)
        {
            Value = char.ToLower(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}