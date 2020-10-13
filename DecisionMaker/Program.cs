using System;

namespace DecisionMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Decision Maker!");

            // Ask user for name
            string name;
            Console.Write("Before we start, please enter your name: ");
            name = Console.ReadLine();
            name = name.Trim();
            if (string.IsNullOrEmpty(name)) { name = "User"; }

            makeLineSpace();

            // Set up Application Loop
            bool done = false;
            while (!done)
            {
                int input = -1;

                // Nested loop for Validation, input must be an integer value between 1 and 100
                bool inputValid = false;

                while (!inputValid)
                {
                    Console.Write($"{name}, please enter a number between 1 and 100: ");
                    string inputStr = Console.ReadLine();
                    int inputInt;
                    // Value is non-integer
                    if ( int.TryParse(inputStr, out inputInt) == false ) { Console.WriteLine("Error: Non-integer input. Please enter an integer!"); } 
                    else // Value is an integer
                    {
                        // Value is outside the bounds specified
                        if (inputInt < 1 || inputInt > 100) { Console.WriteLine("Error: Out of bounds. Please enter a number BETWEEN 1 AND 100!"); }
                        else // Value is a valid integer in bounds.
                        {
                            Console.WriteLine($"Thank you for your input, {name}! You entered {inputInt}.");
                            input = inputInt;
                            inputValid = true; // inputValid is updated, nested loop ends
                        }
                    }
                    makeLineSpace();
                }

                // Input is obtained, determine with output string should be displayed in console using the makeDecision method
                Console.Write($"{name}, here is the result: ");
                makeDecision(input);

                // Prompt user if they want to continue. If yes, then let the loop iterate. Otherwise, stop the loop by setting done to true.
                Console.Write($"Decision is made! {name}, would you like to continue and make another decision? (y/n) ");

                if (!(Console.ReadLine().ToLower().Trim()).Equals("y")) {
                    Console.WriteLine($"Thank you for using Decision Maker, {name}! Have a nice day!");
                    done = true;
                }
                else { Console.WriteLine("Reseting!"); }
                makeLineSpace();
            }
        }

        public static void makeDecision(int x)
        {
            if (x % 2 == 1) // Input is odd
            {
                //  Outcome 5: If the integer entered is odd and greater than 60, print the number entered and “Odd.”
                if (x > 60) { Console.WriteLine($"{x}, Odd"); }
                //  Outcome 1: If the integer entered is odd, print the number entered and “Odd.”
                else { Console.WriteLine($"{x}, Odd"); }
            }
            else // Input is even
            {
                // Outcome 2:  If the integer entered is even and in the inclusive range of 2 to 25, 
                //             print “Even and less than 25.”
                if (x >= 2 && x <= 25) { Console.WriteLine("Even and less than 25."); }
                // Outcome 3:  : If the integer entered is even and in the inclusive range of 26 to 60,
                //             print “Even.”
                else if (x >= 26 && x <= 60) { Console.WriteLine("Even."); }
                //  Outcome 4: If the integer entered is even and greater than 60, print the number
                //             entered and “Even”.
                else { Console.WriteLine($"{x}, Even"); }
            }
        }

        public static void makeLineSpace() { Console.WriteLine(" "); }
    }
}
