// This class represents a data analyser that can summarise a list of numbers
// using a selected strategy.
using System;
using System.Collections.Generic;

public class DataAnalyser
{
    private List<int> _numbers; // list of numbers to analyse
    private SummaryStrategy _strategy; // selected strategy for summarising

    // Default constructor, creates a new DataAnalyser object with an empty list of numbers
    // and the default strategy of AverageSummary.
    public DataAnalyser() : this(new List<int>(), new AverageSummary())
    {
    }

    // Constructor that takes a list of numbers as a parameter and sets the default strategy to AverageSummary.
    public DataAnalyser(List<int> numbers) : this(numbers, new AverageSummary())
    {
    }

    // Constructor that takes a list of numbers and a strategy as parameters.
    public DataAnalyser(List<int> numbers, SummaryStrategy strategy)
    {
        _numbers = numbers;
        _strategy = strategy;
    }

    // Property to get or set the summary strategy.
    public SummaryStrategy Strategy
    {
        get { return _strategy; }
        set { _strategy = value; }
    }

    // Method to add a new number to the list of numbers.
    public void AddNumber(int num)
    {
        _numbers.Add(num);
    }

    // Method to summarise the list of numbers using the selected strategy.
    public void Summarise()
    {
        _strategy.PrintSummary(_numbers);
    }

}
