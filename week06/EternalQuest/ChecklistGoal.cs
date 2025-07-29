namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _count, _target, _bonus;

        public ChecklistGoal(string name, int points, int target, int bonus)
            : base(name, points)
        {
            _target = target;
            _bonus = bonus;
            _count = 0;
        }

        public override int RecordEvent()
        {
            if (IsComplete) return 0;
            _count++;
            int earned = Points;
            if (_count >= _target)
            {
                earned += _bonus;
                IsComplete = true;
            }
            return earned;
        }

        public override string GetStatus() => $"Completed {_count}/{_target}";

        public override string Serialize() =>
            $"Checklist|{Name}|{Points}|{_count}|{_target}|{_bonus}|{IsComplete}";
    }
}
