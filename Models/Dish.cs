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

    }
}
