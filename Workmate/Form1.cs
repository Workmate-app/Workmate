using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Workmate
{
    public partial class Form1 : Form
    {
        private int borderSize = 2;
        private bool magazzino = false;
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
                XmlNode descrizione = xml_doc.DocumentElement.SelectSingleNode("/codice/descrizione");
                string[] riga = { codice.InnerText, prezzo.InnerText, quantita.InnerText, descrizione.InnerText };
                magazzino_data.Rows.Add(riga);
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

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void edit_btn_Click_1(object sender, EventArgs e)
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
    }
}