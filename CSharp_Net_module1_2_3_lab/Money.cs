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
                // энумка на практике всегда дожна содеражть нулевым элемнтом какой нибудь Unknown или Unspecified или None
                // потому что энумку можно парсить со строки
                // и если не распарсили - 0, т.е. Unknown

        //Unknown
        UAH,
        USD,
        EU
    }


    //деньги всегда decimal, никогда инт либо дабл
    class Money
    {
        // 2) declare 2 properties Amount, CurrencyType
        public decimal Amount { get; set; }
        public CurrencyTypes CurrencyType { get; set; }
        public Money()
        {

        }
        // 3) declare parameter constructor FOR PROPERTIES INITIALIZATION
        public Money(decimal amount, CurrencyTypes currencyType)
        {
            Amount = amount;
            CurrencyType = currencyType;
        }
        // 4) declare overloading of operator + to add 2 objects of Money
        public static decimal operator +(Money money1,Money money2)
        {
            if (money1.CurrencyType == money2.CurrencyType)
                return money1.Amount + money2.Amount;
            else
                return -1;
        }

        public static decimal operator +(Money money1, double money2)
        {
                return money1.Amount + (decimal)money2;
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
        public static decimal operator *(Money money,decimal value)
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
            return money1.Amount > decimal.Parse(money2);
        }

        public static bool operator <(Money money1, Money money2)
        {
            return money1.Amount < money2.Amount;
        }

        public static bool operator <(Money money1, string money2)
        {
            return money1.Amount < decimal.Parse(money2);
        }
        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money money1)
        {
            // и автор задания скорее всего предполагал чтоб волюта не была Unknown, т.е. не была 0
            return money1.CurrencyType == (CurrencyTypes)0;
        }

        public static bool operator false(Money money1)
        {
            return money1.CurrencyType == (CurrencyTypes)1;
        }
        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static explicit operator double(Money d)
        {            
            return (double)d.Amount;
        }

        public static explicit operator string(Money d)
        {
            //хорошо, но я б еще код валюты включил сюда
            //string a = $"{d.Amount}";
            //return a;

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            //такой формат создания строки  - знак доллара и фигурные скобки - интерполяция
            return $"{d.CurrencyType.ToString()} {d.Amount}";

        }

        public static explicit operator Money(string value)
        {
            //мы это не рассматривали, но в задании оно есть
            // Enum.Parse - механизм приведения строки к енумке: в метод передали тип и строку, на выходе получили object который привели к нужному типу
            //string.Split() - получения массива стрингов по разделителю (пробел, запятая и т.п.)
            //value.Split()[0] вернет нам значение до пробела
            //value.Split()[1] вернет нам значение после пробела
            string strCur = value.Split()[0];
            CurrencyTypes currency = (CurrencyTypes)Enum.Parse(typeof(CurrencyTypes), strCur);
            string strAmount = value.Split()[1];
            decimal amount = decimal.Parse(strAmount);
            return new Money(amount, currency);

        }
    }
}
