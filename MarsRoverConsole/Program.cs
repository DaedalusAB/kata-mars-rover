using System;
using MarsRover;
using MarsRover.Positioning;

namespace MarsRoverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(height: 20, width: 20);
            grid.AddRandomObstacles(30);

            var position = new Position(0, 0, DirectionEnum.North, grid);
            var rover = new ConsoleRover(position);
            var roverControl = new RoverControl(rover);


            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Write(rover.DisplaySensorData());
                var inputKey = Console.ReadKey().Key;
                InvokeCommand(inputKey, roverControl);
                Console.Clear();
            }
        }

        private static void InvokeCommand(ConsoleKey command, RoverControl roverControl)
        {
            switch (command)
            {
                case (ConsoleKey.UpArrow):
                    roverControl.SendCommands("f");
                    break;
                case(ConsoleKey.DownArrow):
                    roverControl.SendCommands("b");
                    break;
                case (ConsoleKey.LeftArrow):
                    roverControl.SendCommands("l");
                    break;
                case (ConsoleKey.RightArrow):
                    roverControl.SendCommands("r");
                    break;
                default:
                    return;
            }
            roverControl.InvokeCommands();
        }
    }
}
