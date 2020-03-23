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
        int logico;
        nodo siguiente;
        nodo derecha;
        nodo izquierda;
        nodo u;

        public nodo(int id, string lexema, int tipo, int logico)
        {
            this.id = id;
            this.lexema = lexema;
            this.tipo = tipo;
            this.logico = logico;
            this.siguiente = null;
            this.derecha = null;
            this.izquierda = null;
            this.u = null;
        }

        public int Id { get => id; set => id = value; }
        public string Lexema { get => lexema; set => lexema = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public int Logico { get => logico; set => logico = value; }
        internal nodo Siguiente { get => siguiente; set => siguiente = value; }
        internal nodo Derecha { get => derecha; set => derecha = value; }
        internal nodo Izquierda { get => izquierda; set => izquierda = value; }
        internal nodo U { get => u; set => u = value; }
    }
}
