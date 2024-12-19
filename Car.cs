using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_
{
    internal class Car
    {

        public string Category { get; set; }
        public List<string> Brands { get; set; }
        public double PricePerDay { get; set; }
        public double Discount { get; set; }
        public Car(string category, List<string> brands, double pricePerDay, double discount)
        {
            Category = category;
            Brands = brands;
            PricePerDay = pricePerDay;
            Discount = discount;
        }
        public static Car[] GetCarCategories()
        {
            return new Car[]
            {
           new Car("Sedan", new List<string> { "Volvo", "Volkswagen", "Honda" }, 50, 0.1),
           new Car("Truck", new List<string> { "Ford", "Chevrolet", "RAM" }, 70, 0.15),
           new Car("Luxury", new List<string> { "Bugatti", "Rolls Royce", "Lamborghini" }, 150, 0.2),
           new Car("Economy", new List<string> { "Toyota", "Kia", "Hyundai" }, 30, 0.05),
           new Car("E-Vehicle", new List<string> { "Tesla", "Nissan Leaf", "Rivian" }, 60, 0.1),
           new Car("Motorbike", new List<string> { "Harley Davidson", "Yamaha", "Kawasaki" }, 25, 0.0)
            };
        }
        public void DisplayPromotion()
        {
            Console.WriteLine($"{Category}: ${PricePerDay}/day (Discount: {Discount * 100}%)");
            Console.WriteLine("Available Brands: " + string.Join(", ", Brands));
        }
    }
}