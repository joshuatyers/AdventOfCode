using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Day1
{
    static void Main()
    {
        // Previously used new[] {} to initialize the collection.
        // Now using a collection initializer with square brackets [] for simplicity.
        List<int> column1 = new List<int>();
        List<int> column2 = new List<int>();

        string currentDirectory = Directory.GetCurrentDirectory();
        string[] lines = File.ReadAllLines(currentDirectory + @"\inputs\input1.txt");
        foreach (var line in lines)
        {
            var columns = line.Split(new[] { "  " }, StringSplitOptions.None);
            column1.Add(int.Parse(columns[0]));
            column2.Add(int.Parse(columns[1]));
        }

        column1.Sort();
        column2.Sort();

        Console.WriteLine($"Part 1: {Part1(column1, column2)}");
        Console.WriteLine($"Part 2: {Part2(column1, column2)}");
    }

    static int Part1(List<int> column1, List<int> column2)
    {
        // Zip is used to combine the two collections into a single collection of pairs.
        return column1.Zip(column2, (num1, num2) => Math.Abs(num1 - num2)).Sum();
    }

    static int Part2(List<int> column1, List<int> column2)
    {
        // Works as a nested loop to multiply each element in column1 by the 
        // count of the same element in column2.
        return column1.Sum(num1 => num1 * column2.Count(num2 => num2 == num1));
    }
}
