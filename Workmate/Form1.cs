using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

namespace Workmate
{
    public partial class Form1 : Form
    {
        private int borderSize = 2;
        private bool magazzino = false;
        private bool prod = false;
        private bool clienti=false;
        bool mostra_avviso = true;
        bool avv_mostrati = false;
        public float totalefatturato;
        bool ordinicaricati = false;
        bool prodotticaricati = false;
        bool codicicaricati = false;
        bool clienticaricati = false;
        public Form1()
        {
            InitializeComponent();
            Checkdirs();
            carica_foto_home();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(29, 133, 181);
            carica_ordini();
            carica_clienti();
            ordinicaricati = true;
            clienticaricati=true;
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
            settings_pnl.Visible = false;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            desktop_pnl.Visible = true;
        }
        private void closeform(object sender, FormClosingEventArgs e)
        {
            if (magazzino == true && var.ended == true)
            {
                carica_codici();
                var.ended = false;
                codicicaricati = true;
            }
            else if (prod == true && var.ended == true)
            {
                carica_prodotti();
                var.ended = false;
                prodotticaricati = true;
            }
            else if(clienti==true && var.ended == true)
            {
                carica_clienti();
                var.ended = false;
                clienticaricati = true;
            }
            else if (var.ended == true)
            {
                carica_ordini();
                var.ended = false;
                ordinicaricati = true;
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
                Directory.CreateDirectory(root + @"\Magazzino\Foto");
            }
            if (!Directory.Exists(root + @"\Ordini"))
            {
                Directory.CreateDirectory(root + @"\Ordini");
                //Directory.CreateDirectory(root + @"\Ordini\Foto");
            }
            if (!Directory.Exists(root + @"\Prodotti"))
            {
                Directory.CreateDirectory(root + @"\Prodotti");
                Directory.CreateDirectory(root + @"\Prodotti\Foto");
            }
            if (!Directory.Exists(root + @"\Clienti"))
            {
                Directory.CreateDirectory(root + @"\Clienti");
            }
            if (!File.Exists(root + @"\workmate.xml"))
            {
                XDocument doc_xml = new XDocument(new XElement("workmate",
                    new XElement("bollaid", 1)
                    ));
                doc_xml.Save(root + @"\workmate.xml");
            }
        }

        private void carica_foto_home()
        {
            if (File.Exists(var.db + @"home.png"))
            {
                Image image = Image.FromFile(var.db + @"home.png");
                logo_pic.BackgroundImage = image;
                logo_pic.Tag = var.db + @"home.png";
            }
            else if (File.Exists(var.db + @"home.jpg"))
            {
                Image image = Image.FromFile(var.db + @"home.jpg");
                logo_pic.BackgroundImage = image;
                logo_pic.Tag = var.db + @"home.jpg";
            }
            else if (Directory.Exists(var.db + @"home.jpeg"))
            {
                Image image = Image.FromFile(var.db + @"home.jpeg");
                logo_pic.BackgroundImage = image;
                logo_pic.Tag = var.db + @"home.jpeg";
            }
        }

