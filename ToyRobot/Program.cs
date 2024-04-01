using ToyRobotLibrary.BusinessLogic;

class Program
{
    static void Main(string[] args)
    {
        var inputArgument = args.FirstOrDefault(arg => arg.StartsWith("-i="));

        if (inputArgument == null)
        {
            Console.WriteLine("Please Specify Commands Filepath.");
            return;
        }

        var filePath = inputArgument.Split("=")[1];

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File Not found");
            return;
        }

        if (Path.GetExtension(filePath) != ".txt")
        {
            Console.WriteLine("File Extension Must Be .txt");
            return;
        }

        var commands = File.ReadAllLines(filePath).ToList();
        var simulator = new Simulator(new Table(5, 5), new Robot());
        var execution = new Execution(simulator);

        execution.Execute(commands);

        Console.WriteLine("Completed!");
    }
}
