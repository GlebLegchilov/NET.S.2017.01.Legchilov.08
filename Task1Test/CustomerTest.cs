using System;
using NUnit.Framework;
using Task1;
using Task1Extension;
using System.Collections.Generic;

namespace Task1Test
{
    
    public class CustomerTest
    {

        static object[] CustomerFormatting_TestData =
        {
                new TestCaseData("G", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00"),
                new TestCaseData("NPR", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00"),
                new TestCaseData("NP", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, +1 (425) 555-0100"),
                new TestCaseData("NR", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, 1,000,000.00"),
                new TestCaseData("PR", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("+1 (425) 555-0100, 1,000,000.00"),
                new TestCaseData("N", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter"),
                new TestCaseData("P", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("+1 (425) 555-0100"),
                new TestCaseData("R", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("1,000,000.00")
        };

        [Test, TestCaseSource("CustomerFormatting_TestData")]
        public static string CustomerFormatting_PositivTest(string format, Customer customer)
        {
            return string.Format("{0:" + format + "}", customer);
        }


        static object[] CustomerFormatProvider_TestData =
        {            
            new TestCaseData(new CustomerFormatProvider(), "NRd", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Customer record: Jeffrey Richter, $1,000,000.00"),
            new TestCaseData(new CustomerFormatProvider(), "Rd", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Customer record: $1,000,000.00"),
            new TestCaseData(new CustomerFormatProvider(), "G", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00"),
            new TestCaseData(new CustomerFormatProvider(), "NPR", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00"),
            new TestCaseData(new CustomerFormatProvider(), "NP", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, +1 (425) 555-0100"),
            new TestCaseData(new CustomerFormatProvider(), "NR", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter, 1,000,000.00"),
            new TestCaseData(new CustomerFormatProvider(), "PR", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("+1 (425) 555-0100, 1,000,000.00"),
            new TestCaseData(new CustomerFormatProvider(), "N", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("Jeffrey Richter"),
            new TestCaseData(new CustomerFormatProvider(), "P", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("+1 (425) 555-0100"),
            new TestCaseData(new CustomerFormatProvider(), "R", new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 }).Returns("1,000,000.00")
    };


        [Test, TestCaseSource("CustomerFormatProvider_TestData")]
        public static string CustomerFormatProvider_PositivTest(IFormatProvider formatProvider, string format, Customer customer)
        {
            return string.Format(formatProvider, "{0:" + format + "}", customer);
        }

    }
}
