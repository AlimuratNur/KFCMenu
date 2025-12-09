namespace KFCMenu.Models;

public class CartItem 
{
    public Dish DishObject  { get; }

    public string PicturePath { get; set; }
    
    public int ItemCount { get; set; }

    public CartItem(int itemCount, Dish dish)
    {
        ItemCount = itemCount;
        DishObject = dish;
    }


    public double TotalPrice => ItemCount * DishObject.Price;


    #region base methods overridings (tostring, get hash code, equals)
    public override int GetHashCode() => DishObject.GetHashCode();
    

    public override bool Equals(object? obj)
    {
        if(obj is null) return false;
        if ( !(obj is CartItem))return false;
        
        var cartItem= (CartItem) obj;
        return this.DishObject.Equals(cartItem.DishObject);
    }
    public override string ToString() => string.Format($"{DishObject.Title}   {ItemCount}") ;
    #endregion
}
