using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary.BusinessLogic
{
    public class Table : ITable
    {
        private int _x;
        private int _y;

        public Table(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Invalid Coordinates");
            }

            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public bool IsValidCoordinates(int x, int y)
        {
            return (x >= 0 && x < _x) && (y >= 0 && y < _y);
        }
    }
}
