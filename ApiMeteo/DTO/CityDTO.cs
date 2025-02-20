using ApiMeteo.Data;

namespace ApiMeteo.DTO
{
    public class CityDTO
    {
        public int IDCity { get; set; }
        public string NameCity { get; set; }
        public string NazionCity { get; set; }
        public List<UserDTO>? Users { get; set; }
    }
}
