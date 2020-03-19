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

        public Token(int id, string lexema,  int tipo, int logico, string name)
        {
            this.Id = id;
            this.Lexema = lexema;
            this.Tipo = tipo;
            this.logico = logico;
            this.Name = name;
        }



       

        public string Lexema { get; set; }

        public int Tipo { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public int Logico { get => logico; set => logico = value; }

        public string mostrar() {

            return Id + "  lexema: " + Lexema + " tipo: " + Tipo + " Logico:" + Logico + " Name: " + Name;

        } 
    }
}
