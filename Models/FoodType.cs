using System;
using System.Collections.Generic;

namespace KFCMenu.Models
{
    internal class FoodType
    {
        public string Title { get; }

        public ICollection<Dish> Diches { get; set; }
    }
}
