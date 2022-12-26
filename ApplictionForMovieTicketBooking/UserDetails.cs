using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplictionForMovieTicketBooking
{
    public class UserDetails:PersonelDetails,IWallete
    {
      private static   double s_walleteBalance=0;
        public  double WalleteBalance{get{return s_walleteBalance;}set{}}
        private static int s_userID=1000;
        public string UserID{get;set;}
        
        public UserDetails(string name,int age,long phone):base( name,age, phone)
        {
           s_userID++;
           UserID="UID"+s_userID;
           Name=name;
           Age=age;
           Phone=phone;
        }
        public UserDetails(string name,int age,long phone,string data):base( name,age, phone)
        {
            string[]  values=data.Split(",");
            WalleteBalance=Convert.ToDouble(values[0]);
            s_userID=Convert.ToInt32(values[1].Remove(0,3));
            UserID=values[1];
            Name=values[2];
            Age=Convert.ToInt32(values[3]);
            Phone=Convert.ToInt64(values[4]);
            
        }
       
        public void Withdraw(double amount)
        {
            s_walleteBalance-=amount;
        }
        public void Deposit(double amount)
        {
            s_walleteBalance+=amount;
        }
    }
}