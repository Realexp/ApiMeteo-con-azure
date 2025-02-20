using ApiMeteo.Data;

namespace ApiMeteo.DTO
{
    public class UserDTO
    {
        public string EmailUser { get; set; }
        public string NameUser { get; set; }
        public List<CityDTO>? Cities { get; set; }
    }

    public class Userdto
    {
        public string EmailUser { get; set; }
        public string NameUser { get; set; }
    }
}
