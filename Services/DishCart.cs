using KFCMenu.Models;
using System.Collections.Specialized;

namespace KFCMenu.Services
{
    public record DishCart :  IList<CartItem>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public List<CartItem> CartItems { get; }


        public DishCart()
        {
            CartItems = new();
        }


        #region ---------------------------------------------------ADD---------------------------------------------------
        public void Add(CartItem item)
        {
            if(item is null) throw new ArgumentNullException("item");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            Add(item, 1);
        }
        public void Add(CartItem cartItem, int count)
        {
            var item = CartItems.FirstOrDefault(items => items.Equals(cartItem));
            
            if (item is null || !cartItem.Equals(item))
            {
               OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, cartItem));
                CartItems.Add(cartItem);
                return;
            }
            
            item.ItemCount += count;
        }
        #endregion


        #region ---------------------------------------------------Insert---------------------------------------------------
        
        public void Insert(int index, CartItem item)
        {
            if (index >= CartItems.Count || index < 0) 
                throw new ArgumentOutOfRangeException(nameof(index), index,"index out of range");
            
            if (item is null) 
                throw new ArgumentNullException("item");

            CartItems.Insert(index, item);
        }

        #endregion


        #region ---------------------------------------------------Remove---------------------------------------------------
        public void RemoveByCount(CartItem cartItem, int removeCount)  
        {
            var removeItem = CartItems.FirstOrDefault(item => cartItem.Equals(item));
            if (removeItem is null || !cartItem.Equals(removeItem))
                return;

            var index = CartItems.IndexOf(removeItem);
            

            if (removeItem.ItemCount > removeCount)
                removeItem.ItemCount -= removeCount;
            else  
                CartItems.Remove(removeItem);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removeItem,index));
        }

        public bool Remove(CartItem item) 
        {
            var index = CartItems.IndexOf(item);
            var succesfulRemove = CartItems.Remove(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
            return succesfulRemove;
        }

        public void RemoveAt(int index) 
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, CartItems[index], index));
            CartItems.RemoveAt(index); 
        }
        
        #endregion

        public void CopyTo(CartItem[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(CartItems[i], arrayIndex++);
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

        public CartItem FirstOrDefault() => CartItems.FirstOrDefault();

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

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                
                CollectionChanged(this, e);
            }
            
        }

    }
}