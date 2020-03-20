using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        ArrayList ListaPestaña = new ArrayList();
        List<Token> token = new List<Token>();
        List<Error> ErrorT = new List<Error>();
        List<Conjunto> conj = new List<Conjunto>();
        List<validaciones> validacion = new List<validaciones>();
        List<Expresion> exp = new List<Expresion>();
        int pestaña = 0;
        string root = "";
        int id = 0;
        int ide = 0;


        bool c, e, v = false;



        public Form1()
        {
            InitializeComponent();
            nuevaPestaña("");

        }

        private void agregarPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevaPestaña("nueva Pestaña" + pestaña);

        }

        private TextBox Crear()
        {
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.ScrollBars = ScrollBars.Both;
            textBox.WordWrap = false;

            return textBox;
        }

        private void nuevaPestaña(string name) {
            TabPage nueva = new TabPage(name);
            nueva.Controls.Add(Crear());
            ListaPestaña.Add(nueva);
            tabControl1.TabPages.Add(nueva);
            pestaña++;
            tabControl1.SelectedTab = nueva;



        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();

            if (Open.ShowDialog() == DialogResult.OK) {
                root = Open.FileName;
                AbrirLectura(Open.SafeFileName, leer(root));
            }
        }

        private String leer(string url) {
            string texto;
            TextReader leer = new StreamReader(url);
            texto = leer.ReadToEnd();
            return texto;
        }

        private void AbrirLectura(string nombre, string texto) {

            TabPage nueva = new TabPage(nombre);
            TextBox T = Crear();
            T.Text = texto;
            nueva.Controls.Add(T);
            ListaPestaña.Add(nueva);
            tabControl1.TabPages.Add(nueva);
            pestaña++;
            tabControl1.SelectedTab = nueva;


        }


        private String guardar() {

            int selectedTab = tabControl1.SelectedIndex;
            Control ctrl = tabControl1.Controls[selectedTab].Controls[0];
            TextBox rtb = ctrl as TextBox;
            string guardar = rtb.Text;
            return guardar;



        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog guardo = new SaveFileDialog();
            // guardo.Filter=".txt";
            guardo.Title = tabControl1.SelectedTab.Text;
            var resultado = guardo.ShowDialog();
            if (resultado == DialogResult.OK) {
                StreamWriter escribir = new StreamWriter(guardo.FileName);
                escribir.Write(guardar());
                escribir.Close();
            }

        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analizar(guardar());
            /* foreach (var item in token)
             {
                 Console.WriteLine(item.mostrar());
             }

             Console.WriteLine(token.Count);*/

            obtenerExpresiones();
            //mostrar();
            //Console.WriteLine(ArchivoToken());
            EscribirArchivo("Token", ArchivoToken());
            EscribirArchivo("Error", ArchivoError());
        }


        public void Analizar(string entrada) {
            int estado = 0;
            string lexema = "";
            char c;
            int fila = 1;
            int columna = 1;
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                // Console.WriteLine(c);

                switch (estado)
                {
                    case 0:
                        if (c == '<')
                        {
                            estado = 1;
                            //lexema += c;

                        }
                        else if (c == '/')
                        {
                            estado = 4;
                            //lexema += c;
                        }
                        else if (Char.IsLetter(c))
                        { //identificador
                            estado = 6;
                            lexema += c;
                        } else if (c == '-')
                        { //asignacion
                            estado = 7;
                            lexema += c;

                        }
                        else if (c == '\"')
                        { //cadena
                            estado = 8;
                            lexema += c;

                        }
                        else if (Char.IsDigit(c))
                        {//digito
                            estado = 9;
                            lexema += c;


                        }
                        else if (c == '.')
                        {//concatenacion
                            lexema += c;
                            token.Add(new Token(id, lexema, 5, 1, "concatenacion", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '|')
                        {//disyuncion
                            lexema += c;
                            token.Add(new Token(id, lexema, 5, 1, "disyuncion",fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '?')
                        { //cerradura
                            lexema += c;
                            token.Add(new Token(id, lexema, 5, 2, "cerradura", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '*')
                        { // 0 o mas
                            lexema += c;
                            token.Add(new Token(id, lexema, 5, 2, "0 o mas", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '+')
                        { //1 o mas
                            lexema += c;
                            token.Add(new Token(id, lexema, 5, 2, "1 o mas", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == ';')
                        {//punto coma
                            lexema += c;
                            token.Add(new Token(id, lexema, 6, 0, "PC", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == ',')
                        {// coma
                            lexema += c;
                            token.Add(new Token(id, lexema, 12, 0, "C", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '{')
                        { //llA
                            lexema += c;
                            token.Add(new Token(id, lexema, 6, 0, "LLA", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '}')
                        { //llC
                            lexema += c;
                            token.Add(new Token(id, lexema, 6, 0, "LLC", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '%')
                        {//porcentaje
                            lexema += c;
                            token.Add(new Token(id, lexema, 6, 0, "P", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == '~')
                        {//porcentaje
                            lexema += c;
                            token.Add(new Token(id, lexema, 11, 0, "range", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == ':')
                        {//dos puntos
                            lexema += c;
                            token.Add(new Token(id, lexema, 10, 0, "dos Puntos", fila, columna));
                            id++;
                            lexema = "";

                        }
                        else if (c == ' ' || c == '\t')
                        {
                            estado = 0;
                            columna ++;


                        } else if ( c == '\n') {
                            fila++;
                            columna = 1;
                        }
                        else
                        {

                            estado = 0;
                            ErrorT.Add(new Error(ide, lexema, "no se encuentra en la gramatica", fila, columna));
                            ide++;
                            lexema = "";
                            // System.out.println("error");
                        }

                        break;
                    case 1:
                        if (c == '!')
                        {
                            estado = 2;
                           // lexema += c;

                        }
                        else
                        {
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 2:
                        if (c != '!')
                        {
                            estado = 2;
                            if (c == '\n' || c == '\t')
                            {

                            }
                            else {
                                lexema += c;
                            }

                        }
                        else
                        {
                            estado = 3;
                           // lexema += c;
                        }
                        break;
                    case 3:
                        if (c == '>')
                        {
                            //lexema += c;
                            token.Add(new Token(id, lexema, 1, 0, "comentario multiple", fila, columna));
                            id++;
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            estado = 0;
                            ErrorT.Add(new Error(ide, lexema, "comentario multiple con error", fila, columna));
                            ide++;
                            lexema = "";
                        }
                        break;
                    case 4:
                        if (c == '/')
                        {
                            estado = 5;
                           // lexema += c;
                          


                        }
                        else
                        {
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 5:
                        if (c != '\n')
                        {
                            estado = 5;
                            lexema += c;
                        }
                        else
                        {
                            //lexema+=c;
                            token.Add(new Token(id, lexema, 2, 0, "Comentario S", fila, columna));
                            id++;
                            lexema = "";
                            estado = 0;

                            i--;
                        }
                        break;
                    case 6:
                        if (Char.IsLetter(c) || Char.IsDigit(c))
                        {
                            estado = 6;
                            lexema += c;

                        }
                        else
                        {
                            if (lexema.Equals("CONJ"))
                            {
                                token.Add(new Token(id, lexema, 7, 0, "conjunto", fila, columna));
                                id++;
                                lexema = "";
                                estado = 0;
                                i--;
                            }
                            else
                            {
                                token.Add(new Token(id, lexema, 3, 0, "variable", fila, columna));
                                id++;
                                lexema = "";
                                estado = 0;
                                i--;
                            }
                        }
                        break;
                    case 7:
                        if (c == '>')
                        {
                            lexema += c;
                            token.Add(new Token(id, lexema, 4, 0, "asignacion", fila, columna));
                            id++;
                            lexema = "";
                            estado = 0;

                        }
                        else
                        {
                            token.Add(new Token(id, lexema, 6, 0, "guion", fila, columna));
                            id++;
                            lexema = "";
                            estado = 0;
                            i--;
                        }
                        break;
                    case 8:
                        if (c != '\"')
                        {
                            estado = 8;
                            lexema += c;

                        }
                        else
                        {
                            //lexema += c;
                            token.Add(new Token(id, lexema, 8, 0, "cadena", fila, columna));
                            id++;
                            lexema = "";
                            estado = 0;


                        }
                        break;
                    case 9:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 9;

                        }
                        else
                        {
                            token.Add(new Token(id, lexema, 9, 0, "Digito", fila, columna));
                            id++;
                            lexema = "";
                            estado = 0;
                            i--;

                        }
                        break;
                }
            }
        }

        public void obtenerExpresiones() {
            int x = 1;
            int y = 1;
            int z = 1;


            for (int i = 0; i < token.Count; i++)
            {

                //definicion
                if (token[i].Tipo == 7 && token[i + 1].Tipo == 10)
                {
                    conj.Add(new Conjunto(x, token[i + 2].Lexema));
                    x++;
                    i = i + 3;
                    c = true;
                    e = false; v = false;
                }

                if ((token[i].Tipo == 3 || token[i].Tipo == 11 || token[i].Tipo == 9 || token[i].Tipo == 12) && c == true)
                {
                    conj[conj.Count - 1].Con.Add(token[i].Lexema);
                }
                ////expresion
                if (token[i].Tipo == 3 && token[i + 1].Tipo == 4)
                {
                    
                    exp.Add(new Expresion(y, token[i].Lexema));
                    y++;
                    i = i + 1;
                    c = false; e = true; v = false;
                   
                }
                if ((token[i].Tipo == 3 || token[i].Tipo == 5 || token[i].Tipo == 8) && e == true)
                {
                    exp[exp.Count - 1].Token.Add(token[i]);
                }

                // definicion cadena
                if (token[i].Tipo == 3 && token[i+1].Tipo == 10)
                {
                   
                    validacion.Add(new validaciones(z, token[i].Lexema, token[i + 2].Lexema));
                    z++;
                    i = i + 1;
                    c = false; v = true; e = false;

                }

            }
        }


        public void mostrar() {
                Console.WriteLine("-----------------------------------------CONJUNTOS--------------------------------");

                foreach (var item in conj)
                {
                    Console.WriteLine(item.Id + "  name: " + item.Nombre);
                    item.mostrarTokens();
                }
                Console.WriteLine("-----------------------------------------EXPRECIONES--------------------------------");
                foreach (var item in exp)
                {
                    Console.WriteLine(item.Name);
                    item.mostrarTokens();
                }
                Console.WriteLine("-----------------------------------------VALIDACIONES--------------------------------");
                foreach (var item in validacion)
                {
                    Console.WriteLine(item.Id + " nombre: " + item.Nombre +" Cadena:"+item.Cadena);
                }
            }


        public void EscribirArchivo(string titulo, string mensaje) {

            TextWriter archivo;
            archivo = new StreamWriter(titulo+".xml");
            archivo.WriteLine(mensaje);
            archivo.Close();
            
        }

        public string ArchivoToken() {
            string Archivo = "<ListaTokens>\n";
            foreach (var item in token)
            {
                Archivo += "\t<Token> \n\t\t";
                Archivo += "\t<Nombre>" + item.Lexema+ "</Nombre>\n\t\t";
                Archivo += "\t<Valor>" + item.Name + "</Valor>\n\t\t";
                Archivo += "\t<Fila>" + item.Fila + "</Fila>\n\t\t";
                Archivo += "\t<Columna>" + item.Columna + "</Columna>\n";
                Archivo += "\t</Token>\n";

            }


            Archivo += "\n</ListaTokens>";

            return Archivo;

        }

        public string ArchivoError()
        {
            string Archivo = "<ListaError> \n";
            foreach (var item in ErrorT)
            {
                Archivo += "\t<Error> \n\t\t";
                Archivo += "\t<Nombre>" + item.Erro + "</Nombre>\n\t\t";
                Archivo += "\t<Valor>" + item.Tipo + "</Valor>\n\t\t";
                Archivo += "\t<Fila>" + item.Fila + "</Fila>\n\t\t";
                Archivo += "\t<Columna>" + item.Columna + "</Columna>\n";
                Archivo += "\t</Error>\n";

            }


            Archivo += "\n </ListaError>";

            return Archivo;

        }

    }
    
}
