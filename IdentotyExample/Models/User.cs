using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IdentotyExample.Models
{
    public class User : IdentityUser
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        [JsonIgnore]
        public List<Address> Addresses { get; set; }
    }
}
