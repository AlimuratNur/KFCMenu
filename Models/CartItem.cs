using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenu.Models
{
    public class CartItem 
    {
        public int ItemCount { get; set; }
        
        public Dish DishObject  { get; }

        public CartItem(int itemCount, Dish dish)
        {
            ItemCount = itemCount;
            DishObject = dish;
        }


        public double TotalPrice => ItemCount * DishObject.Price;

        public override int GetHashCode() => DishObject.GetHashCode();
        

        public override bool Equals(object? obj)
        {
            if(obj is null) return false;
            if ( !(obj is CartItem))return false;
            
            var cartItem= (CartItem) obj;
            return this.DishObject.Equals(cartItem.DishObject);
        }
    }
}
