using System;
using System.Text;
using MarsRover.Positioning;

namespace MarsRoverConsole
{
    public static class PosititonExtensions
    {
        public static string DisplayAsString(this Position position)
        {
            var gridDisplay = position.Grid.ToDisplayFormat();
            gridDisplay[position.Coordinates.Y][position.Coordinates.X] = position.DisplayRover();

            var sb = new StringBuilder();

            for (var i = gridDisplay.Length - 1; i >= 0; i--)
            {
                var line = gridDisplay[i];

                sb.Append(gridDisplay[i]);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
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
