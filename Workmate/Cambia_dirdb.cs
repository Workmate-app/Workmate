using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workmate
{
    public partial class Cambia_dirdb : Form
    {
        public Cambia_dirdb()
        {
            InitializeComponent();
        }

        private void Cambia_dirdb_Load(object sender, EventArgs e)
        {
            if(dir_txt.Text == "")
            {
                dir_txt.Text = var.db.Remove(var.db.Length - 10, 10);
            }
            sfogliaCartelle_dlg.SelectedPath = var.db.Remove(var.db.Length - 10, 10);
        }

        private void no_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.percorso_db = dir_txt.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void sfoglia_btn_Click(object sender, EventArgs e)
        {
            sfogliaCartelle_dlg.ShowDialog();
            dir_txt.Text = sfogliaCartelle_dlg.SelectedPath;
        }
    }
}
