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
        int pestaña = 0;
        string root = "";

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
    }
}

