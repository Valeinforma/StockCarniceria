using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Service.Models; // Asegúrate de que tu modelo 'Producto' está aquí
using Service.Services; // Asegúrate de que 'GenericService' está aquí
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq; // Necesario para el filtrado (opcional)

namespace MovilApp.ViewModels.Admin
{
    // Usamos 'partial' porque el Community Toolkit genera código adicional.
    partial class AdminProductosViewModel : ObservableObject
    {
        // 1. SERVICIOS 🛠️
        // Instancia del servicio genérico para manejar la entidad Producto
        GenericService<Producto> _productoService = new();

        // 2. PROPIEDADES OBSERVABLES (ENLACE DE DATOS) ✨

        // Colección principal de todos los productos (ObservableCollection notifica cambios)
        [ObservableProperty]
        private ObservableCollection<Producto> productos;

        // Propiedad para el elemento seleccionado actualmente en la lista (Current)
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EditCommand))]
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
        private Producto productoCurrent;

        // Propiedad para indicar si la lista se está actualizando (RefreshView)
        [ObservableProperty]
        private bool isRefreshing;

        // Propiedad para el texto de búsqueda/filtro
        [ObservableProperty]
        // [NotifyPropertyChangedFor(nameof(ProductosFiltrados))] // <-- Descomentar si implementas el filtrado
        private string filterText;

        // 3. COMANDOS (ACCIONES DE LA INTERFAZ) ⚡
        public IRelayCommand AddCommand { get; }
        public IRelayCommand EditCommand { get; }
        public IRelayCommand DeleteCommand { get; }
        public IRelayCommand RefreshCommand { get; }

        // 4. CONSTRUCTOR 🏗️
        public AdminProductosViewModel()
        {
            // Carga inicial de datos al iniciar el ViewModel (ignora el resultado con '_')
            _ = LoadProductos();

            // Inicialización de comandos
            AddCommand = new AsyncRelayCommand(AddProducto);
            // Los comandos Edit y Delete usan métodos 'CanExecute' para deshabilitarse si no hay un producto seleccionado
            EditCommand = new AsyncRelayCommand(EditProducto, CanEditProducto);
            DeleteCommand = new AsyncRelayCommand(DeleteProducto, CanDeleteProducto);
            RefreshCommand = new AsyncRelayCommand(LoadProductos);
        }

        // 5. MÉTODOS DE LÓGICA 🧠

        // --- Lógica de Carga y Refresco ---
        private async Task LoadProductos()
        {
            // Inicia el indicador de refresco (propiedad generada por el toolkit)
            IsRefreshing = true;

            // Llama al servicio para obtener todos los productos
            var productos = await _productoService.GetAllAsync();

            // Asigna los resultados a la colección observable. Si es null, usa una colección vacía.
            Productos = productos != null
                ? new ObservableCollection<Producto>(productos)
                : new ObservableCollection<Producto>();

            // Detiene el indicador de refresco
            IsRefreshing = false;
        }

        // --- Lógica de Agregar ---
        private async Task AddProducto()
        {
            // TODO: Implementar la navegación a la página de detalle/creación de Producto.
            // Ejemplo: await Shell.Current.GoToAsync("ProductoDetailPage");
            throw new System.NotImplementedException();
        }

        // --- Lógica de Edición ---
        private bool CanEditProducto()
        {
            // Solo se puede editar si hay un producto seleccionado (no es null)
            return ProductoCurrent != null;
        }
        private async Task EditProducto()
        {
            // TODO: Implementar la navegación a la página de detalle, pasando el ProductoCurrent.
            // Ejemplo: await Shell.Current.GoToAsync($"ProductoDetailPage?Id={ProductoCurrent.Id}");
            throw new System.NotImplementedException();
        }

        // --- Lógica de Eliminación ---
        private bool CanDeleteProducto()
        {
            // Solo se puede eliminar si hay un producto seleccionado (no es null)
            return ProductoCurrent != null;
        }
        private async Task DeleteProducto()
        {
            // TODO: Implementar la lógica de confirmación y eliminación.

            // 1. Mostrar confirmación al usuario (opcional pero recomendado)
            // bool confirmed = await Application.Current.MainPage.DisplayAlert("Confirmar", 
            //     $"¿Desea eliminar el producto: {ProductoCurrent.Nombre}?", "Sí", "No");

            // if (confirmed)
            // {
            // 2. Llamar al servicio para eliminar el producto en la base de datos
            // bool success = await _productoService.DeleteAsync(ProductoCurrent.Id);

            // if (success)
            // {
            // 3. Eliminar el producto de la colección en memoria (para actualizar la UI)
            // Productos.Remove(ProductoCurrent);
            // ProductoCurrent = null; // Deseleccionar
            // }
            // }

            throw new System.NotImplementedException();
        }
    }
}