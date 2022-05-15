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

        string OldCod = "";
        private void add_btn_Click(object sender, EventArgs e)
        {
            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Magazzino\\";
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
            if (System.Text.RegularExpressions.Regex.IsMatch(qtmin_txt.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Controllare la quantità minima");
                return;
            }
            if (qtmin_txt.Text.Length == 0)
            {
                qtmin_txt.Text = "0";
            }
            #endregion

            string extfoto = "";
            if (imgcod.Tag != null)
            {
                extfoto = Path.GetExtension(imgcod.Tag.ToString());
            }
            string percorsofoto = root + "Foto\\" + cod_txt.Text + extfoto;
            if (imgcod.Tag == null)
                percorsofoto = "";
            XDocument doc_xml = new XDocument(new XElement("codice",
                new XElement("cod", cod_txt.Text),
                new XElement("prezzo", prz_txt.Text),
                new XElement("quantità", qt_txt.Text),
                new XElement("quantitàmin", qtmin_txt.Text),
                new XElement("descrizione", desc_txt.Text),
                new XElement("foto", percorsofoto)
                ));

            if (File.Exists(root + cod_txt.Text + ".xml") && Modifica != 1)
            {
                MessageBox.Show("Codice già esistente");
                return;
            }
            else
            {
                if (imgcod.Tag != null)
                {
                    if (File.Exists(root + "Foto\\" + cod_txt.Text + "png"))
                        File.Delete(root + "Foto\\" + cod_txt.Text + "png");
                    else if(File.Exists(root + "Foto\\" + cod_txt.Text + "jpg"))
                        File.Delete(root + "Foto\\" + cod_txt.Text + "jpg");
                    else if (File.Exists(root + "Foto\\" + cod_txt.Text + "jpeg"))
                        File.Delete(root + "Foto\\" + cod_txt.Text + "jpeg");
                    File.Copy(imgcod.Tag.ToString(), root + "Foto\\" + cod_txt.Text + extfoto);
                }
                doc_xml.Save(root + cod_txt.Text + ".xml");
                if (Modifica == 1 && OldCod != cod_txt.Text)
                    File.Delete(root + OldCod + ".xml");
            }
            var.ended = true;
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Aggiungi_Codice_Load_1(object sender, EventArgs e)
        {
            if (Modifica == 1)
            {
                this.Text = "Modifica codice";
                OldCod = varCod;
                qtmin_txt.Text = varQtmin;
                cod_txt.Text = varCod;
                prz_txt.Text = varPrz;
                qt_txt.Text = varQt;
                desc_txt.Text = varDes;
                if (varFoto.Length != 0)
                {
                    Image image = Image.FromFile(varFoto);
                    imgcod.BackgroundImage = image;
                    imgcod.Tag = varFoto;
                }
                else
                {
                    imgcod.BackgroundImage = Properties.Resources.Workmate;
                    imgcod.Tag = null;
                }
            }
        }
        public string varCod { get; set; }
        public string varPrz { get; set; }
        public string varQt { get; set; }
        public string varQtmin { get; set; }
        public string varDes { get; set; }
        public int Modifica { get; set; }
        public string varFoto { get; set; }

        private void addimg_btn_Click(object sender, EventArgs e)
        {
            if (addphoto_dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (addphoto_dlg.FileName != null)
                    {
                        Image image = Image.FromFile(addphoto_dlg.FileName);
                        imgcod.BackgroundImage = image;
                        imgcod.Tag = addphoto_dlg.FileName;
                    }
                }
                catch
                {

                }
            }
        }
        private void removeimg_btn_Click(object sender, EventArgs e)
        {
            imgcod.BackgroundImage = Properties.Resources.Workmate;
            imgcod.Tag = null;
        }
    }
}
