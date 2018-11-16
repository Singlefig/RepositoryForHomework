using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU
    enum CurrencyTypes
    {
        UAH,
        USD,
        EU
    }



    class Money
    {
        // 2) declare 2 properties Amount, CurrencyType
        public int Amount { get; set; }
        public CurrencyTypes CurrencyType { get; set; }
        // 3) declare parameter constructor for properties initialization
        public Money()
        {
            
        }
        // 4) declare overloading of operator + to add 2 objects of Money
        public static int operator +(Money money1,Money money2)
        {
            if (money1.CurrencyType == money2.CurrencyType)
                return money1.Amount + money2.Amount;
            else
                return -1;
        }

        public static int operator +(Money money1, double money2)
        {
                return money1.Amount + (int)money2;
        }

        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator --(Money money)
        {
            money.Amount--;
            return money;
        }

        public static Money operator ++(Money money)
        {
            money.Amount++;
            return money;
        }
        // 6) declare overloading of operator * to increase object of Money 3 times
        public static int operator *(Money money,int value)
        {
            return money.Amount*value;
        }
        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator >(Money money1,Money money2)
        {
            return money1.Amount>money2.Amount;
        }

        public static bool operator >(Money money1, string money2)
        {
            return money1.Amount > int.Parse(money2);
        }

        public static bool operator <(Money money1, Money money2)
        {
            return money1.Amount < money2.Amount;
        }

        public static bool operator <(Money money1, string money2)
        {
            return money1.Amount < int.Parse(money2);
        }
        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money money1)
        {
            return money1.CurrencyType == (CurrencyTypes)0;
        }

        public static bool operator false(Money money1)
        {
            return money1.CurrencyType == (CurrencyTypes)1;
        }
        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static explicit operator double(Money d)
        {
            double d0 = d.Amount;
            return d0;
        }

        public static explicit operator string(Money d)
        {
            string a = $"{d.Amount}";
            return a;
        }
    }
}
