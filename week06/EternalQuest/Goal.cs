using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Name { get; private set; }
        public int Points { get; private set; }
        public bool IsComplete { get; protected set; }

        protected Goal(string name, int points)
        {
            Name = name;
            Points = points;
            IsComplete = false;
        }

        public abstract int RecordEvent();
        public abstract string GetStatus();
        public abstract string Serialize();
    }
}
