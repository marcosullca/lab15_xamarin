using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace laboratorio15
{
    public partial class MainPage : ContentPage
    {
        private const string url = "https://lab14-xamarin.herokuapp.com/api/users";
        private readonly HttpClient _httpClient = new HttpClient();
        public MainPage()
        {
            
            InitializeComponent();
            Nav_agregar.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AgregarUsuario());
            };
        }

       

        protected override async void OnAppearing()
        {
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("contenido" + content);
            Root rootClase = new Root();
            rootClase = JsonConvert.DeserializeObject<Root>(content);
            miLista.ItemsSource = rootClase.users;
            base.OnAppearing();
        }






        private void Usuario_seleccionado(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelectedData = e.SelectedItem as User;
            Navigation.PushAsync(new UpdateDelete(itemSelectedData));

        }


    }
}
