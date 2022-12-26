using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForMetroCard
{
    public delegate void EventManager();
    public static class Operations
    {
        public static CutomList<UserDetails> UsersList = new CutomList<UserDetails>();
        public static CutomList<TravelDetails> TravelList = new CutomList<TravelDetails>();
        public static CutomList<TicketFairDetails> TicketList = new CutomList<TicketFairDetails>();
        public static event EventManager Starter;
        public static void Subscribe()
        {
            Starter+=new EventManager(Files.Create);
            Starter+=new EventManager(Files.ReadFile);
            Starter+=new EventManager(Operations.MainMenu);
            Starter+=new EventManager(Files.WriteFile);

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
                Console.WriteLine("__________Welcome To main Menu__________");
                Console.WriteLine("\n\t\t1.New User Registration");
                Console.WriteLine("\n\t\t2.Login");
                Console.WriteLine("\n\t\t3.Exit");
                Console.Write("Enter yOUR choice:");
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
                }

            } while (Option != 3);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("___Welcome to User Registration Page_____");
            Console.Write("\n\tEnter Your Name:");
            string name = Console.ReadLine().ToUpper();
            Console.Write("Enter your Phone Number:");
            long phone = Convert.ToInt64(Console.ReadLine());
            UserDetails user1 = new UserDetails(name, phone);
            UsersList.Add(user1);
            Console.WriteLine("Your Registration is done Sucessfully your Card Number  is:" + user1.CardNumber);
        }

        public static void Login()
        {
            Console.WriteLine("______Welcome to lOGIN Page:________");
            Console.Write("Enter Your Card Number:");
            string cardID = Console.ReadLine().ToUpper();
            int flag = 0;
            foreach (UserDetails user in UsersList)
            {
                if (user.CardNumber == cardID)
                {
                    flag = 1;
                    Console.WriteLine("Logged In sucessfully");
                    currentUser = user;
                    SubMenu();
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("You have entered wrong Card Number");
            }
        }

        public static void SubMenu()
        {
            int Option = 0;
            do
            {
                Console.WriteLine("__________Welcome to Submenu Page_________");
                Console.WriteLine("\n1.Balance Check");
                Console.WriteLine("\n2.Recharge");
                Console.WriteLine("\n3.View Travel History");
                Console.WriteLine("\n4.Travel");
                Console.WriteLine("\n5.Go back To MainMenu");
                Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        {
                            checkBalance();
                            break;
                        }
                    case 2:
                        {
                            Recharge();
                            break;

                        }
                    case 3:
                        {
                            ViewTravelHistory();
                            break;
                        }
                    case 4:
                        {
                            Travel();
                            break;
                        }
                }
            } while (Option != 5);

        }

        public static void checkBalance()
        {
            Console.WriteLine("Your curent Balance is " + currentUser.Balance);
        }

        public static void Recharge()
        {
            Console.WriteLine("Here you can recharge your Wallete");
            Console.Write("Enter the amount that you want to recharge:");
            double amount = Convert.ToDouble(Console.ReadLine());
            currentUser.Deposit(amount);
            Console.WriteLine("Your recharge has done sucessfully");
        }

        public static void ViewTravelHistory()
        {
           Console.WriteLine("Here you can see your Travel history");
           foreach(TravelDetails travels in TravelList)
           {
            if(currentUser.CardNumber==travels.CardNumber)
            {
                Console.WriteLine($"{travels.TravelID},{travels.CardNumber},{travels.FromLocation},{travels.Tolocation},{travels.Date},{travels.TravelCost}");
            }
           }
        }

        public static void Travel()
        {
            Console.WriteLine("Here you can Book your Ticket:");
            foreach (TicketFairDetails tickets in TicketList)
            {
                Console.WriteLine($"{tickets.TicketID},{tickets.FromLocation},{tickets.Tolocation},{tickets.Fair}");

            }
            Console.Write("Enter the Ticket ID that you want to book:");
            string ticketID=Console.ReadLine().ToUpper();
            int flag=0;
            foreach(TicketFairDetails tickets in TicketList)
            {
                if(tickets.TicketID==ticketID)
                {
                    flag=1;
                    if(tickets.Fair<=currentUser.Balance)
                    {
                         currentUser.Withdraw(tickets.Fair);
                         TravelDetails travel1=new TravelDetails(currentUser.CardNumber,tickets.FromLocation,tickets.Tolocation,DateTime.Now,tickets.Fair);
                         TravelList.Add(travel1);
                         Console.WriteLine("Your Ticket has booked Sucessfully");
                    }
                    else
                    {
                        Console.WriteLine("You have Insufficient Balance Pls recharge and try again");
                    }
                }
            }
            if(flag==0)
            {
              Console.WriteLine("You have entered Wrong Ticket ID");
            }
        }

        public static void AddDefaultDetails()
        {
            UserDetails user1 = new UserDetails("Mohammed", 5476584893);
            UsersList.Add(user1);
            TicketFairDetails Ticket1 = new TicketFairDetails("AirPort", "Egmore", 55);
            TicketList.Add(Ticket1);
            TicketFairDetails Ticket2 = new TicketFairDetails("AirPort", "Koyambedu", 25);
            TicketList.Add(Ticket2);
            TicketFairDetails Ticket3 = new TicketFairDetails("Aalandur", "Koyambedu", 25);
            TicketList.Add(Ticket3);
            TicketFairDetails Ticket4 = new TicketFairDetails("Koyambedu", "Egmore", 32);
            TicketList.Add(Ticket4);
            TicketFairDetails Ticket5 = new TicketFairDetails("VadaPalani", "Egmore", 45);
            TicketList.Add(Ticket5);
            TicketFairDetails Ticket6 = new TicketFairDetails("ArumBaakam", "Egmore", 25);
            TicketList.Add(Ticket6);
        }
    }
}
//To Add Custom List

//To Handle CSV File Handling