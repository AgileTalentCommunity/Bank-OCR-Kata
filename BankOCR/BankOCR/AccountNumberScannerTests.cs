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
        public void Should_return_00_when_input_is_00()
        {
            var scanner = new AccountNumberScanner();
            var input = " _  _ \n| || |\n|_||_|\n      ";
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo("00");
        }

        [Test]
        public void Should_return_000000000_when_input_is_000000000()
        {
            var scanner = new AccountNumberScanner();
            var input = " _  _  _  _  _  _  _  _  _ \n| || || || || || || || || |\n|_||_||_||_||_||_||_||_||_|\n                           ";
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo("000000000");
        }

        [Test]
        public void Should_return_111111111_when_input_is_111111111()
        {
            var scanner = new AccountNumberScanner();
            var input = "                           \n  |  |  |  |  |  |  |  |  |\n  |  |  |  |  |  |  |  |  |\n                           ";
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo("111111111");
        }

        [Test]
        public void Should_return_222222222_when_input_is_222222222()
        {
            var scanner = new AccountNumberScanner();
            var input = " _  _  _  _  _  _  _  _  _ \n _| _| _| _| _| _| _| _| _|\n|_ |_ |_ |_ |_ |_ |_ |_ |_ \n                           ";
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo("222222222");
        }

        [Test]
        public void Should_return_333333333_when_input_is_333333333()
        {
            var scanner = new AccountNumberScanner();
            var input = " _  _  _  _  _  _  _  _  _ \n _| _| _| _| _| _| _| _| _|\n _| _| _| _| _| _| _| _| _|\n                           ";
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo("333333333");
        }
    }
}