        private void carica_codici(string testoc = "", string colonnac = "", int search = 0)
        {
            MessageBox.Show("Caricamento codici in corso...");
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
                XmlNode foto = xml_doc.DocumentElement.SelectSingleNode("/codice/foto");
                string[] riga = { codice.InnerText, prezzo.InnerText, quantita.InnerText, quantitamin.InnerText, descrizione.InnerText, foto.InnerText };
                string contenuto = "";
                switch (colonnac)
                {
                    case "Codice":
                        contenuto = codice.InnerText;
                        break;
                    case "Prezzo":
                        contenuto = prezzo.InnerText;
                        break;
                    case "Quantità":
                        contenuto = quantita.InnerText;
                        break;
                    case "Descrizione":
                        contenuto = descrizione.InnerText;
                        break;
                    default:
                        contenuto = "";
                        break;
                }
                contenuto = contenuto.ToLower();
                testoc = testoc.ToLower();
                if (contenuto.Contains(testoc))
                    magazzino_data.Rows.Add(riga);

                if (Int32.Parse(quantita.InnerText) < Int32.Parse(quantitamin.InnerText) && mostra_avviso == true && search == 0 && avv_mostrati == false)
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

        private void carica_ordini(string testoc = "", string colonnac = "")
        {
            MessageBox.Show("Caricamento ordini in corso...");
            if (testoc == "")
                totalefatturato = 0;
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
                XmlNode prodotto1 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod1");
                XmlNode prodotto2 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod2");
                XmlNode prodotto3 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod3");
                XmlNode prodotto4 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod4");
                XmlNode prodotto5 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod5");
                XmlNode prodotto6 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod6");
                XmlNode prodotto7 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod7");
                XmlNode prodotto8 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod8");
                XmlNode prodotto9 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod9");
                XmlNode prodotto10 = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod10");
                XmlNode qt1 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt1");
                XmlNode qt2 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt2");
                XmlNode qt3 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt3");
                XmlNode qt4 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt4");
                XmlNode qt5 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt5");
                XmlNode qt6 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt6");
                XmlNode qt7 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt7");
                XmlNode qt8 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt8");
                XmlNode qt9 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt9");
                XmlNode qt10 = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt10");
                string[] riga = { ordine.InnerText, prezzo.InnerText, cliente.InnerText, note.InnerText, prodotto1.InnerText, prodotto2.InnerText, prodotto3.InnerText, prodotto4.InnerText, prodotto5.InnerText, prodotto6.InnerText, prodotto7.InnerText, prodotto8.InnerText, prodotto9.InnerText, prodotto10.InnerText, qt1.InnerText, qt2.InnerText, qt3.InnerText, qt4.InnerText, qt5.InnerText, qt6.InnerText, qt7.InnerText, qt8.InnerText, qt9.InnerText, qt10.InnerText };

                string contenuto = "";
                switch (colonnac)
                {
                    case "Ordine":
                        contenuto = ordine.InnerText;
                        break;
                    case "Prezzo":
                        contenuto = prezzo.InnerText;
                        break;
                    case "Cliente":
                        contenuto = cliente.InnerText;
                        break;
                    case "Note":
                        contenuto = note.InnerText;
                        break;
                    default:
                        contenuto = "";
                        break;
                }
                contenuto = contenuto.ToLower();
                testoc = testoc.ToLower();
                if (contenuto.Contains(testoc))
                    ordini_data.Rows.Add(riga);
                if (testoc == "")
                {
                    totalefatturato += float.Parse(prezzo.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    totfat_lbl.Text = totalefatturato.ToString("0.00") + " €";
                    nordini_lbl.Text = var.cno().ToString();
                }
            }
        }

        private void carica_prodotti(string testoc = "", string colonnac = "")
        {
            MessageBox.Show("Caricamento prodotti in corso...");
            prod_data.Rows.Clear();
            string[] prodotti = var.carica_prodotti();
            for (int i = 0; i < prodotti.Length; i++)
            {
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.Load(prodotti[i]);
                XmlNode prodotto = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/prodotto");
                XmlNode descrizione = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/descrizione");
                XmlNode cod1 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod1");
                XmlNode cod2 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod2");
                XmlNode cod3 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod3");
                XmlNode cod4 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod4");
                XmlNode cod5 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod5");
                XmlNode cod6 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod6");
                XmlNode cod7 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod7");
                XmlNode cod8 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod8");
                XmlNode cod9 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod9");
                XmlNode cod10 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod10");
                XmlNode cod11 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod11");
                XmlNode cod12 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod12");
                XmlNode cod13 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod13");
                XmlNode cod14 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod14");
                XmlNode cod15 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/cod15");
                XmlNode qt1 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt1");
                XmlNode qt2 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt2");
                XmlNode qt3 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt3");
                XmlNode qt4 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt4");
                XmlNode qt5 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt5");
                XmlNode qt6 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt6");
                XmlNode qt7 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt7");
                XmlNode qt8 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt8");
                XmlNode qt9 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt9");
                XmlNode qt10 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt10");
                XmlNode qt11 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt11");
                XmlNode qt12 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt12");
                XmlNode qt13 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt13");
                XmlNode qt14 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt14");
                XmlNode qt15 = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/qt15");
                XmlNode foto = xml_doc.DocumentElement.SelectSingleNode("/Prodotto/foto");

                string[] riga = { prodotto.InnerText, descrizione.InnerText , cod1.InnerText, cod2.InnerText, cod3.InnerText, cod4.InnerText, cod5.InnerText, cod6.InnerText, cod7.InnerText, cod8.InnerText, cod9.InnerText, cod10.InnerText, cod11.InnerText, cod12.InnerText, cod13.InnerText, cod14.InnerText, cod15.InnerText, qt1.InnerText, qt2.InnerText, qt3.InnerText, qt4.InnerText, qt5.InnerText, qt6.InnerText, qt7.InnerText, qt8.InnerText, qt9.InnerText, qt10.InnerText, qt11.InnerText, qt12.InnerText, qt13.InnerText, qt14.InnerText, qt15.InnerText, foto.InnerText };
                string contenuto = "";
                switch (colonnac)
                {
                    case "Prodotto":
                        contenuto = prodotto.InnerText;
                        break;
                    default:
                        contenuto = "";
                        break;
                }
                contenuto = contenuto.ToLower();
                testoc = testoc.ToLower();
                if (contenuto.Contains(testoc))
                   prod_data.Rows.Add(riga);
            }
        }

        private void carica_clienti(string testoc = "", string colonnac = "")
        {
            MessageBox.Show("Caricamento clienti in corso...");
            clienti_data.Rows.Clear();
            string[] codici = var.carica_clienti();
            for (int i = 0; i < codici.Length; i++)
            {
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.Load(codici[i]);
                XmlNode cliente = xml_doc.DocumentElement.SelectSingleNode("/cliente/cliente");
                XmlNode piva = xml_doc.DocumentElement.SelectSingleNode("/cliente/piva");
                XmlNode cf = xml_doc.DocumentElement.SelectSingleNode("/cliente/codice_fiscale");
                XmlNode indirizzo = xml_doc.DocumentElement.SelectSingleNode("/cliente/indirizzo");
                XmlNode cap = xml_doc.DocumentElement.SelectSingleNode("/cliente/cap");
                XmlNode paese = xml_doc.DocumentElement.SelectSingleNode("/cliente/paese");
                XmlNode prov = xml_doc.DocumentElement.SelectSingleNode("/cliente/prov");
                XmlNode note = xml_doc.DocumentElement.SelectSingleNode("/cliente/note");
                string[] riga = { cliente.InnerText, piva.InnerText, cf.InnerText, indirizzo.InnerText,cap.InnerText,paese.InnerText,prov.InnerText, note.InnerText };
                string contenuto = "";
                switch (colonnac)
                {
                    case "Codice":
                        contenuto = cliente.InnerText;
                        break;
                    case "Piva":
                        contenuto = piva.InnerText;
                        break;
                    case "CF":
                        contenuto = cf.InnerText;
                        break;
                    default:
                        contenuto = "";
                        break;
                }
                contenuto = contenuto.ToLower();
                testoc = testoc.ToLower();
                if (contenuto.Contains(testoc))
                    clienti_data.Rows.Add(riga);
            }
        }
        private void magazzino_btn_Click(object sender, EventArgs e)
        {
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            logo_pic.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            bolla_btn.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = true;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            magazzino = true;
            prod = false;
            clienti = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Codice");
            comboBox1.Items.Add("Prezzo");
            comboBox1.Items.Add("Quantità");
            comboBox1.Items.Add("Descrizione");
            comboBox1.SelectedIndex = 0;
            if (codicicaricati == false || mostra_avviso == true)
            {
                carica_codici();
                codicicaricati = true;
            }
            avv_mostrati = true;

        }

        private void ordini_btn_Click(object sender, EventArgs e)
        {
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            logo_pic.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            bolla_btn.Visible = true;
            ordini_data.Visible = true;
            magazzino_data.Visible = false;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            magazzino = false;
            prod = false;
            clienti= false;
            avv_mostrati = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Ordine");
            comboBox1.Items.Add("Prezzo");
            comboBox1.Items.Add("Cliente");
            comboBox1.Items.Add("Note");
            comboBox1.SelectedIndex = 0;
            if (ordinicaricati == false)
            {
                carica_ordini();
                ordinicaricati = true;
            }

        }
        private void prod_btn_Click(object sender, EventArgs e)
        {
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            logo_pic.Visible = false;
            prod_data.Visible = true;
            magazzino_data.Visible = false;
            ordini_data.Visible = false;
            clienti_data.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            bolla_btn.Visible = false;
            magazzino = false;
            prod = true;
            clienti = false;
            avv_mostrati = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Prodotto");
            comboBox1.Items.Add("Descrizione");
            comboBox1.SelectedIndex = 0;
            if (prodotticaricati == false)
            {
                carica_prodotti();
                prodotticaricati = true;
            }
        }
        private void home_btn_Click(object sender, EventArgs e)
        {
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            avv_mostrati = false;
            nordini_pnl.Visible = true;
            totfat_pnl.Visible = true;
            totfat_pic.Visible = true;
            totord_pic.Visible = true;
            logo_pic.Visible = true;
            clienti = false;
            magazzino = false;
            prod=false;
        }
        private void clienti_btn_Click(object sender, EventArgs e)
        {
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            logo_pic.Visible = false;
            bolla_btn.Visible = false;
            clienti_data.Visible = true;
            magazzino_data.Visible = false;
            ordini_data.Visible = false;
            prod_data.Visible = false;
            settings_pnl.Visible = false;
            bar_pnl.Visible = true;
            clienti = true;
            magazzino = false;
            prod = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Cliente");
            comboBox1.Items.Add("Piva");
            comboBox1.Items.Add("CF");
            comboBox1.SelectedIndex = 0;
            if (clienticaricati == false)
            {
                carica_clienti();
                clienticaricati = true;
            }
        }
        private void impostazioni_btn_Click(object sender, EventArgs e)
        {
            desktop_pnl.Visible = false;
            bar_pnl.Visible = false;
            settings_pnl.Visible = true;
            avv_mostrati = false;
        }

        private void plus_btn_Click_1(object sender, EventArgs e)
        {
            if (magazzino == true)
            {
                Aggiungi_Codice Nuovo_Codice = new Aggiungi_Codice();
                Nuovo_Codice.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Codice.ShowDialog();
                if(Nuovo_Codice.DialogResult == DialogResult.Yes)
                    codicicaricati = false;
            }
            else if (prod == true)
            {
                Aggiungi_Prodotto Nuovo_Prodotto = new Aggiungi_Prodotto();
                Nuovo_Prodotto.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Prodotto.ShowDialog();
                if(Nuovo_Prodotto.DialogResult == DialogResult.Yes)
                    prodotticaricati = false;
            }
            else if(clienti == true)
            {
                Aggiungi_Cliente Nuovo_Cliente = new Aggiungi_Cliente();
                Nuovo_Cliente.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Cliente.ShowDialog();
                /*if (Nuovo_Prodotto.DialogResult == DialogResult.Yes)
                    prodotticaricati = false;*/
            }
            else
            {
                Aggiungi_Ordine Nuovo_Ordine = new Aggiungi_Ordine();
                Nuovo_Ordine.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Ordine.ShowDialog();
                if(Nuovo_Ordine.DialogResult == DialogResult.Yes)
                    ordinicaricati = false;
            }
        }

        private void edit_btn_Click_1(object sender, EventArgs e)
        {
            if (magazzino == true)
            {
                if(magazzino_data.SelectedCells.Count > 0)
                {
                    Aggiungi_Codice Nuovo_Codice = new Aggiungi_Codice();
                    Nuovo_Codice.FormClosing += new FormClosingEventHandler(closeform);
                    Nuovo_Codice.varCod = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    Nuovo_Codice.varPrz = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    Nuovo_Codice.varQt = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    Nuovo_Codice.varQtmin = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    Nuovo_Codice.varDes = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    Nuovo_Codice.varFoto = magazzino_data.Rows[magazzino_data.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    Nuovo_Codice.Modifica = 1;
                    Nuovo_Codice.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selezionare prima un codice!");
                }
            }
            else if (prod == true)
            {
                if(prod_data.SelectedCells.Count > 0)
                {
                    Aggiungi_Prodotto Nuovo_Prodotto = new Aggiungi_Prodotto();
                    Nuovo_Prodotto.FormClosing += new FormClosingEventHandler(closeform);
                    Nuovo_Prodotto.varProdotto = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    Nuovo_Prodotto.varDescrizione = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    Nuovo_Prodotto.varCod1 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    Nuovo_Prodotto.varCod2 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    Nuovo_Prodotto.varCod3 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    Nuovo_Prodotto.varCod4 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    Nuovo_Prodotto.varCod5 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    Nuovo_Prodotto.varCod6 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    Nuovo_Prodotto.varCod7 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[8].Value.ToString();
                    Nuovo_Prodotto.varCod8 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[9].Value.ToString();
                    Nuovo_Prodotto.varCod9 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[10].Value.ToString();
                    Nuovo_Prodotto.varCod10 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[11].Value.ToString();
                    Nuovo_Prodotto.varCod11 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[12].Value.ToString();
                    Nuovo_Prodotto.varCod12 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[13].Value.ToString();
                    Nuovo_Prodotto.varCod13 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[14].Value.ToString();
                    Nuovo_Prodotto.varCod14 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[15].Value.ToString();
                    Nuovo_Prodotto.varCod15 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[16].Value.ToString();
                    Nuovo_Prodotto.varQt1 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[17].Value.ToString();
                    Nuovo_Prodotto.varQt2 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[18].Value.ToString();
                    Nuovo_Prodotto.varQt3 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[19].Value.ToString();
                    Nuovo_Prodotto.varQt4 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[20].Value.ToString();
                    Nuovo_Prodotto.varQt5 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[21].Value.ToString();
                    Nuovo_Prodotto.varQt6 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[22].Value.ToString();
                    Nuovo_Prodotto.varQt7 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[23].Value.ToString();
                    Nuovo_Prodotto.varQt8 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[24].Value.ToString();
                    Nuovo_Prodotto.varQt9 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[25].Value.ToString();
                    Nuovo_Prodotto.varQt10 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[26].Value.ToString();
                    Nuovo_Prodotto.varQt11 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[27].Value.ToString();
                    Nuovo_Prodotto.varQt12 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[28].Value.ToString();
                    Nuovo_Prodotto.varQt13 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[29].Value.ToString();
                    Nuovo_Prodotto.varQt14 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[30].Value.ToString();
                    Nuovo_Prodotto.varQt15 = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[31].Value.ToString();
                    Nuovo_Prodotto.varFoto = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[32].Value.ToString();
                    Nuovo_Prodotto.Modifica = 1;

                    Nuovo_Prodotto.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selezionare prima un prodotto!");
                }
            }
            else if (clienti == true)
            {
                if(clienti_data.SelectedCells.Count >0)
                {
                    Aggiungi_Cliente Nuovo_Cliente = new Aggiungi_Cliente();
                    Nuovo_Cliente.FormClosing += new FormClosingEventHandler(closeform);
                    Nuovo_Cliente.varCli = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    Nuovo_Cliente.varPiva = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    Nuovo_Cliente.varCf = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    Nuovo_Cliente.varInd = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    Nuovo_Cliente.varCap = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    Nuovo_Cliente.varPaese = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    Nuovo_Cliente.varProv = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    Nuovo_Cliente.varNote = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    Nuovo_Cliente.Modifica = 1;
                    Nuovo_Cliente.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selezionare prima un cliente!");
                }
            }
            else
            {
                if(ordini_data.SelectedCells.Count > 0)
                {
                    Aggiungi_Ordine Nuovo_Ordine = new Aggiungi_Ordine();
                    Nuovo_Ordine.FormClosing += new FormClosingEventHandler(closeform);
                    Nuovo_Ordine.varOrdine = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    Nuovo_Ordine.varPrz = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    Nuovo_Ordine.varCliente = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    Nuovo_Ordine.varNote = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    Nuovo_Ordine.varProdotto1 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    Nuovo_Ordine.varProdotto2 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    Nuovo_Ordine.varProdotto3 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    Nuovo_Ordine.varProdotto4 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[7].Value.ToString();
                    Nuovo_Ordine.varProdotto5 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[8].Value.ToString();
                    Nuovo_Ordine.varProdotto6 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[9].Value.ToString();
                    Nuovo_Ordine.varProdotto7 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[10].Value.ToString();
                    Nuovo_Ordine.varProdotto8 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[11].Value.ToString();
                    Nuovo_Ordine.varProdotto9 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[12].Value.ToString();
                    Nuovo_Ordine.varProdotto10 = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[13].Value.ToString();
                    try
                    {
                        Nuovo_Ordine.varQt1 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[14].Value);
                        Nuovo_Ordine.varQt2 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[15].Value);
                        Nuovo_Ordine.varQt3 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[16].Value);
                        Nuovo_Ordine.varQt4 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[17].Value);
                        Nuovo_Ordine.varQt5 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[18].Value);
                        Nuovo_Ordine.varQt6 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[19].Value);
                        Nuovo_Ordine.varQt7 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[20].Value);
                        Nuovo_Ordine.varQt8 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[21].Value);
                        Nuovo_Ordine.varQt9 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[22].Value);
                        Nuovo_Ordine.varQt10 = Convert.ToInt32(ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[23].Value);

                    }
                    catch
                    {

                    }
                    Nuovo_Ordine.Modifica = 1;

                    Nuovo_Ordine.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selezionare prima un ordine!");
                }
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
                        if (File.Exists(var.db + @"Magazzino\Foto\" + codice + ".png"))
                            File.Delete(var.db + @"Magazzino\Foto\" + codice + ".png");

                        if (File.Exists(var.db + @"Magazzino\Foto\" + codice + ".jpg"))
                            File.Delete(var.db + @"Magazzino\Foto\" + codice + ".jpg");

                        if (File.Exists(var.db + @"Magazzino\Foto\" + codice + ".jpeg"))
                            File.Delete(var.db + @"Magazzino\Foto\" + codice + ".jpeg");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Impossibile eliminare il codice");
                    }
                    carica_codici();
                }
            }else if (prod == true)
            {
                string prodotto = prod_data.Rows[prod_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                DialogResult Scelta = MessageBox.Show("Sei sicuro di voler eliminare " + prodotto, "Eliminazione Prodotto", MessageBoxButtons.YesNo);
                if (Scelta == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(var.db + @"Prodotti\" + prodotto + ".xml");
                        if (File.Exists(var.db + @"Prodotti\Foto\" + prodotto + ".png"))
                            File.Delete(var.db + @"Prodotti\Foto\" + prodotto + ".png");
                        
                        if (File.Exists(var.db + @"Prodotti\Foto\" + prodotto + ".jpg"))
                            File.Delete(var.db + @"Prodotti\Foto\" + prodotto + ".jpg");

                        if (File.Exists(var.db + @"Prodotti\Foto\" + prodotto + ".jpeg"))
                            File.Delete(var.db + @"Prodotti\Foto\" + prodotto + ".jpeg");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Impossibile eliminare il prodotto");
                    }
                    carica_prodotti();
                }
            }
            else if (clienti == true)
            {
                string cliente = clienti_data.Rows[clienti_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                DialogResult Scelta = MessageBox.Show("Sei sicuro di voler eliminare " + cliente, "Eliminazione cliente", MessageBoxButtons.YesNo);
                if (Scelta == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(var.db + @"Clienti\" + cliente + ".xml");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Impossibile eliminare il cliente");
                    }
                    carica_clienti();
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Impossibile eliminare l'ordine");
                    }
                    carica_ordini();
                }
            }
        }

        private void srch_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if (magazzino == true)
                {
                    carica_codici(textBox1.Text, comboBox1.Text, 1);
                }
                else if (prod == true)
                {
                    carica_prodotti(textBox1.Text, comboBox1.Text);
                }
                else if (clienti == true)
                {
                    carica_clienti(textBox1.Text, comboBox1.Text);
                }
                else
                {
                    carica_ordini(textBox1.Text, comboBox1.Text);
                }
            }
            else
            {
                if (magazzino == true)
                    carica_codici();
                else if (prod == true)
                    carica_prodotti();
                else if (clienti == true)
                    carica_clienti();
                else
                    carica_ordini();
            }
        }

        private void ordini_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    ordini_data.CurrentCell = ordini_data.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    ordini_data.Rows[e.RowIndex].Selected = true;
                    ordini_data.Focus();
                    ordini_data.ContextMenuStrip = contextMenuStrip1;
                    Point posizioneContext = new Point(MousePosition.X, MousePosition.Y);
                    ordini_data.ContextMenuStrip.Show(posizioneContext);
                    ordini_data.ContextMenuStrip = null;
                }
                else
                    ordini_data.ContextMenuStrip = null;
            }
        }

        private void magazzino_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    magazzino_data.CurrentCell = magazzino_data.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    magazzino_data.Rows[e.RowIndex].Selected = true;
                    magazzino_data.Focus();
                    magazzino_data.ContextMenuStrip = contextMenuStrip1;
                    Point posizioneContext = new Point(MousePosition.X, MousePosition.Y);
                    magazzino_data.ContextMenuStrip.Show(posizioneContext);
                    magazzino_data.ContextMenuStrip = null;
                }
                else
                    magazzino_data.ContextMenuStrip = null;
            }
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_btn_Click_1(sender, e);
        }

        private void aggiungiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plus_btn_Click_1(sender, e);
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            del_btn_Click(sender, e);
        }

        private void erase_btn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            if (magazzino == true)
                carica_codici();
            else if (prod == true)
                carica_prodotti();
            else if (clienti == true)
                carica_clienti();
            else
                carica_ordini();
        }

        private void prod_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    prod_data.CurrentCell = prod_data.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    prod_data.Rows[e.RowIndex].Selected = true;
                    prod_data.Focus();
                    prod_data.ContextMenuStrip = contextMenuStrip1;
                    Point posizioneContext = new Point(MousePosition.X, MousePosition.Y);
                    prod_data.ContextMenuStrip.Show(posizioneContext);
                    prod_data.ContextMenuStrip = null;
                }
                else
                    prod_data.ContextMenuStrip = null;
            }
        }

        private void changeimg_btn_Click(object sender, EventArgs e)
        {
            if (imghome_dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (imghome_dlg.FileName != null)
                    {
                        Image image = Image.FromFile(imghome_dlg.FileName);
                        logo_pic.BackgroundImage = image;
                        logo_pic.Tag = imghome_dlg.FileName;
                        string extfoto = Path.GetExtension(logo_pic.Tag.ToString());
                        if (File.Exists(var.db + @"home.png"))
                            File.Delete(var.db + @"home.png");
                        else if (File.Exists(var.db + @"home.jpg"))
                            File.Delete(var.db + @"home.jpg");
                        else if (File.Exists(var.db + @"home.jpeg"))
                            File.Delete(var.db + @"home.jpeg");
                        File.Copy(logo_pic.Tag.ToString(), var.db + @"home" + extfoto);
                    }
                }
                catch
                {

                }
            }
        }

        private void bolla_btn_Click(object sender, EventArgs e)
        {
            Crea_Bolla Bolla = new Crea_Bolla();
            Bolla.FormClosing += new FormClosingEventHandler(closeform);
            Bolla.ShowDialog();
        }
    }
}