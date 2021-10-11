using FluentValidation.Results;
using MarsRover.Business;
using MarsRover.Business.RoverActions;
using MarsRover.Business.Validations;
using MarsRover.Business.Validators;
using MarsRover.Core;
using MarsRover.Core.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Configure();
            Console.WriteLine("=========================*Welcome*=========================\r\n");
            Console.WriteLine();

            var area = serviceProvider.GetService<IArea>();
            AreaValidator areaValidator = new AreaValidator();
            bool isNewArea = false;

            while (!isNewArea)
            {
                Console.WriteLine("Please enter area coordinates (Format. {Lenght} {Height})");
                var coordinatesInput = Console.ReadLine();
                area.Create(coordinatesInput);
                var valid = areaValidator.Validate(area);
                if (valid.IsValid)
                {
                    isNewArea = true;
                }
                else
                {
                    Console.WriteLine($"{valid.Errors[0].ErrorMessage}\r\n");
                }
            }

            bool addNewRover = false;
            var roverPosition = serviceProvider.GetService<IRoverPosition>();
            RoverPositionValidator roverPositionValidator = new RoverPositionValidator(area);

            do
            {
                Console.WriteLine("Please enter rover coordinates and Direction (Format. {xPosition} {yPosition} {Direction)");
                var roverPositionInput = Console.ReadLine();
                roverPosition.Create(roverPositionInput);
                ValidationResult roverPositionValidationResult = roverPositionValidator.Validate(roverPosition);

                if (!roverPositionValidationResult.IsValid)
                {
                    Console.WriteLine($"{roverPositionValidationResult.Errors[0].ErrorMessage}\r\n");
                    continue;
                }

                bool hasDirection = false;
                IRoverDirection roverDirection;
                ActionValidator actionValidator = new ActionValidator();

                while (!hasDirection)
                {
                    Console.WriteLine("Please enter rover Directions (Format. {Direction1}{Direction2}{Direction3}..)");
                    var directionInput = Console.ReadLine();

                    char[] roverActions = directionInput.ToUpper().ToCharArray();
                    ValidationResult actionValidationResult = actionValidator.Validate(directionInput);
                    if (!actionValidationResult.IsValid)
                    {
                        Console.WriteLine($"{actionValidationResult.Errors[0].ErrorMessage}\r\n");
                        continue;
                    }

                    hasDirection = true;
                    foreach (var item in directionInput)
                    {
                        roverDirection = RoverAction.RoverDirection(roverPosition);
                        InputAction action = (InputAction)Enum.Parse(typeof(InputAction), item.ToString());
                        switch (action)
                        {
                            case InputAction.M:
                                {
                                    roverPosition = roverDirection.MoveForward();
                                    break;
                                }
                            case InputAction.L:
                                {
                                    roverPosition = roverDirection.TurnLeft();
                                    break;
                                }
                            case InputAction.R:
                                {
                                    roverPosition = roverDirection.TurnRight();
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                Console.WriteLine("Rover last position and direction");
                Console.WriteLine($"{roverPosition.X} " +
                     $"{roverPosition.Y} " +
                     $"{roverPosition.Direction}");

                Console.WriteLine("Are you want add new Rover? (Y)");
                addNewRover = !(Console.ReadLine().ToUpper() == "Y");
            }
            while (!addNewRover);
        }
        static IServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IRoverPosition, RoverPosition>();
            services.AddTransient<IArea, Area>();

            return services.BuildServiceProvider();
        }
    }
}
