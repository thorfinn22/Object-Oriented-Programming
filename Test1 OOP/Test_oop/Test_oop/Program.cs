using System;
using System.Collections.Generic;

namespace Test_oop
{
    
    class Program
    {
        static void Main(string[] args)
        {
            
            var test_analyser = new DataAnalyser(new List<int> { 1, 0, 3, 5, 1, 7, 2, 9, 9 }, new MinMaxSummary());

            // Call the Summarise method to print the summary of the list
            test_analyser.Summarise();

            // Add three more numbers to the data analyser
            Console.WriteLine("Now adding three more numbers ::::");
            test_analyser.AddNumber(12);
            test_analyser.AddNumber(18);
            test_analyser.AddNumber(20);

      
            test_analyser.Strategy = new AverageSummary();

            // Call the Summarise method again to print the new summary of the updated list
            test_analyser.Summarise();

            Console.ReadLine();
        }
    }
}
