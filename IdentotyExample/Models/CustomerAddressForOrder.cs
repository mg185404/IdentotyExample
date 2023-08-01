namespace IdentotyExample.Models
{
    public class CustomerAddressForOrder
    {
        public int addressId { get; set; }
        public int addressType { get; set; }
        public bool isDefault { get; set; }
        public string description { get; set; }
        public string departmentName { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal { get; set; }
        public Dictionary<Object, Object> extraData { get; set; }
        public string addressNotes { get; set; }
    }
}
