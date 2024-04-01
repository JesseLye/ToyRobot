using ToyRobotLibrary.BusinessLogic;

namespace ToyRobotTests
{
    [TestClass]
    public class TestTable
    {
        [TestMethod]
        public void ValidCoordinates()
        {
            var table = new Table(5, 5);

            Assert.IsTrue(table.IsValidCoordinates(0, 0), "(0, 0) is False");
            Assert.IsTrue(table.IsValidCoordinates(4, 4), "(4, 4) is False");
            Assert.IsTrue(table.IsValidCoordinates(2, 3), "(2, 3) is False");
            Assert.IsTrue(table.IsValidCoordinates(1, 4), "(2, 3) is False");

            Assert.IsFalse(table.IsValidCoordinates(-1, -1), "(-1, -1) is True");
            Assert.IsFalse(table.IsValidCoordinates(5, 5), "(5, 5) is True");
            Assert.IsFalse(table.IsValidCoordinates(-1, 2), "(-1, 2) is True");
            Assert.IsFalse(table.IsValidCoordinates(1, -1), "(1, -1) is True");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid Coordinates")]
        public void InvalidTable()
        {
            var table = new Table(-1, -1);
        }
    }
}
