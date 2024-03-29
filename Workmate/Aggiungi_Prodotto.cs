﻿using System;
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
    public partial class Aggiungi_Prodotto : Form
    {
        public Aggiungi_Prodotto()
        {
            InitializeComponent();
        }

        string OldProd = "";
        private void Aggiungi_Prodotto_Load(object sender, EventArgs e)
        {
            if (Modifica == 1)
            {
                this.Text = "Modifica Prodotto";
                OldProd = varProdotto;
                prodotto_txt.Text = varProdotto;
                desc_txt.Text = varDescrizione;
                Cod1.Text = varCod1;
                Cod2.Text = varCod2;
                Cod3.Text = varCod3;
                Cod4.Text = varCod4;
                Cod5.Text = varCod5;
                Cod6.Text = varCod6;
                Cod7.Text = varCod7;
                Cod8.Text = varCod8;
                Cod9.Text = varCod9;
                Cod10.Text = varCod10;
                Cod11.Text = varCod11;
                Cod12.Text = varCod12;
                Cod13.Text = varCod13;
                Cod14.Text = varCod14;
                Cod15.Text = varCod15;
                qt1.Text = varQt1;
                qt2.Text = varQt2;
                qt3.Text = varQt3;
                qt4.Text = varQt4;
                qt5.Text = varQt5;
                qt6.Text = varQt6;
                qt7.Text = varQt7;
                qt8.Text = varQt8;
                qt9.Text = varQt9;
                qt10.Text = varQt10;
                qt11.Text = varQt11;
                qt12.Text = varQt12;
                qt13.Text = varQt13;
                qt14.Text = varQt14;
                qt15.Text = varQt15;
                if (varFoto.Length != 0)
                {
                    FileStream stream = new FileStream(varFoto, FileMode.Open, FileAccess.Read);
                    prodimg.BackgroundImage = Image.FromStream(stream);
                    prodimg.Tag = addphoto_dlg.FileName;
                    stream.Close();
                }
                else
                {
                    prodimg.BackgroundImage = Properties.Resources.Workmate;
                    prodimg.Tag = null;
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            if (prodotto_txt.Text.Length == 0)
            {
                MessageBox.Show("Prodotto non può essere vuoto");
                return;
            }

            string extfoto = "";
            if (prodimg.Tag != null)
            {
                extfoto = Path.GetExtension(prodimg.Tag.ToString());
            }
            string root = var.db + "Prodotti\\";
            string percorsofoto = root + "Foto\\" + prodotto_txt.Text + extfoto;
            if (prodimg.Tag == null)
                percorsofoto = "";

            XDocument doc_xml = new XDocument(new XElement("Prodotto",
                new XElement("prodotto", prodotto_txt.Text),
                new XElement("descrizione", desc_txt.Text),
                new XElement("cod1", Cod1.Text),
                new XElement("cod2", Cod2.Text),
                new XElement("cod3", Cod3.Text),
                new XElement("cod4", Cod4.Text),
                new XElement("cod5", Cod5.Text),
                new XElement("cod6", Cod6.Text),
                new XElement("cod7", Cod7.Text),
                new XElement("cod8", Cod8.Text),
                new XElement("cod9", Cod9.Text),
                new XElement("cod10", Cod10.Text),
                new XElement("cod11", Cod11.Text),
                new XElement("cod12", Cod12.Text),
                new XElement("cod13", Cod13.Text),
                new XElement("cod14", Cod14.Text),
                new XElement("cod15", Cod15.Text),
                new XElement("qt1", qt1.Text),
                new XElement("qt2", qt2.Text),
                new XElement("qt3", qt3.Text),
                new XElement("qt4", qt4.Text),
                new XElement("qt5", qt5.Text),
                new XElement("qt6", qt6.Text),
                new XElement("qt7", qt7.Text),
                new XElement("qt8", qt8.Text),
                new XElement("qt9", qt9.Text),
                new XElement("qt10", qt10.Text),
                new XElement("qt11", qt11.Text),
                new XElement("qt12", qt12.Text),
                new XElement("qt13", qt13.Text),
                new XElement("qt14", qt14.Text),
                new XElement("qt15", qt15.Text),
                new XElement("foto", percorsofoto)
                ));

            if (File.Exists(root + prodotto_txt.Text + ".xml") && Modifica != 1)
            {
                MessageBox.Show("Prodotto già esistente");
                return;
            }

            foreach (TextBox textbox in cod_pnl.Controls.OfType<TextBox>())
            {
                if (textbox.Text != "")
                {
                    try
                    {
                        XmlDocument xml_doc = new XmlDocument();
                        xml_doc.Load(var.db + "Magazzino\\" + textbox.Text + ".xml");
                    }
                    catch
                    {
                        MessageBox.Show("Codice " + textbox.Text + " non trovato!");
                        return;
                    }
                }
            }

            foreach (TextBox textbox in qt_pnl.Controls.OfType<TextBox>())
            {
                if (textbox.Text != "")
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(textbox.Text, @"^[0-9]+$") == false)
                    {
                        MessageBox.Show("Controllare la quantità!");
                        return;
                    }
                }
            }
            if (prodimg.Tag != null)
            {
                if (File.Exists(root + "Foto\\" + prodotto_txt.Text + ".png"))
                    File.Delete(root + "Foto\\" + prodotto_txt.Text + ".png");
                else if (File.Exists(root + "Foto\\" + prodotto_txt.Text + ".jpg"))
                    File.Delete(root + "Foto\\" + prodotto_txt.Text + ".jpg");
                else if (File.Exists(root + "Foto\\" + prodotto_txt.Text + ".jpeg"))
                    File.Delete(root + "Foto\\" + prodotto_txt.Text + ".jpeg");
                File.Copy(prodimg.Tag.ToString(), root + "Foto\\" + prodotto_txt.Text + extfoto);
            }
            doc_xml.Save(root + prodotto_txt.Text + ".xml");
            if (Modifica == 1 && OldProd != prodotto_txt.Text)
                File.Delete(root + OldProd + ".xml");
            this.DialogResult = DialogResult.Yes;
            var.ended = true;
            this.Close();

        }

        private void addimg_btn_Click(object sender, EventArgs e)
        {
            if (addphoto_dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (addphoto_dlg.FileName != null)
                    {
                        FileStream stream = new FileStream(addphoto_dlg.FileName, FileMode.Open, FileAccess.Read);
                        prodimg.BackgroundImage = Image.FromStream(stream);
                        prodimg.Tag = addphoto_dlg.FileName;
                        stream.Close();
                    }
                }
                catch
                {

                }
            }
        }

        private void removeimg_btn_Click(object sender, EventArgs e)
        {
            prodimg.BackgroundImage = Properties.Resources.Workmate;
            prodimg.Tag = null;
        }

        private void showimg_btn_Click(object sender, EventArgs e)
        {

        }
        public int Modifica { get; set; }

        public string varProdotto { get; set; }
        public string varDescrizione { get; set; }
        public string varCod1 { get; set; }
        public string varCod2 { get; set; }
        public string varCod3 { get; set; }
        public string varCod4 { get; set; }
        public string varCod5 { get; set; }
        public string varCod6 { get; set; }
        public string varCod7 { get; set; }
        public string varCod8 { get; set; }
        public string varCod9 { get; set; }
        public string varCod10 { get; set; }
        public string varCod11 { get; set; }
        public string varCod12 { get; set; }
        public string varCod13 { get; set; }
        public string varCod14 { get; set; }
        public string varCod15 { get; set; }
        public string varQt1 { get; set; }
        public string varQt2 { get; set; }
        public string varQt3 { get; set; }
        public string varQt4 { get; set; }
        public string varQt5 { get; set; }
        public string varQt6 { get; set; }
        public string varQt7 { get; set; }
        public string varQt8 { get; set; }
        public string varQt9 { get; set; }
        public string varQt10 { get; set; }
        public string varQt11 { get; set; }
        public string varQt12 { get; set; }
        public string varQt13 { get; set; }
        public string varQt14 { get; set; }
        public string varQt15 { get; set; }
        public string varFoto { get; set; }

    }
}
