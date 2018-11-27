using System;
using System.Collections.Generic;
using System.Text;

namespace CitasMedicas.Models
{

    public class Paciente
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacim { get; set; }
        public string Rh { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
    }

}
