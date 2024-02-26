using ISP_253504_Zhak.Entities;
using Newtonsoft.Json;          

namespace ISP_253504_Zhak.Services
{
    internal class RateServise : IRateServise
    {
        HttpClient _httpClient;
        public RateServise(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Rate>> GetRates(DateTime date)
        {
            var formattedDate = date.ToString("yyyy-MM-dd");
            var response = await _httpClient.GetAsync($"https://api.nbrb.by/exrates/rates?ondate={formattedDate}&periodicity=0");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var rates = JsonConvert.DeserializeObject<IEnumerable<Rate>>(content);
                return rates;
            }
            else
            {
                return Enumerable.Empty<Rate>();
            }
       
        }
    }
}
