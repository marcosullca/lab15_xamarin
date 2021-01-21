using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace laboratorio15
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarUsuario : ContentPage
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void Add_Clicked(object sender,EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                firstName = firstName.Text,
                lastName = lastName.Text,
                email = email.Text,
                password =password.Text
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(usuario);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.PostAsync(String.Format("https://lab14-xamarin.herokuapp.com/api/users"), httpContent);
            Console.WriteLine("UsuarioAgregado" + httpContent);

            Navigation.PopAsync();
        }
    }
}