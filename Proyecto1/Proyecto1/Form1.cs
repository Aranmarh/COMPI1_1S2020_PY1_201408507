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
        ArrayList token = new ArrayList();
        int pestaña = 0;
        string root = "";
        int id = 0;
        Token t1 = new Token(1, "hola", 2, "name");
        

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
                AbrirLectura(Open.SafeFileName,leer(root));
            }
        }

        private String leer(string url) {
            string texto;
            TextReader leer = new StreamReader(url);
            texto = leer.ReadToEnd();
            return texto;
        }

        private void AbrirLectura(string nombre,string texto) {

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
            string guardar= rtb.Text;
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

        }


        public void Analizar(string entrada) {
            int estado = 0;
            string lexema = "";
            char c;
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                Console.WriteLine(c);

                switch (estado)
                {
                    case 0:
                        if (c == '<')
                        {
                            estado = 1;
                            lexema += c;

                        }
                        else if (c == '/')
                        {
                            estado = 4;
                            lexema += c;
                        }
                        else if (Char.IsLetter(c))
                        { //identificador
                            estado = 6;
                            lexema += c;
                        }else if (c == '-')
                        { //asignacion
                            estado = 7;
                            lexema += c;

                        }
                        else if (c == '\"')
                        { //cadena
                            estado = 8;
                            lexema += c;
                            //  System.out.println("ingreso a 8");
                        }
                        else if (Char.IsDigit(c))
                        {//digito
                            estado = 9;
                            lexema += c;
                            // System.out.println("ingreso a 9");

                        }
                        else if (c == '.')
                        {//concatenacion
                            lexema += c;
                            token.Add(new Token(id, lexema, 1, "concatenacion"));
                            id++;
                            lexema = "";
                            //  System.out.println("aceptacion 0");
                        }
                        else if (c == '|')
                        {//disyuncion
                            lexema += c;
                            token.Add(new Token(id, lexema, 1, "disyuncion"));
                            id++;
                            lexema = "";
                            //  System.out.println("aceptacion 0");
                        }
                        else if (c == '?')
                        { //cerradura
                            lexema += c;
                            token.Add(new Token(id, lexema, 2, "cerradura"));
                            id++;
                            lexema = "";
                            //  System.out.println("aceptacion 0");
                        }
                        else if (c == '*')
                        { // 0 o mas
                            lexema += c;
                            token.Add(new Token(id, lexema, 2, "0 o mas"));
                            id++;
                            lexema = "";
                            // System.out.println("aceptacion 0");
                        }
                        else if (c == '+')
                        { //1 o mas
                            lexema += c;
                            token.Add(new Token(id, lexema, 2, "1 o mas"));
                            id++;
                            lexema = "";
                            // System.out.println("aceptacion 0");
                        }
                        else if (c == ';')
                        {//punto coma
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "PC"));
                            id++;
                            lexema = "";
                            // System.out.println("aceptacion 0");
                        }
                        else if (c == ',')
                        {// coma
                            lexema += c;
                            token.Add(new Token(id, lexema,  0, "C"));
                            id++;
                            lexema = "";
                            //System.out.println("aceptacion 0");
                        }
                        else if (c == '{')
                        { //llA
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "LLA"));
                            id++;
                            lexema = "";
                            // System.out.println("aceptacion 0");
                        }
                        else if (c == '}')
                        { //llC
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "LLC"));
                            id++;
                            lexema = "";
                            // System.out.println("aceptacion 0");
                        }
                        else if (c == '%')
                        {//porcentaje
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "P"));
                            id++;
                            lexema = "";
                            //System.out.println("aceptacion 0");
                        }
                        else if (c == '~')
                        {//porcentaje
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "range"));
                            id++;
                            lexema = "";
                            // System.out.println("aceptacion 0");
                        }
                        else if (c == ':')
                        {//dos puntos
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "dos Puntos"));
                            id++;
                            lexema = "";
                            //System.out.println("aceptacion 0");
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')
                        {
                            estado = 0;
                            //  System.out.println("salto o espacio");

                        }
                        else
                        {

                            estado = 0;
                            lexema = "";
                            // System.out.println("error");
                        }

                        break;
                    case 1:
                        if (c == '!')
                        {
                            estado = 2;
                            lexema += c;

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
                            if (c != '\n' || c != ' ' || c != '\t')
                            {
                                lexema += c;
                            }

                        }
                        else
                        {
                            estado = 3;
                            lexema += c;
                        }
                        break;
                    case 3:
                        if (c == '>')
                        {
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "comentario multiple"));
                            id++;
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 4:
                        if (c == '/')
                        {
                            estado = 5;
                            lexema += c;
                            //System.out.println("entro a 5");


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
                            token.Add(new Token(id, lexema, 0, "Comentario S"));
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
                                token.Add(new Token(id, lexema, 0, "conjunto"));
                                id++;
                                lexema = "";
                                estado = 0;
                                i--;
                            }
                            else
                            {
                                token.Add(new Token(id, lexema, 0, "variable"));
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
                            token.Add(new Token(id, lexema, 0, "asignacion"));
                            id++;
                            lexema = "";
                            estado = 0;

                        }
                        else
                        {
                            token.Add(new Token(id, lexema, 0, "guion"));
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
                            lexema += c;
                            token.Add(new Token(id, lexema, 0, "cadena"));
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
                            token.Add(new Token(id, lexema, 0, "Digito"));
                            id++;
                            lexema = "";
                            estado = 0;
                            i--;

                        }
                        break;
                }
            }
        }
    }
}

