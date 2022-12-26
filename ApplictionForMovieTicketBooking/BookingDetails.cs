using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplictionForMovieTicketBooking
{
    public enum BookingStatus{booked,cancelled}
    public class BookingDetails
    {
        private static int s_bookingID=1000;
        public string BookingID{get;set;}
        public string UserID{get;set;}
        public string MovieID{get;set;}
        public string TheaterID{get;set;}
        public int SeatCount{get;set;}
        public double TotalAmount{get;set;}
        public BookingStatus BookingState{get;set;}
        public BookingDetails(string userID,string movieID,string theaterID,int seatCount,double totalAmount,BookingStatus bookingState)
        {
            s_bookingID++;
            BookingID="BID"+s_bookingID;
            UserID=userID;
            MovieID=movieID;
            TheaterID=theaterID;
            SeatCount=seatCount;
            TotalAmount=totalAmount;
            BookingState=bookingState;
        }
        public BookingDetails(string data)
        {
            string[] values=data.Split(",");
            s_bookingID=Convert.ToInt32(values[0].Remove(0,3));
            BookingID=values[0];
            UserID=values[1];
            MovieID=values[2];
            TheaterID=values[3];
            SeatCount=Convert.ToInt32(values[4]);
            TotalAmount=Convert.ToDouble(values[5]);
            BookingState=Enum.Parse<BookingStatus>(values[6],true);
        }
    }
}