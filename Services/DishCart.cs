using KFCMenu.Models;
using System.Collections;
using System.Linq;

namespace KFCMenu.Services
{
    public record DishCart : IEnumerable
    {
        public List<CartItem> CartItems { get; }


        public DishCart()
        {
            CartItems = new();
        }

        public void Add(CartItem cartItem, int count)
        {
            var item = CartItems.FirstOrDefault(items => items.Equals(cartItem));
            if (item is null || !cartItem.Equals(item))
            {
                CartItems.Add(cartItem);
                return;
            }
            item.ItemCount += count;
        }

        public void Remove(CartItem cartItem, int removeCount)  
        {
            var removeItem = CartItems.FirstOrDefault(item => cartItem.Equals(item));
            if (removeItem is null || !cartItem.Equals(removeItem))
            {
                return;
            }
            if (removeItem.ItemCount > removeCount)
                removeItem.ItemCount -= removeCount;
            else
                CartItems.Remove(removeItem);

        }

        public int Count => CartItems.Sum(i => i.ItemCount);

        public double TotalPrice => CartItems.Sum(i => i.TotalPrice);

        public bool Any() => CartItems.Any();

        public bool Contains(object p)
        {
            if(p is null) throw new ArgumentNullException(nameof(p));
            if(!(p is CartItem)) throw new ArgumentException(nameof(p));
            return CartItems.Contains(p);
        }

        public IEnumerator GetEnumerator() => CartItems.GetEnumerator();

    }
}
