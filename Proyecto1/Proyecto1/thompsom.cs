using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class thompsom
    {

        int id;
        nodo primero;
        nodo segundo;
        bool p,s;
        nodo raiz;
        string nombre;

        public thompsom(String nombre,nodo r)
        {
            this.nombre = nombre;
            this.id = 0;
            this.primero = null;
            this.segundo = null;
            this.raiz = r;
            this.p = false;
            this.s = false;
        }


        public void manejo(nodo nuevo) {
            if (p == false)
            {
                primero = nuevo;
                p = true;
            }
            else if (p == true && s == false)
            {
                segundo = nuevo;
                s = true;
            }
            else if (p == true && s == true)
            {
                primero = nuevo;
                segundo = null;
                s = false;
            }   

        }



        public nodo a(string hijo ) {
            nodo nuevo =  new nodo(id,hijo,20,20);
            id++;
            nodo ultimo = new nodo(id,"",30,30);
            id++;
            primero.Siguiente = ultimo;
            primero.U = ultimo;

            return nuevo;

        }

        public nodo concatenacion(nodo primero, nodo segundo) {
            primero.U.Siguiente = segundo;


            return primero;

        }
        public nodo alternacion(nodo primero, nodo segundo) {
            nodo nuevo = new nodo(id, "", 30, 30);
            id++;
            nodo ultimo  = new nodo(id, "", 30, 30);
            id++;
            nuevo.Izquierda = primero;
            nuevo.Derecha = segundo;
            primero.U.Siguiente = ultimo;
            segundo.U.Siguiente = ultimo;

            return nuevo;


        }

        public nodo cuantificacionM(nodo unico) {
            nodo nuevo = new nodo(id, "", 30, 30);
            id++;
            nodo ultimo = new nodo(id, "", 30, 30);
            id++;
            nuevo.Siguiente = unico;
            nuevo.Derecha = ultimo;
            unico.U.Siguiente = ultimo;
            unico.U.Izquierda = unico;
            nuevo.U = ultimo;

            return nuevo;
        }

        public nodo cuantificacionA(nodo unico)
        {
            nodo nuevo = new nodo(id, "", 30, 30);
            id++;
            nodo ultimo = new nodo(id, "", 30, 30);
            id++;
            nuevo.Siguiente = unico;
            
            unico.U.Siguiente = ultimo;
            unico.U.Izquierda = primero;
            nuevo.U = ultimo;

            return nuevo;
        }


        public nodo cuantificacionC(nodo unico)
        {
            nodo nuevo = new nodo(id, "", 30, 30);
            id++;
            nodo ultimo = new nodo(id, "", 30, 30);
            id++;
            nuevo.Siguiente = unico;
            nuevo.Derecha = ultimo;
            unico.U.Siguiente = ultimo;
            nuevo.U = ultimo;
          

            return nuevo;
        }


        public void generarT(Lista l ) {
            for (int i = 0; i < l.id; i++)
            {

            }


        }

        public void recorrer(nodo r) {
            if (r != null)
            {
                
                recorrer(r.Izquierda);

                recorrer(r.Derecha);

                if (r.Logico == 8 || r.Logico == 3) {

                    manejo(a(r.Lexema));
                } else if (r.Logico == 5 && r.Lexema.Equals(".")) {
                    manejo(concatenacion(primero, segundo));
                }
                else if (r.Logico == 5 && r.Lexema.Equals("|"))
                {
                    manejo(alternacion(primero,segundo));

                }

            }


        }
    }
}
