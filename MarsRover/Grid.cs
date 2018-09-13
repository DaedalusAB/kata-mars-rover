using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Grid : ValueObject
    {
        public int Width { get; }
        public int Height { get; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Width;
            yield return Height;
        }
    }
}