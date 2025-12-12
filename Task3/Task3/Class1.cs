// See https://aka.ms/new-console-template for more information
using System;

class StoreSalesAnalysis
{
    static void Main()
    {
        Console.Write("Enter number of days in month: ");
        int n = int.Parse(Console.ReadLine());

        int[] sales = new int[n];

        Console.WriteLine("\nEnter sales for each day:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Day {i + 1}: ");
            sales[i] = int.Parse(Console.ReadLine());
        }

        int[] backup = new int[n];
        Array.Copy(sales, backup, n);

        Console.WriteLine("\nOriginal Sales Data:");
        DisplayArray(sales);

        int[] sorted = new int[n];
        Array.Copy(sales, sorted, n);
        Array.Sort(sorted);

        Console.WriteLine("\nSorted Sales Data:");
        DisplayArray(sorted);

        int total = 0, highest = sales[0], lowest = sales[0];

        foreach (int s in sales)
        {
            total += s;
            if (s > highest) highest = s;
            if (s < lowest) lowest = s;
        }

        Console.WriteLine("\n--- Summary Statistics ---");
        Console.WriteLine($"Total Sales: {total}");
        Console.WriteLine($"Highest Sales in a Day: {highest}");
        Console.WriteLine($"Lowest Sales in a Day: {lowest}");

        Console.Write("\nEnter a sales value to search: ");
        int searchValue = int.Parse(Console.ReadLine());

        bool exists = Array.Exists(sales, x => x == searchValue);
        Console.WriteLine(exists ? "Sales value FOUND." : "Sales value NOT FOUND.");

        Console.WriteLine("\nEnter another set of sales values to compare:");

        int[] compareSet = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Value {i + 1}: ");
            compareSet[i] = int.Parse(Console.ReadLine());
        }

        bool equal = CompareArrays(sales, compareSet);
        Console.WriteLine(equal ? "\nBoth sales sets are IDENTICAL." : "\nSales sets are DIFFERENT.");
    }

    static void DisplayArray(int[] arr)
    {
        foreach (int v in arr) Console.Write(v + " ");
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