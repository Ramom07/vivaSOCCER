using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vsoccer
{
     class Alumno
    {
        private int id;
        private string nombre;
        private string categoria;
        private DateTime fechaNac;
        private string tutor;
        private string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Tutor { get => tutor; set => tutor = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
