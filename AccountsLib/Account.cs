using System;

namespace AccountsLib
{
    public class Account
    {
        private int _id;

        //Nice.
        public int ID => _id;

        private double _balance;
        public double Balance => _balance;

        internal Account(int accId)
        {
            _id = accId;
        }

        //It isn't good to write console messages in business data. Remember that this is a class library that can be loaded in an app that isn't a console applicaoin.
        public void Deposit(double depositAmount)
        {
            _balance += depositAmount;
            Console.WriteLine($"New account {_id} balance after deposit is: {_balance}");
        }

        //How would you unit test this?
        public void Withdraw(double withdrawAmount)
        {
            if (withdrawAmount > _balance)
            {
                Console.WriteLine($"Account {_id} do not have any funds");
            }
            else
            {
                _balance -= withdrawAmount;
                Console.WriteLine($"Account ID {_id} New balance for  after withdraw: {_balance}");
            }
        }

        public void Transfer(Account secAccount, double transferAmount)
        {
            if (transferAmount > _balance)
            {
                Console.WriteLine($"Account ID {_id} Can't you do not have money.. go work");
            }
            else
            {
                secAccount._balance += transferAmount;
                Console.WriteLine($"Account ID {secAccount._id} New Balance after transfer is: {secAccount._balance}");
                _balance -= transferAmount;
                Console.WriteLine($"Account ID {_id} New Balance after transfer is: {_balance}");
            }
        }
    }

    public static class AccountFactory
    {
        private static int _initialId = 1;
        public static Account CreateAccount(double initialBalance)
        {
            Account newAccount = new Account(_initialId++);
            newAccount.Deposit(initialBalance);
            return newAccount;
        }
    }
}

