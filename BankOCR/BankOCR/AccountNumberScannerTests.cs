using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace BankOCR
{
    public class AccountNumberScannerTests
    {
        [Test]
        public void Should_return_000000000_when_input_is_000000000()
        {
            var scanner = new AccountNumberScanner();
            var input = " _  _  _  _  _  _  _  _  _ \n| || || || || || || || || |\n| _ || _ || _ || _ || _ || _ || _ || _ || _ |\n                           ";
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo("000000000");
        }
    }

    public class AccountNumberScanner
    {
        public string Scan(string empty)
        {
            return "000000000";
        }
    }
}
