using lab3.Commands;
using lab3.Commands.Base;
using lab3.DB;
using lab3.DB.Repository;
using lab3.DB.Repository.Base;
using lab3.DB.Services;
using lab3.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context= new DbContext();

            CommandManager comandManager = new CommandManager();
            
            comandManager.Commands.Add(new CreatePlayerWithAccountType());
            comandManager.Commands.Add(new DisplayPlayersFromDb());
            comandManager.Commands.Add(new GetPlayerStatsById());
            comandManager.Commands.Add(new PlayGame());
            bool stopProgram = false;
            while (stopProgram == false)
            {
                comandManager.DisplayCommands();
                comandManager.ExecuteCommand(context);
                Console.WriteLine("continue y/n");
                if (Console.ReadLine() != "y")
                {
                    stopProgram = true;
                }

            }
         
           

        }

    }
}