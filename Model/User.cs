using System.ComponentModel.DataAnnotations;

namespace userService.Model
{
    public class User
    {
        [Key]
        public int id {get; set;}
        [MinLength(5), MaxLength(15)]
        public string username {get ; set;}
        public string passhash {get ; set;}
        [MinLength(10)]
        public string address {get; set;}
        public long cellphone {get; set;}
        [EmailAddress]
        public string email {get; set;}
    }
}

