using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Conjunto
    {

        int id;
        String nombre;
        List<string> con = new List<string>();

        public Conjunto(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
           
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<string> Con { get => con; set => con = value; }

        public void mostrarTokens()
        {
            foreach (var item in con)
            {
                Console.WriteLine("     "+item);
            }
        }
    }
}
