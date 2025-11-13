using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilApp.ViewModels.Admin
{
    partial class AdminProductosViewModel : ObservableObject
    {
        GenericService<Producto> _productoService = new();

        [ObservableProperty]
        private ObservableCollection<Producto> productos;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EditCommand))]
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))]
        private Producto productoCurrent;

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        private string filterText;

        public IRelayCommand AddCommand { get; }
        public IRelayCommand EditCommand { get; }
        public IRelayCommand DeleteCommand { get; }
        public IRelayCommand RefreshCommand { get; }

        public AdminProductosViewModel()
        {
            _ = LoadProductos();
            AddCommand = new AsyncRelayCommand(AddProducto);
            EditCommand = new AsyncRelayCommand(EditProducto, CanEditProducto);
            DeleteCommand = new AsyncRelayCommand(DeleteProducto, CanDeleteProducto);
            RefreshCommand = new AsyncRelayCommand(LoadProductos);
        }

        private bool CanDeleteProducto()
        {
            return productoCurrent != null;
        }

        private async Task DeleteProducto()
        {
            throw new NotImplementedException();
        }

        private bool CanEditProducto()
        {
            return productoCurrent != null;
        }

        private async Task EditProducto()
        {
            throw new NotImplementedException();
        }

        private async Task AddProducto()
        {
            throw new NotImplementedException();
        }

        private async Task LoadProductos()
        {
            isRefreshing = true;
            var productos = await _productoService.GetAllAsync();
            Productos =  productos != null ? new ObservableCollection<Producto>(productos) : new ObservableCollection<Producto>();
            isRefreshing = false;
        }
    }
}