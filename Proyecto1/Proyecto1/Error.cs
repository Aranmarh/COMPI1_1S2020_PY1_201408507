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
        int fila, columna;

        public Error(int id, string error, string tipo,int fila, int columna)
        {
            this.id = id;
            this.erro = error;
            this.tipo = tipo;
            this.fila = fila;
            this.columna = columna;
        }

        public int Id { get => id; set => id = value; }
        public string Erro { get => erro; set => erro = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Columna { get => columna; set => columna = value; }
        public int Fila { get => fila; set => fila = value; }
    }
}
