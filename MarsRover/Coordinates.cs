using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Coordinates : ValueObject
    {
        public int X { get; }
        public int Y { get; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return X;
            yield return Y;
        }

        public Coordinates Translate(int dx, int maxX, int dy, int maxY)
        {
            var newX = (X + dx + maxX) % maxX;
            var newY = (Y + dy + maxY) % maxY;

            return new Coordinates(newX, newY);
        }
    }
}