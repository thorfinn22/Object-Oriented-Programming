using System;
using System.Collections.Generic;

// Abstract class for summarizing data.
public abstract class SummaryStrategy
{
    public abstract void PrintSummary(List<int> numbers);
}