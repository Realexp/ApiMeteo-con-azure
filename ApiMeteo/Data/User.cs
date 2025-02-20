using Microsoft.EntityFrameworkCore;

namespace ApiMeteo.Data
{
    [PrimaryKey("EmailUser")]
    public class User
    {
        public string EmailUser { get; set; }
        public string NameUser { get; set; }
        public List<Preference>? Preference { get; set; }
    }
}
