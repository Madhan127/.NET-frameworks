using System;

class TransactionDetails
{
    static void Main()
    {
        string transactionId = "A1B2C3D4E5F6";   // 12-character alphanumeric ID
        decimal amount = 1000000.75m;            // financial amount
        bool isInternational = true;             // boolean
        decimal customerRating = 4.25m;          // precise up to 2 decimals
        DateTime transactionTimestamp = DateTime.Now;  // current date & time
        int rewardPoints = 2500000;              // whole number, up to millions

        Console.WriteLine($"Transaction ID:{transactionId}");
        Console.WriteLine($"Amount: {amount}");
        Console.WriteLine($"International Transaction: {isInternational}");
        Console.WriteLine($" customerRating: {customerRating}");
        Console.WriteLine($"Timestamp: {transactionTimestamp}");
        Console.WriteLine($"Reward Points: {rewardPoints}");
    }
}
