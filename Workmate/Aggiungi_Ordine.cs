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
                new XElement("note", note_txt.Text),
                new XElement("prod1", prod1_txt.Text),
                new XElement("prod2", prod2_txt.Text),
                new XElement("prod3", prod3_txt.Text),
                new XElement("prod4", prod4_txt.Text),
                new XElement("prod5", prod5_txt.Text),
                new XElement("prod6", prod6_txt.Text),
                new XElement("prod7", prod7_txt.Text),
                new XElement("prod8", prod8_txt.Text),
                new XElement("prod9", prod9_txt.Text),
                new XElement("prod10", prod10_txt.Text),
                new XElement("qt1", qt1_txt.Text),
                new XElement("qt2", qt2_txt.Text),
                new XElement("qt3", qt3_txt.Text),
                new XElement("qt4", qt4_txt.Text),
                new XElement("qt5", qt5_txt.Text),
                new XElement("qt6", qt6_txt.Text),
                new XElement("qt7", qt7_txt.Text),
                new XElement("qt8", qt8_txt.Text),
                new XElement("qt9", qt9_txt.Text),
                new XElement("qt10", qt10_txt.Text)
                ));

            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Ordini\\";
            if (File.Exists(root + ord_txt.Text + ".xml") && Modifica != 1)
            {
                MessageBox.Show("Ordine già esistente");
                return;
            }
            else
            {
                if (Modifica != 1)
                {
                    foreach (TextBox textbox in prod_pnl.Controls.OfType<TextBox>()) {
                        if (textbox.Text.Length != 0)
                        {
                            try
                            {
                                XmlDocument xml_doc = new XmlDocument();
                                xml_doc.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Prodotti\\" + textbox.Text + ".xml");
                                //XmlNode qt = xml_doc.DocumentElement.SelectSingleNode("/codice/quantità");
                            }
                            catch
                            {
                                MessageBox.Show("Prodotto " + textbox.Text + " non trovato!");
                                return;
                            }
                        }
                    }
                }

                doc_xml.Save(root + ord_txt.Text + ".xml");
                if (Modifica == 1 && OldOrd != ord_txt.Text)
                    File.Delete(root + OldOrd + ".xml");
                this.DialogResult = DialogResult.Yes;
                var.ended = true;
                this.Close();
                }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Aggiungi_Ordine_Load_1(object sender, EventArgs e)
        {
            add_prod_pnl.Visible = false;
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

        private void add_prod_btn_Click(object sender, EventArgs e)
        {
            add_prod_pnl.Visible = true;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            add_prod_pnl.Visible = false;
        }
    }
}
