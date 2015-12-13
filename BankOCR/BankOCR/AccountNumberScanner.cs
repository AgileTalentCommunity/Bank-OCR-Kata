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
            { " _  _| _|", "3" },
            { "   |_|  |", "4" },
            { " _ |_  _|", "5" },
        };

        public string Scan(string account)
        {            
            if (account.Length >= 9)
                return numberCodes[account.ExtractFirstNumberCode()] + Scan(account.ExtractPendingNumbersCode());            
            return string.Empty;            
        }                
    }
}