using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public static class StringExtensions
    {
        public static List<Command> GetCommands(this IEnumerable<char> input)
        {
            return input.Select(c => new Command(c)).ToList();
        }
    }
}
