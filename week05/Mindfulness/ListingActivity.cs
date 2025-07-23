using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "List people you appreciate:",
        "List your personal strengths:",
        "List your interests:",
        "List your dreams:",
        "List the people who have made the biggest impact on you:",
        "List your goals for the next year:",
        "List the people who have influenced you the most:",
        "List your greatest fears:",
    };

    public ListingActivity()
        : base("Listing Activity", "List as many positive items as you can.")
    { }

    protected override void RunActivity()
    {
        // Get a truly random prompt
        string prompt = _prompts[GetRandom(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("You have 5 seconds to think: ");
        ShowCountdown(5);

        var items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}
