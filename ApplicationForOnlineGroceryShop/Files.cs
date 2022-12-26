using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ApplicationForOnlineGroceryShop
{
    public static class Files
    {
      public static void Create()
      {
        if(!Directory.Exists("ApplicationForOnlineGroceryShop"))
        {
            Directory.CreateDirectory("ApplicationForOnlineGroceryShop");
        }
        if(!File.Exists("ApplicationForOnlineGroceryShop/UserRegistration.csv"))
        {
            File.Create("ApplicationForOnlineGroceryShop/UserRegistration.csv").Close();
        }
        if(!File.Exists("ApplicationForOnlineGroceryShop/productDetails.csv"))
        {
            File.Create("ApplicationForOnlineGroceryShop/productDetails.csv").Close();
        }
        if(!File.Exists("ApplicationForOnlineGroceryShop/OrderDetails.csv"))
        {
            File.Create("ApplicationForOnlineGroceryShop/OrderDetails.csv").Close();
        }
        if(!File.Exists("ApplicationForOnlineGroceryShop/BookingDetails.csv"))
        {
            File.Create("ApplicationForOnlineGroceryShop/BookingDetails.csv").Close();
        }
      } 
      public static void WriteToFiles()
      {
        string[] userRegistration=new string[Operations.UserList.Count];
        for(int i=0;i<Operations.UserList.Count;i++)
        {
            userRegistration[i]=Operations.UserList[i].CustomerID+","+Operations.UserList[i].Name+","+Operations.UserList[i].FatherName+","+Operations.UserList[i].GenDer+","+Operations.UserList[i].Phone+","+Operations.UserList[i].DateOfBirth.ToString("dd/MM/yyyy")+","+Operations.UserList[i].Mail+","+Operations.UserList[i].Balance;
        }
        File.WriteAllLines("ApplicationForOnlineGroceryShop/UserRegistration.csv",userRegistration);
        string[] productDetails=new string[Operations.ProductList.Count];
        for(int i=0;i<Operations.ProductList.Count;i++)
        {
            productDetails[i]=Operations.ProductList[i].ProductID+","+Operations.ProductList[i].ProductName+","+Operations.ProductList[i].Quantity+","+Operations.ProductList[i].Price;
        }
        File.WriteAllLines("ApplicationForOnlineGroceryShop/productDetails.csv",productDetails);
        string[] orderDetails=new string[Operations.OrderList.Count];
        for(int i=0;i<Operations.OrderList.Count;i++)
        {
            orderDetails[i]=Operations.OrderList[i].OrderID+","+Operations.OrderList[i].BookingID+","+Operations.OrderList[i].ProductID+","+Operations.OrderList[i].PurchaseCount+","+Operations.OrderList[i].Price;
        }
        File.WriteAllLines("ApplicationForOnlineGroceryShop/OrderDetails.csv",orderDetails);
        string[] bookingDetails=new string[Operations.BookingList.Count];
        for(int i=0;i<Operations.BookingList.Count;i++)
        {
            bookingDetails[i]=Operations.BookingList[i].BookingID+","+Operations.BookingList[i].CustomerID+","+Operations.BookingList[i].TotalPrice+","+Operations.BookingList[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Operations.BookingList[i].BookingState;
        }
        File.WriteAllLines("ApplicationForOnlineGroceryShop/BookingDetails.csv",bookingDetails);
      } 
      public static void ReadFromFile()
      {
        string[] UserRegistration=File.ReadAllLines("ApplicationForOnlineGroceryShop/UserRegistration.csv");
        foreach(string data in UserRegistration)
        {
            UserRegistration user=new UserRegistration("mohammed","Thamin",Gender.Male,73858,new DateTime(1000,10,10),"fhdgvhsg",data);
            Operations.UserList.Add(user);
        }
        string[] ProductDetails=File.ReadAllLines("ApplicationForOnlineGroceryShop/productDetails.csv");
        foreach(string data in ProductDetails)
        {
            productDetails product1=new productDetails(data);
            Operations.ProductList.Add(product1);
        }
        string[] OrderDetails=File.ReadAllLines("ApplicationForOnlineGroceryShop/OrderDetails.csv");
        foreach(string data in OrderDetails)
        {
            OrderDetails order1=new OrderDetails(data);
            Operations.OrderList.Add(order1);
        }
        string[] BookingDetails=File.ReadAllLines("ApplicationForOnlineGroceryShop/BookingDetails.csv");
        foreach(string data in BookingDetails)
        {
            BookingDetails books1=new BookingDetails(data);
            Operations.BookingList.Add(books1);
        }
      }
    }
}