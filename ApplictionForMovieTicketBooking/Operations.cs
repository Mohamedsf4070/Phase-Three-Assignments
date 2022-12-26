using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplictionForMovieTicketBooking
{
    public delegate void EventManager();
    public static class Operations
    {
        public static CustomList<UserDetails> UserList = new CustomList<UserDetails>();
        public static CustomList<TheaterDetails> TheaterList = new CustomList<TheaterDetails>();
        public static CustomList<MovieDetails> MovieList = new CustomList<MovieDetails>();
        public static CustomList<ScreeningDetails> ScreeningList = new CustomList<ScreeningDetails>();
        public static CustomList<BookingDetails> BookingList = new CustomList<BookingDetails>();
        public static EventManager  Starter;
        public static void Subscribe()
        {
            Starter+=new EventManager(Files.Create);
            Starter+=new EventManager(Files.ReadToFile);
            Starter+=new EventManager(Operations.MainMenu);
            Starter+=new EventManager(Files.WriteToFile);
            
        }
        public static void Start()
        {
            Subscribe();
            Starter();
        }

        public static UserDetails currentUser = null;
        public static void MainMenu()
        {
            int Option = 0;
            do
            {
                Console.WriteLine("____Welcome to Online Theater Booking Platform______");
                Console.WriteLine("\t1.User Registration");
                Console.WriteLine("\t2.Login");
                Console.WriteLine("\t3.Exit");
                Console.Write("Enter your Option:");
                Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        {
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter the correct Option");
                            break;
                        }
                }


            } while (Option != 3);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("___Welcome To User Registration Page____");
            Console.Write("Enter your Name:");
            string name = Console.ReadLine();
            Console.Write("Enter your Age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your Phone no:");
            long phone = Convert.ToInt64(Console.ReadLine());
            UserDetails user1 = new UserDetails(name, age, phone);
            Console.WriteLine("Your Registration has done Sucessfully");
            UserList.Add(user1);
            Console.Write("Press Any Key To exit:");
            Console.ReadLine();
        }

        public static void Login()
        {
            Console.WriteLine("_____Welcome to Login Page____");
            Console.Write("Enter your User ID:");
            string userID = Console.ReadLine().ToUpper();
            int flag = 0;
            foreach (UserDetails users in UserList)
            {
                if (userID == users.UserID)
                {
                    flag = 1;
                    Console.WriteLine("Logged In sucessfully");
                    currentUser = users;
                    SubMenu();
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("You have entered Wrong UserID");
            }
        }

        public static void SubMenu()
        {
            int Option = 0;
            do
            {
                Console.WriteLine("____Welcome to SubMenu page____");
                Console.WriteLine("\t1.Ticket Booking");
                Console.WriteLine("\t2.Ticket Cancellation");
                Console.WriteLine("\t3.Booking History");
                Console.WriteLine("\t4.Wallete Recharge");
                Console.WriteLine("\t5.Exit");
                Console.Write("Enter your Option:");
                Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        {
                            TicketBooking();
                            break;
                        }
                    case 2:
                        {
                            TicketCancellation();
                            break;
                        }
                    case 3:
                        {
                            BookingHistory();
                            break;
                        }
                    case 4:
                        {
                            WalleteRecharge();
                            break;
                        }
                }

            } while (Option != 5);
        }

        public static void TicketBooking()
        {
            Console.WriteLine("Those are the Available theater:\n");
            //displaying all the theaters available
            foreach (TheaterDetails theaters in TheaterList)
            {
                Console.WriteLine($"TheaterID:{theaters.TheaterID},TheaterName:{theaters.TheaterName},TheaterLocation:{theaters.TheaterLocation}");
            }
            //ask the user for the Theater ID
            Console.Write("Enter the Theater id that you wish to see the MOVIE :");
            string theaterID = Console.ReadLine().ToUpper();
            int flag = 0, flag1 = 0;
            //checking for theater exsist
            foreach (TheaterDetails theaters in TheaterList)
            {
                if (theaterID == theaters.TheaterID)
                {
                    flag = 1;
                    //Display the movie running on that theater
                    Console.WriteLine("Those are the movies running on that Theater:\n");
                    foreach (ScreeningDetails screens in ScreeningList)
                    {
                        if (theaters.TheaterID == screens.TheaterID)
                        {
                            foreach (MovieDetails movies in MovieList)
                            {
                                if (screens.MovieID == movies.MovieID)
                                {
                                    Console.WriteLine($"MovieID:{movies.MovieID},MovieNamd:{movies.MovieName},Language:{movies.Language},NumberOfSeatsAvailable:{screens.NumberOFSeat},Price:{screens.TicketPrice}");
                                }
                            }
                        }
                    }
                    //Asking for the MovieID 
                    Console.Write("Enter the Movie ID that you want to book:");
                    string movieID = Console.ReadLine().ToUpper();
                    //Check for the Movie Exsist
                    foreach (MovieDetails movies in MovieList)
                    {
                        if (movieID == movies.MovieID)
                        {
                            flag1 = 1;
                        }
                    }
                    //if(movie exsits)
                    if (flag1 == 1)
                    {
                        //Asking for Number of seats
                        Console.WriteLine("Enter the Number Of seats that you want to book:");
                        int numberOfSeats = Convert.ToInt32(Console.ReadLine());
                        foreach(ScreeningDetails screens in ScreeningList)
                        {
                            if(movieID==screens.MovieID  && theaterID==screens.TheaterID)
                            {
                                //Checking Number of Seats Available
                                if(numberOfSeats<=screens.NumberOFSeat)
                                {
                                   double TotalPrice=screens.TicketPrice;
                                   TotalPrice+=(18*TotalPrice)/100;
                                   if(currentUser.WalleteBalance>=TotalPrice)
                                   {
                                    screens.NumberOFSeat-=numberOfSeats;
                                      currentUser.Withdraw(TotalPrice);
                                     BookingDetails booking1=new BookingDetails(currentUser.UserID,screens.MovieID,screens.TheaterID,numberOfSeats,TotalPrice,BookingStatus.booked);
                                     BookingList.Add(booking1);
                                     Console.WriteLine("Your Ticket has Booked Sucessfully");
                                     Console.Write("Press Any key to exit:");
                                     Console.ReadLine();
                                   }
                                   else 
                                   {
                                    Console.WriteLine("you have insufficient Balance pls do Recharge");
                                   }
                                }
                                //Dont have that much of seats
                                else 
                                {
                                    Console.WriteLine($"We Dont have that much of seat available we have only {screens.NumberOFSeat} seats");
                                }
                            }
                        }
                    }
                    else
                    {
                      Console.WriteLine("You have entered wrong Movie ID"); 
                    }

                }

            }

            if (flag == 0)
            {
                Console.WriteLine("You have entered wrong theater id");
            }
        }

        public static void TicketCancellation()
        {
            Console.WriteLine("Here you can Cancell your Ticket:");
            foreach(BookingDetails books in BookingList )
            {
                if(currentUser.UserID==books.UserID  && books.BookingState==BookingStatus.booked)
                {
                Console.WriteLine($"Booking ID:{books.BookingID},UserID:{books.UserID},MovieID:{books.MovieID},TheaterID:{books.TheaterID},SeatCount:{books.SeatCount},TotalAmount:{books.TotalAmount},status:{books.BookingState}");
                }
            }
            Console.Write("Enter the Booking ID that you want to cancel:");
            string bookID=Console.ReadLine().ToUpper();
            int flag=0;
            foreach(BookingDetails books in BookingList)
            {
                if(bookID==books.BookingID)
                {
                  flag=1;
                  currentUser.Deposit(books.TotalAmount);
                  foreach(ScreeningDetails screens in ScreeningList)
                  {
                    if(books.TheaterID==screens.TheaterID && books.MovieID==screens.MovieID)
                    {
                        screens.NumberOFSeat+=books.SeatCount;
                    }
                  }
                  books.BookingState=BookingStatus.cancelled;
                  Console.WriteLine("Your seat was cancelled sucessfully");
                  Console.Write("Press Any Key to exit:");
                  Console.ReadLine();
                }
                
            }
            if(flag==0)
            {
                
                    Console.WriteLine("You have entered wrong Booking ID");
            
            }

        }

        public static void BookingHistory()
        {
            Console.WriteLine("Those are ticket you have booked in our theater:");
            foreach(BookingDetails books in BookingList )
            {
                if(currentUser.UserID==books.UserID)
                {
                Console.WriteLine($"Booking ID:{books.BookingID},UserID:{books.UserID},MovieID:{books.MovieID},TheaterID:{books.TheaterID},SeatCount:{books.SeatCount},TotalAmount:{books.TotalAmount},status:{books.BookingState}");
                }
            }
            Console.Write("Press Any key to exit:");
            Console.ReadLine();
        }

        public static void WalleteRecharge()
        {
            Console.WriteLine("Here You can recharge your wallete");
            Console.Write("Enter the amount that you want to recharge:");
            double Amount = Convert.ToDouble(Console.ReadLine());
            currentUser.Deposit(Amount);
            Console.WriteLine("Your recharge has done Sucessfully");
            Console.Write("Press Any Key to Exit:");
            Console.ReadLine();
        }

        public static void AddDefaultDetails()
        {
            //UserDetails
            UserDetails user1 = new UserDetails("Mohammed Ashik", 17, 6783863990);
            UserList.Add(user1);
            //TheaterDetails
            TheaterDetails theater1 = new TheaterDetails("IMAX", "Annanagar");
            TheaterList.Add(theater1);
            TheaterDetails theater2 = new TheaterDetails("Ega Theater", "Chetpet");
            TheaterList.Add(theater2);
            TheaterDetails theater3 = new TheaterDetails("Kamala", "vadapalani");
            TheaterList.Add(theater3);
            //MovieDetails
            MovieDetails movie1 = new MovieDetails("GameOfThrones", "English");
            MovieList.Add(movie1);
            MovieDetails movie2 = new MovieDetails("Poniyin selvan", "Spanish");
            MovieList.Add(movie2);
            MovieDetails movie3 = new MovieDetails("Vikram", "Jebrish");
            MovieList.Add(movie3);
            MovieDetails movie4 = new MovieDetails("Beast", "Korean");
            MovieList.Add(movie4);
            //Screening Details
            ScreeningDetails screen1 = new ScreeningDetails("MID501", "TID301", 45, 200);
            ScreeningList.Add(screen1);
            ScreeningDetails screen2 = new ScreeningDetails("MID502", "TID301", 15, 100);
            ScreeningList.Add(screen2);
            ScreeningDetails screen3 = new ScreeningDetails("MID504", "TID301", 25, 200);
            ScreeningList.Add(screen3);
            ScreeningDetails screen4 = new ScreeningDetails("MID501", "TID302", 45, 200);
            ScreeningList.Add(screen4);
            ScreeningDetails screen5 = new ScreeningDetails("MID504", "TID302", 15, 100);
            ScreeningList.Add(screen5);
            ScreeningDetails screen6 = new ScreeningDetails("MID503", "TID302", 45, 200);
            ScreeningList.Add(screen6);
            ScreeningDetails screen7 = new ScreeningDetails("MID502", "TID303", 45, 200);
            ScreeningList.Add(screen7);
            ScreeningDetails screen8 = new ScreeningDetails("MID504", "TID303", 45, 200);
            ScreeningList.Add(screen8);
            ScreeningDetails screen9 = new ScreeningDetails("MID503", "TID303", 45, 200);
            ScreeningList.Add(screen9);




        }
    
        //Adding Custom List

        //CSV file Handling

        //Defusing Events and Delegates
    
    }
}
