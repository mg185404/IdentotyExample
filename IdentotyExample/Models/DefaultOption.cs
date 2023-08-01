using IdentotyExample.Enums;

namespace IdentotyExample.Models
{
    public class DefaultOption
    {
        public int ModifierGroupId { get; set; }
        public int ModifierId { get; set; }
        public int DefaultQuantity { get; set; }
        public DefaultOptionReason DefaultReason { get; set; }
    }
}
