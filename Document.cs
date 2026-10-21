namespace csharp_homework9;

public abstract class Document : ITextProcessor
{
    private string _title;
    private string _author;
    private string _text;
    private string _createdAt;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }
    public string Text
    {
        get { return _text; }
        set { _text = value; }
    } 
    public string CreatedAt
    {
        get { return _createdAt; }
        set { _createdAt = value; }
    }

    public Document()
    {
        _title = "Document";
        _author = "Author";
        _text = "Text";
        _createdAt = "Created At";
    }

    public Document(string title, string author, string text, string createdAt)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("[EXCEPTION!] Title cannot be empty!", nameof(title));
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("[EXCEPTION!] Author cannot be empty!", nameof(author));
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("[EXCEPTION!] Text cannot be empty!", nameof(text));
        if (string.IsNullOrWhiteSpace(createdAt))
            throw new ArgumentException("[EXCEPTION!] Created At cannot be empty!", nameof(createdAt));
        
        _title = title;
        _author = author;
        _text = text;
        _createdAt = createdAt;
    }

    public virtual string GetInfo()
    {
        return $"Title: {Title}\n " +
               $"Author: {Author}\n " +
               $"Text: {Text}\n " +
               $"Created At: {CreatedAt}\n";
    }

    public string ProcessText()
    {
        return Text.Trim();
    }
    
    public int CountWords()
    {
        int count = Text.Split(
            new char[] { ' ', '\n', '\t', '.', ',', '!', '?', ':', ';' },
            StringSplitOptions.RemoveEmptyEntries).Length;
        return count;
    }
    
    public bool ContainsWord(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return  false;
    
        string[] words = Text.Split(
            new char[] { ' ', '\n', '\t', '.', ',', '!', '?', ':', ';' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string currentWord in words)
        {
            if (currentWord.Equals(
                    word,
                    StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public DocumentStatistics AnalyzeText()
    {
        char[] separators = { ' ', '\n', '\t', '.', ',', '!', '?', ':', ';' };
        string[] words = Text.Split(
            separators,
            StringSplitOptions.RemoveEmptyEntries
        );
        string longestWord = "";
        foreach (string word in  words)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }

        int uniqueWordCount = words.Distinct(StringComparer.OrdinalIgnoreCase).Count();
        return new DocumentStatistics(
            words.Length,
            Text.Length,
            longestWord,
            uniqueWordCount
        );
    }

    public DocumentSummary GetSummary()
    {
        return new DocumentSummary(
            Title,
            Author,
            GetType().Name,
            CountWords()
        );
    }
}