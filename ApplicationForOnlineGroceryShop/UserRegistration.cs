using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public class UserRegistration:PersonelDetails,IBalance
    {
      private static double s_balance=0;
      public double Balance{get{return s_balance;}set{}}
      private static int s_customerID=1000;
      public string CustomerID{get;set;}
      public UserRegistration(string name,string fatherName,Gender gender,long phone,DateTime dob,string mail):base(name,fatherName, gender,phone, dob,mail)
      {
        s_customerID++;
        CustomerID="CID"+s_customerID;
        Name=name;
        FatherName=fatherName;
        GenDer=gender;
        Phone=phone;
        DateOfBirth=dob;
        Mail=mail;
      }
      public UserRegistration(string name,string fatherName,Gender gender,long phone,DateTime dob,string mail,string data):base(name,fatherName, gender,phone, dob,mail)
      {
         string[] values=data.Split(",");
         s_customerID=Convert.ToInt32(values[0].Remove(0,3));
         CustomerID=values[0];
         Name=values[1];
         FatherName=values[2];
         GenDer=Enum.Parse<Gender>(values[3],true);
         Phone=Convert.ToInt64(values[4]);
         DateOfBirth=DateTime.ParseExact(values[5],("dd/MM/yyyy"),null);
         Mail=values[6];
         Balance=Convert.ToDouble(values[7]);
      }
      public void Deposit(double amount)
      {
        s_balance+=amount;
      }
      public void WithDraw(double amount)
      {
        s_balance-=amount;
      }
    }
}