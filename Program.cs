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

                            Console.WriteLine($"Album: {searchAlbums}");
                            var albumTitle = searchAlbums;

                            Console.WriteLine("Is the album explicit? [Yes/No]: ");
                            var isExplicit = getBoolInputValue(Console.ReadLine());

                            Console.WriteLine("Album Release Date: ");
                            var releaseDate = Console.ReadLine();

                            var newAlbum = new Album
                            {
                                Title = albumTitle,
                                IsExplicit = isExplicit
                            };

                            context.SaveChanges();
                            Console.WriteLine($"Your selection of {albumTitle} has been recorded. ");
                        }
                    }

                    if (directoryOption == "4")
                    {
                        Console.WriteLine("What is the name of the song you would like to add to an album");
                        var searchSong = PromptForString("> : ");

                        var existingSong = context.Songs.FirstOrDefault(Songs => Songs.Title == searchSong);

                        if (existingSong != null)
                        {
                            Console.WriteLine($"The song {existingSong} is already in the records.\nTry again. ");
                        }
                        else
                        {
                            Console.WriteLine("What is the name of the album that this song is located in?");
                            var searchAlbum = PromptForString("> : ");

                            var existingAlbums = context.Album.FirstOrDefault(searchAlbums => searchAlbums.Title == searchAlbums);

                            if (existingAlbums == null)
                            {
                                Console.WriteLine($"\n {searchAlbum} does not exist in our record label. Try again.");
                            }
                            else
                            {
                                Console.WriteLine($"Album; {searchAlbum} ");

                                Console.WriteLine($"Song Title: {searchSong}");
                                var songTitle = searchSong;

                                Console.WriteLine("Track Number; ");
                                var songTrackNumber = int.Parse(Console.ReadLine());

                                var songDuration = PromptForString("Song duration - [00:00:00]");
                                var newSong = new Songs
                                {
                                    TrackNumber = songTrackNumber,
                                    Title = songTitle,
                                    Duration = songDuration,
                                };

                                context.Songs.Add(newSong);
                                context.SaveChanges();

                                Console.WriteLine($"Your selection of {songTitle} has been collected.");


                            }
                        }
                    }
                    if (directoryOption == "5")
                    {
                        var searchBands = PromptForString("What is the bands name you would like to let go?");

                        var existingBand = context.Band.FirstOrDefault(Bands => Bands.Name == searchBands);

                        if (existingBand == null)
                        {
                            Console.WriteLine($"\n{searchBands} is not in our records. \n Please try again.");
                        }

                        else
                        {
                            existingBand.IsSigned = false;
                            context.SaveChanges();

                            Console.WriteLine($"\n {searchBands} has been move to the 'Un-Signed' department.");
                        }
                    }
                    if (directoryOption == "6")
                    {
                        var searchBands = PromptForString("Which band would you like to bring back to the label?");

                        var existingBand = context.Band.FirstOrDefault(Bands => Bands.Name == searchBands);

                        if (existingBand == null)
                        {
                            Console.WriteLine($"\n {searchBands} is not in our collection. \n Please try again.");
                        }

                        else
                        {
                            existingBand.IsSigned = true;
                            context.SaveChanges();
                            Console.WriteLine($"\n {searchBands} has been moved to the 'Re-signed' department.");
                        }
                    }
                    if (directoryOption == "7")
                    {
                        var bandAlbum = PromptForString("Which bands discography would you like to take a look at?");
                        bandAlbum = context.Album.Include(albums => albums.Id).ThenInclude(context.bands => Bands.Name == searchBands);

                        foreach (var album in context.Album)
                        {
                            Console.WriteLine($"\n This albums name is {album.Title} in our records for the band {Bands.Name}. ");
                        }
                    }
                    if (directoryOption == "8")
                    {
                        var
                    }
                }
            }

        }
    }

}
