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
    public partial class CitasPage : ContentPage
    {
        private Paciente paciente;

        public CitasPage(Paciente paciente)
        {
            InitializeComponent();
        }

    }
}