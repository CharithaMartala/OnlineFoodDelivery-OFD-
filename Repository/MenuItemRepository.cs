using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Model;

namespace OnlineFoodDelivery.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly UserLoginContext _context;

        public MenuItemRepository(UserLoginContext context)
        {
            _context = context;
        }
        public void AddItem(MenuItem item)
        {
            _context.MenuItems.Add(item);
            _context.SaveChanges();
        }
        public void UpdateItem(MenuItem item)
        {
            _context.MenuItems.Update(item);
            _context.SaveChanges();
        }
        public void RemoveItem(MenuItem item)
        {
            _context.MenuItems.Remove(item);
            _context.SaveChanges();
        }
        public MenuItem GetItemById(long Itemid)
        {
            return _context.MenuItems.FirstOrDefault(r => r.MenuItemId == Itemid);
        }
        public MenuItem GetItemByName(string Name)
        {
            return _context.MenuItems.FirstOrDefault(r => r.ItemName == Name);

        }
        public List<MenuItem> GetAllItems()
        {
            return _context.MenuItems.ToList();
        }
        public List<MenuItem> GetItemsByCategoryId(long Cid)
        {
            return _context.MenuItems.Where(r=>r.CategoryId==Cid).ToList();
        }

    }
}
