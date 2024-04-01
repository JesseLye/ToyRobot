using ToyRobotLibrary.BusinessLogic;
using ToyRobotLibrary.Enums;

namespace ToyRobotTests
{
    [TestClass]
    public class TestSimulator
    {
        [TestMethod]
        public void PlaceRobot()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.Place(0, 0, Direction.North);

            Assert.AreEqual("0,0,North", simulator.Report());
        }

        [TestMethod]
        public void MoveRobot()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.Place(0, 0, Direction.North);
            simulator.Move();

            Assert.AreEqual("0,1,North", simulator.Report());
        }

        [TestMethod]
        public void TurnRobot()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.Place(0, 0, Direction.North);
            simulator.TurnLeft();

            Assert.AreEqual("0,0,West", simulator.Report());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Robot Not Placed")]
        public void TurnLeftWithoutPlacing()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.TurnLeft();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Robot Not Placed")]
        public void TurnRightWithoutPlacing()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.TurnRight();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Robot Not Placed")]
        public void MoveWithoutPlacing()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.Move();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Robot Not Placed")]
        public void ReportWithoutPlacing()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.Report();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Coordinates")]
        public void PlaceOutsideTable()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            simulator.Place(10, 10, Direction.North);
        }
    }
}
