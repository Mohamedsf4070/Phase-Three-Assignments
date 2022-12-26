using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForMetroCard
{
    public class TicketFairDetails
    {
        private static int s_ticketID=100;
        public string TicketID{get;set;}
        public string FromLocation{get;set;}
        public string Tolocation{get;set;}
        public double Fair{get;set;}
        public TicketFairDetails(string fromLocation,string tolocation,double fair)
        {
            s_ticketID++;
            TicketID="MR"+s_ticketID;
            FromLocation=fromLocation;
            Tolocation=tolocation;
            Fair=fair;
        }
        public TicketFairDetails(string data)
        {
            string[] values=data.Split(",");
            s_ticketID=Convert.ToInt32(values[0].Remove(0,2));
            TicketID=values[0];
            FromLocation=values[1];
            Tolocation=values[2];
            Fair=Convert.ToDouble(values[3]);
        }
    }
}