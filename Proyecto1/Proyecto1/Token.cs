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
        string name;

        public Token(int id, string lexema, int tipo, string name)
        {
            this.Id = id;
            this.Lexema = lexema;
            this.Tipo = tipo;
            this.Name = name;
        }



       

        public string Lexema { get => lexema; set => lexema = value; }

        public int Tipo { get => tipo; set => tipo = value; }

        public string Name { get => name; set => name = value; }

        public int Id { get => id; set => id = value; }
    }
}
