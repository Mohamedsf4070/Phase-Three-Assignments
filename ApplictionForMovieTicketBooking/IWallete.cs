using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplictionForMovieTicketBooking
{
    public interface IWallete
    {
        static double s_walleteBalance;
        public void Withdraw(double amount);
        public void Deposit(double amount);
    }
}