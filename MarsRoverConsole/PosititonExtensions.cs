using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Positioning;

namespace MarsRoverConsole
{
    public static class PosititonExtensions
    {
        public static string DisplayAsString(this Position position, List<Coordinates> discoveredObstacles)
        {
            var gridDisplay = position.Grid.ToDisplayFormat(discoveredObstacles);
            gridDisplay[position.Coordinates.Y][position.Coordinates.X] = position.DisplayRover();

            var sb = new StringBuilder();

            for (var i = gridDisplay.Length - 1; i >= 0; i--)
            {
                sb.Append(gridDisplay[i]);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public static List<Coordinates> CoordinatesesAround(this Position position)
        {
            var result = new List<Coordinates>(8);
            for (var dx = -1; dx <= 1; ++dx)
            {
                for (var dy = -1; dy <= 1; ++dy)
                {
                    if (dx != 0 || dy != 0)
                    {
                        result.Add(
                            new Coordinates(
                                (position.Coordinates.X + dx + position.Grid.Width) % position.Grid.Width,
                                (position.Coordinates.Y + dy + position.Grid.Height) % position.Grid.Height
                                        ));
                    }
                }
            }

            return result;
        }

        private static char DisplayRover(this Position position)
        {
            switch (position.Direction.Value)
            {
                case (DirectionEnum.North): return '↑';
                case (DirectionEnum.South): return '↓';
                case (DirectionEnum.East): return '→';
                case (DirectionEnum.West): return '←';
                default: return '?';
            }
        }
    }
}
