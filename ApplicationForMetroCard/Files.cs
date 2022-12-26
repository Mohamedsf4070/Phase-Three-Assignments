using System;

using System.IO;

namespace ApplicationForMetroCard
{
    public static class Files
    {
        public static void Create()
        {
            if (!Directory.Exists("ApplicationForMetroCard"))
            {
                Directory.CreateDirectory("ApplicationForMetroCard");
                Console.WriteLine("Folder Created");
            }
            else 
            {
                Console.WriteLine("Folder Founded");
            }
            if(!File.Exists("ApplicationForMetroCard/UserDetails.csv"))
            {
               File.Create("ApplicationForMetroCard/UserDetails.csv").Close();
               Console.WriteLine("File created");

            }
            else 
            {
                Console.WriteLine("File Founded");
            }
            if(!File.Exists("ApplicationForMetroCard/TravelDetails.csv"))
            {
               File.Create("ApplicationForMetroCard/TravelDetails.csv").Close();
               Console.WriteLine("File created");

            }
            else 
            {
                Console.WriteLine("File Founded");
            }
            if(!File.Exists("ApplicationForMetroCard/TicketFairDetails.csv"))
            {
               File.Create("ApplicationForMetroCard/TicketFairDetails.csv").Close(
                
               );
               Console.WriteLine("File created");

            }
            else 
            {
                Console.WriteLine("File Founded");
            }
        }
        public static void WriteFile()
        {
           string [] userDetails=new string[Operations.UsersList.Count];
           for(int i=0;i<Operations.UsersList.Count;i++)
           {
            userDetails[i]=Operations.UsersList[i].CardNumber+","+Operations.UsersList[i].UserName+","+Operations.UsersList[i].Phone+","+Operations.UsersList[i].Balance;
           }
           File.WriteAllLines("ApplicationForMetroCard/UserDetails.csv",userDetails);
           string [] ticketFairDetails=new string[Operations.TicketList.Count];
           for(int i=0;i<Operations.TicketList.Count;i++)
           {
            ticketFairDetails[i]=Operations.TicketList[i].TicketID+","+Operations.TicketList[i].FromLocation+","+Operations.TicketList[i].Tolocation+","+Operations.TicketList[i].Fair;
           }
           File.WriteAllLines("ApplicationForMetroCard/TicketFairDetails.csv",ticketFairDetails);
           string [] travelDetails=new string[Operations.TravelList.Count];
           for(int i=0;i<Operations.TravelList.Count;i++)
           {
             travelDetails[i]=Operations.TravelList[i].TravelID+","+Operations.TravelList[i].CardNumber+","+Operations.TravelList[i].FromLocation+","+Operations.TravelList[i].Tolocation+","+Operations.TravelList[i].Date.ToString("dd/MM/yyyy")+","+Operations.TravelList[i].TravelCost;
           }
           File.WriteAllLines("ApplicationForMetroCard/TravelDetails.csv",travelDetails);
        }
        public static void ReadFile()
        {
            string[] UserDetails=File.ReadAllLines("ApplicationForMetroCard/UserDetails.csv");
            foreach(string data in UserDetails)
            {
                UserDetails user1=new UserDetails(data);
                Operations.UsersList.Add(user1);
            }
            string[] TicketFairDetails=File.ReadAllLines("ApplicationForMetroCard/TicketFairDetails.csv");
            foreach(string data in TicketFairDetails)
            {
                TicketFairDetails ticket1=new TicketFairDetails(data);
                Operations.TicketList.Add(ticket1);
            }
            string [] TravelDetails=File.ReadAllLines("ApplicationForMetroCard/TravelDetails.csv");
            foreach(string data in TravelDetails)
            {
                TravelDetails travel1=new TravelDetails(data);
                Operations.TravelList.Add(travel1);
            }
        }
    }
}