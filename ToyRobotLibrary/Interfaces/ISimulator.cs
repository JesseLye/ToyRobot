using ToyRobotLibrary.Enums;

namespace ToyRobotLibrary.Interfaces
{
    public interface ISimulator
    {
        public void Place(int x, int y, Direction direction);
        public void Move();
        public void TurnLeft();
        public void TurnRight();
        public string Report();
    }
}
