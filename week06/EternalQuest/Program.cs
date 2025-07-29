using System;
using System.Collections.Generic;
using System.IO;
using EternalQuest;

class Program
{
    private const string FileName = "goals.txt";
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;

    static void Main()
    {
        LoadGoals();

        while (true)
        {
            Console.WriteLine($"\nTotal Score: {totalScore}"); // shows total scores
            Console.WriteLine("1. Create New Goal"); // menu
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save & Quit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine()) // reads the response and run a fuction accordingly
            {
                case "1": CreateNewGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); Console.WriteLine("Saved. Goodbye!"); return;
                default: Console.WriteLine("Choose 1–4."); break;
            }
        }
    }

    static void LoadGoals()
    {
        if (!File.Exists(FileName)) return;
        foreach (var line in File.ReadAllLines(FileName))
        {
            var parts = line.Split('|');
            switch (parts[0])
            {
                case "Simple":
                    var sg = new SimpleGoal(parts[1], int.Parse(parts[2]));
                    if (bool.TryParse(parts[3], out bool done) && done) sg.RecordEvent();
                    goals.Add(sg);
                    break;
                case "Eternal":
                    goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                    break;
                case "Checklist":
                    var cg = new ChecklistGoal(parts[1],
                        int.Parse(parts[2]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]));
                    for (int i = 0; i < int.Parse(parts[3]); i++) cg.RecordEvent();
                    goals.Add(cg);
                    break;
            }
        }
    }

    static void SaveGoals()
    {
        var lines = new List<string>();
        foreach (var g in goals)
            lines.Add(g.Serialize());
        File.WriteAllLines(FileName, lines);
    }

    static void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].Name} — {goals[i].GetStatus()}");
    }

    static void CreateNewGoal()
    {
        Console.Write("Type (simple/eternal/checklist): ");
        var type = (Console.ReadLine() ?? "").Trim().ToLower();
        Console.Write("Name: "); var name = Console.ReadLine() ?? "";
        Console.Write("Points per record: "); int.TryParse(Console.ReadLine(), out int pts);

        if (type == "simple") goals.Add(new SimpleGoal(name, pts));
        else if (type == "eternal") goals.Add(new EternalGoal(name, pts));
        else if (type == "checklist")
        {
            Console.Write("Target count: "); int target = int.Parse(Console.ReadLine()!);
            Console.Write("Bonus points on completion: "); int bonus = int.Parse(Console.ReadLine()!);
            goals.Add(new ChecklistGoal(name, pts, target, bonus));
        }
        else { Console.WriteLine("Invalid type."); return; }

        Console.WriteLine("Added!");
    }

    static void RecordEvent()
    {
        if (goals.Count == 0) { Console.WriteLine("No goals. Add one."); return; }
        ListGoals();
        Console.Write("Which goal accomplished? (#): ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= goals.Count)
        {
            var g = goals[idx - 1];
            int earned = g.RecordEvent();
            totalScore += earned;
            Console.WriteLine($"Earned {earned} points. Total: {totalScore}");
        }
        else Console.WriteLine("Invalid choice.");
    }
}
