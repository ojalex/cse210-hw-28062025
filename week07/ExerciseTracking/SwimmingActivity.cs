using System;
namespace ExerciseTracker
{
    public class SwimmingActivity : Activity
    {
        private int laps;

        public SwimmingActivity(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            this.laps = laps;
        }

        // using miles; pools are 50 m per lap
        public override double GetDistance()
        {
            double meters = laps * 50;
            double km = meters / 1000.0;
            return km * 0.62;
        }

        public override double GetSpeed()
        {
            double hours = DurationMinutes / 60.0;
            return hours > 0 ? GetDistance() / hours : 0;
        }
    }
}
