using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Lista
    {
        nodo primero;
        nodo ultimo;
        int id = 0;

        public Lista(nodo primero, nodo ultimo)
        {
            this.primero = null;
            this.ultimo = null;
        }

        public void insertar(string lexema, int tipo) {

            nodo nuevo = new nodo(id, lexema, tipo);
            if (primero == null)
            {
                primero = nuevo;
                primero = ultimo;
            }
            else {
                ultimo.Siguiente = nuevo;
                ultimo = nuevo;

            }
        }

        public void eliminar(int id) {
            nodo actual = primero;
            nodo anterior=null;
            while (actual != null) {
                if (actual.Id==id)
                {
                    break;
                }

                anterior = actual;
                actual = actual.Siguiente;
            }
            if (actual!=null)
            {
                anterior.Siguiente = actual.Siguiente;
            }
        }
    }
}
