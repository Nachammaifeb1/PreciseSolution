using System;
using ToyRobotSimulator.Core;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;

            Robot robot = new Robot();

            Console.WriteLine("Hi! I am Toy Robot Simulator!! Enter commands to operate me!!! Press X at any time to quit.");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("X"))
                    break;

                Console.WriteLine(robot.command(inputCommand));
                Console.WriteLine();
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}
