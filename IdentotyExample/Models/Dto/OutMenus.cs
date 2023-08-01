namespace IdentotyExample.Models.Dto
{
    public class OutMenus
    {
        public List<Menu> Menus { get; set; }
        public List<SubMenu> SubMenus { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<SalesItem> SalesItems { get; set; }
        public List<ModifierGroup> ModifierGroups { get; set; } //odavde
        public List<Modifier> Modifiers { get; set; }
        public List<ModifierActionItem> ModifierActions { get; set; }
    }
}
