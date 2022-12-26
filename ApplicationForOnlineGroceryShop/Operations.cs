using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public  delegate void EventManager();
    public static class Operations
    {
        public static CutomList<UserRegistration> UserList = new CutomList<UserRegistration>();
        public static CutomList<productDetails> ProductList = new CutomList<productDetails>();
        public static CutomList<BookingDetails> BookingList = new CutomList<BookingDetails>();
        public static CutomList<OrderDetails> OrderList = new CutomList<OrderDetails>();
        public static EventManager  Starter;
        public static void Subscribe()
        {
            Starter+=new EventManager(Files.Create);
            Starter+=new EventManager(Files.ReadFromFile);
            Starter+=new EventManager(Operations.MainMenu);
            Starter+=new EventManager(Files.WriteToFiles);
            
        }
        public static void Start()
        {
            Subscribe();
            Starter();
        }
        public static UserRegistration currentUser = null;
        public static void MainMenu()
        {
            int Option = 0;
            do
            {
                Console.WriteLine("__Welcome to Onine Grocery Shop______");
                Console.WriteLine("\n\t1.User Registration");
                Console.WriteLine("\n\t2.Login");
                Console.WriteLine("\n\t3.Exit");
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

                }
            } while (Option != 3);
        }
        public static void UserRegistration()
        {
            Console.WriteLine("Welcome To user Registration Page");
            Console.Write("Enter your Name:");
            string name = Console.ReadLine();
            Console.Write("Enter your FatherName:");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Gender:");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your Phone Number:");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your Date Of Birth:");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter your MailID");
            string mail = Console.ReadLine();
            UserRegistration user1 = new UserRegistration(name, fatherName, gender, phone, dob, mail);
            Console.WriteLine("Your Registration has done Sucessfully Your Registration Id is:" + user1.CustomerID);
            UserList.Add(user1);
            Console.Write("Press any key to exit:");
            Console.ReadLine();
        }
        public static void Login()
        {
            Console.WriteLine("Wecome To Login Page");
            Console.Write("Enter your Customer ID:");
            string CusID = Console.ReadLine().ToUpper();
            int flag = 0;
            foreach (UserRegistration user in UserList)
            {
                if (CusID == user.CustomerID)
                {
                    flag = 1;
                    Console.WriteLine("Logged in Sucessfully");
                    currentUser = user;
                    SubMenu();
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("You have entered Wrong Customer ID");
            }
        }
        public static void SubMenu()
        {
            int Option = 0;
            do
            {
                Console.WriteLine("You can choose One of these options");
                Console.WriteLine("\n\t1.Show Customer Details");
                Console.WriteLine("\n\t2.Show Product details");
                Console.WriteLine("\n\t3.Wallete recharge");
                Console.WriteLine("\n\t4.Take Order");
                Console.WriteLine("\n\t5.Modify Order Quantity");
                Console.WriteLine("\n\t6.Cancel Order");
                Console.WriteLine("\n\t7.Exit");
                Console.Write("Enter your Choice:");
                Option = Convert.ToInt32(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        {
                            ShowCustomerDetails();
                            break;
                        }
                    case 2:
                        {
                            ShowProductDetails();
                            break;
                        }
                    case 3:
                        {
                            WalleteRecharge();
                            break;
                        }
                    case 4:
                        {
                            TakeOrder();
                            break;
                        }
                    case 5:
                        {
                            ModifyOrderQuantity();
                            break;
                        }
                    case 6:
                        {
                            CancelOrder();
                            break;
                        }
                }
            } while (Option != 7);
        }
        public static void ShowCustomerDetails()
        {
            Console.WriteLine("Those Are the Details of the Customer:");
            Console.WriteLine($"CustomerID:{currentUser.CustomerID},CustomerName:{currentUser.Name},CustomerFatherName:{currentUser.FatherName},Gender:{currentUser.GenDer},Phone Number:{currentUser.Phone},MailID:{currentUser.Mail},WalleteBalance:{currentUser.Balance}");
        }
        public static void ShowProductDetails()
        {
            Console.WriteLine("Those are the List Of Products Available on our store:\n");
            foreach (productDetails products in ProductList)
            {
                Console.WriteLine($"ProductID:{products.ProductID},Product Name:{products.ProductName},Product Quantity:{products.Quantity},Product Price:{products.Price}");
            }
        }
        public static void WalleteRecharge()
        {
            Console.WriteLine("Here You can Recharge Your Wallete:");
            Console.Write("Enter the Amount that you want to recharge:");
            double amount = Convert.ToDouble(Console.ReadLine());
            currentUser.Deposit(amount);
            Console.WriteLine("Your Recharge has done Sucessfully");
            Console.Write("Press any key to exit:");
            Console.ReadLine();
        }
        public static void TakeOrder()
        {
            string choice = "";
            double totalPrice = 0;
            int Flag = 0;
            BookingDetails bookingOne = new BookingDetails(currentUser.CustomerID, totalPrice, DateTime.Now, BookingStatus.Initiated);
            CutomList<OrderDetails> tempOrderList = new CutomList<OrderDetails>();
            do
            {
                Console.Write("Do you want to Purchase or Not:(yes/no)");
                choice = Console.ReadLine().ToLower();
                if (choice == "yes")
                {
                    Flag = 1;
                    Console.WriteLine("Those are the Products Available on Our Store:");
                    foreach (productDetails products in ProductList)
                    {
                        Console.WriteLine($"ProductID:{products.ProductID},Product Name:{products.ProductName},Product Quantity:{products.Quantity},Product Price:{products.Price}");
                    }
                    Console.Write("Enter the Product ID:");
                    string productId = Console.ReadLine().ToUpper();
                    foreach (productDetails product in ProductList)
                    {
                        if (productId == product.ProductID)
                        {
                            Console.Write("Enter the Quantity You want To buy:");
                            int qunt = Convert.ToInt32(Console.ReadLine());
                            if (product.Quantity >= qunt)
                            {
                                double price = product.Price * qunt;
                                totalPrice += price;
                                OrderDetails order1 = new OrderDetails(bookingOne.BookingID, product.ProductID, qunt, price);
                                tempOrderList.Add(order1);
                                product.Quantity -= qunt;
                                Console.WriteLine("Total Amount For your Order is:" + totalPrice);
                                Console.WriteLine("Your Product is sucessfully Added to the Cart");
                            }
                            else
                            {
                                Console.WriteLine("We dont Have that much of quantity available at this momemt");
                            }
                        }
                    }

                }
            } while (choice == "yes");
            if (Flag == 1)
            {
                Console.Write("Do you want to Confirm the Order:");
                string confirmation = Console.ReadLine().ToLower();
                if (confirmation == "yes")
                {
                    if (totalPrice <= currentUser.Balance)
                    {
                        currentUser.WithDraw(totalPrice);
                        bookingOne.BookingState = BookingStatus.Booked;
                        BookingList.Add(bookingOne);
                        foreach (OrderDetails orders in tempOrderList)
                        {
                            OrderList.Add(orders);
                        }
                        Console.WriteLine("Your Booking Was Sucessfull");
                    }
                    else
                    {
                        string say = "";
                        int flag1 = 0;
                        do
                        {
                            Console.WriteLine("You have insufficient Balance");
                            Console.Write("Do you want to Recharge your wallete:");
                            say = Console.ReadLine().ToLower();
                            if (say == "yes")
                            {
                                Console.Write("Enter the Amount That you want to Recharge:");
                                double amount = Convert.ToDouble(Console.ReadLine());
                                currentUser.Deposit(amount);
                                Console.WriteLine("Your Recharge has done Sucessfully");
                                Console.Write("Press any key to exit:");
                                Console.ReadLine();
                            }
                            if (totalPrice <= currentUser.Balance)
                            {
                                say = "no";
                                flag1 = 1;
                            }

                        } while (say == "yes");
                        if (flag1 == 1)
                        {
                            currentUser.WithDraw(totalPrice);
                            bookingOne.BookingState = BookingStatus.Booked;
                            bookingOne.TotalPrice = totalPrice;
                            BookingList.Add(bookingOne);

                            OrderList = tempOrderList;
                            Console.WriteLine("Your Booking Was Sucessfull");
                        }
                        if (flag1 == 0)
                        {
                            Console.WriteLine("Your cart was removed Sucessfully");
                        }
                    }
                }
                else
                {
                    foreach (OrderDetails orders in tempOrderList)
                    {
                        foreach (productDetails product in ProductList)
                        {
                            if (orders.ProductID == product.ProductID)
                            {
                                product.Quantity += orders.PurchaseCount;
                            }
                        }
                    }
                    Console.WriteLine("Your Cart Removed Sucessfully");
                }
            }
            else
            {
                Console.WriteLine("Thank You for visiting Our Store");
            }
        }
        public static void ModifyOrderQuantity()
        {
            int flag = 0, Flag1 = 0; ;
            Console.WriteLine("Here you can Modify Your Order Quantity:");
            foreach (BookingDetails books in BookingList)
            {
                if (books.CustomerID == currentUser.CustomerID && books.BookingState == BookingStatus.Booked)
                {
                    Console.WriteLine($"BookingID:{books.BookingID},CustomerID:{books.CustomerID},TotalPrice:{books.TotalPrice},BookingDate:{books.DateOfBooking},Status:{books.BookingState}");
                }
            }
            Console.Write("Enter the BookingID that you want to Modify the Order quantity:");
            string bookID = Console.ReadLine().ToUpper();

            foreach (BookingDetails books1 in BookingList)
            {
                if (books1.BookingID == bookID)
                {
                    flag = 1;
                    foreach (OrderDetails order in OrderList)
                    {
                        if (order.BookingID == bookID)
                        {
                            Console.WriteLine($"Order ID:{order.OrderID},ProductID:{order.ProductID},PurchaseCount:{order.PurchaseCount},Price:{order.Price}");
                        }
                    }
                    Console.Write("Enter the Order ID that you want to Alter count:");
                    string Orderid = Console.ReadLine().ToUpper();

                    foreach (OrderDetails orders in OrderList)
                    {
                        if (Orderid == orders.OrderID)
                        {
                            Flag1 = 1;
                            Console.Write("Enter the New Quantity:");
                            int Qnut = Convert.ToInt32(Console.ReadLine());
                            foreach (productDetails product in ProductList)
                            {
                                if (product.ProductID == orders.ProductID)
                                {
                                    double TotalPrice2 = product.Price * orders.PurchaseCount;
                                    books1.TotalPrice -= TotalPrice2;
                                    product.Quantity += orders.PurchaseCount;
                                    product.Quantity -= Qnut;
                                    double TotalPrice1 = product.Price * Qnut;
                                    books1.TotalPrice = TotalPrice1;
                                    if (TotalPrice2 > TotalPrice1)
                                    {
                                        double returnAmount = TotalPrice2 - TotalPrice1;
                                        currentUser.Deposit(returnAmount);
                                        Console.WriteLine("Order Modified Sucessfully");
                                    }
                                    else
                                    {
                                        double getAmount = TotalPrice1 - TotalPrice2;
                                        if (currentUser.Balance >= getAmount)
                                        {
                                            currentUser.WithDraw(getAmount);
                                            Console.WriteLine("Order Modified Sucessfully");
                                        }
                                        else
                                        {
                                            string say = "";
                                            int flag1 = 0;
                                            do
                                            {
                                                Console.WriteLine("You have insufficient Balance");
                                                Console.Write("Do you want to Recharge your wallete:");
                                                say = Console.ReadLine().ToLower();
                                                if (say == "yes")
                                                {
                                                    Console.Write("Enter the Amount That you want to Recharge:");
                                                    double amount = Convert.ToDouble(Console.ReadLine());
                                                    currentUser.Deposit(amount);
                                                    Console.WriteLine("Your Recharge has done Sucessfully");
                                                    Console.Write("Press any key to exit:");
                                                    Console.ReadLine();
                                                }
                                                if (getAmount <= currentUser.Balance)
                                                {
                                                    say = "no";
                                                    flag1 = 1;
                                                }

                                            } while (say == "yes");
                                            if (flag == 1)
                                            {
                                                currentUser.WithDraw(getAmount);
                                                Console.WriteLine("Order Modified Sucessfully");
                                            }
                                            if (flag1 == 0)
                                            {
                                                Console.WriteLine("Since Your Wallete Balance is Low you cannot buy more Products");
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            if (Flag1 == 0)
            {
                Console.WriteLine("You have entered Wrong Order ID");
            }
            if (flag == 0)
            {
                Console.WriteLine("You have entered wrong Booking ID");
            }


        }
        public static void CancelOrder()
        {
            Console.WriteLine("Here you can Cancel Your Order:");
            foreach (BookingDetails books in BookingList)
            {
                if (books.CustomerID == currentUser.CustomerID && books.BookingState == BookingStatus.Booked)
                {
                    Console.WriteLine($"BookingID:{books.BookingID},CustomerID:{books.CustomerID},TotalPrice:{books.TotalPrice},BookingDate:{books.DateOfBooking},Status:{books.BookingState}");
                }
            }
            Console.Write("Enter the BookingID that you want to Modify the Order quantity:");
            string bookID = Console.ReadLine().ToUpper();
            int flag = 0;
            foreach (BookingDetails books in BookingList)
            {
                if (books.BookingID == bookID)
                {
                    flag = 1;
                    foreach (OrderDetails order in OrderList)
                    {
                        if (order.BookingID == bookID)
                        {
                            foreach (productDetails product in ProductList)
                            {
                                if (order.ProductID == product.ProductID)
                                {
                                    product.Quantity += order.PurchaseCount;
                                }
                            }
                        }
                    }
                    currentUser.Deposit(books.TotalPrice);
                    Console.WriteLine("Your Order has Cancelled Sucessfully");
                }


            }
            if (flag == 0)
            {
                Console.WriteLine("You Have Entered Wrong BookingID");
            }
        }
        public static void AddDefaultData()
        {    //User Details
            UserRegistration user1 = new UserRegistration("mohammed", "Thamin", Gender.Male, 46783749, new DateTime(2000, 10, 11), "mohammedimrancr7@gmail.com");
            UserList.Add(user1);
            //Product Details
            productDetails producT1 = new productDetails("Sugar", 20, 50);
            ProductList.Add(producT1);
            productDetails producT2 = new productDetails("Rice", 50, 100);
            ProductList.Add(producT2);
            productDetails producT3 = new productDetails("Milk", 20, 60);
            ProductList.Add(producT3);
            productDetails producT4 = new productDetails("Salt", 20, 50);
            ProductList.Add(producT4);
            productDetails producT5 = new productDetails("Cofee Powder", 10, 15);
            ProductList.Add(producT5);
            productDetails producT6 = new productDetails("Tea Powder", 10, 15);
            ProductList.Add(producT6);
            productDetails producT7 = new productDetails("Milk Biscuit", 10, 100);
            ProductList.Add(producT7);

        }
    }
}
//Custom List

//File Handling 

//Delegates