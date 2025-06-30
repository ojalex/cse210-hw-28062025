// Words in the scripture to be memorized
public class Word
{
    // Stores word text
    private string _text;

    // Indicates whether the word is currently hidden
    private bool _hidden;

    // Constructor: Initializes the word with the given text and sets it as visible (not hidden)
    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    // Returns either the full text (if text is not hidden), or underscores of equal length (if the text ishidden)
    public string GetDisplayText()
    {
        if (_hidden)
            return new string('_', _text.Length); // Replace each character with an underscore (_)
        else
            return _text;
    }

    // Sets the word as hidden
    public void Hide()
    {
        _hidden = true;
    }

    // Returns whether the word is currently hidden
    public bool IsHidden()
    {
        return _hidden;
    }
}
