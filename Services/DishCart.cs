using KFCMenu.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenu.Services
{
    public record DishCart : IEnumerable
    {
        public HashSet<CartItem> CartItems { get; } = new();


        public DishCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public void Add(CartItem cartItem, int count)
        {
            if (CartItems.Contains(cartItem))
            {
                cartItem.ItemCount += count;
                return;
            }
            CartItems.Add(cartItem);
        }

        public void Remove(CartItem cartItem, int removeCount)
        {
            if (!CartItems.Contains(cartItem)) return;

            if (removeCount >= cartItem.ItemCount) CartItems.Remove(cartItem);
            else cartItem.ItemCount -= removeCount;
        }

        public int Count => CartItems.Sum(i => i.ItemCount);

        public double TotalPrice => CartItems.Sum(i => i.TotalPrice);

        public bool Any() => CartItems.Any();

        public IEnumerator GetEnumerator() => CartItems.GetEnumerator();

    }
}
