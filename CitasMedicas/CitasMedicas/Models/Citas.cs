using System;
using System.Collections.Generic;
using System.Text;

namespace CitasMedicas.Models
{
    public class Citas
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Paciente { get; set; }
        public string Doc { get; set; }
        public string Eps { get; set; }
        public string Medico { get; set; }
        public DateTime Fecha
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
