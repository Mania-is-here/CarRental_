using System;
using System.Collections.Generic;


namespace CarRental_
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Rental Car System!");
            string loggedInUser = null;
            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        User.Register();
                        break;
                    case "2":
                        if (User.LogIn())
                        {
                            Console.Write("Enter your username: ");
                            loggedInUser = Console.ReadLine();
                            UserMenu(loggedInUser);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using the Rental Car System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void UserMenu(string username)
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. Rent a Car");
                Console.WriteLine("2. View Booking");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Log Out");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Rental.StartRental(username);
                        break;
                    case "2":
                        Rental.ViewBooking(username);
                        break;
                    case "3":
                        Rental.CancelBooking(username);
                        break;
                    case "4":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}