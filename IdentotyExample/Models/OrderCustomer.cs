namespace IdentotyExample.Models
{
    public class OrderCustomer
    {
        public string id { get; set; }
        public string CustomerId { get; set; }
        public string EMail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? BusinessName { get; set; }
        public string? VoicePhone { get; set; }
        public string VoicePhoneExtension { get; set; }
        public string DepartmentName { get; set; }
        public string? AltPhone { get; set; }
        public string AltPhoneExtension { get; set; }
        //public string FavoriteSiteId { get; set; }
        //public string FavoriteSiteIds { get; set; }
        //public string LoyaltyCardNumber { get; set; }
        //public string SecondaryEmailAddress { get; set; }
        //public string Addresses { get; set; }
        //public string Birthday { get; set; }
        //public string LoyaltyZipCode { get; set; }
    }
}
