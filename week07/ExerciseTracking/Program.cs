using System;
using System.Collections.Generic;
using ExerciseTracker;

class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2022,11,3), 30, 3.0),
            new CyclingActivity(new DateTime(2022,11,3), 45, 12.0),
            new SwimmingActivity(new DateTime(2022,11,3), 60, 40)
        };

        foreach (var act in activities)
        {
            Console.WriteLine(act.GetSummary());
        }
    }
}
