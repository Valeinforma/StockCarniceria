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

namespace MovilApp.ViewModels.Productos
{
    partial class ProductosViewModel : ObservableObject
    {
         GenericService<Producto> _productosService = new();

        [ObservableProperty]
        private string textoBusqueda = string.Empty;

        [ObservableProperty]
        private bool estaDescargando;

        [ObservableProperty]
        private ObservableCollection<Producto> productos = new();



        public IRelayCommand BuscarCommand { get; }
        public IRelayCommand LimpiarCommand { get; }


        public ProductosViewModel()
        {
            BuscarCommand = new RelayCommand(OnBuscar);
            LimpiarCommand = new RelayCommand(OnLimpiar);
            _ = InicializarAsync();
        }

        private async Task InicializarAsync()
        {
            OnBuscar();
        }





        private async void OnBuscar()
        {
            if (EstaDescargando) return;

            try
            {
                EstaDescargando = true;


                var productos = await _productosService.GetAllAsync(TextoBusqueda);

                Productos = productos != null ?
                        new ObservableCollection<Producto>(productos)
                        : new ObservableCollection<Producto>();
            }
            finally
            {
                EstaDescargando = false;
            }
        }



        private void OnLimpiar()
        {
            TextoBusqueda = string.Empty;
            // Mantener los filtros pero ejecutar búsqueda limpia
            OnBuscar();
        }


    }
}
