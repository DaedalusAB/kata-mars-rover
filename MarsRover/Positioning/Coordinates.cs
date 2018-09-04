﻿using System;

namespace MarsRover.Positioning
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) =>
            obj is Coordinates coordinates && X == coordinates.X && Y == coordinates.Y;


        public override int GetHashCode() =>
            throw new NotImplementedException();
    }
}