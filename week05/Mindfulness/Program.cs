using System;

class Program {
  static void Main() {
    //W05 Project: Mindfulness Program by Alex Juma
    while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Mindfulness Program! by Alex Juma"); //Welcome message
            Console.WriteLine();
            Console.WriteLine("Please choose an activity to continue: "); //Line asking user to choose activity
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. Breathing\n2. Reflection\n3. Listing\n4. Quit "); //Menu
            Console.Write("Enter number to continue: "); //Line asking user to choose activity
            switch (Console.ReadLine()) // reads user input
            {
                case "1": new BreathingActivity().Start(); break; // if user chooses 1, it will run the BreathingActivity class
                case "2": new ReflectionActivity().Start(); break; // if user chooses 2, it will run the ReflectionActivity class
                case "3": new ListingActivity().Start(); break; // if user chooses 3, it will run the ListingActivity class
                case "4": return; // if user chooses 4, it will return to the main menu
            }
        }
  }
}

