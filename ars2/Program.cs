using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordProcessor
{
    static void Main()
    {
        try
        {
            // Step 1: Read text from file
            string filePath = @"C:\Users\DELL\OneDrive\Desktop\textfile.txt"; // Use the full file path
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string text = File.ReadAllText(filePath);

            // Step 2: Preprocess the text into words
            var words = text.ToLower()
                            .Replace("'", "") // Handle possessive cases
                            .Replace(",", "")
                            .Replace(".", "")
                            .Replace(":", "")
                            .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Step 3: Count word frequencies using a dictionary
            var wordCount = words.GroupBy(w => w)
                                 .ToDictionary(g => g.Key, g => g.Count());

            // Step 4: Display words repeated more than twice
            Console.WriteLine("Words that occur more than twice:");
            foreach (var word in wordCount.Where(w => w.Value > 2))
            {
                Console.WriteLine($"{word.Key} : {word.Value}");
            }

            // Step 5: Display words within a user-specified range
            Console.WriteLine("\nEnter Range Start:");
            int rangeStart = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Range End:");
            int rangeEnd = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nWords with counts between {rangeStart} and {rangeEnd}:");
            foreach (var word in wordCount.Where(w => w.Value >= rangeStart && w.Value <= rangeEnd))
            {
                Console.WriteLine($"{word.Key} : {word.Value}");
            }

            // Step 6: Reverse every word and display
            Console.WriteLine("\nReversed Words:");
            foreach (var word in words)
            {
                Console.Write($"{new string(word.Reverse().ToArray())} ");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        Console.ReadKey(); // Keeps the console open for user to review output
    }
}
