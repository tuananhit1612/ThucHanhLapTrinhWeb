namespace TranTuanAnh_BaiTap.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public void AddItem(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.XeID ==
           item.XeID);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(int xeID)
        {
            Items.RemoveAll(i => i.XeID == xeID);
        }
    }
}
