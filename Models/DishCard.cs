using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenu.Models
{
    class DishCard
    {
        public Dictionary<Dish, int> Dishes { get; private set; } = new Dictionary<Dish, int>();

        

        public void Add(Dish dish, int count)
        {
            if(Dishes.ContainsKey(dish)) Dishes[dish] += count;
            Dishes.Add(dish, count);
        }

        public void Remove(Dish dish, int removeCount)
        {
            if (!Dishes.ContainsKey(dish)) return;

            if (removeCount >= Dishes[dish]) Dishes.Remove(dish);
            else Dishes[dish] -= removeCount;
        }
        
        public int Count => Dishes.Count;
    }
}
