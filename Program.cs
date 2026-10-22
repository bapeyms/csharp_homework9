namespace csharp_homework9;

class Program
{
    static void Main(string[] args)
    {
        Document[] documents = new Document[100];
        int documentCounter = 0;
        ReportGenerator reportGenerator = new ReportGenerator();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("--- MENU ---");
            Console.WriteLine("1. Add an article");
            Console.WriteLine("2. Add a report");
            Console.WriteLine("3. Show all documents");
            Console.WriteLine("4. Find a document by the word");
            Console.WriteLine("5. Show document's statistics");
            Console.WriteLine("6. Generate a summary");
            Console.WriteLine("7. Exit");
            
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            Console.WriteLine($"You entered: {option}");
            Console.WriteLine("");
            
            switch (option)
            {
                case "1":
                    if (documentCounter >= documents.Length)
                    {
                        Console.WriteLine("The document array is full!");
                        break;
                    }

                    Console.Write("Enter a title: ");
                    string articleTitle = Console.ReadLine();
                    Console.Write("Enter an author: ");
                    string articleAuthor = Console.ReadLine();
                    Console.Write("Enter a category: ");
                    string articleCategory = Console.ReadLine();
                    int articleReadTime = ReadPositiveInt("Enter a read time (in minutes): ");
                    Console.Write("Enter an article text: ");
                    string articleText = Console.ReadLine();
                    try
                    {
                        documents[documentCounter] = new Article(
                            articleTitle,
                            articleAuthor,
                            articleText,
                            DateTime.Now.ToString("dd.MM.yyyy"),
                            articleCategory,
                            articleReadTime);
                        documentCounter++;
                        Console.WriteLine($"Article {documentCounter} has been added");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"[ERROR!] {e.Message}");
                    }
                    Console.WriteLine("");
                    break;
                case "2":
                    if (documentCounter >= documents.Length)
                    {
                        Console.WriteLine("The document array is full!");
                        break;
                    }

                    Console.Write("Enter a title: ");
                    string reportTitle = Console.ReadLine();
                    Console.Write("Enter an author: ");
                    string reportAuthor = Console.ReadLine();
                    Console.Write("Enter a department: ");
                    string reportDepartment = Console.ReadLine();
                    int reportPageCount = ReadPositiveInt("Enter a page count: ");
                    Console.Write("Enter a report text: ");
                    string reportText = Console.ReadLine();
                    try
                    {
                        documents[documentCounter] = new Report(
                            reportTitle,
                            reportAuthor,
                            reportText,
                            DateTime.Now.ToString("dd.MM.yyyy"),
                            reportDepartment,
                            reportPageCount
                            );
                        documentCounter++;
                        Console.WriteLine($"Report {documentCounter} has been added");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"[ERROR!] {e.Message}");
                    }
                    Console.WriteLine("");
                    break;
                case "3":
                    if (documentCounter == 0)
                    {
                        Console.WriteLine("The document array is empty!");
                        Console.WriteLine("");
                        break;
                    }

                    for (int i = 0; i < documentCounter; i++)
                    {
                        Console.WriteLine($"--- Document {i + 1} ---");
                        Console.WriteLine(documents[i].GetInfo());
                    }
                    Console.WriteLine("");
                    break;
                case "4":
                    Console.Write("Enter a word for the search: ");
                    string searchWord = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < documentCounter; i++)
                    {
                        if (documents[i].ContainsWord(searchWord))
                        {
                            DocumentSummary summary = documents[i].GetSummary();
                            Console.WriteLine($"Document {summary.TitleSummary} is found");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Document with this word was not found!");
                    Console.WriteLine("");
                    break;
                case "5":
                    if (documentCounter == 0)
                    {
                        Console.WriteLine("The document array is empty!");
                        Console.WriteLine("");
                        break;
                    }
                    Console.WriteLine("A list of documents: ");
                    for (int i = 0; i < documentCounter; i++)
                        Console.WriteLine($"{i+1}. {documents[i].Title}");
                    Console.WriteLine("");
                    
                    int documentNumber = ReadPositiveInt("Enter a document number: ");
                    Console.WriteLine("");
                    
                    if (documentNumber > documentCounter)
                    {
                        Console.WriteLine("The document number is greater than the number of the document!");
                        break;
                    }

                    DocumentStatistics statistics = documents[documentNumber - 1].AnalyzeText();
                    Console.WriteLine($"--- Statistics for document {documentCounter} ---");
                    Console.WriteLine($"Number of words: {statistics.WordCount}");
                    Console.WriteLine($"Number of characters: {statistics.CharacterCount}");
                    Console.WriteLine($"The longest word: {statistics.LongestWord}");
                    Console.WriteLine($"Number of unique words: {statistics.UniqueCount}");
                    Console.WriteLine("");
                    break;
                case "6":
                    if (documentCounter == 0)
                    {
                        Console.WriteLine("The document array is empty!");
                        Console.WriteLine("");
                        break;
                    }

                    string result = reportGenerator.GenerateReport(documents, documentCounter);
                    Console.WriteLine(result);
                    break;
                case "7":
                    isRunning = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    static int ReadPositiveInt(string message)
    {
        int number;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                return number;
            Console.WriteLine("Please enter a positive integer!");
        }
    }
}