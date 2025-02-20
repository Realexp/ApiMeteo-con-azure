using Microsoft.EntityFrameworkCore;

namespace ApiMeteo.Data
{
    [PrimaryKey("IDCity")]
    public class City
    {
        public int IDCity { get; set; }
        public string NameCity { get; set; }
        public string NazionCity { get; set; }
        public List<Preference>? Preference { get; set; } 
    }
}
