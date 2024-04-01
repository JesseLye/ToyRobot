using ToyRobotLibrary.BusinessLogic;
using ToyRobotLibrary.Enums;

namespace ToyRobotTests
{
    [TestClass]
    public class TestRobot
    {
        [TestMethod]
        public void MoveEast()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.East);
            var coordinates = robot.CalculateNewMovement();
            robot.Place(coordinates.X, coordinates.Y, coordinates.Direction);

            Assert.AreEqual(1, robot.X);
            Assert.AreEqual(0, robot.Y);
            Assert.AreEqual(Direction.East, robot.Direction);
        }

        [TestMethod]
        public void MoveWest()
        {
            var robot = new Robot();
            robot.Place(2, 0, Direction.West);
            var coordinates = robot.CalculateNewMovement();
            robot.Place(coordinates.X, coordinates.Y, coordinates.Direction);

            Assert.AreEqual(1, robot.X);
            Assert.AreEqual(0, robot.Y);
            Assert.AreEqual(Direction.West, robot.Direction);
        }

        [TestMethod]
        public void MoveNorth()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.North);
            var coordinates = robot.CalculateNewMovement();
            robot.Place(coordinates.X, coordinates.Y, coordinates.Direction);

            Assert.AreEqual(0, robot.X);
            Assert.AreEqual(1, robot.Y);
            Assert.AreEqual(Direction.North, robot.Direction);
        }

        [TestMethod]
        public void MoveSouth()
        {
            var robot = new Robot();
            robot.Place(0, 2, Direction.South);
            var coordinates = robot.CalculateNewMovement();
            robot.Place(coordinates.X, coordinates.Y, coordinates.Direction);

            Assert.AreEqual(0, robot.X);
            Assert.AreEqual(1, robot.Y);
            Assert.AreEqual(Direction.South, robot.Direction);
        }

        [TestMethod]
        public void Report()
        {
            var robot = new Robot();
            robot.Place(2, 2, Direction.East);

            Assert.AreEqual("2,2,East", robot.Report());
        }
    }
}
