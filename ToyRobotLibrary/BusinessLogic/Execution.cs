using ToyRobotLibrary.Enums;
using ToyRobotLibrary.Interfaces;
using System.Text.RegularExpressions;

namespace ToyRobotLibrary.BusinessLogic
{
    public class Execution : IExecution
    {
        private ISimulator _simulator;
        public Execution(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute(List<string> commands)
        {
            // Ignore all commands until first "place" command
            var placeIndex = commands.FindIndex(command => IsPlace(command));

            if (placeIndex == -1)
            {
                throw new ArgumentException("'PLACE' Command Not Found");
            }

            for (var i = placeIndex; i < commands.Count(); i++)
            {
                ProcessCommand(commands[i]);
            }
        }

        private void ProcessCommand(string command)
        {
            if (IsPlace(command))
            {
                var arguments = Regex.Replace(command, @"\s", ",").Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (arguments.Length != 4)
                {
                    throw new FormatException("Invalid 'PLACE' Argument Length");
                }

                var validX = int.TryParse(arguments[1], out var x);
                var validY = int.TryParse(arguments[2], out var y);
                var validDirection = Enum.GetValues<Direction>().Any(e => arguments[3].Equals(e.ToString(), StringComparison.CurrentCultureIgnoreCase));

                if (!validX || !validY || !validDirection)
                {
                    throw new FormatException("Invalid 'PLACE' Argument");
                }

                _simulator.Place(x, y, Enum.Parse<Direction>(arguments[3], true));

                return;
            }

            if (IsMove(command))
            {
                _simulator.Move();
                return;
            }

            if (IsLeft(command))
            {
                _simulator.TurnLeft();
                return;
            }

            if (IsRight(command))
            {
                _simulator.TurnRight();
                return;
            }

            if (IsReport(command))
            {
                Console.WriteLine(_simulator.Report());
                return;
            }

            throw new NotImplementedException();
        }

        private static bool IsPlace(string command)
        {
            return Regex.IsMatch(command, @"^Place\s+", RegexOptions.IgnoreCase);
        }

        private static bool IsMove(string command)
        {
            return command.Equals("Move", StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsLeft(string command)
        {
            return command.Equals("Left", StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsRight(string command)
        {
            return command.Equals("Right", StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsReport(string command)
        {
            return command.Equals("Report", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
