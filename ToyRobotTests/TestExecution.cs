using ToyRobotLibrary.BusinessLogic;

namespace ToyRobotTests
{
    [TestClass]
    public class TestExecution
    {
        [TestMethod]
        public void ValidCommand()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            var execution = new Execution(simulator);
            var commands = new List<string>()
            {
                "PLACE 0,2,EAST",
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "RIGHT",
                "PLACE 3,3,SOUTH",
                "REPORT"
            };

            execution.Execute(commands);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Invalid 'PLACE' Argument")]
        public void InvalidPlace()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            var execution = new Execution(simulator);
            var commands = new List<string>()
            {
                "PLACE 0,2,INVALID"
            };

            execution.Execute(commands);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Invalid 'PLACE' Argument Length")]
        public void InvalidPlaceLength()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            var execution = new Execution(simulator);
            var commands = new List<string>()
            {
                "PLACE 0,2,INVALID,INVALID,INVALID,INVALID"
            };

            execution.Execute(commands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "'PLACE' Command Not Found")]
        public void NoPlace()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            var execution = new Execution(simulator);
            var commands = new List<string>()
            {
                "MOVE",
                "MOVE",
                "MOVE",
                "REPORT"
            };

            execution.Execute(commands);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void InvalidCommand()
        {
            var simulator = new Simulator(new Table(5, 5), new Robot());
            var execution = new Execution(simulator);
            var commands = new List<string>()
            {
                "PLACE 0,2,EAST",
                "MOVE",
                "MOVE",
                "WHAT'S THIS?",
                "MOVE"
            };

            execution.Execute(commands);
        }
    }
}
