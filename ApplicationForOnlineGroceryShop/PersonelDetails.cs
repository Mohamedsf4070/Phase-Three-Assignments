using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public enum Gender{select,Male,Female}
    public class PersonelDetails
    {
        public string Name{get;set;}
        public string FatherName{get;set;}
        public Gender GenDer{get;set;}
        public long Phone{get;set;}
        public DateTime DateOfBirth{get;set;}
        public string Mail{get;set;}
        public PersonelDetails(string name,string fatherName,Gender gender,long phone,DateTime dob,string mail)
        {
            Name=name;
            FatherName=fatherName;
            GenDer=gender;
            DateOfBirth=dob;
            Mail=mail;

        }
    }
}