using KFCMenu.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace KFCMenu.Services
{
    public record DishCart : IEnumerable
    {
        public Dictionary<CartItem, int> CartItems { get; }


        public DishCart()
        {
            CartItems = new();
        }

        public void Add(CartItem cartItem, int count)
        {
            if (CartItems.ContainsKey(cartItem))
            {
                int objectCount = CartItems[cartItem] + count;
                CartItems.Remove(cartItem);
                cartItem.ItemCount = objectCount;
                CartItems[cartItem] = objectCount;
                return;
            }
            CartItems.Add(cartItem, 1);
        }

        public void Remove(CartItem cartItem, int removeCount)
        {
            if (!CartItems.ContainsKey(cartItem)) return;

            if (removeCount >= cartItem.ItemCount) CartItems.Remove(cartItem);
            else cartItem.ItemCount -= removeCount;
        }

        public int Count => CartItems.Sum(i => i.Value);

        public double TotalPrice => CartItems.Sum(i => i.Key.TotalPrice);

        public bool Any() => CartItems.Any();

        public IEnumerator GetEnumerator() => CartItems.GetEnumerator();

    }
}
