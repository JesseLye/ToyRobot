using ToyRobotLibrary.Enums;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary.BusinessLogic
{
    public class Simulator : ISimulator
    {
        private ITable _table;
        private IRobot _robot;
        
        public Simulator(ITable table, IRobot robot)
        {
            _table = table;
            _robot = robot;
        }

        public void Place(int x, int y, Direction direction)
        {
            if (_table.IsValidCoordinates(x, y))
            {
                _robot.Place(x, y, direction);
                return;
            }

            throw new ArgumentException("Invalid Coordinates");
        }

        public void Move()
        {
            var robotCoordinates = _robot.CalculateNewMovement();

            if (_table.IsValidCoordinates(robotCoordinates.X, robotCoordinates.Y))
            {
                _robot.Place(robotCoordinates.X, robotCoordinates.Y, robotCoordinates.Direction);
            }
        }

        public void TurnLeft()
        {
            _robot.TurnLeft();
        }

        public void TurnRight()
        {
            _robot.TurnRight();
        }

        public string Report()
        {
            return _robot.Report();
        }
    }
}
