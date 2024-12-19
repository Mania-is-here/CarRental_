using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_
{
    internal class Rental
    {

        // Static dictionary to store bookings (username: booking details)
        private static Dictionary<string, string> bookings = new Dictionary<string, string>();
        public static void StartRental(string username)
        {
            var cars = Car.GetCarCategories();
            Console.WriteLine("\n--- Car Categories ---");
            for (int i = 0; i < cars.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                cars[i].DisplayPromotion();
            }
            Console.Write("\nEnter the number of the car category you'd like to rent: ");
            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice < 0 || choice >= cars.Length)
            {
                Console.WriteLine("Invalid choice. Returning to main menu.");
                return;
            }
            Car selectedCar = cars[choice];
            Console.WriteLine("\nAvailable Brands: " + string.Join(", ", selectedCar.Brands));
            Console.Write("Enter the brand you'd like to rent: ");
            string brand = Console.ReadLine();
            if (!selectedCar.Brands.Contains(brand))
            {
                Console.WriteLine("Invalid brand. Returning to main menu.");
                return;
            }
            Console.Write("Enter the duration of the rental in days: ");
            int days = int.Parse(Console.ReadLine());
            double total = days * selectedCar.PricePerDay * (1 - selectedCar.Discount);
            string bookingDetails = $"{selectedCar.Category} ({brand}) for {days} days. Total: ${total:F2}";
            bookings[username] = bookingDetails;
            Console.WriteLine("Booking confirmed!");
            Console.WriteLine($"Booking Details: {bookingDetails}");
        }
        public static void ViewBooking(string username)
        {
            Console.WriteLine("\n--- View Booking ---");
            if (bookings.ContainsKey(username))
            {
                Console.WriteLine($"Your Booking: {bookings[username]}");
            }
            else
            {
                Console.WriteLine("No active bookings found.");
            }
        }
        public static void CancelBooking(string username)
        {
            Console.WriteLine("\n--- Cancel Booking ---");
            if (bookings.ContainsKey(username))
            {
                Console.WriteLine($"Your Booking: {bookings[username]}");
                Console.Write("Are you sure you want to cancel this booking? (yes/no): ");
                string confirmation = Console.ReadLine().ToLower();
                if (confirmation == "yes")
                {
                    bookings.Remove(username);
                    Console.WriteLine("Booking cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Booking cancellation aborted.");
                }
            }
            else
            {
                Console.WriteLine("No active bookings found.");
            }
        }
    }
}