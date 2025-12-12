// See https://aka.ms/new-console-template for more information
using System;

class StudentMarksReport
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[] marks = new int[n];

        Console.WriteLine("\nEnter marks:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Student {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }

        int[] backup = new int[n];
        Array.Copy(marks, backup, n);

        Console.WriteLine("\nOriginal Marks:");
        DisplayArray(marks);

        int[] sorted = new int[n];
        Array.Copy(marks, sorted, n);
        Array.Sort(sorted);

        Console.WriteLine("\nSorted Marks:");
        DisplayArray(sorted);

        int total = 0, highest = marks[0], lowest = marks[0];
        foreach (int m in marks)
        {
            total += m;
            if (m > highest) highest = m;
            if (m < lowest) lowest = m;
        }

        Console.WriteLine("\n--- Marks Summary ---");
        Console.WriteLine($"Total Marks: {total}");
        Console.WriteLine($"Highest Mark: {highest}");
        Console.WriteLine($"Lowest Mark: {lowest}");


        Console.Write("\nEnter a mark to search: ");
        int searchVal = int.Parse(Console.ReadLine());

        bool found = Array.Exists(marks, x => x == searchVal);
        Console.WriteLine(found ? "Mark FOUND." : "Mark NOT FOUND.");

        Console.WriteLine("\nEnter another set of marks to compare:");
        int[] compareSet = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Value {i + 1}: ");
            compareSet[i] = int.Parse(Console.ReadLine());
        }

        bool equal = CompareArrays(marks, compareSet);
        Console.WriteLine(equal ? "\nBoth mark sets are IDENTICAL." : "\nMark sets are DIFFERENT.");
    }

    static void DisplayArray(int[] arr)
    {
        foreach (var v in arr) Console.Write(v + " ");
        Console.WriteLine();
    }

    static bool CompareArrays(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return false;
        return true;
    }
}