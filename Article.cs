namespace csharp_homework9;

public class Article : Document
{
    private string _category;
    private int _readtime;
    
    public string Category { get => _category; set => _category = value; }
    public int Readtime { get => _readtime; set => _readtime = value; }

    public Article() : base()
    {
        _category = "Category";
        _readtime = 1;
    }

    public Article(string title, string author, string text, 
        string createAt, string category, int readtime) 
        :base(title, author, text, createAt)
    {
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category cannot be empty", nameof(category));
        if (readtime <= 0)
            throw new ArgumentException("Read time must be greater than zero",  nameof(readtime));
        
        _category = category;
        _readtime = readtime;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $"Category: {Category}\n" + 
               $"Read Time: {Readtime} minutes";
    }
}