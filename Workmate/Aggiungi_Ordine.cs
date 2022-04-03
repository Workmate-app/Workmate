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
    public partial class Aggiungi_Ordine : Form
    {
        public Aggiungi_Ordine()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            #region Controlli
            if (ord_txt.Text.Length == 0)
            {
                MessageBox.Show("Ordine non può essere vuoto");
                return;
            }
            if (prz_txt.Text.Length == 0)
            {
                MessageBox.Show("Prezzo non può essere vuoto");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(prz_txt.Text, @"^[0-9]+([.][0-9]+)?$") == false)
            {
                MessageBox.Show("Controllare il prezzo (per la , inserire il .)");
                return;
            }
            #endregion

            XDocument doc_xml = new XDocument(new XElement("ordine",
                new XElement("ordine", ord_txt.Text),
                new XElement("prezzo", prz_txt.Text),
                new XElement("cliente", cliente_txt.Text),
                new XElement("note", note_txt.Text)
                ));

            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Ordini\\";
            if (File.Exists(root + ord_txt.Text + ".xml"))
            {
                MessageBox.Show("Ordine già esistente");
                return;
            }
            else
            {
                doc_xml.Save(root + ord_txt.Text + ".xml");
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
