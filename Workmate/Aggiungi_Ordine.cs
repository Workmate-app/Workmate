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
            this.DialogResult = DialogResult.No;
            InitializeComponent();
        }

        string OldOrd = "";
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
           /* foreach (TextBox textbox in qt_pnl.Controls.OfType<TextBox>())
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textbox.Text, @"^[0-9]+$") == false && textbox.Text.Length != 0)
                {
                    MessageBox.Show("Controllare la quantità dei codici");
                    return;
                }
            }*/
            #endregion

            XDocument doc_xml = new XDocument(new XElement("ordine",
                new XElement("ordine", ord_txt.Text),
                new XElement("prezzo", prz_txt.Text),
                new XElement("cliente", cliente_txt.Text),
                new XElement("note", note_txt.Text)
                ));

            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Ordini\\";
            if (File.Exists(root + ord_txt.Text + ".xml") && Modifica != 1)
            {
                MessageBox.Show("Ordine già esistente");
                return;
            }
            else
            {
                doc_xml.Save(root + ord_txt.Text + ".xml");
                if (Modifica == 1 && OldOrd != ord_txt.Text)
                    File.Delete(root + OldOrd + ".xml");
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Aggiungi_Ordine_Load_1(object sender, EventArgs e)
        {
            //Codici.Visible = false;
            if (Modifica == 1)
            {
                this.Text = "Modifica ordine";
                OldOrd = varOrdine;
            }
            ord_txt.Text = varOrdine;
            prz_txt.Text = varPrz;
            cliente_txt.Text = varCliente;
            note_txt.Text = varNote;
        }

        public string varOrdine { get; set; }
        public string varPrz { get; set; }
        public string varCliente { get; set; }
        public string varNote { get; set; }
        public int Modifica { get; set; }
    }
}
