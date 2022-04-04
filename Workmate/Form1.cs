using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Workmate
{
    public partial class Form1 : Form
    {
        private int borderSize = 2;
        private bool magazzino = false;
        bool mostra_avviso = true;
        public Form1()
        {
            InitializeComponent();
            Checkdirs();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(29, 133, 181);
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
        }
        private void closeform(object sender, FormClosingEventArgs e)
        {
            if (magazzino == true)
            {
                carica_codici();
            }
            else
            {
                carica_ordini();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bars_btn_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.dock_pnl.Width > 200)
            {
                dock_pnl.Width = 100;
                bars_btn.Dock = DockStyle.Top;
                pictureBox1.Visible = false;
                foreach (Button menuButton in dock_pnl.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                dock_pnl.Width = 230;
                bars_btn.Dock = DockStyle.None;
                pictureBox1.Visible = true;
                foreach (Button menuButton in dock_pnl.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void Checkdirs()
        {
            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Workmate";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(root + @"\Magazzino"))
            {
                Directory.CreateDirectory(root + @"\Magazzino");
            }
            if (!Directory.Exists(root + @"\Ordini"))
            {
                Directory.CreateDirectory(root + @"\Ordini");
            }
        }

        private void carica_codici()
        {
            magazzino_data.Rows.Clear();
            string[] codici = var.carica_codici();
            for (int i = 0; i < codici.Length; i++)
            {
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.Load(codici[i]);
                XmlNode codice = xml_doc.DocumentElement.SelectSingleNode("/codice/cod");
                XmlNode prezzo = xml_doc.DocumentElement.SelectSingleNode("/codice/prezzo");
                XmlNode quantita = xml_doc.DocumentElement.SelectSingleNode("/codice/quantità");
                XmlNode quantitamin = xml_doc.DocumentElement.SelectSingleNode("/codice/quantitàmin");
                XmlNode descrizione = xml_doc.DocumentElement.SelectSingleNode("/codice/descrizione");
                string[] riga = { codice.InnerText, prezzo.InnerText, quantita.InnerText, quantitamin.InnerText,descrizione.InnerText };
                magazzino_data.Rows.Add(riga);
                if(Int32.Parse(quantita.InnerText) < Int32.Parse(quantitamin.InnerText) && mostra_avviso == true)
                {
                    CustomDialog customdialog = new CustomDialog();
                    customdialog.label1.Text = codice.InnerText + " è sceso sotto la soglia minima";
                    customdialog.ShowDialog();
                    if (customdialog.DialogResult.Equals(DialogResult.Yes))
                    {
                        mostra_avviso = false;
                    }
                }
            }
        }

        private void carica_ordini()
        {
            ordini_data.Rows.Clear();
            string[] ordini = var.carica_ordini();
            for (int i = 0; i < ordini.Length; i++)
            {
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.Load(ordini[i]);
                XmlNode ordine = xml_doc.DocumentElement.SelectSingleNode("/ordine/ordine");
                XmlNode prezzo = xml_doc.DocumentElement.SelectSingleNode("/ordine/prezzo");
                XmlNode cliente = xml_doc.DocumentElement.SelectSingleNode("/ordine/cliente");
                XmlNode note = xml_doc.DocumentElement.SelectSingleNode("/ordine/note");
                string[] riga = { ordine.InnerText, prezzo.InnerText, cliente.InnerText, note.InnerText };
                ordini_data.Rows.Add(riga);
            }
        }
        private void magazzino_btn_Click(object sender, EventArgs e)
        {
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            ordini_data.Visible = false;
            magazzino_data.Visible = true;
            magazzino = true;
            carica_codici();
        }

        private void ordini_btn_Click(object sender, EventArgs e)
        {
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            ordini_data.Visible = true;
            magazzino_data.Visible = false;
            magazzino = false;
            carica_ordini();
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
        }
        private void impostazioni_btn_Click(object sender, EventArgs e)
        {
            desktop_pnl.Visible = false;
            bar_pnl.Visible = false;
            settings_pnl.Visible = true;
        }

        private void plus_btn_Click_1(object sender, EventArgs e)
        {
            if (magazzino == true)
            {
                Aggiungi_Codice Nuovo_Codice = new Aggiungi_Codice();
                Nuovo_Codice.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Codice.ShowDialog();
            }
            else
            {
                Aggiungi_Ordine Nuovo_Ordine = new Aggiungi_Ordine();
                Nuovo_Ordine.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Ordine.ShowDialog();
            }
        }

        private void edit_btn_Click_1(object sender, EventArgs e)
        {
            if (magazzino == true)
            {
                Aggiungi_Codice Nuovo_Codice = new Aggiungi_Codice();
                Nuovo_Codice.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Codice.varCod = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                Nuovo_Codice.varPrz = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                Nuovo_Codice.varQt = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                Nuovo_Codice.varQtmin = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                Nuovo_Codice.varDes = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[4].Value.ToString();
                Nuovo_Codice.Modifica = 1;

                Nuovo_Codice.ShowDialog();
            }
            else
            {
                Aggiungi_Ordine Nuovo_Ordine = new Aggiungi_Ordine();
                Nuovo_Ordine.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Ordine.varOrdine = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                Nuovo_Ordine.varPrz = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                Nuovo_Ordine.varCliente = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                Nuovo_Ordine.varNote = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                Nuovo_Ordine.Modifica = 1;

                Nuovo_Ordine.ShowDialog();
            }
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            if (magazzino == true)
            {
                string codice = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                DialogResult Scelta = MessageBox.Show("Sei sicuro di voler eliminare " + codice, "Eliminazione codice", MessageBoxButtons.YesNo);
                if (Scelta == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(var.db + @"Magazzino\" + codice + ".xml");
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Impossibile eliminare il codice");
                    }
                    carica_codici();
                }
            }
            else
            {
                string ordine = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                DialogResult Scelta = MessageBox.Show("Sei sicuro di voler eliminare " + ordine, "Eliminazione ordine", MessageBoxButtons.YesNo);
                if (Scelta == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(var.db + @"Ordini\" + ordine + ".xml");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Impossibile eliminare l'ordine");
                    }
                        carica_ordini();
                }
            }
        }
    }
}