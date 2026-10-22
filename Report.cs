namespace csharp_homework9;

public class Report : Document
{
    private string _department;
    private int _pagecount;

    public string Department { get => _department; set => _department = value; }
    public int Pagecount { get => _pagecount; set => _pagecount = value; }
    
    public Report() : base()
    {
        _department = "Department";
        _pagecount = 1;
    }

    public Report(string title, string author, string text, 
        string createAt, string department, int pagecount) 
        :base(title, author, text, createAt)
    {
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department cannot be empty", nameof(department));
        if (pagecount <= 0)
            throw new ArgumentException("Page count must be greater than zero",  nameof(pagecount));
        
        _department = department;
        _pagecount = pagecount;
    }
    
    public override string GetInfo()
    {
        return base.GetInfo() + $"Department: {Department}\n" + 
               $"Page count: {Pagecount}";
    }
}