using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Service.Models;
using Service.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Maui.Controls; 

namespace MovilApp.ViewModels.Productos
{
    // La clase parcial es necesaria para que el Community Toolkit genere el código
    public partial class ProductosViewModel : ObservableObject
    {
        // 1. SERVICIOS 
        // Instancia del servicio genérico para el modelo 'Producto'
        GenericService<Producto> _productosService = new();

        // 2. PROPIEDADES OBSERVABLES 

        [ObservableProperty]
        private string textoBusqueda = string.Empty;

        // Propiedad que indica la actividad para la UI 
        [ObservableProperty]
        private bool estaDescargando;

        // Colección principal de productos (enlazada al CollectionView)
        [ObservableProperty]
        private ObservableCollection<Producto> productos = new();

        [ObservableProperty]
        private string mensajeError = string.Empty;

        // Propiedad opcional para manejar el producto seleccionado si no usas el botón
        [ObservableProperty]
        private Producto productoSeleccionado;


        // 3. COMANDOS 
        // Búsqueda y Limpiar usando el patrón de inyección en el constructor.
        public IRelayCommand BuscarCommand { get; }
        public IRelayCommand LimpiarCommand { get; }

        // Comando para el botón "Ver Detalle" en la tarjeta del producto.
        public IRelayCommand VerDetalleCommand { get; }


        // 4. CONSTRUCTOR 
        public ProductosViewModel()
        {
            // Usamos AsyncRelayCommand para la búsqueda ya que llama a un servicio (async)
            BuscarCommand = new AsyncRelayCommand(OnBuscar);

            // Usamos RelayCommand para limpiar, llamando luego al comando de búsqueda
            LimpiarCommand = new RelayCommand(OnLimpiar);

            // Usamos RelayCommand<T> para pasar el objeto 'Producto' al método
            VerDetalleCommand = new RelayCommand<Producto>(OnVerDetalle);

            // Inicializar la carga de datos al iniciar el ViewModel
            _ = InicializarAsync();
        }

        // 5. MÉTODOS DE LÓGICA 

        private async Task InicializarAsync()
        {
            // Llama a la búsqueda inicial para llenar la lista (con TextoBusqueda vacío)
            await OnBuscar();
        }


        // Método Asíncrono para buscar productos
        private async Task OnBuscar()
        {
            if (EstaDescargando) return;

            try
            {
                EstaDescargando = true;
                MensajeError = string.Empty; // Limpiar mensajes de error

                // Llama al servicio para obtener productos (filtrados por TextoBusqueda)
                // Asumimos que GetAllAsync() maneja la lógica de filtrado del texto.
                var productosData = await _productosService.GetAllAsync(TextoBusqueda);

                // Asignar los resultados a la propiedad 'Productos'
                Productos = productosData != null
              ? new ObservableCollection<Producto>(productosData)
              : new ObservableCollection<Producto>();

                if (Productos.Count == 0 && !string.IsNullOrWhiteSpace(TextoBusqueda))
                {
                    MensajeError = "No se encontraron productos que coincidan con la búsqueda.";
                }
            }
            catch (Exception ex)
            {
                MensajeError = "Error al cargar los productos: " + ex.Message;
                // Opcional: Mostrar alerta de error
                await Shell.Current.DisplayAlert("Error", MensajeError, "OK");
            }
            finally
            {
                EstaDescargando = false;
            }
        }


        private void OnLimpiar()
        {
            TextoBusqueda = string.Empty;

            // Disparar la búsqueda nuevamente con el texto vacío.
            BuscarCommand.Execute(null);
        }

        // Método para el botón "Ver Detalle" (enlazado al VerDetalleCommand)
        private async void OnVerDetalle(Producto producto)
        {
            if (producto == null) return;

            // 🚨 Aquí debes implementar la lógica de navegación real
            await Shell.Current.DisplayAlert("Detalle de Producto",
                $"Navegando a la página de detalle para: {producto.Nombre}",
                "OK");

        }


       
        [RelayCommand]
        private async Task Volver()
        {
            // Usa Shell.Current.GoToAsync("..") para subir un nivel de navegación
            await Shell.Current.GoToAsync("..");
        }
    }
}