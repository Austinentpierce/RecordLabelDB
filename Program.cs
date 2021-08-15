using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RecordLabelDB
{
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to:");
            Console.WriteLine("[1]Add a band");
            Console.WriteLine("[2]View all the bands");
            Console.WriteLine("[3]Add an album for a band");
            Console.WriteLine("[4]Add a song to an album");
            Console.WriteLine("[5]Let a band go");
            Console.WriteLine("[6] Resign a band");
            Console.WriteLine("[7]Prompt for a band name and view their albums");
            Console.WriteLine("[8]View all albums ordered by release date");
            Console.WriteLine("[9]View all bands that are signed");
            Console.WriteLine("[10]View all bands that are unsigned");
            Console.WriteLine("[11]Quit the program");
        }
        static DateTime PromptForDateTime(string prompt)
        {
            Console.Write(prompt);
            DateTime userInput;
            var IsThisGoodInput = DateTime.TryParse(Console.ReadLine(), out userInput);
            if (IsThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry there is no options under this input, ill use a default date for your selection");
                return default(DateTime);
            }

        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var IsThisGoodInput = int.TryParse(Console.ReadLine(), out userInput);
            if (IsThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry there is no options under this input, ill use 0 as your number. ");
                return 0;
            }

        }
        static bool PromptForBoolean(string prompt)
        {
            Console.Write(prompt);
            bool userInput;
            var IsThisGoodInput = bool.TryParse(Console.ReadLine(), out userInput);
            if (IsThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry there is no options under this input, Im going to choose false as your choice");
                return false;
            }

        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt)
          var userInput = Console.ReadLine();

            return userInput;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");
        }

    }
