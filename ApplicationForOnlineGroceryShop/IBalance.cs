using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public interface IBalance
    {
        static double s_balance;
        public void Deposit(double amount);
        public void WithDraw(double amount);
    }
}