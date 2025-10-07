using System;
using System.Collections.Generic;

namespace KFCMenu.Models
{
    public class FoodType
    {
        public string? Title { get; set; }

        public ICollection<Dish>? Diches { get; set; }


    }
}
