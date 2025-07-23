using System;
using System.Threading;

abstract class Activity
{
    private static readonly Random _rng = new Random();
    private string _name;// name of the activity
    private string _description;// description of the activity
    protected int _duration;// duration of the activity in seconds

    public Activity(string name, string description)// constructor
    {
        _name = name;
        _description = description;
    }

    public void Start()// start the activity
    {
        Console.Clear();// clear the console
        Console.WriteLine($"--- {_name} ---");// display the name of the activity
        Console.WriteLine(_description); //display the description of the activity
        Console.Write("Enter duration in seconds: "); // prompt the user to enter the duration of the activity
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)// validate the duration of the activity
        {
            Console.Write("Invalid. Enter a positive number: ");
        }

        Console.WriteLine("Get ready...");
        ShowAnimation(3);// display the animation for 3 seconds 

        RunActivity();// run the activity for the specified duration 

        Console.WriteLine("Well done!");
        ShowAnimation(3);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.\n");
        ShowAnimation(2);
    }

    protected abstract void RunActivity();

    protected void ShowAnimation(int seconds)
    {
        var endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            foreach (char c in "|/-\\")
            {
                Console.Write(c);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }
    }

    // Reusable countdown for derived classes
    protected void ShowCountdown(int seconds) // display the countdown for the specified duration
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    protected int GetRandom(int count) => _rng.Next(count);// return a random number between 0 and count-1
}
