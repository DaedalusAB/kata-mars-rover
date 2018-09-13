using MarsRover;

namespace MarsRoverTests
{
    public class GridBuilder
    {
        private int _width;
        private int _hegiht;

        public GridBuilder Width(int width)
        {
            _width = width;
            return this;
        }

        public GridBuilder Height(int height)
        {
            _hegiht = height;
            return this;
        }

        public Grid Build()
        {
            return new Grid(_width, _hegiht);
        }
    }
}