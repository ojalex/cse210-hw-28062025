using System;
namespace ExerciseTracker
{
    public abstract class Activity
    {
        public DateTime Date { get; private set; }
        public int DurationMinutes { get; private set; }

        protected Activity(DateTime date, int duration)
        {
            Date = date;
            DurationMinutes = duration;
        }

        // Polymorphic methods to calculate derived properties
        public abstract double GetDistance(); // miles or km
        public abstract double GetSpeed();    // mph or kph
        public double GetPace()               // minutes per unit
        {
            double dist = GetDistance();
            return dist > 0 ? DurationMinutes / dist : 0;
        }

        public virtual string GetSummary()
        {
            return $"{Date:dd MMM yyyy} {this.GetType().Name} ({DurationMinutes} min) - " +
                   $"Distance {GetDistance():0.00}, Speed {GetSpeed():0.00}, Pace {GetPace():0.00} per unit";
        }
    }
}
