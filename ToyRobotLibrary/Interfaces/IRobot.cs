using ToyRobotLibrary.Enums;
using ToyRobotLibrary.Models;

namespace ToyRobotLibrary.Interfaces
{
    public interface IRobot
    {
        int X { get; }
        int Y { get; }
        bool IsPlaced { get; }
        Direction Direction { get; }
        public void Place(int x, int y, Direction direction);
        public void TurnLeft();
        public void TurnRight();
        public string Report();
        public Location CalculateNewMovement();
    }
}
