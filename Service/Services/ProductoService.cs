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

        public async Task<List<Producto>?> GetProductoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/productos/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, _options);
        }

        public async Task<List<Producto>?> GetProductosPorCategoriaAsync(int categoriaId)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/productos/categoria/{categoriaId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los productos por categoría: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, _options);
        }

        public async Task<List<Producto>?> BuscarProductosPorNombreAsync(string nombre)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/productos/buscar?nombre={Uri.EscapeDataString(nombre)}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al buscar productos por nombre: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Producto>>(content, _options);
        }
    }
}