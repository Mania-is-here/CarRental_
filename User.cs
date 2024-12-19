using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_
{
    internal class User
    {
      

        private const string FilePath = "users.txt";

        public static void Register()

        {

            Console.WriteLine("\n--- Registration ---");

            Console.Write("Enter a username: ");

            string username = Console.ReadLine();

            Console.Write("Enter a password: ");

            string password = Console.ReadLine();

            if (File.Exists(FilePath))

            {

                foreach (var line in File.ReadAllLines(FilePath))

                {

                    var parts = line.Split(',');

                    if (parts[0] == username)

                    {

                        Console.WriteLine("Username already exists. Please try a different one.");

                        return;

                    }

                }

            }

            File.AppendAllText(FilePath, $"{username},{password}\n");

            Console.WriteLine("Registration successful!");

        }

        public static bool LogIn()

        {

            Console.WriteLine("\n--- Login ---");

            Console.Write("Enter your username: ");

            string username = Console.ReadLine();

            Console.Write("Enter your password: ");

            string password = Console.ReadLine();

            if (File.Exists(FilePath))

            {

                foreach (var line in File.ReadAllLines(FilePath))

                {

                    var parts = line.Split(',');

                    if (parts[0] == username && parts[1] == password)

                    {

                        Console.WriteLine($"Welcome, {username}!");

                        return true;

                    }

                }

            }

            Console.WriteLine("Invalid username or password.");

            return false;

        }

    }
}

