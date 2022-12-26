using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public class productDetails
    {
        private static int s_productID=100;
        public string ProductID{get;set;}
        public string ProductName{get;set;}
        public int Quantity{get;set;}
        public double Price{get;set;}
        public productDetails(string productName,int quantity,double price)
        {
                s_productID++;
                ProductID="PID"+s_productID;
                ProductName=productName;
                Quantity=quantity;
                Price=price;
        }
        public productDetails(string data)
        {
            String[] values=data.Split(",");
            s_productID=Convert.ToInt32(values[0].Remove(0,3));
            ProductID=values[0];
            ProductName=values[1];
            Quantity=Convert.ToInt32(values[2]);
            Price=Convert.ToDouble(values[3]);
        }
        
    }
}