using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Workmate
{
    public partial class Aggiungi_Codice : Form
    {
        public Aggiungi_Codice()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            #region Controlli
            if (cod_txt.Text.Length == 0)
            {
                MessageBox.Show("Codice non può essere vuoto");
                return;
            }
            if (prz_txt.Text.Length == 0)
            {
                MessageBox.Show("Prezzo non può essere vuoto");
                return;
            }
            if (qt_txt.Text.Length == 0)
            {
                MessageBox.Show("Quantità non può essere vuoto");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(prz_txt.Text, @"^[0-9]+([.][0-9]+)?$") == false)
            {
                MessageBox.Show("Controllare il prezzo (per la , inserire il .)");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(qt_txt.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Controllare la quantità");
                return;
            }
            #endregion

            XDocument doc_xml = new XDocument(new XElement("codice",
                new XElement("cod", cod_txt.Text),
                new XElement("prezzo", prz_txt.Text),
                new XElement("quantità", qt_txt.Text),
                new XElement("quantitàmin", qtmin_txt.Text),
                new XElement("descrizione", desc_txt.Text)
                ));

            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Magazzino\\";
            if (File.Exists(root + cod_txt.Text + ".xml"))
            {
                MessageBox.Show("Codice già esistente");
                return;
            }
            else
            {
                doc_xml.Save(root + cod_txt.Text + ".xml");
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
