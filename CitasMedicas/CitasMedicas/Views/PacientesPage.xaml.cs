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
    public partial class PacientesPage : ContentPage
    {
        public PacientesPage()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private async void CargarPacientes()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://172.18.25.244");

            var request = await client.GetAsync("/ApiPacientes/api/Paciente");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var pacientes = JsonConvert.DeserializeObject<List<Paciente>>(responseJson);
                listpacientes.ItemsSource = pacientes;
            }
            else
            {
                await DisplayAlert("Lo sentimos!", "Ha ocurrido un error de comunicacion", "OK");
            }
        }
        private async void Paciente_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var paciente = (Paciente)e.SelectedItem;
            await Navigation.PushAsync(new CitasPage(paciente));
     }
    }
}