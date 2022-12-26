using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForMetroCard
{
    public class UserDetails
    {
        private static int s_cardNumber=100;
        private double _balance=0;
        public string CardNumber{get;set;}
        public string UserName{get;set;}
        public long Phone{get;set;}
        public double Balance{get{return _balance;}set{_balance=value;}}
        public UserDetails(string userName,long phone)
        {
           s_cardNumber++;
           CardNumber="CMRL"+s_cardNumber;
           UserName=userName;
           Phone=phone;
           
        }
        public UserDetails(string data)
        {
            string[] values=data.Split(",");
            s_cardNumber=Convert.ToInt32(values[0].Remove(0,4));
            CardNumber=values[0];
            UserName=values[1];
            Phone=Convert.ToInt64(values[2]);
            Balance=Convert.ToDouble(values[3]);
        }
        public void Withdraw(double amount)
        {
            _balance-=amount;
        }
        public void Deposit(double amount)
        {
            _balance+=amount;
        }
       
    }
}