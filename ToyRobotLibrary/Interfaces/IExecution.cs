namespace ToyRobotLibrary.Interfaces
{
    public interface IExecution
    {
        void Execute(List<string> commands);
        private void ProcessCommand(string command) => throw new NotImplementedException();
        static private bool IsPlace(string command) => throw new NotImplementedException();
        static private bool IsMove(string command) => throw new NotImplementedException();
        static private bool IsLeft(string command) => throw new NotImplementedException();
        static private bool IsRight(string command) => throw new NotImplementedException();
        static private bool IsReport(string command) => throw new NotImplementedException();
    }
}
