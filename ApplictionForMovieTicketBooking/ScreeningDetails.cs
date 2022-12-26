using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplictionForMovieTicketBooking
{
    public class ScreeningDetails
    {
        public string MovieID{get;set;}
        public string TheaterID{get;set;}
        public int NumberOFSeat{get;set;}
        public double TicketPrice{get;set;}
        public ScreeningDetails(string movieID,string theaterID,int numberOfSeat,double ticketPrice)
        {
            MovieID=movieID;
            TheaterID=theaterID;
            NumberOFSeat=numberOfSeat;
            TicketPrice=ticketPrice;
        }
        public ScreeningDetails(string data)
        {
            string[] values=data.Split(",");
            MovieID=values[0];
            TheaterID=values[1];
            NumberOFSeat=Convert.ToInt32(values[2]);
            TicketPrice=Convert.ToDouble(values[3]);
        }

    }
}