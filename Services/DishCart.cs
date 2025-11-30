using KFCMenu.Models;
using System.Collections;
using System.Linq;

namespace KFCMenu.Services
{
    public record DishCart :  IList<CartItem>
    {
        public List<CartItem> CartItems { get; }


        public DishCart()
        {
            CartItems = new();
        }


        #region ---------------------------------------------------ADD---------------------------------------------------
        public void Add(CartItem item)
        {
            if(item is null) throw new ArgumentNullException("item");
            Add(item, 1);
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
        #endregion


        #region ---------------------------------------------------Insert---------------------------------------------------
        
        public void Insert(int index, CartItem item)
        {
            if (index >= CartItems.Count) throw new ArgumentOutOfRangeException("index is more than cart items count");
            if (item is null) throw new ArgumentNullException("item");
            CartItems.Insert(index, item);
        }

        #endregion


        #region ---------------------------------------------------Remove---------------------------------------------------
        public void RemoveWithCount(CartItem cartItem, int removeCount)  
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

        public bool Remove(CartItem item) => CartItems.Remove(item);
        public void RemoveAt(int index) => CartItems.RemoveAt(index);
        
        #endregion

        public void CopyTo(CartItem[] cartItems, int index)
        {
            for (int i = 0; i < Count; i++)
            {
                cartItems.SetValue(CartItems[i], index++);
            }
        }

        public int Count => CartItems.Sum(i => i.ItemCount);

        public double TotalPrice => CartItems.Sum(i => i.TotalPrice);

        public bool Any() => CartItems.Any();

        public bool Contains(CartItem p)
        {
            if(p is null) throw new ArgumentNullException(nameof(p));
            return CartItems.Contains(p);
        }

        public void Clear() => CartItems.Clear();

        public int IndexOf(CartItem item) => CartItems.IndexOf(item); 


        public CartItem this[int index]
        {
            get => CartItems[index];
            set => CartItems[index] = value;
        }

        public IEnumerator<CartItem> GetEnumerator() => CartItems.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsReadOnly
        {
            get => false;
        }

    }
}