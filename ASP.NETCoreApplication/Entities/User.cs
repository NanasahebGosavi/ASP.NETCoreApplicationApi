using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASP.NETCoreApplication.Entities
{
    public class User
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public string LastName { get; set; }

        public required string Username { get; set; }

        //[JsonIgnore]
       public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
