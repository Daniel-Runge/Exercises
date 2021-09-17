using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class BankAccount
    {
        private int _balance;
        private int _borrowingRate;
        private int _savingsRate;

        public int Balance
        {
            get => _balance;
            set
            {
                if (value is < -100000 or > 250000)
                {
                    throw new ArgumentException($"{nameof(value)} can't be less than -100.000 or above 250.000");
                }
                _balance = value;
            }
        }

        public int BorrowingRate
        {
            get => _borrowingRate;
            set
            {
                if (value < 6)
                {
                    throw new ArgumentException($"{nameof(value)} must be at least 6");
                }

                _borrowingRate = value;
            }
        }

        public int SavingsRate
        {
            get => _savingsRate;
            set
            {
                if (value > 2)
                {
                    throw new ArgumentException($"{nameof(value)} must be at most 2");
                }
                _savingsRate = value;
            }
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"{nameof(amount)} must be positive");
            }

            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"{nameof(amount)} must be positive");
            }

            Balance -= amount;
        }

        public void AccrueOrChargeInterest()
        {
            if (Balance < 0)
            {
                Balance += Balance * BorrowingRate / 100;
            }
            else
            {
                Balance += Balance * SavingsRate / 100;
            }


        }
    }
}
