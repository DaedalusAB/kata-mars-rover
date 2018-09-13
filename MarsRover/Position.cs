﻿using System;
using System.Collections.Generic;
using MarsRover.Helpers;

namespace MarsRover
{
    public class Position : ValueObject
    {
        private Coordinates Coordinates { get; }
        private Direction Direction { get; }
        public Grid Grid { get; }

        public Position(Coordinates coordinates, Direction direction, Grid grid)
        {
            Coordinates = coordinates;
            Direction = direction;
            Grid = grid;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Coordinates;
            yield return Direction;
            yield return Grid;
        }

        public Position InFront()
        {
            return Translate(CoordinatesChangeByDirection().dx, CoordinatesChangeByDirection().dy);
        }

        public Position Behind()
        {
            return Translate(CoordinatesChangeByDirection().Item1 * -1, CoordinatesChangeByDirection().Item2 * -1);
        }

        public Position TurnRight()
        {
           return new Position(Coordinates, Direction.TurnRight(), Grid);
        }

        public Position TurnLeft()
        {
            return new Position(Coordinates, Direction.TurnLeft(), Grid);
        }

        private Position Translate(int dx, int dy)
        {
            return new Position(Coordinates.Translate(dx, Grid.Width, dy, Grid.Height), Direction, Grid);
        }

        private (int dx, int dy) CoordinatesChangeByDirection()
        {
            if (Direction == Direction.North)
                return (0, 1);
            if (Direction == Direction.East)
                return (1, 0);
            if (Direction == Direction.South)
                return (0, -1);
            if (Direction == Direction.West)
                return (-1, 0);

            throw new ArgumentOutOfRangeException(nameof(Direction));
        }
    }
}