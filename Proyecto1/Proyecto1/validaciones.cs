using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class validaciones
    {
        int id;
        String nombre;
        String cadena;

        public validaciones(int id, string nombre, string cadena)
        {
            this.id = id;
            this.nombre = nombre;
            this.cadena = cadena;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Cadena { get => cadena; set => cadena = value; }
    }
}
