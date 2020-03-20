using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class nodo
    {
        int id;
        string lexema;
        int tipo;
        nodo siguiente;
        nodo derecha;
        nodo izquierda;

        public nodo(int id, string lexema, int tipo)
        {
            this.id = id;
            this.lexema = lexema;
            this.tipo = tipo;
            this.siguiente = null;
            this.derecha = null;
            this.izquierda = null;
        }

        public int Id { get => id; set => id = value; }
        public string Lexema { get => lexema; set => lexema = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        internal nodo Siguiente { get => siguiente; set => siguiente = value; }
        internal nodo Derecha { get => derecha; set => derecha = value; }
        internal nodo Izquierda { get => izquierda; set => izquierda = value; }
    }
}
