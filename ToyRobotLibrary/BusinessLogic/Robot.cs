using ToyRobotLibrary.Enums;
using ToyRobotLibrary.Interfaces;
using ToyRobotLibrary.Models;

namespace ToyRobotLibrary.BusinessLogic
{
    public class Robot : IRobot
    {
        private int _x;
        private int _y;
        private bool _isPlaced = false;
        private Direction _direction;

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public bool IsPlaced
        {
            get { return _isPlaced; }
        }

        public Direction Direction
        {
            get { return _direction; }
        }

        public void Place(int x, int y, Direction direction)
        {
            _x = x;
            _y = y;
            _isPlaced = true;
            _direction = direction;
        }

        public void TurnLeft()
        {
            if (!_isPlaced)
            {
                throw new InvalidOperationException("Robot Not Placed");
            }

            _direction--;

            if ((int)_direction < 0)
            {
                _direction = (Direction)3;
            }
        }

        public void TurnRight()
        {
            if (!_isPlaced)
            {
                throw new InvalidOperationException("Robot Not Placed");
            }

            _direction++;

            if ((int)_direction > 3)
            {
                _direction = (Direction)0;
            }
        }

        public string Report()
        {
            if (!_isPlaced)
            {
                throw new InvalidOperationException("Robot Not Placed");
            }

            return $"{_x},{_y},{Enum.GetName(typeof(Direction), _direction)}";
        }

        public Location CalculateNewMovement()
        {
            if (!_isPlaced)
            {
                throw new InvalidOperationException("Robot Not Placed");
            }

            var robotLocation = new Location
            {
                X = _x,
                Y = _y,
                Direction = _direction,
            };

            switch (_direction)
            {
                case Direction.North:
                    robotLocation.Y++;
                    break;
                case Direction.South:
                    robotLocation.Y--;
                    break;
                case Direction.East:
                    robotLocation.X++;
                    break;
                case Direction.West:
                    robotLocation.X--;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return robotLocation;
        }
    }
}
