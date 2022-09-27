using System.Text;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;
using SuperSimpleTcp;

namespace Workmate
{
    public partial class Form1 : Form
    {
        private int borderSize = 2;
        private bool magazzino = false;
        private bool prod = false;
        private bool clienti = false;
        private bool acquisti=false;
        bool mostra_avviso = true;
        bool avv_mostrati = false;
        public decimal totalefatturato;
        bool ordinicaricati = false;
        bool prodotticaricati = false;
        bool codicicaricati = false;
        bool clienticaricati = false;
        bool acquisticaricati= false;
        string[] impostazioni = new string[9];
        private string btn;
        public bool cs = false;
        public Form1()
        {
            InitializeComponent();
            var.check_db();
            Checkdirs();
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(var.db + "workmate.xml");
            XmlNode clientserver = xml_doc.DocumentElement.SelectSingleNode("/workmate/clientserver");
            if (clientserver.InnerText == "true")
            {
                XmlNode ip = xml_doc.DocumentElement.SelectSingleNode("/workmate/ip");
                cs = true;
                var.ipserver = ip.InnerText+ ":16460";
                ThreadStart childref = new ThreadStart(CallToChildThread);
                Thread childThread = new Thread(childref);
                childThread.IsBackground = true;
                childThread.Start();
            }
            carica_foto_home();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(29, 133, 181);
            carica_codici();
            carica_ordini();
            carica_clienti();
            carica_acquisti();
            carica_impostazioni();
            StileDataGrid();
            ordinicaricati = true;
            clienticaricati = true;
            acquisticaricati = true;
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
            settings_pnl.Visible = false;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            acquisti_data.Visible = false;
            desktop_pnl.Visible = true;
            sempre_btn.BackColor = Color.FromArgb(29, 133, 181);
            sempre_btn.ForeColor = Color.White;
        }

        static SimpleTcpClient client = new SimpleTcpClient(var.ipserver);
        public static void CallToChildThread()
        {
            MessageBox.Show("Thread");

            client.Events.Connected += Connected;
            client.Events.Disconnected += Disconnected;
            client.Events.DataReceived += DataReceived;
            try
            { 
                client.ConnectWithRetries(10000);
            }
            catch
            {
                MessageBox.Show("Impossibile connettersi al server! ("+ var.ipserver + ")");
            }
            while (true)
            {

            }

        }

        private static void Connected(object? sender, ConnectionEventArgs e)
        {
            MessageBox.Show("Connesso");
        }

        private static void Disconnected(object? sender, ConnectionEventArgs e)
        {
            MessageBox.Show("Connessione con il server persa!");
        }

        private static void DataReceived(object? sender, DataReceivedEventArgs e)
        {
            Form1 form = new Form1();
            if (Encoding.UTF8.GetString(e.Data) == "Aggiornare magazzino")
            {
                client.Send("Aggiornamento magazzino in corso");
                form.mostra_avviso = false;
                form.carica_codici();
                form.mostra_avviso = true;
            }
            else if(Encoding.UTF8.GetString(e.Data) == "Aggiornare prodotti")
            {
                client.Send("Aggiornamento prodotti in corso");
                form.carica_prodotti();
            }
            else if (Encoding.UTF8.GetString(e.Data) == "Aggiornare ordini")
            {
                client.Send("Aggiornamento ordini in corso");
                form.carica_ordini();
                form.mostra_avviso = false;
                form.carica_codici();
                form.mostra_avviso = true;
            }
            else if (Encoding.UTF8.GetString(e.Data) == "Aggiornare clienti")
            {
                client.Send("Aggiornamento clienti in corso");
                form.carica_clienti();
            }
            else if (Encoding.UTF8.GetString(e.Data) == "Aggiornare acquisti")
            {
                client.Send("Aggiornamento acquisti in corso");
                form.carica_acquisti();
                form.mostra_avviso = false;
                form.carica_codici();
                form.mostra_avviso = true;
            }
        }

