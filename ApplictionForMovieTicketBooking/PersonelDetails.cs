using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplictionForMovieTicketBooking
{
    public class PersonelDetails
    {
        public string Name{get;set;}
        public int Age{get;set;}
        public long Phone{get;set;}
        public PersonelDetails(string name,int age,long phone)
        {
            Name=name;
            Age=age;
            Phone=phone;
        }
    }
}