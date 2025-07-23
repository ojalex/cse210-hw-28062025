class ReflectionActivity : Activity {
  private List<string> _prompts = new() {
    "Think of a time you stood up for someone.",
    "Think of a time you did something difficult.",
    "Think of a time you did something you were proud of.",
    "Think of a time you had to overcome a fear.",
  };
  private List<string> _questions = new() {
    "Why was this meaningful?",
    "How did it make you feel?",
    "How did it make others feel?",
    "What can you learn from this experience?",
    "What do you want to do differently next time?",
  };

  public ReflectionActivity() : base("Reflection", 
    "Reflect on times you’ve shown strength.") {}

  protected override void RunActivity() {
    Console.WriteLine(_prompts[new Random().Next(_prompts.Count)]);
    ShowAnimation(3);

    var end = DateTime.Now.AddSeconds(_duration);
    while (DateTime.Now < end) {
      var q = _questions[new Random().Next(_questions.Count)];
      Console.WriteLine(q);
      ShowAnimation(5);
    }
  }
}
