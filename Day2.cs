using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Day2
{
    static void Main2()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        var reports = File.ReadAllLines(currentDirectory + @"\inputs\input2.txt").Select(line => line.Split(' ').Select(int.Parse).ToList()).ToList();

        var numReportsSafe = reports.Count(IsReportSafe);
        var numReportsSafeWithOneRemoval = reports.Count(IsReportSafeWithOneRemoval);

        Console.WriteLine($"Part 1: {numReportsSafe}");
        Console.WriteLine($"Part 2: {numReportsSafeWithOneRemoval}");
    }

    static bool IsReportSafe(List<int> report)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;
        for (int i = 1; i < report.Count; i++)
        {
            var difference = Math.Abs(report[i] - report[i - 1]);

            if (difference < 1 || difference > 3)
            {
                return false;
            }

            if (report[i] < report[i - 1])
            {
                isIncreasing = false;
            }
            else if (report[i] > report[i - 1])
            {
                isDecreasing = false;
            }
        }
        return isIncreasing || isDecreasing;
    }

    static bool IsReportSafeWithOneRemoval(List<int> report)
    {
        for (int i = 0; i < report.Count; i++)
        {
            var modifiedReport = new List<int>(report);
            modifiedReport.RemoveAt(i);
            if (IsReportSafe(modifiedReport))
            {
                return true;
            }
        }
        return false;
    }
}