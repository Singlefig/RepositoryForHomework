using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money money1 = new Money
            {
                Amount = 2000,
                CurrencyType = (CurrencyTypes)0
            };

            Money money2 = new Money
            {
                Amount = 3000,
                CurrencyType = (CurrencyTypes)0
            };
            // 11) do operations
            // add 2 objects of Money
            Console.WriteLine(money1 + money2);
            // add 1st object of Money and double
            double d0 = 1000.25;
            Console.WriteLine(money1 + d0);
            // decrease 2nd object of Money by 1 
            money2--;
            Console.WriteLine(money2.Amount);
            // increase 1st object of Money
            money1++;
            Console.WriteLine(money1.Amount);
            // compare 2 objects of Money
            Console.WriteLine(money1 > money2);
            Console.WriteLine(money1 < money2);
            // compare 2nd object of Money and string
            Console.WriteLine(money2 > "123");
            // check CurrencyType of every object
            if (money1)
            {
                Console.WriteLine(money1.CurrencyType);
            }
            if (money2)
            {
                Console.WriteLine(money2.CurrencyType);
            }
            // convert 1st object of Money to string
            string strMoney = (string)money1;    //именуем пременные так, что было видно что это. не используем одну букву
            Console.WriteLine(strMoney);         //  strMoney - венгерская нотация: имя влючает в себя указание на тип

            //и vice versa
            var money = (Money)strMoney;
        }
    }
}
