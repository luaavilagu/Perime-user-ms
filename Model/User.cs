using System.ComponentModel.DataAnnotations;

namespace userService.Model
{
    public class User
    {
        [Key]
        public int id_user {get; set;}
        [MinLength(5), MaxLength(15)]
        public string username_user {get ; set;}
        public string passhash_user {get ; set;}
        [MinLength(10), MaxLength(30)]
        public string address_user {get; set;}
        [RegularExpression(@"^[3]([0-9]){9}$")]
        public string cellphone_user {get; set;}
        [EmailAddress]
        public string email_user {get; set;}
    }
}

