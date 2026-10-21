namespace csharp_homework9;

public interface ITextProcessor
{
    string ProcessText();
    int CountWords();
    bool ContainsWord(string word);
}