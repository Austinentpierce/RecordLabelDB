using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecordLabelDB
{
    class Program
    {
        public static void Directory()
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
            var isThisGoodInput = false;
            do
            {
                var stringInput = PromptForString(prompt);

                int numberInput;
                isThisGoodInput = Int32.TryParse(stringInput, out numberInput);

                if (isThisGoodInput)
                {
                    return numberInput;
                }
                else
                {
                    Console.WriteLine("Sorry, this option does not exist, try again.");
                }
            } while (!isThisGoodInput);

            return 0;

        }
        static bool getBoolInputValue(string IsSigned)
        {
            var IsSignedToLower = IsSigned.ToLower();

            if (IsSigned.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (IsSigned.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;

        }

        static void Main(string[] args)
        {
            var context = new RecordLabelDBContext();

            var keepGoing = true;
            while (keepGoing)
            {
                Directory();
                var directoryOption = PromptForString("> : ");

                if (directoryOption == "1")
                {
                    var searchBands = PromptForString("What is the name of the band you would like to add?");

                    var existingBand = context.Band.FirstOrDefault(Band => Band.Name == searchBands);

                    if (existingBand != null)
                    {
                        Console.WriteLine($"{searchBands} already exists in our records as a Band.\n Please try another input");
                    }
                    else
                    {
                        Console.WriteLine("Name of the band: ");
                        Console.WriteLine($"{searchBands}");
                        var bandName = searchBands;

                        var countryOfOrigin = PromptForString("\n What country did this band originate in?\n");

                        Console.WriteLine("Number of members in the band: ");
                        var numberOfMembers = int.Parse(Console.ReadLine());

                        var website = PromptForString("What is the bands website? \n");

                        var style = PromptForString("What is the genre of music the band plays? \n ");

                        Console.WriteLine("Is the band signed with the record label? True or False: \n ");
                        var isSigned = getBoolInputValue(Console.ReadLine());

                        var contactName = PromptForString("What is the name of the manager to contact: /n");

                        var contactPhoneNumber = PromptForString("What is the number to contact the manager: ");

                        var newBand = new Band
                        {
                            Name = bandName,
                            CountryOfOrigin = countryOfOrigin,
                            NumberOfMembers = numberOfMembers,
                            Website = website,
                            Style = style,
                            IsSigned = isSigned,
                            ContactName = contactName,
                            ContactPhoneNumber = contactPhoneNumber,
                        };

                        context.Band.Add(newBand);
                        context.SaveChanges();
                        Console.WriteLine($"Your selection of {bandName} has been saved. ");
                    }


                }

                if (directoryOption == "2")
                {
                    foreach (var band in context.Band)
                    {
                        Console.WriteLine($"There is a band called {band.Name} in our records.");
                    }
                }

                if (directoryOption == "3")
                {
                    Console.WriteLine("What is the title of the album you would like to add?");
                    var searchAlbums = PromptForString("> : ");

                    var existingAlbum = context.Album.FirstOrDefault(Albums => Albums.Title == searchAlbums);

                    if (existingAlbum != null)
                    {
                        Console.WriteLine($"{searchAlbums} is already in the record label as an Album.\nPossibly choose a different album name. ");
                    }

                    else
                    {
                        var searchBands = PromptForString("What band made the album you are referring? ");
                        var existingBand = context.Band.FirstOrDefault(Band => Band.Name == searchBands);

                        if (existingBand == null)
                        {
                            Console.WriteLine($"{searchBands} does not exist in the record label. Please add the band you are mentioning first.");
                        }

                        else
                        {
                            Console.WriteLine($"Band: {searchBands}");
                        }
                    }
                }
            }

        }
    }

}
