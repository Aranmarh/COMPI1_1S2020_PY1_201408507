using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Expresion
    {
        int id;
        string name;
        List<Token> t = new List<Token>();
        Lista l = new Lista();

        public Expresion(int id, string name)
        {
            this.id = id;
            this.name = name;
            
        }

        public int Id { get => id; set => id = value; }
        public List<Token> Token { get => t; set => t= value; }
        public string Name { get => name; set => name = value; }
        internal Lista L { get => l; set => l = value; }

        public void mostrarTokens() {
            foreach (var item in t)
            {
                Console.WriteLine("           lexema "+item.Lexema+" logico: "+item.Logico+" tipo:"+item.Tipo);
            }
        }
    }
}
