﻿using System;
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
        [TestCase("444444444")]
        [TestCase("555555555")]
        [TestCase("666666666")]
        [TestCase("777777777")]
        [TestCase("888888888")]
        [TestCase("999999999")]
        [TestCase("123456789")]
        public void Should_return_account_number_for_the_input(string expected)
        {
            var scanner = new AccountNumberScanner();
            var input = File.ReadAllText($"./TestInputs/{expected}.txt");            
            var actual = scanner.Scan(input);
            Check.That(actual).IsEqualTo(expected);
        }
    }
}