        private void closeform(object sender, FormClosingEventArgs e)
        {
            if (magazzino == true && var.ended == true)
            {
                if (cs == false)
                {
                    carica_codici();
                    var.ended = false;
                    codicicaricati = true;
                }
                else
                {
                    client.Send("Magazzino aggiornato");
                    carica_codici();
                    var.ended = false;
                }
            }
            else if (prod == true && var.ended == true)
            {
                if (cs == false)
                {
                    carica_prodotti();
                    var.ended = false;
                    prodotticaricati = true;
                }
                else
                {
                    client.Send("Prodotti aggiornati");
                    carica_prodotti();
                    var.ended = false;
                }
            }
            else if (clienti == true && var.ended == true)
            {
                if (cs == false)
                {
                    carica_clienti();
                    var.ended = false;
                    clienticaricati = true;
                }
                else
                {
                    client.Send("Clienti aggiornati");
                    carica_clienti();
                    var.ended = false;
                }
            }
            else if(acquisti== true && var.ended == true)
            {
                if (cs == false)
                {
                    carica_acquisti();
                    mostra_avviso = false;
                    carica_codici();
                    mostra_avviso = true;
                    var.ended = false;
                    acquisticaricati = true;
                }
                else
                {
                    client.Send("Acquisti aggiornati");
                    carica_acquisti();
                    mostra_avviso = false;
                    carica_codici();
                    mostra_avviso = true;
                    var.ended = false;
                }
            }
            else if (var.ended == true)
            {
                if (cs == false)
                {
                    carica_ordini();
                    if (var.edited_prod == true)
                    {
                        carica_codici();
                        var.edited_prod = false;
                    }
                    var.ended = false;
                    ordinicaricati = true;
                }
                else
                {
                    client.Send("Ordini aggiornati");
                    carica_ordini();
                    carica_codici();
                    var.ended = false;
                }
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
            if (!Directory.Exists(var.db))
            {
                Directory.CreateDirectory(var.db);
            }
            if (!Directory.Exists(var.db + @"\Magazzino"))
            {
                Directory.CreateDirectory(var.db + @"\Magazzino");
                Directory.CreateDirectory(var.db + @"\Magazzino\Foto");
            }
            if (!Directory.Exists(var.db + @"\Ordini"))
            {
                Directory.CreateDirectory(var.db + @"\Ordini");
                //Directory.CreateDirectory(root + @"\Ordini\Foto");
            }
            if (!Directory.Exists(var.db + @"\Prodotti"))
            {
                Directory.CreateDirectory(var.db + @"\Prodotti");
                Directory.CreateDirectory(var.db + @"\Prodotti\Foto");
            }
            if (!Directory.Exists(var.db + @"\Clienti"))
            {
                Directory.CreateDirectory(var.db + @"\Clienti");
            }
            if (!Directory.Exists(var.db + @"\Acquisti"))
            {
                Directory.CreateDirectory(var.db + @"\Acquisti");
                Directory.CreateDirectory(var.db + @"\Acquisti\Foto");
            }
            if (!File.Exists(var.db + @"\workmate.xml"))
            {
                XDocument doc_xml = new XDocument(new XElement("workmate",
                    new XElement("bollaid", 1),
                    new XElement("azienda", "Nome Azienda"),
                    new XElement("indirizzo", "Indirizzo"),
                    new XElement("paese", "Paese"),
                    new XElement("cap", "CAP"),
                    new XElement("prov", "Provincia"),
                    new XElement("piva", ""),
                    new XElement("codicefiscale", ""),
                    new XElement("clientserver", "false"),
                    new XElement("ip", "")
                    ));
                doc_xml.Save(var.db + @"\workmate.xml");
            }
        }

        private void carica_foto_home()
        {
            if (File.Exists(var.db + @"home.png"))
            {
                Image image = Image.FromFile(var.db + @"home.png");
                logo_pic.BackgroundImage = image;
                logo_pic.Tag = var.db + @"home.png";
                var.nfotohome = "home.png";
            }
            else if (File.Exists(var.db + @"home.jpg"))
            {
                Image image = Image.FromFile(var.db + @"home.jpg");
                logo_pic.BackgroundImage = image;
                logo_pic.Tag = var.db + @"home.jpg";
                var.nfotohome = "home.jpg";
            }
            else if (Directory.Exists(var.db + @"home.jpeg"))
            {
                Image image = Image.FromFile(var.db + @"home.jpeg");
                logo_pic.BackgroundImage = image;
                logo_pic.Tag = var.db + @"home.jpeg";
                var.nfotohome = "home.jpeg";
            }
            else
            {
                logo_pic.BackgroundImage = Properties.Resources.Workmate;
                logo_pic.Tag = Properties.Resources.Workmate;
            }
        }

        private void StileDataGrid()
        {
            foreach (DataGridView datagreedview in desktop_pnl.Controls.OfType<DataGridView>())
            {
                datagreedview.BorderStyle = BorderStyle.None;
                datagreedview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(239, 239, 249);
                datagreedview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                datagreedview.EnableHeadersVisualStyles = false;
                datagreedview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                datagreedview.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
                datagreedview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(29, 133, 181);
                datagreedview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
        }
        private void carica_codici(string testoc = "", string colonnac = "", int search = 0)
        {
            qtreminder_txt.Text = "";
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

                if (Int32.Parse(quantita.InnerText) < Int32.Parse(quantitamin.InnerText) && search == 0)
                {
                    qtreminder_txt.Text += codice.InnerText.ToString() + ": " + quantita.InnerText.ToString() + Environment.NewLine;
                    if (mostra_avviso == true && avv_mostrati == false)
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
        }

        private void carica_ordini(string testoc = "", string colonnac = "")
        {
            if (testoc == "")
                totalefatturato = 0.00m;
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
                XmlNode scadenza = xml_doc.DocumentElement.SelectSingleNode("/ordine/scadenza");
                XmlNode evaso = xml_doc.DocumentElement.SelectSingleNode("/ordine/evaso");
                string[] riga = { ordine.InnerText, prezzo.InnerText, cliente.InnerText, note.InnerText, prodotto1.InnerText, prodotto2.InnerText, prodotto3.InnerText, prodotto4.InnerText, prodotto5.InnerText, prodotto6.InnerText, prodotto7.InnerText, prodotto8.InnerText, prodotto9.InnerText, prodotto10.InnerText, qt1.InnerText, qt2.InnerText, qt3.InnerText, qt4.InnerText, qt5.InnerText, qt6.InnerText, qt7.InnerText, qt8.InnerText, qt9.InnerText, qt10.InnerText , scadenza.InnerText, evaso.InnerText};

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
                    if(evaso.InnerText == "Sì")
                        totalefatturato += decimal.Parse(prezzo.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                    totfat_lbl.Text = totalefatturato.ToString() + " €";
                    nordini_lbl.Text = var.cno().ToString();
                }
            }
        }

        private void carica_prodotti(string testoc = "", string colonnac = "")
        {
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
                    case "Cliente":
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

        private void carica_acquisti(string testoc = "", string colonnac = "")
        {
            acquisti_data.Rows.Clear();
            string[] codici = var.carica_acquisti();
            for (int i = 0; i < codici.Length; i++)
            {
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.Load(codici[i]);
                XmlNode codice = xml_doc.DocumentElement.SelectSingleNode("/acquisto/cod");
                XmlNode prezzo = xml_doc.DocumentElement.SelectSingleNode("/acquisto/prezzo");
                XmlNode quantita = xml_doc.DocumentElement.SelectSingleNode("/acquisto/quantità");
                XmlNode data_acquisto = xml_doc.DocumentElement.SelectSingleNode("/acquisto/data_acquisto");
                XmlNode descrizione = xml_doc.DocumentElement.SelectSingleNode("/acquisto/descrizione");
                XmlNode foto = xml_doc.DocumentElement.SelectSingleNode("/acquisto/foto");
                XmlNode arrivato = xml_doc.DocumentElement.SelectSingleNode("/acquisto/arrivato");
                XmlNode timestamp = xml_doc.DocumentElement.SelectSingleNode("/acquisto/timestamp");
                string[] riga = { codice.InnerText, prezzo.InnerText, quantita.InnerText, data_acquisto.InnerText, descrizione.InnerText, foto.InnerText, arrivato.InnerText, timestamp.InnerText};
                string contenuto = "";
                switch (colonnac)
                {
                    case "Codice":
                        contenuto = codice.InnerText;
                        break;
                    case "Data acquisto":
                        contenuto = data_acquisto.InnerText;
                        break;
                    default:
                        contenuto = "";
                        break;
                }
                contenuto = contenuto.ToLower();
                testoc = testoc.ToLower();
                if (contenuto.Contains(testoc))
                    acquisti_data.Rows.Add(riga);
            }
        }

        private void carica_impostazioni()
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(var.db + "workmate.xml");
            XmlNode bollaid = xml_doc.DocumentElement.SelectSingleNode("/workmate/bollaid");
            XmlNode azienda = xml_doc.DocumentElement.SelectSingleNode("/workmate/azienda");
            XmlNode indirizzo = xml_doc.DocumentElement.SelectSingleNode("/workmate/indirizzo");
            XmlNode paese = xml_doc.DocumentElement.SelectSingleNode("/workmate/paese");
            XmlNode cap = xml_doc.DocumentElement.SelectSingleNode("/workmate/cap");
            XmlNode prov = xml_doc.DocumentElement.SelectSingleNode("/workmate/prov");
            XmlNode piva = xml_doc.DocumentElement.SelectSingleNode("/workmate/piva");
            XmlNode codicefiscale = xml_doc.DocumentElement.SelectSingleNode("/workmate/codicefiscale");
            XmlNode clientserver = xml_doc.DocumentElement.SelectSingleNode("/workmate/clientserver");
            XmlNode ip = xml_doc.DocumentElement.SelectSingleNode("/workmate/ip");
            impostazioni[0] = azienda.InnerText;
            impostazioni[1] = indirizzo.InnerText;
            impostazioni[2] = cap.InnerText;
            impostazioni[3] = prov.InnerText;
            impostazioni[4] = piva.InnerText;
            impostazioni[5] = codicefiscale.InnerText;
            impostazioni[6] = paese.InnerText;
            impostazioni[7] = clientserver.InnerText;
            impostazioni[8] = ip.InnerText;
            azienda_lbl.Text = azienda.InnerText;
            ind_lbl.Text = indirizzo.InnerText;
            paese_lbl.Text = paese.InnerText;
            cap_lbl.Text = cap.InnerText;
            prov_lbl.Text = prov.InnerText;
            piva_lbl.Text = "P.Iva: "+piva.InnerText;
            cf_lbl.Text = "Cod. Fiscale: "+codicefiscale.InnerText;
        }
        private void magazzino_btn_Click(object sender, EventArgs e)
        {
            generaBollaToolStripMenuItem.Visible = false;
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            logo_pic.Visible = false;
            qtreminder_pnl.Visible =false;
            btnsfilter_pnl.Visible = false;
            info_pnl.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            bolla_btn.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = true;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            acquisti_data.Visible = false;
            magazzino = true;
            prod = false;
            clienti = false;
            acquisti = false;
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
            generaBollaToolStripMenuItem.Visible = true;
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            info_pnl.Visible = false;
            btnsfilter_pnl.Visible = false;
            logo_pic.Visible = false;
            qtreminder_pnl.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            bolla_btn.Visible = true;
            ordini_data.Visible = true;
            magazzino_data.Visible = false;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            acquisti_data.Visible = false;
            magazzino = false;
            prod = false;
            clienti= false;
            acquisti = false;
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
            generaBollaToolStripMenuItem.Visible = false;
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            logo_pic.Visible = false;
            qtreminder_pnl.Visible = false;
            info_pnl.Visible = false;
            btnsfilter_pnl.Visible = false;
            prod_data.Visible = true;
            magazzino_data.Visible = false;
            ordini_data.Visible = false;
            clienti_data.Visible = false;
            acquisti_data.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            bolla_btn.Visible = false;
            magazzino = false;
            prod = true;
            clienti = false;
            acquisti = false;
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
            generaBollaToolStripMenuItem.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            acquisti_data.Visible = false;
            avv_mostrati = false;
            nordini_pnl.Visible = true;
            totfat_pnl.Visible = true;
            totfat_pic.Visible = true;
            totord_pic.Visible = true;
            info_pnl.Visible = true;
            btnsfilter_pnl.Visible = true;
            logo_pic.Visible = true;
            qtreminder_pnl.Visible = true;
            clienti = false;
            magazzino = false;
            prod=false;
            acquisti = false;
        }
        private void clienti_btn_Click(object sender, EventArgs e)
        {
            generaBollaToolStripMenuItem.Visible = false;
            desktop_pnl.Visible = true;
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            info_pnl.Visible = false;
            btnsfilter_pnl.Visible = false;
            logo_pic.Visible = false;
            qtreminder_pnl.Visible = false;
            bolla_btn.Visible = false;
            clienti_data.Visible = true;
            magazzino_data.Visible = false;
            ordini_data.Visible = false;
            prod_data.Visible = false;
            acquisti_data.Visible = false;
            settings_pnl.Visible = false;
            bar_pnl.Visible = true;
            clienti = true;
            magazzino = false;
            prod = false;
            acquisti = false;
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
            generaBollaToolStripMenuItem.Visible = false;
            desktop_pnl.Visible = false;
            bar_pnl.Visible = false;
            settings_pnl.Visible = true;
            avv_mostrati = false;
            azienda_txt.Text = impostazioni[0];
            indirizzo_txt.Text = impostazioni[1];
            paese_txt.Text = impostazioni[6];
            cap_txt.Text=impostazioni[2];
            prov_txt.Text = impostazioni[3];
            cf_txt.Text =impostazioni[4];
            piva_txt.Text = impostazioni[5];
            ip_text.Text = impostazioni[8];
            if (impostazioni[7] == "true")
            {
                client_server_ckb.Checked = true;
                ip_text.Visible = true;
                label10.Visible = true;
            }
            else
            {
                client_server_ckb.Checked = false;
                ip_text.Visible = false;
                label10.Visible = false;
            }
            if (Properties.Settings.Default.apri_all_avvio == true)
                bootstart_ckb.Checked = true;
            else
                bootstart_ckb.Checked = false;
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
            }
            if(acquisti == true)
            {
                Aggiungi_Acquisto Nuovo_Acquisto = new Aggiungi_Acquisto();
                Nuovo_Acquisto.FormClosing += new FormClosingEventHandler(closeform);
                Nuovo_Acquisto.ShowDialog();
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
            else if (acquisti == true)
            {
                if (acquisti_data.SelectedCells.Count > 0)
                {
                    Aggiungi_Acquisto Nuovo_Acquisto = new Aggiungi_Acquisto();
                    Nuovo_Acquisto.FormClosing += new FormClosingEventHandler(closeform);
                    Nuovo_Acquisto.varCod = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    Nuovo_Acquisto.varPrz = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    Nuovo_Acquisto.varQt = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    Nuovo_Acquisto.varData = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    Nuovo_Acquisto.varDes = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    Nuovo_Acquisto.varFoto = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[5].Value.ToString();
                    Nuovo_Acquisto.varArrivato = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[6].Value.ToString();
                    Nuovo_Acquisto.varTimestamp = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex ].Cells[7].Value.ToString();
                    Nuovo_Acquisto.Modifica = 1;
                    Nuovo_Acquisto.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selezionare prima un acquisto!");
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
                    Nuovo_Ordine.varEvaso = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[25].Value.ToString();
                    Nuovo_Ordine.varScadenza = ordini_data.Rows[ordini_data.CurrentCell.RowIndex].Cells[24].Value.ToString();
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
            }else if (acquisti == true)
            {
                string acquisto = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string timestamp = acquisti_data.Rows[acquisti_data.CurrentCell.RowIndex].Cells[7].Value.ToString();
                DialogResult Scelta = MessageBox.Show("Sei sicuro di voler eliminare " + acquisto, "Eliminazione acquisto", MessageBoxButtons.YesNo);
                if (Scelta == DialogResult.Yes)
                {
                    try
                    {
                        XmlDocument xml_acq_doc = new XmlDocument();
                        xml_acq_doc.Load(var.db + @"Acquisti\" + acquisto+"_"+timestamp+".xml");
                        XmlNode arrivato = xml_acq_doc.DocumentElement.SelectSingleNode("/acquisto/arrivato");
                        XmlNode qtacq = xml_acq_doc.DocumentElement.SelectSingleNode("/acquisto/quantità");
                        if (arrivato.InnerText == "Sì")
                        {
                            XmlDocument xml_cod_doc = new XmlDocument();
                            xml_cod_doc.Load(var.db + @"Magazzino\" + acquisto + ".xml");
                            XmlNode qt = xml_cod_doc.DocumentElement.SelectSingleNode("/codice/quantità");
                            qt.InnerText = (Convert.ToInt32(qt.InnerText)-Convert.ToInt32(qtacq.InnerText)).ToString();
                            xml_cod_doc.Save(var.db + @"Magazzino\" + acquisto + ".xml");
                            carica_codici();
                        }
                        File.Delete(var.db + @"Acquisti\" + acquisto + "_" + timestamp + ".xml");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Impossibile eliminare l'acquisto");
                    }
                    carica_acquisti();
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
                        XmlDocument xml_doc = new XmlDocument();
                        xml_doc.Load(var.db + @"Ordini\" + ordine + ".xml");
                        for (int i = 0; i < 10; i++)
                        {
                            XmlNode prod = xml_doc.DocumentElement.SelectSingleNode("/ordine/prod" + (i + 1));
                            XmlNode qtprod = xml_doc.DocumentElement.SelectSingleNode("/ordine/qt" + (i + 1));
                            if (prod.InnerText.Length != 0) { 
                                XmlDocument xml2_doc = new XmlDocument();
                                xml2_doc.Load(var.db + @"Prodotti\" + prod.InnerText + ".xml");
                                for (int x = 0; x < 15; x++)
                                {
                                    XmlNode cod = xml2_doc.DocumentElement.SelectSingleNode("/Prodotto/cod" + (x + 1));
                                    XmlNode qtcod = xml2_doc.DocumentElement.SelectSingleNode("/Prodotto/qt" + (x + 1));
                                    if (cod.InnerText.Length != 0)
                                    {
                                        XmlDocument xml3_doc = new XmlDocument();
                                        xml3_doc.Load(var.db + @"Magazzino\" + cod.InnerText + ".xml");
                                        XmlNode qt = xml3_doc.DocumentElement.SelectSingleNode("/codice/quantità");
                                        qt.InnerText = (Convert.ToInt32(qt.InnerText) + (Convert.ToInt32(qtprod.InnerText) * Convert.ToInt32(qtcod.InnerText))).ToString();
                                        xml3_doc.Save(var.db + @"Magazzino\" + cod.InnerText + ".xml");
                                    }
                                }
                            }
                        }
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
            string[] ordini = new string[ordini_data.SelectedCells.Count];
            int i = ordini_data.SelectedCells.Count-1;
            foreach (DataGridViewCell cell in ordini_data.SelectedCells)
            {
                ordini[i]=ordini_data.Rows[cell.RowIndex].Cells[0].Value.ToString();
                i--;
            }
            Crea_Bolla Bolla = new Crea_Bolla();
            Bolla.FormClosing += new FormClosingEventHandler(closeform);
            Bolla.ordini = ordini;
            Bolla.nordini = ordini_data.SelectedCells.Count;
            Bolla.ShowDialog();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(var.db + "workmate.xml");
            XmlNode bollaid = xml_doc.DocumentElement.SelectSingleNode("/workmate/bollaid");
            XmlNode azienda = xml_doc.DocumentElement.SelectSingleNode("/workmate/azienda");
            XmlNode indirizzo = xml_doc.DocumentElement.SelectSingleNode("/workmate/indirizzo");
            XmlNode paese = xml_doc.DocumentElement.SelectSingleNode("/workmate/paese");
            XmlNode cap = xml_doc.DocumentElement.SelectSingleNode("/workmate/cap");
            XmlNode prov = xml_doc.DocumentElement.SelectSingleNode("/workmate/prov");
            XmlNode piva = xml_doc.DocumentElement.SelectSingleNode("/workmate/piva");
            XmlNode codicefiscale = xml_doc.DocumentElement.SelectSingleNode("/workmate/codicefiscale");
            XmlNode clientserver = xml_doc.DocumentElement.SelectSingleNode("/workmate/clientserver");
            XmlNode ip = xml_doc.DocumentElement.SelectSingleNode("/workmate/ip");
            azienda.InnerText = azienda_txt.Text;
            indirizzo.InnerText = indirizzo_txt.Text;
            paese.InnerText = paese_txt.Text;
            cap.InnerText = cap_txt.Text;
            prov.InnerText = prov_txt.Text;
            piva.InnerText = piva_txt.Text;
            codicefiscale.InnerText = cf_txt.Text;
            ip.InnerText = ip_text.Text;
            if (client_server_ckb.Checked)
                clientserver.InnerText = "true";
            else
                clientserver.InnerText = "false";
            xml_doc.Save(var.db + "workmate.xml");
            if (bootstart_ckb.Checked)
            {
                Properties.Settings.Default.apri_all_avvio = true;
                Microsoft.Win32.RegistryKey chiavereg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Gestionale_Workmate", Application.ExecutablePath, Microsoft.Win32.RegistryValueKind.String);
            }
            else
            {
                Properties.Settings.Default.apri_all_avvio = false;
                Microsoft.Win32.RegistryKey chiavereg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if(chiavereg.GetValue("Gestionale_Workmate") != null)
                    chiavereg.DeleteValue("Gestionale_Workmate", false);
            }
            Properties.Settings.Default.Save();
            carica_impostazioni();
        }

        private void clienti_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    clienti_data.CurrentCell = clienti_data.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    clienti_data.Rows[e.RowIndex].Selected = true;
                    clienti_data.Focus();
                    clienti_data.ContextMenuStrip = contextMenuStrip1;
                    Point posizioneContext = new Point(MousePosition.X, MousePosition.Y);
                    clienti_data.ContextMenuStrip.Show(posizioneContext);
                    clienti_data.ContextMenuStrip = null;
                }
                else
                    clienti_data.ContextMenuStrip = null;
            }
        }

        private void oggi_btn_Click(object sender, EventArgs e)
        {
            oggi_btn.BackColor = Color.FromArgb(29, 133, 181);
            oggi_btn.ForeColor = Color.White;
            btn = oggi_btn.Name;
            foreach (Button btns in btnsfilter_pnl.Controls.OfType<Button>())
            {
                if (btns.Name != btn)
                {
                    btns.BackColor = Color.FromArgb(245, 245, 255);
                    btns.ForeColor = Color.Black;
                }
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(var.db + @"ordini\");
            List<FileInfo> files = directoryInfo.GetFiles("*.xml").Where(a => a.CreationTime >= DateTime.Today).ToList();
            nordini_lbl.Text = files.Count.ToString();
            totfat_lbl.Text = "0,00 €";
            decimal totfatturatofiltrato = 0;
            for(int i = 0; i < files.Count; i++)
            {
                XmlDocument xml_docperfatturato = new XmlDocument();
                xml_docperfatturato.Load(files.ElementAt(i).ToString());
                XmlNode evaso = xml_docperfatturato.SelectSingleNode("/ordine/evaso");
                if (evaso.InnerText == "Sì")
                {
                    XmlNode prezzo = xml_docperfatturato.DocumentElement.SelectSingleNode("/ordine/prezzo");
                    totfatturatofiltrato += decimal.Parse(prezzo.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            totfat_lbl.Text = totfatturatofiltrato.ToString() + " €";
        }

        private void d7_btn_Click(object sender, EventArgs e)
        {
            d7_btn.BackColor = Color.FromArgb(29, 133, 181);
            d7_btn.ForeColor = Color.White;
            btn = d7_btn.Name;
            foreach(Button btns in btnsfilter_pnl.Controls.OfType<Button>())
            {
                if(btns.Name != btn)
                {
                    btns.BackColor = Color.FromArgb(245, 245, 255);
                    btns.ForeColor = Color.Black;
                }
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(var.db + @"ordini\");
            List<FileInfo> files = directoryInfo.GetFiles("*.xml").Where(a => a.CreationTime >= DateTime.Today.AddDays(-7)).ToList();
            nordini_lbl.Text = files.Count.ToString();
            totfat_lbl.Text = "0,00 €";
            decimal totfatturatofiltrato = 0;
            for (int i = 0; i < files.Count; i++)
            {
                XmlDocument xml_docperfatturato = new XmlDocument();
                xml_docperfatturato.Load(files.ElementAt(i).ToString());
                XmlNode evaso = xml_docperfatturato.SelectSingleNode("/ordine/evaso");
                if (evaso.InnerText == "Sì")
                {
                    XmlNode prezzo = xml_docperfatturato.DocumentElement.SelectSingleNode("/ordine/prezzo");
                    totfatturatofiltrato += decimal.Parse(prezzo.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            totfat_lbl.Text = totfatturatofiltrato.ToString() + " €";
        }

        private void d30_btn_Click(object sender, EventArgs e)
        {
            d30_btn.BackColor = Color.FromArgb(29, 133, 181);
            d30_btn.ForeColor = Color.White;
            btn = d30_btn.Name;
            foreach (Button btns in btnsfilter_pnl.Controls.OfType<Button>())
            {
                if (btns.Name != btn)
                {
                    btns.BackColor = Color.FromArgb(245, 245, 255);
                    btns.ForeColor = Color.Black;
                }
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(var.db + @"ordini\");
            List<FileInfo> files = directoryInfo.GetFiles("*.xml").Where(a => a.CreationTime >= DateTime.Today.AddDays(-30)).ToList();
            nordini_lbl.Text = files.Count.ToString();
            totfat_lbl.Text = "0,00 €";
            decimal totfatturatofiltrato = 0;
            for (int i = 0; i < files.Count; i++)
            {
                XmlDocument xml_docperfatturato = new XmlDocument();
                xml_docperfatturato.Load(files.ElementAt(i).ToString());
                XmlNode evaso = xml_docperfatturato.SelectSingleNode("/ordine/evaso");
                if (evaso.InnerText == "Sì")
                {
                    XmlNode prezzo = xml_docperfatturato.DocumentElement.SelectSingleNode("/ordine/prezzo");
                    totfatturatofiltrato += decimal.Parse(prezzo.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            totfat_lbl.Text = totfatturatofiltrato.ToString() + " €";
        }

        private void mese_btn_Click(object sender, EventArgs e)
        {
            mese_btn.BackColor = Color.FromArgb(29, 133, 181);
            mese_btn.ForeColor = Color.White;
            btn = mese_btn.Name;
            foreach (Button btns in btnsfilter_pnl.Controls.OfType<Button>())
            {
                if (btns.Name != btn)
                {
                    btns.BackColor = Color.FromArgb(245, 245, 255);
                    btns.ForeColor = Color.Black;
                }
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(var.db + @"ordini\");
            List<FileInfo> files = directoryInfo.GetFiles("*.xml").Where(a => a.CreationTime >= DateTime.Today.AddDays(-DateTime.Today.Day)).ToList();
            nordini_lbl.Text = files.Count.ToString();
            totfat_lbl.Text = "0,00 €";
            decimal totfatturatofiltrato = 0;
            for (int i = 0; i < files.Count; i++)
            {
                XmlDocument xml_docperfatturato = new XmlDocument();
                xml_docperfatturato.Load(files.ElementAt(i).ToString());
                XmlNode evaso = xml_docperfatturato.SelectSingleNode("/ordine/evaso");
                if (evaso.InnerText == "Sì")
                {
                    XmlNode prezzo = xml_docperfatturato.DocumentElement.SelectSingleNode("/ordine/prezzo");
                    totfatturatofiltrato += decimal.Parse(prezzo.InnerText, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            totfat_lbl.Text = totfatturatofiltrato.ToString() + " €";
        }

        private void sempre_btn_Click(object sender, EventArgs e)
        {
            sempre_btn.BackColor = Color.FromArgb(29, 133, 181);
            sempre_btn.ForeColor = Color.White;
            btn = sempre_btn.Name;
            foreach (Button btns in btnsfilter_pnl.Controls.OfType<Button>())
            {
                if (btns.Name != btn)
                {
                    btns.BackColor = Color.FromArgb(245, 245, 255);
                    btns.ForeColor = Color.Black;
                }
            }
            nordini_lbl.Text = var.cno().ToString();
            if (totalefatturato == 0)
                totfat_lbl.Text = "0,00 €";
            else
                totfat_lbl.Text = totalefatturato.ToString() + " €";
        }

        private void generaBollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bolla_btn_Click(sender, e);
        }

        private void changedb_btn_Click_1(object sender, EventArgs e)
        {
            Cambia_dirdb cambia_percorsodb = new Cambia_dirdb();
            cambia_percorsodb.FormClosing += new FormClosingEventHandler(closeform);
            cambia_percorsodb.ShowDialog();
            if(cambia_percorsodb.DialogResult == DialogResult.Yes)
            {
                var.db = Properties.Settings.Default.percorso_db;
                totfat_lbl.Text = totalefatturato.ToString("0,00") + " €";
                mostra_avviso = true;
                carica_codici();
                carica_prodotti();
                carica_ordini();
                carica_clienti();
                carica_foto_home();
                carica_impostazioni();
                azienda_txt.Text = azienda_lbl.Text;
                indirizzo_txt.Text=ind_lbl.Text;
                paese_txt.Text = paese_lbl.Text;
                prov_txt.Text = prov_lbl.Text;
                cap_txt.Text = cap_lbl.Text;
                piva_txt.Text = piva_lbl.Text.Remove(0,7);
                cf_txt.Text = cf_lbl.Text.Remove(0,14);
            }
        }

        private void acquisti_btn_Click(object sender, EventArgs e)
        {
            acquisti_data.Visible = true;
            generaBollaToolStripMenuItem.Visible = false;
            nordini_pnl.Visible = false;
            totfat_pnl.Visible = false;
            totfat_pic.Visible = false;
            totord_pic.Visible = false;
            logo_pic.Visible = false;
            qtreminder_pnl.Visible = false;
            btnsfilter_pnl.Visible = false;
            info_pnl.Visible = false;
            settings_pnl.Visible = false;
            desktop_pnl.Visible = true;
            bar_pnl.Visible = true;
            bolla_btn.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
            prod_data.Visible = false;
            clienti_data.Visible = false;
            magazzino = false;
            prod = false;
            clienti = false;
            acquisti = true;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Codice");
            comboBox1.Items.Add("Data acquisto");
            comboBox1.SelectedIndex = 0;
            if(acquisticaricati==false)
                carica_acquisti();
        }

        private void client_server_ckb_CheckedChanged(object sender, EventArgs e)
        {
            if (client_server_ckb.Checked == true)
            {
                ip_text.Visible = true;
                label10.Visible = true;
            }
            else
            {
                ip_text.Visible = false;
                label10.Visible = false;
            }
        }
    }
}