using lab3.Commands.Base;
using lab3.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Commands
{
    public class CommandManager
    {
        public List<ICommand> Commands { get; set; }
        public CommandManager()
        {
            Commands = new List<ICommand>();
        }
        public void AddCommand(ICommand command)
        {
            Commands.Add(command);
        }
        public void DisplayCommands()
        {
            int i = 1;
            foreach(var command in Commands)
            {
                Console.Write(i + ". ");
                command.CommandInfo();
                i++;
            }
        }
        public void ExecuteCommand(DbContext context)
        {
            int i = 0;
            string userinput = Console.ReadLine();
            if (int.TryParse(userinput, out int commandNumber))
            {
                Console.WriteLine($"You chose command number: {commandNumber}");
                Commands[commandNumber-1].Execute(context);
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
        }
    }
}
