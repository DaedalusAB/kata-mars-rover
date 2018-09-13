using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Coordinates : ValueObject
    {
        public int X { get; }
        public int Y { get; }
        public Grid Grid { get; }

        public Coordinates(int x, int y, Grid grid)
        {
            X = x;
            Y = y;
            Grid = grid;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return X;
            yield return Y;
        }

        public Coordinates Translate(int dx, int dy)
        {
            var newX = (X + dx + Grid.Width) % Grid.Width;
            var newY = (Y + dy + Grid.Height) % Grid.Height;

            return new Coordinates(newX, newY, Grid);
        }
    }
}