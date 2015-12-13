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
    }

    public class AccountNumberScanner
    {
        public string Scan(string account)
        {
            string number = string.Empty;
            if (account.Length >= 9)
            {
                var accountLines = account.Split('\n');
                var firstLine = accountLines[0].Substring(0, 3);
                var secondLine = accountLines[1].Substring(0, 3);
                var thirdLine = accountLines[2].Substring(0, 3);
                
                if (IsZero(firstLine + secondLine + thirdLine))
                {
                    number = "0";                    
                }
                else if (IsOne(firstLine + secondLine + thirdLine))
                {
                    number = "1";                    
                }
                else if (IsTwo(firstLine + secondLine + thirdLine))
                {
                    number = "2";                    
                }
                var pendingFirstLine = accountLines[0].Substring(3, accountLines[0].Length - 3);
                var pendingSecondLine = accountLines[1].Substring(3, accountLines[1].Length - 3);
                var pendingThirdLine = accountLines[2].Substring(3, accountLines[2].Length - 3);
                return number + Scan(pendingFirstLine + "\n" + pendingSecondLine + "\n" + pendingThirdLine);
            }
            return number;            
        }

        private bool IsZero(string numberCoded)
        {
            return numberCoded == " _ | ||_|";
        }

        private bool IsOne(string numberCoded)
        {
            return numberCoded == "     |  |";
        }

        private bool IsTwo(string numberCoded)
        {
            return numberCoded == " _  _||_ ";
        }
    }
}
