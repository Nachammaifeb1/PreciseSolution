using NUnit.Framework;
using ToyRobotSimulator.Core;

namespace ToyRobotSimulator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Robot_CommandNotPlacedYet()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("REPORT");
            //assert
            Assert.AreEqual(Robot.NOT_PLACED_YET_MESSAGE, result);
        }

        [Test]
        public void Robot_CommandReturnEmptyAfterPlaced()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Robot_Report_AfterPlaced()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,NORTH", result);
        }

        // -------------- Test movements --------------------------------------------
        [Test]
        public void Robot_Report_N_SingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,1,NORTH", result);
        }

        [Test]
        public void Robot_Report_E_SingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,EAST");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("1,0,EAST", result);
        }

        [Test]
        public void Robot_Report_S_SingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,1,SOUTH");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("1,0,SOUTH", result);
        }

        [Test]
        public void Robot_Report_W_SingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,1,WEST");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,1,WEST", result);
        }

        // -------------- Test left direction --------------------------------------------
        [Test]
        public void Robot_Report_N_LeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }

        [Test]
        public void Robot_Report_W_LeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,WEST");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,SOUTH", result);
        }

        [Test]
        public void Robot_Report_S_LeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,SOUTH");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,EAST", result);
        }

        [Test]
        public void Robot_Report_E_LeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,EAST");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,NORTH", result);
        }

        // -----------------------Test right direction -------------------------------------------------------
        [Test]
        public void Robot_Report_N_RightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,EAST", result);
        }
        [Test]
        public void Robot_Report_E_RightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,EAST");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,SOUTH", result);
        }
        [Test]
        public void Robot_Report_S_RightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,SOUTH");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }
        [Test]
        public void Robot_Report_W_RightCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,WEST");
            result = robot.command("RIGHT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,NORTH", result);
        }

        // -------------- Test robot table edges on placement ------------------------------
        [Test]
        public void Robot_NegativeXCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE -1,0,WEST");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }
        [Test]
        public void Robot_NegativeYCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,-1,WEST");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }
        [Test]
        public void Robot_UpperLimitX()
        {
            //arrange
            Robot robot = new Robot(5, 5);
            //act
            string result = robot.command("PLACE 6,5,WEST");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }
        [Test]
        public void Robot_UpperLimitY()
        {
            //arrange
            Robot robot = new Robot(5, 5);
            //act
            string result = robot.command("PLACE 5,6,WEST");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }

        // -------------- Test robot boundaries on movement ------------------------
        [Test]
        public void Robot_AfterMove_NegativeXCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,WEST");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }
        [Test]
        public void Robot_AfterMove_NegativeYCoordinate()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,SOUTH");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }
        [Test]
        public void Robot_AfterMove_UpperLimitXCoordinate()
        {
            //arrange
            Robot robot = new Robot(1, 1);
            //act
            string result = robot.command("PLACE 0,0,EAST");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }
        [Test]
        public void Robot_IgnoreCommand_AfterMove_UpperLimitYCoordinate()
        {
            //arrange
            Robot robot = new Robot(1, 1);
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDARY_MESSAGE, result);
        }

        // -------------- Sample tests provided ------------------------
        [Test]
        public void ProvidedTest_A()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,1,NORTH", result);
        }
        [Test]
        public void ProvidedTest_B()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }
        [Test]
        public void ProvidedTest_C()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,2,EAST");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            result = robot.command("LEFT");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("3,3,NORTH", result);
        }

        [Test]
        public void ProvidedTest_D()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,2,EAST");
            result = robot.command("MOVE");
            result = robot.command("LEFT");
            result = robot.command("MOVE");
            result = robot.command("PLACE 3,1");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("3,2,NORTH", result);
        }

        // -------------- Test wrong command ------------------------
        [Test]
        public void Robot_WrongCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,2,EAST");
            result = robot.command("TELSTRA PURPLE");
            //assert
            Assert.AreEqual(Robot.COMMAND_NOT_RECOGNISED_MESSAGE, result);
        }


    }
}
