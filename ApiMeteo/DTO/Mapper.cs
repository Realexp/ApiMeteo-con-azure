using ApiMeteo.Data;

namespace ApiMeteo.DTO
{
    public class Mapper
    {
        public UserDTO mapDataToDTO(User user) { 
            return new UserDTO()
            {
                EmailUser = user.EmailUser,
                NameUser = user.NameUser,
            };
        }
        public User mapDTOToData(UserDTO dto) {
            return new User()
            {
                EmailUser = dto.EmailUser,
                NameUser = dto.NameUser,
            };
        }
        public CityDTO mapDataToDTO(City city) {
            return new CityDTO()
            {
                IDCity = city.IDCity,
                NameCity = city.NameCity,
                NazionCity  = city.NazionCity,
            };
        }
        public City mapDTOToData(CityDTO city)
        {
            return new City()
            {
                IDCity = city.IDCity,
                NameCity = city.NameCity,
                NazionCity = city.NazionCity
            };
        }
    }
}
