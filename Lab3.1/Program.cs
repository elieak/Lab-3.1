using AccountsLib;

namespace Account
{
    class Program
    {
        static void Main()
        {
            var account = AccountFactory.CreateAccount(1000);
            var account2 = AccountFactory.CreateAccount(900);
            account.Deposit(50);
            account.Withdraw(100);
            account.Transfer(account2,400);
        }
    }
}
