using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Loans.Tests
{
    public class MonthlyRepaymentCsvData
    {
        public static IEnumerable GetTestCases(string csvFileName)
        {
            var csvLines = File.ReadAllLines(csvFileName);
            var testCases = new List<TestCaseData>();

            foreach (var line in csvLines)
            {
                string[] values = line.Replace(" ", "").Split(',');

                decimal principal = decimal.Parse(values[0], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                decimal interestRate = decimal.Parse(values[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                int termInYears = int.Parse(values[2]);
                decimal expectedRepayment = decimal.Parse(values[3], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

                testCases.Add(new TestCaseData(principal, interestRate, termInYears, expectedRepayment));
            }

            return testCases;
        }
    }
}