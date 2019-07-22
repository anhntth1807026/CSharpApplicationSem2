using System;
namespace ConsoleApp3.entity
{
    public class SHBAccount
    {
        public SHBAccount() { }
        public SHBAccount(string username, string password, double balance, string accountNumber)
        {
            Username = username;
            Password = password;
            Balance = balance;
            AccountNumber = accountNumber;
        }
        
        public string Username { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        
        public long CreatedAtMLS { get; set; }
        
        public long UpdatedAtMLS { get; set; }
        public string AccountNumber { get; set; }

    }
}