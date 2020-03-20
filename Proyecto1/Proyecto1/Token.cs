using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Token
    {
        int id;
        string lexema;
        int tipo;
        int logico;
        string name;
        int fila, columna;

        public Token(int id, string lexema,  int tipo, int logico, string name,int fila, int columna)
        {
            this.Id = id;
            this.Lexema = lexema;
            this.Tipo = tipo;
            this.logico = logico;
            this.Name = name;
            this.fila = fila;
            this.columna = columna;
        }



       

        public string Lexema { get; set; }

        public int Tipo { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public int Logico { get => logico; set => logico = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }

        public string mostrar() {

            return Id + "  lexema: " + Lexema + " tipo: " + Tipo + " Logico:" + Logico + " Name: " + Name;

        } 
    }
}
