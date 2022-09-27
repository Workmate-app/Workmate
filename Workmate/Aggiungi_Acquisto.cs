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
using System.Windows.Media.Imaging;

namespace Workmate
{
    public partial class Aggiungi_Acquisto : Form
    {
        public Aggiungi_Acquisto()
        {
            InitializeComponent();
        }
        string OldAcq = "";
        string timestamp = "";

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string root = var.db + "Acquisti\\";
            #region Controlli
            if (cod_txt.Text.Length == 0)
            {
                MessageBox.Show("Il codice non può essere vuoto");
                return;
            }
            if (prz_txt.Text.Length == 0)
            {
                MessageBox.Show("Il prezzo non può essere vuoto");
                return;
            }
            if (qt_txt.Text.Length == 0)
            {
                MessageBox.Show("La quantità non può essere vuota");
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
            string extfoto = "";
            if (pictureBox1.Tag != null)
            {
                extfoto = Path.GetExtension(pictureBox1.Tag.ToString());
            }
            string percorsofoto = root + "Foto\\" + cod_txt.Text + extfoto;
            if (pictureBox1.Tag == null)
                percorsofoto = "";
            if (Modifica != 1)
                timestamp = GetTimestamp(DateTime.Now);
            string arrivato = "No";
            if (arrivato_ckb.Checked == true)
                arrivato = "Sì";
            XDocument doc_xml = new XDocument(new XElement("acquisto",
                new XElement("cod", cod_txt.Text),
                new XElement("prezzo", prz_txt.Text),
                new XElement("quantità", qt_txt.Text),
                new XElement("data_acquisto", data_txt.Text),
                new XElement("descrizione", desc_txt.Text),
                new XElement("foto", percorsofoto),
                new XElement("timestamp", timestamp),
                new XElement("arrivato", arrivato)
                ));
            if (pictureBox1.Tag != null)
            {
                if (File.Exists(root + "Foto\\" + cod_txt.Text + ".png"))
                    File.Delete(root + "Foto\\" + cod_txt.Text + ".png");
                else if (File.Exists(root + "Foto\\" + cod_txt.Text + ".jpg"))
                    File.Delete(root + "Foto\\" + cod_txt.Text + ".jpg");
                else if (File.Exists(root + "Foto\\" + cod_txt.Text + ".jpeg"))
                    File.Delete(root + "Foto\\" + cod_txt.Text + ".jpeg");
                File.Copy(pictureBox1.Tag.ToString(), root + "Foto\\" + cod_txt.Text + extfoto);
            }

            XmlDocument xml_doc = new XmlDocument();
            try
            {
                xml_doc.Load(var.db + "Magazzino\\" + cod_txt.Text + ".xml");
                if (arrivato_ckb.Checked)
                {
                    XmlNode qt = xml_doc.DocumentElement.SelectSingleNode("/codice/quantità");
                    qt.InnerText = (Convert.ToInt32(qt.InnerText) + Convert.ToInt32(qt_txt.Text) - Convert.ToInt32(oldqt)).ToString();
                    xml_doc.Save(var.db + "Magazzino\\" + cod_txt.Text + ".xml");
                }
                else if(varArrivato == "Sì" && !arrivato_ckb.Checked)
                {
                    XmlNode qt = xml_doc.DocumentElement.SelectSingleNode("/codice/quantità");
                    qt.InnerText = (Convert.ToInt32(qt.InnerText) - Convert.ToInt32(oldqt)).ToString();
                    xml_doc.Save(var.db + "Magazzino\\" + cod_txt.Text + ".xml");
                }
            }
            catch
            {
                if (MessageBox.Show("Codice non presente nel magazzino, crearlo?", "Attenzione", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!arrivato_ckb.Checked)
                        qt_txt.Text = "0";
                    XDocument doc_cod_xml = new XDocument(new XElement("codice",
                        new XElement("cod", cod_txt.Text),
                        new XElement("prezzo", "0.00"),
                        new XElement("quantità", qt_txt.Text),
                        new XElement("quantitàmin", "0"),
                        new XElement("descrizione", ""),
                        new XElement("foto", "")
                        ));
                    doc_cod_xml.Save(var.db + "Magazzino//" + cod_txt.Text + ".xml");
                }
                else
                    return;
            }

            doc_xml.Save(root + cod_txt.Text + "_" + timestamp + ".xml");
            if (Modifica == 1 && OldAcq != cod_txt.Text)
                File.Delete(root + OldAcq + "_" + timestamp + ".xml");
            var.ended = true;
            this.Close();
        }

        private void Aggiungi_Acquisto_Load(object sender, EventArgs e)
        {
            if (Modifica == 1)
            {
                this.Text = "Modifica acquisto";
                OldAcq = varCod;
                cod_txt.Text = varCod;
                prz_txt.Text = varPrz;
                qt_txt.Text = varQt;
                data_txt.Text = varData;
                desc_txt.Text = varDes;
                timestamp = varTimestamp;
                if (varArrivato == "Sì")
                {
                    arrivato_ckb.Checked = true;
                    oldqt = qt_txt.Text;
                }
                else
                {
                    oldqt = "0";
                }
                if (varFoto.Length != 0)
                {
                    FileStream stream = new FileStream(varFoto, FileMode.Open, FileAccess.Read);
                    pictureBox1.BackgroundImage = Image.FromStream(stream);
                    pictureBox1.Tag = varFoto;
                    stream.Close();
                }
                else
                {
                    pictureBox1.BackgroundImage = Properties.Resources.Workmate;
                    pictureBox1.Tag = null;
                }
            }

        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
        public string varCod { get; set; }
        public string varPrz { get; set; }
        public string varQt { get; set; }
        public string varData { get; set; }
        public string varDes { get; set; }
        public string varTimestamp { get; set; }
        public int Modifica { get; set; }
        public string varFoto { get; set; }

        public string oldqt { get; set; }
        public string varArrivato { get; set; }

        private void addimg_btn_Click_1(object sender, EventArgs e)
        {
            if (addphoto_dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (addphoto_dlg.FileName != null)
                    {
                        FileStream stream = new FileStream(addphoto_dlg.FileName, FileMode.Open, FileAccess.Read);
                        pictureBox1.BackgroundImage = Image.FromStream(stream);
                        pictureBox1.Tag = addphoto_dlg.FileName;
                        stream.Close();
                    }
                }
                catch
                {

                }
            }
        }

        private void removeimg_btn_Click_1(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Workmate;
            pictureBox1.Tag = null;
        }
    }
}
