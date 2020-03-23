using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class nodoM
    {

        string nombre;
        nodo contenido;
        nodoM siguiente;

        public nodoM(string nombre, nodo contenido)
        {
            this.nombre = nombre;
            this.contenido = contenido;
            this.siguiente = null;
        }

        public string Nombre1 { get => nombre; set => nombre = value; }
        nodoM Siguiente { get => siguiente; set => siguiente = value; }
        nodo Contenido { get => contenido; set => contenido = value; }
    }
}
