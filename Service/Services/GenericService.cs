using Service.Interfaces;
using Service.Utlis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _options;
        protected readonly string _endpoint;
        public GenericService()
        {
            _httpClient = new HttpClient();

            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _endpoint = Properties.Resources.UrlApi + ApiEndPoins.GetEndpoint(typeof(T).Name);

  


        }
        public async Task<T?> AddAsync(T? entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_endpoint, entity);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al agregar el registro: {response.StatusCode} - {content}");
            }
            return JsonSerializer.Deserialize<T>(content, _options);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {

                throw new Exception($"Error al eliminar el registro: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;

        }

        public async Task<List<T>?> GetAllAsync(string? filtro = "")
        {
            var response = await _httpClient.GetAsync($"{_endpoint}?filter={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<T>>(content, _options);
        }

        public async Task<List<T>?> GetAllDeletedAsync(string? filtro = "")
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/Deleteds");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode} - {content}");
            }
            return JsonSerializer.Deserialize<List<T>>(content, _options);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            {
                var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al obtener los datos: {response.StatusCode} - {content}");
                }
                return JsonSerializer.Deserialize<T>(content, _options);
            }
        }

        public async Task<bool> RestoreAsync(int id)
        {
            var response = await _httpClient.PutAsync($"{_endpoint}/restore/{id}",null);
            if (!response.IsSuccessStatusCode)
            {

                throw new Exception("Error al eliminar el registro");
            }
            else
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdateAsync(T? entity)
        {
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);
            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hubon un problema al actualizar");
            }
            else
            {
                return response.IsSuccessStatusCode;
            }


        }






    }

}
