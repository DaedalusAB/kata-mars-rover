using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Positioning
{
    public class Grid : IEquatable<Grid>
    {
        public int Height { get; }
        public int Width { get; }
        public List<Coordinates> Obstacles { get; }

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            Obstacles = new List<Coordinates>();
        }

        public void AddObstacle(Coordinates coordinates) =>
            Obstacles.Add(coordinates);


        public bool HasObstacle(Coordinates coordinates) =>
            Obstacles.Any(o => o.Equals(coordinates));

        public bool Equals(Grid other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Height == other.Height && Width == other.Width && Obstacles.SequenceEqual(other.Obstacles);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Grid) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Height;
                hashCode = (hashCode * 397) ^ Width;
                hashCode = (hashCode * 397) ^ (Obstacles != null ? Obstacles.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
