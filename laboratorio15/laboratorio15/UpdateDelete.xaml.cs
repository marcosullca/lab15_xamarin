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
    public partial class UpdateDelete : ContentPage
    {
        private const string url = "https://lab14-xamarin.herokuapp.com/api/users";


        User userDetail;
        public UpdateDelete(User SelectedUser)
        {
            InitializeComponent();

            userDetail = SelectedUser;

            firstName.Text = SelectedUser.firstName;
            lastName.Text = SelectedUser.lastName;
            email.Text = SelectedUser.email;
            password.Text = SelectedUser.password;



        }



        //protected override async void OnAppearing()
        //{
        //    string url = $"https://lab14-xamarin.herokuapp.com/api/users/{userDetail.id}";
        //    var client = new System.Net.Http.HttpClient();
        //    var response = await client.GetAsync(url);
        //    string content = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine("contenido" + content);
        //    User userClase = new User();
        //    userClase = JsonConvert.DeserializeObject<User>(content);
        //    firstName.Text = userClase.firstName;
        //    lastName.Text = userClase.lastName;
        //    email.Text = userClase.email;
        //    password.Text = userClase.password;

        //    base.OnAppearing();
        //}



        private void Update_Clicked(object sender, EventArgs e)
        {
            string url = $"https://lab14-xamarin.herokuapp.com/api/users/{userDetail.id}";
            Usuario usuario = new Usuario
            {
                firstName = firstName.Text,
                lastName = lastName.Text,
                email = email.Text,
                password = password.Text
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(usuario);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.PutAsync(String.Format(url), httpContent);
            Console.WriteLine("Usuario Actualizado" + httpContent);

            Navigation.PopAsync();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            string url = $"https://lab14-xamarin.herokuapp.com/api/users/{userDetail.id}";
           
            var httpClient = new HttpClient();
            httpClient.DeleteAsync(String.Format(url));
            Console.WriteLine("Usuario Actualizado");

            Navigation.PopAsync();
        }
    }
}