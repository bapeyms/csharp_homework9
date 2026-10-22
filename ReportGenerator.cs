using System.Text;

namespace csharp_homework9;

public class ReportGenerator
{
    public string GenerateReport(Document[] documents, int documentCounter)
    {
        StringBuilder report = new StringBuilder();

        int toralDocuments = 0;
        int totalWords = 0;
        int totalCharacters = 0;
        
        report.AppendLine("--- REPORT ---");
        for (int i = 0; i < documentCounter; i++)
        {
            Document document = documents[i];
            toralDocuments++;
            
            DocumentStatistics statistics = document.AnalyzeText();
            
            report.AppendLine(document.GetInfo());
            report.AppendLine("--- Text Statistics ---");
            report.AppendLine($"Word count: {statistics.WordCount}");
            report.AppendLine($"Character count: {statistics.CharacterCount}");
            report.AppendLine($"Longest word: {statistics.LongestWord}");
            report.AppendLine($"Unique words: {statistics.UniqueCount}");
            report.AppendLine(" ");
            
            totalWords += statistics.WordCount;
            totalCharacters += statistics.CharacterCount;
        }
        report.AppendLine(" ");
        report.AppendLine($"--- SUMMARY ---");
        report.AppendLine($"Total documents: {toralDocuments}");
        report.AppendLine($"Total words: {totalWords}");
        report.AppendLine($"Total characters: {totalCharacters}");
        
        return report.ToString();
    }
}