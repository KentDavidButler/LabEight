using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEight
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameArray = InitializeName();
            string[] homeTownArray = InitializeTowns();
            string[] foodArray = InitializeFood();

            Console.Write("Welcome to our C# class. Which student would you like to " +
                "learn more about? (enter a number 1-" + nameArray.Length + ")");
            int selection = ValidIntInput(nameArray.Length);
            do
            {
                try
                {
                    SelectionReturn(selection, nameArray[selection]);

                    MoreInfoAboutSelection(nameArray[selection], homeTownArray[selection],
                        foodArray[selection]);
                    Console.Write("Would you like to know more: ");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Couldn't access that respond.");
                }
                catch (Exception)
                {
                    Console.WriteLine("I'm not sure how you got here, but you are here,");
                    Console.WriteLine("and now I need to figure out how to deal with this.");
                }

            } while (YesOrNo());

        }

        private static void MoreInfoAboutSelection(string name, string town, string food)
        {
            //passing string values of selected student instaed of the full array
            Console.WriteLine("What would you like to know about " + name + "?");
            Console.Write(" (enter \"Hometown\" or \"Favorite Food\"): ");
            int temp = ValidStringInput();
            if (temp == 0)
            {
                Console.WriteLine(name + " is from " + town + ".");
            }
            else if (temp == 1)
            {
                Console.WriteLine(name + "'s favorit food is " + food + ".");
            }
            else
            {
                Console.WriteLine("Ya'll dun messed up!");
            }
        }

        private static int ValidStringInput()
        {
            for (; ; )
            {
                String input = Console.ReadLine();
                Console.WriteLine(" ");
                if(input.ToLower() == "hometown")
                {
                    return 0;
                }
                else if(input.ToLower() == "favorite food")
                {
                    return 1;
                }
                else
                {
                    Console.Write("That data does not exist. Please try again. Please try again. ");
                    Console.Write(" (enter \"Hometown\" or \"Favorite Food\"): ");
                }
            }
        }

        private static void SelectionReturn(int selection, string name)
        {
            Console.Write("Student " + (selection + 1) + " is " + name + ".");
        }

        private static int ValidIntInput(int maxNum)
        { 
            for(; ; )
            {
                String input = Console.ReadLine();
                bool isNum = int.TryParse(input, out int inputInt);
                if (isNum && ((inputInt > 0) && (inputInt <= maxNum)))
                {
                    //only triggers if TryParse is true and inputInt is greater than or equal
                    //to zero and inputInt is lessthan maxNum.
                    //subtracting from input to adjust for array starting at zero
                    return (inputInt-1);
                }
                else
                {
                    Console.WriteLine("That student does not exist. Please try again.");
                }
            }
        }

        private static bool YesOrNo()
        {
            string input;
            bool correctRespone = true;
            while (correctRespone)
            {
                Console.Write("(y/n):");
                input = Console.ReadLine().ToLower();
                if (String.Equals("n", input))
                {
                    return false;
                }
                else if (String.Equals("y", input))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("That is an invalid entry!");
                    continue;
                }
            }
            return false; //should never get hit needed to make it happy.
        }

        private static string[] InitializeName()
        {
            string[] names = {"Stephen J", "Noha H", "Jackie C", "Brian W", "Evan S", "Justin S",
             "Kendra D", "Laura H", "Levi S", "Moe R", "Ron L", "Rudy G", "Steve W", "AK A"};
            return names;
        }

        private static string[] InitializeTowns()
        {
            string[] towns = {"Rochester, MI", "Windsor, ON", "Rochester Hills, MI", "Waterford, MI",
                "Waterville, OH", "Warren, MI", "Royal Oak, MI", "Albuquerque, NM",
                "Detroit, MI", "Ann Arbor, MI", "Lincoln Park, MI", "Detroit, MI",
                "Perrysberg, OH", "Clawson, MI"};
            return towns;
        }

        private static string[] InitializeFood()
        {
            string[] food = {"Honey", "Apples", "Pears", "Watermellon", "Grilled Octopus",
                "Quasadilla", "Tacos", "Bibimbap", "Pizza", "Strawberries", "Saganaki", "Anything", "Pizza", "Pasta"};
            return food;
        }
    }
}
