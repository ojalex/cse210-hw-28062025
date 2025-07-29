namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override int RecordEvent() => Points;

        public override string GetStatus() => "[∞]";

        public override string Serialize() => $"Eternal|{Name}|{Points}";
    }
}
