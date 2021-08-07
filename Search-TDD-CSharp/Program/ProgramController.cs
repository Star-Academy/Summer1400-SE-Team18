using System;
using Program.CommandController;
using Program.View;
using Search.IO;
using Search.IO.FolderIO;
using Search.Search;

namespace Program
{
    public class ProgramController
    {
        private const string WelcomeMessage = "******* Welcome to our program *******";
        private const string ByeMessage = "We hope to see you again soon!";
        
        private readonly ICommandParser _commandParser;
        
        public ProgramController(ICommandParser commandParser)
        {
            _commandParser = commandParser;
        }
        
        public void Run()
        {
            Menu.ShowMessage("******* Welcome to our program *******");
            string command;
            while ((command = Console.ReadLine()) != "quit")
            {
                _commandParser.ParseCommand(command);
            }
            
            Menu.ShowMessage(ByeMessage);
        }
    }
}