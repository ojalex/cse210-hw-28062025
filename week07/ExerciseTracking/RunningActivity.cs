using System;
namespace ExerciseTracker
{
    public class RunningActivity : Activity
    {
        private double distanceMiles;

        public RunningActivity(DateTime date, int minutes, double distanceMiles)
            : base(date, minutes)
        {
            this.distanceMiles = distanceMiles;
        }

        public override double GetDistance() => distanceMiles;
        public override double GetSpeed() => (distanceMiles / DurationMinutes) * 60;
    }
}
