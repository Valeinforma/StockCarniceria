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
    public class CapacitacionService : GenericService<Venta>, IVentaService
    {

        public async Task<List<Venta>?> GetVentasAsync()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/abiertas");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Venta>>(content, _options);
        }
        public async Task<List<Venta>?> GetCapacitacionesFuturasAsync()
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/futuras");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Venta>>(content, _options);
        }

    }
}