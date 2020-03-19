using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Error
    {

        int id;
        String erro;
        String tipo;

        public Error(int id, string error, string tipo)
        {
            this.id = id;
            this.erro = error;
            this.tipo = tipo;
        }

        public int Id { get => id; set => id = value; }
        public string Erro { get => erro; set => erro = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
