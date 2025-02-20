using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMeteo.Data
{
    [PrimaryKey("EmailUser", "IDCity")]
    public class Preference
    {
        public string EmailUser { get; set; }
        public int IDCity { get; set; }

        [ForeignKey("EmailUser")]
        public User? User { get; set; }
        [ForeignKey("IDCity")]
        public City? City { get; set; }
    }
}
