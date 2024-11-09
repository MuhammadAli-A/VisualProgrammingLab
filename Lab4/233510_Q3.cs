using System;
using System.Collections.Generic;
using System.Linq;

public class WordExtractor
{
    public static string[] ExtractWordsWithVowels(string input)
    {
        // Split the input into words
        string[] words = input.Split(new char[] { ' ', '\r', '\n', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Filter words based on length and containing vowels
        var filteredWords = words.Where(word => word.Length >= 4 && word.Length <= 5 && word.Any(c => "aeiouAEIOU".Contains(c))).ToArray();

        return filteredWords;
    }
}

class Program
{
    static void Main()
    {
        string text = "This demo shows how to extract words that fit specific criteria.";
        string[] filteredWords = WordExtractor.ExtractWordsWithVowels(text);

        Console.WriteLine("Extracted Words:");
        foreach (string word in filteredWords)
        {
            Console.WriteLine(word);
        }
    }
}
