using System;

namespace ToyRobotSimulator.Core
{
    public class Robot
    {

        public const string OUT_OF_BOUNDARY_MESSAGE = "Command ignored - out of table boundary";
        public const string NOT_PLACED_YET_MESSAGE = "Command ignored - robot not placed yet";
        public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Command ignored - robot did not understand this command";
        public const string INVALID_COMMANDS_MESSAGE = "Error during reading command.\nValid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";

        private bool isPlaced = false;
        private int xLowerLimit = 0;
        private int yLowerLimit = 0;
        private int xUpperLimit = -1;
        private int yUpperLimit = -1;
       
        private int xCoordinate = -1;
        private int yCoordinate = -1;
        private string direction = string.Empty;
        

        // Provided table size 6,6
        public Robot()
        {
            xUpperLimit = 6;
            yUpperLimit = 6;
        }

        // Custom table size if supplied
        public Robot(int tableSizeX, int tableSizeY)
        {
            xUpperLimit = tableSizeX;
            yUpperLimit = tableSizeY;
        }

        private bool validatePosition()
        {
            if ((xCoordinate < xLowerLimit) || (yCoordinate < yLowerLimit))
                return false;
            else if ((xCoordinate > xUpperLimit) || (yCoordinate > yUpperLimit))
                return false;
            else
                return true;
        }

        private string place(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] wordsInCommand = command.Split(delimiterChars);

            xCoordinate = Int32.Parse(wordsInCommand[1]);
            yCoordinate = Int32.Parse(wordsInCommand[2]);
            direction = wordsInCommand[3];

            if (!validatePosition())
                result = OUT_OF_BOUNDARY_MESSAGE;
            else
                isPlaced = true;

            return result;
        }

        private string report()
        {
            return xCoordinate + "," + yCoordinate + "," + direction;
        }

        private string move()
        {
            string result = string.Empty;
            int originalX = this.xCoordinate;
            int originalY = this.yCoordinate;

            switch (direction)
            {
                case "NORTH":
                    yCoordinate++; break;
                case "WEST":
                    xCoordinate--; break;
                case "SOUTH":
                    yCoordinate--; break;
                case "EAST":
                    xCoordinate++; break;
            }

            if (!validatePosition())
            {
                xCoordinate = originalX;
                yCoordinate = originalY;
                result = OUT_OF_BOUNDARY_MESSAGE;
            }
            return result;
        }

        private void left()
        {
            switch (direction)
            {
                case "NORTH":
                    direction = "WEST"; break;
                case "WEST":
                    direction = "SOUTH"; break;
                case "SOUTH":
                    direction = "EAST"; break;
                case "EAST":
                    direction = "NORTH"; break;
            }
        }

        private void right()
        {
            switch (direction)
            {
                case "NORTH":
                    direction = "EAST"; break;
                case "EAST":
                    direction = "SOUTH"; break;
                case "SOUTH":
                    direction = "WEST"; break;
                case "WEST":
                    direction = "NORTH"; break;
            }
        }

        public string command(string input)
        {
            string command = input.ToUpper();
            string result = string.Empty;

            try
            {
                if (command.Contains("PLACE"))
                    result = place(command);

                else if (!isPlaced)
                    result = NOT_PLACED_YET_MESSAGE;

                else if (command.Contains("REPORT"))
                    result = report();

                else if (command.Contains("MOVE"))
                    result = move();

                else if (command.Contains("LEFT"))
                    left();

                else if (command.Contains("RIGHT"))
                    right();

                else
                    result = COMMAND_NOT_RECOGNISED_MESSAGE;
            }
            catch (Exception e)
            {
                result = INVALID_COMMANDS_MESSAGE;
            }

            return result;
        }
    }
}
