using IdentotyExample.Enums;

namespace IdentotyExample.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MenuType MenuType { get; set; }
        public string ExternalId { get; set; }
        public OrderModeType SupportedOrderModes { get; set; }
        public bool IsVisible { get; set; }
        public MenuAttribute MenuAttribute { get; set; }
        public string DisplayName { get; set; }
        public List<int> SubMenus { get; set; }
    }
}
