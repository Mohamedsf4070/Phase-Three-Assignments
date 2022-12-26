using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ApplictionForMovieTicketBooking
{
    public static class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("ApplictionForMovieTicketBooking"))
            {
                Directory.CreateDirectory("ApplictionForMovieTicketBooking");
            }
            if(!File.Exists("ApplictionForMovieTicketBooking/UserDetails.csv"))
            {
                File.Create("ApplictionForMovieTicketBooking/UserDetails.csv").Close();
            }
            if(!File.Exists("ApplictionForMovieTicketBooking/TheaterDetails.csv"))
            {
                File.Create("ApplictionForMovieTicketBooking/TheaterDetails.csv").Close();
            }
            if(!File.Exists("ApplictionForMovieTicketBooking/MovieDetails.csv"))
            {
                File.Create("ApplictionForMovieTicketBooking/MovieDetails.csv").Close();
            }
            if(!File.Exists("ApplictionForMovieTicketBooking/ScreeningDetails.csv"))
            {
                File.Create("ApplictionForMovieTicketBooking/ScreeningDetails.csv").Close();
            }
            if(!File.Exists("ApplictionForMovieTicketBooking/BookingDetails.csv"))
            {
                File.Create("ApplictionForMovieTicketBooking/BookingDetails.csv").Close();
            }
        }
        public static void WriteToFile()
        {
            string[] userDetails=new string[Operations.UserList.Count];
            for(int i=0;i<Operations.UserList.Count;i++)
            {
                userDetails[i]=Operations.UserList[i].WalleteBalance+","+Operations.UserList[i].UserID+","+Operations.UserList[i].Name+","+Operations.UserList[i].Age+","+Operations.UserList[i].Phone;

            }
            File.WriteAllLines("ApplictionForMovieTicketBooking/UserDetails.csv",userDetails);
            string[] theaterDetails=new string[Operations.TheaterList.Count];
            for(int i=0;i<Operations.TheaterList.Count;i++)
            {
                theaterDetails[i]=Operations.TheaterList[i].TheaterID+","+Operations.TheaterList[i].TheaterName+","+Operations.TheaterList[i].TheaterLocation;
            }
            File.WriteAllLines("ApplictionForMovieTicketBooking/TheaterDetails.csv",theaterDetails);
            string[] movieDetails=new string[Operations.MovieList.Count];
            for(int i=0;i<Operations.MovieList.Count;i++)
            {
                movieDetails[i]=Operations.MovieList[i].MovieID+","+Operations.MovieList[i].MovieName+","+Operations.MovieList[i].Language;
            }
            File.WriteAllLines("ApplictionForMovieTicketBooking/MovieDetails.csv",movieDetails);
            string [] screeningDetails=new string[Operations.ScreeningList.Count];
            for(int i=0;i<Operations.ScreeningList.Count;i++)
            {
                screeningDetails[i]=Operations.ScreeningList[i].MovieID+","+Operations.ScreeningList[i].TheaterID+","+Operations.ScreeningList[i].NumberOFSeat+","+Operations.ScreeningList[i].TicketPrice;
            }
            File.WriteAllLines("ApplictionForMovieTicketBooking/ScreeningDetails.csv",screeningDetails);
            string [] bookingDetails=new string[Operations.BookingList.Count];
            for(int i=0;i<Operations.BookingList.Count;i++)
            {
                bookingDetails[i]=Operations.BookingList[i].BookingID+","+Operations.BookingList[i].UserID+","+Operations.BookingList[i].MovieID+","+Operations.BookingList[i].TheaterID+","+Operations.BookingList[i].SeatCount+","+Operations.BookingList[i].TotalAmount+","+Operations.BookingList[i].BookingState;
            }
            File.WriteAllLines("ApplictionForMovieTicketBooking/BookingDetails.csv",bookingDetails);
        }
        public static void ReadToFile()
        {
            string[] UserDetails=File.ReadAllLines("ApplictionForMovieTicketBooking/UserDetails.csv");
            foreach(string data in UserDetails)
            {
            UserDetails user1=new UserDetails("random",56,687589,data);
            Operations.UserList.Add(user1);
            }
            string[] TheaterDetails=File.ReadAllLines("ApplictionForMovieTicketBooking/TheaterDetails.csv");
            foreach(string data in TheaterDetails)
            {
                TheaterDetails theater1=new TheaterDetails(data);
                Operations.TheaterList.Add(theater1);
            }
            string[] MovieDetails=File.ReadAllLines("ApplictionForMovieTicketBooking/MovieDetails.csv");
            foreach(string data in MovieDetails)
            {
                MovieDetails movie1=new MovieDetails(data);
                Operations.MovieList.Add(movie1);
            }
            string[] ScreeningDetails=File.ReadAllLines("ApplictionForMovieTicketBooking/ScreeningDetails.csv");
            foreach(string data in ScreeningDetails)
            {
                ScreeningDetails screen1=new ScreeningDetails(data);
                Operations.ScreeningList.Add(screen1);
            }
            string[] BookingDetails=File.ReadAllLines("ApplictionForMovieTicketBooking/BookingDetails.csv");
            foreach(string data in BookingDetails)
            {
                BookingDetails books=new BookingDetails(data);
                Operations.BookingList.Add(books);
            }
        }
    }
}