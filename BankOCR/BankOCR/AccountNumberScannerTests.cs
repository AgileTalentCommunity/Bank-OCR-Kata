using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace BankOCR
{
    public class AccountNumberScannerTests
    {        
        [TestCase("00")]
        [TestCase("000000000")]
        [TestCase("111111111")]
        [TestCase("222222222")]
        [TestCase("333333333")]
        public void Should_return_000000000_when_input_is_000000000(string expected)
        {
            var scanner = new AccountNumberScanner();
            var input = File.ReadAllText($"./TestInputs/{expected}.txt");            
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo(expected);
        }
    }
}
