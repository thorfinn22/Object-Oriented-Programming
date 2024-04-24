using System;
using System.Collections.Generic;

public class MinMaxSummary : SummaryStrategy
{

    private int Minimum(List<int> numbers)
    {
        int minimum = numbers[0];
        foreach (int num in numbers)
        {
            if (num < minimum)
            {
                minimum = num;
            }
        }

        return minimum;
    }

    private int Maximum(List<int> numbers)
    {

        int maximum = numbers[0];
        foreach (int num in numbers)
        {
            if (num > maximum)
            {
                maximum = num;
            }
        }

        return maximum;
    }

    public override void PrintSummary(List<int> numbers)
    {


        int minimum = Minimum(numbers);
        int maximum = Maximum(numbers);

        Console.WriteLine("The Minimum of the numbers is : {0}", minimum);
        Console.WriteLine("The Maximum of the numbers is : {0}", maximum);
    }

}