using System;
using System.Collections.Generic;

public class AverageSummary : SummaryStrategy
{

    private float Average(List<int> numbers)
    {
        // calculating the average
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        float avg = (float)sum / numbers.Count;
        return avg;
    }

    public override void PrintSummary(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("Cannot print summary of empty list");
        }

        float average = Average(numbers);
        Console.WriteLine($"The Average is : {average:F2}");
    }
}