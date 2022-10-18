using HelmesTechnicalAssignment.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HelmesTechnicalAssignment.Services
{
    public class TerozaursService: ITerozaursService
    {
        readonly HttpClient _httpClient;
        const string _baseUrl = "http://api.tezaurs.lv";

        public TerozaursService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TerozaursExample>> AnalyzeAsync(string word)
        {
            var result = await _httpClient.GetAsync($"{_baseUrl}/v1/examples/{word}");
            var resultContent = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode) throw new Exception(resultContent);

            var validResult = JsonConvert.DeserializeObject<List<TerozaursExample>>(
                resultContent, 
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            return validResult;
        }
    }
}
