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
        public int id = 0;

        public Lista()
        {
            this.primero = null;
            this.ultimo = null;
        }

        public void insertar(string lexema, int tipo, int logico) {

            nodo nuevo = new nodo(id, lexema, tipo, logico);
            id++;
            if (primero == null)
            {
                primero = nuevo;
                ultimo = primero;
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
                    if (actual == primero)
                    {
                        primero = primero.Siguiente;
                    }
                    else {
                        anterior.Siguiente = actual.Siguiente;
                    }
                }

                anterior = actual;
                actual = actual.Siguiente;
            }
            
        }

        public bool unico() {
            if (primero!=null && primero.Siguiente==null) {
                return true;
            }

            return false;

        }

        public void insertarIzquierda(nodo actual, nodo insertar) {
            actual.Izquierda = insertar;
           // eliminar(insertar.Id);

        }

        public void insertarDerescha(nodo actual, nodo insertar) {
            actual.Derecha = insertar;
            //eliminar(insertar.Id);
        }

        public void operadorUnico() {
            nodo actual = primero;
            ///nodo aux=null;
          
            while (actual!=null) {

                if (actual != null && actual.Siguiente != null) {

                    if (actual.Tipo == 2 && actual.Siguiente.Tipo == 1)
                    {
                      //  Console.WriteLine("encontrado:   " + actual.Lexema + "   ingreso I" + actual.Siguiente.Lexema);
                        insertarIzquierda(actual, actual.Siguiente);
                        eliminar(actual.Siguiente.Id);
                        
                        actual.Tipo = 1;
                    }
                }

                
                actual = actual.Siguiente;
                
               
            }

        }

        public void operdor() {
            nodo actual = primero;
            int x, y;

            while (actual!=null)
            {

                if (actual != null && actual.Siguiente != null && actual.Siguiente.Siguiente != null)
                {

                    if (actual.Tipo == 3 && actual.Siguiente.Tipo == 1 && actual.Siguiente.Siguiente.Tipo == 1)
                    {
                        insertarIzquierda(actual, actual.Siguiente);
                        insertarDerescha(actual, actual.Siguiente.Siguiente);
                        x = actual.Siguiente.Id;
                        y = actual.Siguiente.Siguiente.Id;
                     //  Console.WriteLine("eliminar: " + x);
                     //  Console.WriteLine("eliminar: " + y);
                        eliminar(x);
                        eliminar(y);
                        actual.Tipo = 1;

                    }
                }


                actual = actual.Siguiente;
            }

           
        }

        public void arbol() {

            while (unico()==false)
            {
                operadorUnico();
                operdor();
            }

            recorrerArbol();
        }


        public void recorrerLista() {

            nodo actual = primero;
            while (actual!=null)
            {
                Console.WriteLine( "        "+actual.Id+" Lexema: "+actual.Lexema+"  tipo: "+actual.Tipo+" Logico: "+actual.Logico);

                actual = actual.Siguiente;
            }
        }

        public void eliminarUltimo() {
            eliminar(id-1);
        }



        public void recorrerArbol() {

            recorrerArbol(primero);
        }

        private void recorrerArbol(nodo r) {
            if (r!=null)
            {
                Console.WriteLine(r.Lexema+"  TIPO"+r.Tipo);
                recorrerArbol(r.Izquierda);
                
                recorrerArbol(r.Derecha);

            }
            
        }
    }
}
