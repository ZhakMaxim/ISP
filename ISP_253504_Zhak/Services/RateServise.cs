using ISP_253504_Zhak.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

            try
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
                    // Обработка ошибок
                    // Можно выбросить исключение или вернуть пустой список валют
                    return Enumerable.Empty<Rate>();
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений, например, сетевых ошибок
                return Enumerable.Empty<Rate>();
            }


        }
    }
}
