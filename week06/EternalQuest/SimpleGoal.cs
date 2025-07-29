namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override int RecordEvent()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                return Points;
            }
            return 0;
        }

        public override string GetStatus() => IsComplete ? "[X]" : "[ ]";

        public override string Serialize() => $"Simple|{Name}|{Points}|{IsComplete}";
    }
}
