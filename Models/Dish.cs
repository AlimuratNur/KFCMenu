using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenu.Models
{
    public class Dish
    {
       

        public string Title { get; }

        public string Description { get; }

        public double Price { get; }

        public Dish(string title, string description, double price){
            Title = title;
            Description = description;
            Price = price;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            var dish = (Dish)obj;
            return Title.Equals(dish.Title) &&
                Description.Equals(dish.Description)
                && Price.Equals(dish.Price);
        }

        public override int GetHashCode() => 
            Title.GetHashCode() + Description.GetHashCode() + (int)Price;
        

        public override string ToString()
        {
            return "Title: " + Title + " Description: " + Description + " Price: " ;
        }

    }
}
