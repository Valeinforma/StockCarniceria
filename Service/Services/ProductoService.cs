using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductoService : GenericService<Producto>, IProductoService
    {

        public async Task<List<Producto>?> GetCapacitacionesAbiertasAsync()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/abiertas");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, _options);
        }
        public async Task<List<Producto>?> GetCapacitacionesFuturasAsync()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/futuras");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, _options);
        }
        public async Task<List<Producto>?> GetProductosPorCategoriaAsync()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/por-categoria");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, _options);
        }

        public async Task<List<Producto>?> BuscarProductosPorNombreAsync()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/buscar-por-nombre");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, _options);
        }
    }
}