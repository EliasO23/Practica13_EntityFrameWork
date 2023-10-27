using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica11_Entity_Framework
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set;}
        public int Edad { get; set; }
        public string? Sexo { get; set; }

    }
}
