using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public class OrderDetails
    {
        private static int s_orderID=100;
        public string OrderID{get;set;}
        public string BookingID{get;set;}
        public string ProductID{get;set;}
        public int PurchaseCount{get;set;}
        public double Price{get;set;}
        public OrderDetails(string bookingID,string productID,int purchaseCount,double price)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            BookingID=bookingID;
            ProductID=productID;
            PurchaseCount=purchaseCount;
            Price=price;
        }
        public OrderDetails(string data)
        {
            string[] values=data.Split(",");
            s_orderID=Convert.ToInt32(values[0].Remove(0,3));
            OrderID=values[0];
           BookingID=values[1];
           ProductID=values[2];
           PurchaseCount=Convert.ToInt32(values[3]);
           Price=Convert.ToDouble(values[4]);

        }
    }
}