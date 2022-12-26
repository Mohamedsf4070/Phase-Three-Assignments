using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForMetroCard
{
    public class TravelDetails
    {
        private static int s_travelID=100;
        public string TravelID{get;set;}
        public string CardNumber{get;set;}
        public string FromLocation{get;set;}
        public string  Tolocation{get;set;}
        public DateTime Date{get;set;}
        public double TravelCost{get;set;}
        public TravelDetails(string cardNumber,string fromLocation,string toLocation,DateTime date,double travelCost)
        {
            s_travelID++;
            TravelID="TID"+s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            Tolocation=toLocation;
            Date=date;
            TravelCost=travelCost;

        }
        public TravelDetails(string data)
        {
            string[] values=data.Split(",");
            s_travelID=Convert.ToInt32(values[0].Remove(0,3));
            TravelID=values[0];
            CardNumber=values[1];
            FromLocation=values[2];
            Tolocation=values[3];
            Date=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            TravelCost=Convert.ToDouble(values[5]);
        }
        
    }
}