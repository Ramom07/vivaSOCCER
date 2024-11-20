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
        private string ap1;
        private string ap2;
        private string categoria;
        private DateTime fechaNac;
        private string tutor;
        private string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public string Apellido1 { get =>  ap1; set => ap1 = value; }

        public string Apellido2 { get => ap2; set => ap2 = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Tutor { get => tutor; set => tutor = value; }
        
    }
}
