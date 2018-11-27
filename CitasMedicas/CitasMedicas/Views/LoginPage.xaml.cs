using CitasMedicas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitasMedicas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void Ingresar_Click(object sender, EventArgs e)
        {
            var usuario = Usuario.Text;
            var password = Password.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                await DisplayAlert("Validacion", "Ingrese el usuario", "Aceptar");
                Usuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(usuario))
            {
                await DisplayAlert("Validacion", "Ingrese el usuario", "Aceptar");
                Usuario.Focus();
                return;

            }
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://misapis.azurewebsites.net");

            var autenticacion = new Autenticacion
            {
                Usuario = usuario,
                Password = password
            };

            string json = JsonConvert.SerializeObject(autenticacion);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = await cliente.PostAsync("/api/seguridad", content);
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Respuesta>(responseJson);

                if (respuesta.EsPermitido)
                {
                    await Navigation.PushAsync(new PacientesPage());
                }
                else
                {
                    await DisplayAlert("Lo sentimos!", respuesta.Mensaje, "Aceptar");
                }


            }
            else
            {
                await DisplayAlert("Lo sentimos!", "Ha Ocurrido un error de comunicacion", "OK");
            }

        }
    }

}