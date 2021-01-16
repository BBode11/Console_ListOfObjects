using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsolePracticeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            SetTheme();

            //DisplayMenuScreen(animals);
            AddAnimal(animals);
            DisplayAnimal(animals);
            SaveAnimals(animals);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Main menu **Error in code, will not let user select option (b) or (c)
        /// </summary>
        /// <param name="animals"></param>
        static void DisplayMenuScreen(List<Animal> animals)
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // Show menu and get input from user
                //
                Console.WriteLine("\ta) Add Animal");
                Console.WriteLine("\tb) View Animals");
                Console.WriteLine("\tc) Save Animals");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // gather user input and process with a switch case code block
                //
                switch (menuChoice)
                {
                    case "a":;
                        AddAnimal(animals);
                        break;

                    case "b":
                        DisplayAnimal(animals);
                        break;

                    case "c":
                        SaveAnimals(animals);

                        break;

                    case "q":

                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

       
        static void DisplayAnimal(List<Animal> animals)
        {
            DisplayScreenHeader("Animal Display");

            //
            // creates table for animal list
            //
            Console.WriteLine(
                "Name".PadLeft(15) +
                "lbs".PadLeft(10) +
                "Body Size".PadLeft(15) +
                "Mammal".PadLeft(10)
                );
            Console.WriteLine(
                "----".PadLeft(15) +
                "---".PadLeft(10) +
                "------".PadLeft(15) +
                "----".PadLeft(10)
                );


            foreach (Animal animal in animals)
            {
                //
                // adds the animal values to the table
                //
                Console.WriteLine(
                animal.Name.PadLeft(15) +
                animal.Weight.ToString().PadLeft(10) +
                animal.BodySize.ToString().PadLeft(15) +
                animal.IsMammal.ToString().PadLeft(10)
                );
            }
        }

        /// <summary>
        /// Method to add animals and to place them into a list
        /// </summary>
        /// <param name="animals"></param>
        static void AddAnimal(List<Animal> animals)
        {
            bool validResponse;
            Animal animal = new Animal();

            DisplayScreenHeader("Add Animal");

            bool doneAdding = false;
          
            do
            {
                //
                // get name
                //
                Console.Write("Name: ");
                animal.Name = Console.ReadLine();
                //
                // validation of int
                //
                do
                {
                    validResponse = true;
                    Console.WriteLine("Weight: ");
                    if (int.TryParse(Console.ReadLine(), out int weight))
                    {
                        animal.Weight = weight;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer.");
                        validResponse = false;
                    }
                } while (!validResponse);

                //Console.WriteLine("Mammal |yes| or |no|: ");
                //animal.IsMammal = Console.ReadLine().ToLower();

                // body size enum and validation
                //
                do
                {
                    validResponse = true;
                    Console.WriteLine("Body Size: ");
                    if (Enum.TryParse(Console.ReadLine(), out Animal.Size bodySize))
                    {
                        animal.BodySize = bodySize;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a proper body size ex:'large, medium, small'.");
                        foreach (Animal.Size name in Enum.GetValues(typeof(Animal.Size)))
                        {
                            Console.WriteLine(" | " + name);
                        }
                        Console.WriteLine();

                        validResponse = false;
                    }
                } while (!validResponse);

                do
                {
                    //
                    // validating bool response
                    //
                    validResponse = true;
                    Console.WriteLine("Mammal (Please enter true or false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool mammal))
                    {
                        animal.IsMammal = mammal;
                    }
                    else
                    {
                        Console.WriteLine("Please enter either true or false.");

                        validResponse = false;
                    }
                } while (!validResponse);



                //
                //add animal to list
                //
                animals.Add(animal);

                Console.WriteLine("Add Another: ");
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse == "no")
                {
                    doneAdding = true;
                }
            } while (!doneAdding);

        }

        /// <summary>
        /// Method to save animal into data file using fileIO
        /// </summary>
        /// <param name="animals"></param>
        static void SaveAnimals(List<Animal> animals)
        {
            string dataPath = @"Data\Animals.txt";
            string animalString;

            foreach (Animal animal in animals)
            {
                animalString = animal.Name + " ," + animal.Weight + " ," + animal.BodySize + Environment.NewLine;
                File.AppendAllText(dataPath, animalString);
            }
        }

        #region User Interface


        /// <summary>
        /// Set Up for Console Theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }

        /// <summary>
        /// Display Continue Prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the Screen Header
        /// </summary>
        /// <param name="headerText"></param>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"\t\t {headerText}");
            Console.WriteLine();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using my application!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to my Application");
            Console.WriteLine();

            DisplayContinuePrompt();
        }


        #endregion
    }
}
