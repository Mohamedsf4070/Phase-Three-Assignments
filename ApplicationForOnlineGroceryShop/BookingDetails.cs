using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public enum BookingStatus{select,Initiated,Booked,Cancelled}
    public class BookingDetails
    {
      private static int s_bookingID=100;
      public string BookingID{get;set;}
      public string CustomerID{get;set;}
      public double TotalPrice{get;set;}
      public DateTime DateOfBooking{get;set;}
      public BookingStatus BookingState{get;set;}
      public BookingDetails(string customerID,double totalPrice,DateTime dateOfBooking,BookingStatus status)
      {
        s_bookingID++;
        BookingID="BID"+s_bookingID;
        CustomerID=customerID;
        TotalPrice=totalPrice;
        DateOfBooking=dateOfBooking;
        BookingState=status;
      }  
      public BookingDetails(string data)
      {
        string[] values=data.Split(",");
        s_bookingID=Convert.ToInt32(values[0].Remove(0,3));
        BookingID=values[0];
        CustomerID=values[1];
        TotalPrice=Convert.ToDouble(values[2]);
        DateOfBooking=DateTime.ParseExact(values[3],("dd/MM/yyyy"),null);
        BookingState=Enum.Parse<BookingStatus>(values[4],true);
      }
    }
}