using ApiMeteo.Data;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

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
        public CleanData completeData(CleanData cleanData, WebClient web,string ApiKey) {
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", cleanData.CityData, ApiKey);
            var datas = web.DownloadString(url);
            var weatherData = JsonConvert.DeserializeObject(datas).ToString();
            return new CleanData()
            {
                CityData = cleanData.CityData,
                meteoData = weatherData,
            };
        }
    }
}
