using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Service.Models;
using Service.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace MovilApp.ViewModels.Productos
{
    partial class ProductosViewModel : ObservableObject
    {
        // 1. SERVICIOS 🛠️
        // Utilizamos el servicio genérico
        GenericService<Producto> _productosService = new();

        // 2. PROPIEDADES OBSERVABLES ✨
        [ObservableProperty]
        private string textoBusqueda = string.Empty;

        // Propiedad que indica la actividad para la UI (usando la propiedad autogenerada 'EstaDescargando')
        [ObservableProperty]
        private bool estaDescargando;

        // Colección principal de productos
        [ObservableProperty]
        private ObservableCollection<Producto> productos = new();

        [ObservableProperty]
        private string mensajeError = string.Empty;


        // 3. COMANDOS ⚡
        // Usaremos AsyncRelayCommand para la búsqueda.
        public IRelayCommand BuscarCommand { get; }
        public IRelayCommand LimpiarCommand { get; }


        // 4. CONSTRUCTOR 🏗️
        public ProductosViewModel()
        {
            // **CORRECCIÓN:** Usar AsyncRelayCommand para comandos asíncronos
            BuscarCommand = new AsyncRelayCommand(OnBuscar);

            // Usar RelayCommand para comandos síncronos
            LimpiarCommand = new RelayCommand(OnLimpiar);

            // Inicializar la carga de datos al iniciar el ViewModel
            _ = InicializarAsync();
        }

        // 5. MÉTODOS DE LÓGICA 🧠

        private async Task InicializarAsync()
        {
            // Llama a la búsqueda inicial para llenar la lista.
            await OnBuscar();
        }


        // **CORRECCIÓN:** Cambiado a 'async Task' para mejor manejo asíncrono
        private async Task OnBuscar()
        {
            // Usar la propiedad generada (EstaDescargando)
            if (EstaDescargando) return;

            try
            {
                // Iniciar indicador de actividad
                EstaDescargando = true;

                // Llama al servicio para obtener productos (filtrados por TextoBusqueda)
                var productosData = await _productosService.GetAllAsync(TextoBusqueda);

                // Asignar los resultados a la propiedad 'Productos'
                Productos = productosData != null ?
                            new ObservableCollection<Producto>(productosData)
                            : new ObservableCollection<Producto>();
            }
            finally
            {
                // Detener indicador de actividad
                EstaDescargando = false;
            }
        }


        private void OnLimpiar()
        {
            // Usar la propiedad generada (TextoBusqueda)
            TextoBusqueda = string.Empty;

            // Disparar la búsqueda nuevamente con el texto vacío.
            // La llamada síncrona a un método asíncrono no es ideal, pero es el patrón de tu ejemplo.
            // Lo más limpio sería que OnBuscar fuese también AsyncRelayCommand.Execute().
            // Como ya lo hicimos en el constructor, aquí solo llamamos al método del comando:
            BuscarCommand.Execute(null);
        }

        // COMANDO PARA VOLVER
        [RelayCommand]
        private async Task Volver()
        {
            if (Application.Current?.MainPage is NavigationPage navPage)
            {
                await navPage.PopAsync();
            }
        }
    }
}