using Application.Services;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class CnpjService : ICnpjService
    {
        private readonly HttpClient _httpClient;
        private const string urlBase = "https://www.receitaws.com.br/v1/cnpj/";
        public CnpjService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<EmpresaDto> ObterDadosPorCnpj(string cnpj)
        {
            string url = urlBase + $"{cnpj}";

            var response = await _httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();
            var empresa = JsonConvert.DeserializeObject<EmpresaDto>(content);

            return empresa;
        }

        //Quero aplicar retry, circuit break e policies nessa chamada
    }
}
