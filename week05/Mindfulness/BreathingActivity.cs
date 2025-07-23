class BreathingActivity : Activity {
  public BreathingActivity() : base("Breathing", 
    "Helps you relax through paced breathing.") {}

  protected override void RunActivity() {
    var end = DateTime.Now.AddSeconds(_duration);
    bool inhale = true;
    while (DateTime.Now < end) {
      Console.WriteLine(inhale ? "Breathe in..." : "Breathe out...");
      ShowCountdown(4);
      inhale = !inhale;
    }
  }

  private void ShowCountdown(int sec) { 
    for (int i = sec; i > 0; i--) {
      Console.Write(i); Thread.Sleep(1000);
      Console.Write("\b \b");
    }
  }
}
