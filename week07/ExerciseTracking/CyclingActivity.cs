using System;
namespace ExerciseTracker
{
    public class CyclingActivity : Activity
    {
        private double speedMph;

        public CyclingActivity(DateTime date, int minutes, double speedMph)
            : base(date, minutes)
        {
            this.speedMph = speedMph;
        }

        public override double GetDistance() => (speedMph * DurationMinutes) / 60;
        public override double GetSpeed() => speedMph;
    }
}
