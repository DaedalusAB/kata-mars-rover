﻿using MarsRover;

namespace MarsRoverTests
{
    public class PositionBuilder
    {
        private Coordinates _coordinates = new Coordinates(0, 0, new Grid(2, 2));
        private Direction _direction = new Direction(DirectionEnum.North);
        private Grid _grid = new Grid(2, 2);

        public PositionBuilder At(int x, int y)
        {
            _coordinates = new Coordinates(x, y, _grid);
            return this;
        }

        public PositionBuilder Facing(DirectionEnum direction)
        {
            _direction = new Direction(direction);
            return this;
        }

        public PositionBuilder On(Grid grid)
        {
            _grid = grid;
            return this;
        }

        public Position Build()
        {
            return new Position(_coordinates, _direction, _grid);
        }
    }
}