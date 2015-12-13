using System.Collections.Generic;

namespace BankOCR
{
    public class AccountNumberScanner
    {
        private readonly Dictionary<string, string> numberCodes = new Dictionary<string, string>
        {
            { " _ | ||_|", "0" },
            { "     |  |", "1" },
            { " _  _||_ ", "2" },
        };

        public string Scan(string account)
        {            
            if (account.Length >= 9)
            {
                var accountLines = account.Split('\n');                                            
                return numberCodes[ExtractFirstNumberCode(accountLines)] + Scan(ExtractPendingNumbersCode(accountLines));
            }
            return string.Empty;            
        }

        private static string ExtractPendingNumbersCode(string[] accountLines)
        {
            var pendingFirstLine = accountLines[0].Substring(3, accountLines[0].Length - 3);
            var pendingSecondLine = accountLines[1].Substring(3, accountLines[1].Length - 3);
            var pendingThirdLine = accountLines[2].Substring(3, accountLines[2].Length - 3);
            return pendingFirstLine + "\n" + pendingSecondLine + "\n" + pendingThirdLine;
        }

        private static string ExtractFirstNumberCode(string[] accountLines)
        {
            var firstLine = accountLines[0].Substring(0, 3);
            var secondLine = accountLines[1].Substring(0, 3);
            var thirdLine = accountLines[2].Substring(0, 3);
            return firstLine + secondLine + thirdLine;
        }        
    }
}