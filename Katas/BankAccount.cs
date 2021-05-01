using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Katas
{
    public class BankAccountTests
    {
        [Fact]
        public void Returns_empty_balance_after_opening()
        {
            var account = new BankAccount();
            account.Open();

            Assert.Equal(0, account.Balance);
        }

        [Fact]
        public void Check_basic_balance()
        {
            var account = new BankAccount();
            account.Open();

            var openingBalance = account.Balance;

            account.UpdateBalance(10);
            var updatedBalance = account.Balance;

            Assert.Equal(0, openingBalance);
            Assert.Equal(10, updatedBalance);
        }

        [Fact]
        public void Balance_can_increment_and_decrement()
        {
            var account = new BankAccount();
            account.Open();
            var openingBalance = account.Balance;

            account.UpdateBalance(10);
            var addedBalance = account.Balance;

            account.UpdateBalance(-15);
            var subtractedBalance = account.Balance;

            Assert.Equal(0, openingBalance);
            Assert.Equal(10, addedBalance);
            Assert.Equal(-5, subtractedBalance);
        }

        [Fact]
        public void Closed_account_throws_exception_when_checking_balance()
        {
            var account = new BankAccount();
            account.Open();
            account.Close();

            Assert.Throws<InvalidOperationException>(() => account.Balance);
        }

        [Fact]
        public void Change_account_balance_from_multiple_threads()
        {
            var account = new BankAccount();
            var tasks = new List<Task>();

            var threads = 500;
            var iterations = 100;

            account.Open();
            for (int i = 0; i < threads; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < iterations; j++)
                    {
                        account.UpdateBalance(1);
                        account.UpdateBalance(-1);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Assert.Equal(0, account.Balance);
        }
    }


    public class BankAccount
    {
        private decimal _balance;
        private bool _isAccountStillOpen;
        private Mutex _mutex;

        public BankAccount()
        {
            _mutex = new Mutex();
        }

        public void Open()
        {
            _isAccountStillOpen = true;
            _balance = 0;
        }

        public void Close()
        {
            _isAccountStillOpen = false;
        }

        public decimal Balance
        {
            get
            {
                if (_isAccountStillOpen)
                    return _balance;
                else
                {
                    throw new InvalidOperationException("Account is closed. Cannot update balance.");
                }
            }
        }

        public void UpdateBalance(decimal change)
        {
            _mutex.WaitOne();
            _balance += change;
            _mutex.ReleaseMutex();

        }
    }
}