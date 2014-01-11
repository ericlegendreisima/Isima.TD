using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Isima.TD.Notepad
{
    public partial class MainForm : Form
    {
        string filePath = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog(this))
            {
                filePath = openFileDialog1.FileName;

                string contenu = "Contenu à charger...";
                // Lire le fichier ici

                textBox1.Text = contenu;
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string contenu = textBox1.Text;

            // Enregistrer le fichier ici
        }
    }
}
