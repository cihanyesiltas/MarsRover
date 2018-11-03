using System;
using MarsRover.Infrastructure;
using MarsRover.Infrastructure.Contracts;
using MarsRover.Infrastructure.DTOs;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Plateau upper coordinate..");
                var plateauCoordinateInput = Console.ReadLine();
                var plateau = new Plateau(plateauCoordinateInput);

                Console.WriteLine("Enter first rover position..");
                var firstRoverPositionInput = Console.ReadLine();

                ICommandFactory commandFactory = new CommandFactory();
                var firstRover = new Rover(plateau, commandFactory);

                firstRover.SetPosition(new SetPositionDTO { PositionLetter = firstRoverPositionInput });

                Console.WriteLine("Enter first rover commands..");
                var firstRoverCommandsInput = Console.ReadLine();

                firstRover.RunCommandList(new RunCommandListDTO { CommandLetters = firstRoverCommandsInput });

                Console.WriteLine("Enter second rover position..");
                var secondRoverPositionInput = Console.ReadLine();

                var secondRover = new Rover(plateau, commandFactory);
                secondRover.SetPosition(new SetPositionDTO { PositionLetter = secondRoverPositionInput });

                Console.WriteLine("Enter second rover commands..");
                var secondRoverCommandsInput = Console.ReadLine();

                secondRover.RunCommandList(new RunCommandListDTO { CommandLetters = secondRoverCommandsInput });

                Console.WriteLine("Output:");
                Console.WriteLine(firstRover.GetPosition());
                Console.WriteLine(secondRover.GetPosition());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
            }

            Console.WriteLine("Press enter any key to exit..");
            Console.ReadKey();
        }
    }
}
