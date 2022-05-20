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
        int[] exqt = {0,0,0,0,0,0,0,0,0,0 };

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
           foreach (TextBox textbox in qt_pnl.Controls.OfType<TextBox>())
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textbox.Text, @"^[0-9]+$") == false && textbox.Text.Length != 0)
                {
                    MessageBox.Show("Controllare la quantità dei codici");
                    return;
                }
           }
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
                int[] arr = new int[10];
                int j=0;
                foreach (TextBox textbox in qt_pnl.Controls.OfType<TextBox>())
                {
                    if (textbox.Text.Length != 0)
                    {
                        arr[j] = Convert.ToInt32(textbox.Text);
                        j++;
                    }                   
                }
                int x = 0;

                foreach (TextBox textbox in prod_pnl.Controls.OfType<TextBox>()) {
                    if (textbox.Text.Length != 0)
                    {
                        try
                        {
                            XmlDocument xml_doc = new XmlDocument();
                            xml_doc.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Prodotti\\" + textbox.Text + ".xml");
                            for (int i = 0; i < 15; i++)
                            {
                                XmlNode cod = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod" + (i + 1));
                                if (cod.InnerText != "")
                                {
                                    XmlNode qt = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt" + (i + 1));
                                    XmlDocument xml_doc_cod = new XmlDocument();
                                    xml_doc_cod.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Magazzino\\" + cod.InnerText + ".xml");
                                    XmlNode qt_cod = xml_doc_cod.DocumentElement.SelectSingleNode("/codice/quantità");
                                    int tmp = Convert.ToInt32(qt_cod.InnerText) + (Convert.ToInt32(qt.InnerText) * exqt[x]) - (Convert.ToInt32(qt.InnerText) * arr[x]);
                                    MessageBox.Show(exqt[x].ToString() + "  " + arr[x].ToString());
                                    if (tmp < 0)
                                    {
                                        DialogResult dialogresult = MessageBox.Show("La quantità del codice " + cod.InnerText + " sarà inferiore a 0. Continuare?", "Attenzione", MessageBoxButtons.YesNo);
                                        if (dialogresult == DialogResult.Yes)
                                        {
                                            qt_cod.InnerText = tmp.ToString();
                                            xml_doc_cod.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Magazzino\\" + cod.InnerText + ".xml");
                                        }
                                        else
                                            return;
                                    }
                                    else
                                    {
                                        qt_cod.InnerText = tmp.ToString();
                                        xml_doc_cod.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Magazzino\\" + cod.InnerText + ".xml");
                                    }
                                }
                            }
                            x++;
                        }
                        catch
                        {
                            MessageBox.Show("Prodotto " + textbox.Text + " non trovato!");
                            return;
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
                ord_txt.Text = varOrdine;
                prz_txt.Text = varPrz;
                cliente_txt.Text = varCliente;
                note_txt.Text = varNote;
                prod1_txt.Text = varProdotto1;
                prod2_txt.Text = varProdotto2;
                prod3_txt.Text = varProdotto3;
                prod4_txt.Text = varProdotto4;
                prod5_txt.Text = varProdotto5;
                prod6_txt.Text = varProdotto6;
                prod7_txt.Text = varProdotto7;
                prod8_txt.Text = varProdotto8;
                prod9_txt.Text = varProdotto9;
                prod10_txt.Text = varProdotto10;
                qt1_txt.Text = varQt1.ToString();
                qt2_txt.Text = varQt2.ToString();
                qt3_txt.Text = varQt3.ToString();
                qt4_txt.Text = varQt4.ToString();
                qt5_txt.Text = varQt5.ToString();
                qt6_txt.Text = varQt6.ToString();
                qt7_txt.Text = varQt7.ToString();
                qt8_txt.Text = varQt8.ToString();
                qt9_txt.Text = varQt9.ToString();
                qt10_txt.Text = varQt10.ToString();
                int a = 0;
                foreach (TextBox textbox in qt_pnl.Controls.OfType<TextBox>())
                {
                    if (textbox.Text.Length != 0)
                    {
                        exqt[a] = Convert.ToInt32(textbox.Text);
                        //MessageBox.Show(exqt[a].ToString());
                        a++;
                    }
                }
            }
            selectcli_dlg.InitialDirectory = var.db + @"Clienti\";
        }

        public string varOrdine { get; set; }
        public string varPrz { get; set; }
        public string varCliente { get; set; }
        public string varNote { get; set; }
        public int Modifica { get; set; }
        public string varProdotto1 { get; set; }
        public string varProdotto2 { get; set; }
        public string varProdotto3 { get; set; }
        public string varProdotto4 { get; set; }
        public string varProdotto5 { get; set; }
        public string varProdotto6 { get; set; }
        public string varProdotto7 { get; set; }
        public string varProdotto8 { get; set; }
        public string varProdotto9 { get; set; }
        public string varProdotto10 { get; set; }
        public int varQt1 { get; set; }
        public int varQt2 { get; set; }
        public int varQt3 { get; set; }
        public int varQt4 { get; set; }
        public int varQt5 { get; set; }
        public int varQt6 { get; set; }
        public int varQt7 { get; set; }
        public int varQt8 { get; set; }
        public int varQt9 { get; set; }
        public int varQt10 { get; set; }


        private void add_prod_btn_Click(object sender, EventArgs e)
        {
            add_prod_pnl.Visible = true;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            add_prod_pnl.Visible = false;
        }

        private void selectcli_btn_Click(object sender, EventArgs e)
        {
            if(selectcli_dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(selectcli_dlg.FileName != null)
                    {
                        cliente_txt.Text = Path.ChangeExtension(Path.GetFileName(selectcli_dlg.FileName), null).ToString();
                    }
                }
                catch
                {

                }
            }
        }
    }
}
