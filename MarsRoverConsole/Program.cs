using System;
using System.Collections.Generic;
using MarsRover;
using MarsRover.Positioning;

namespace MarsRoverConsole
{
    class Program
    {
        private static Dictionary<ConsoleKey, string> commandDecoder = new Dictionary<ConsoleKey, string>()
        {
            { ConsoleKey.UpArrow, "f"},
            { ConsoleKey.DownArrow, "b"},
            { ConsoleKey.LeftArrow, "l"},
            { ConsoleKey.RightArrow, "r"}
        };

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
            if (command == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            if (!commandDecoder.ContainsKey(command))
            {
                return;
            }

            roverControl.SendCommands(commandDecoder[command]);
            roverControl.InvokeCommands();
        }
    }
}
