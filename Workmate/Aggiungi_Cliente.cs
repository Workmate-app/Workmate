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
    public partial class Aggiungi_Cliente : Form
    {
        public Aggiungi_Cliente()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string oldcli = "";
        private void add_btn_Click(object sender, EventArgs e)
        {
            string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\Clienti\\";

            XDocument doc_xml = new XDocument(new XElement("cliente",
                new XElement("cliente", cli_txt.Text),
                new XElement("piva", piva_txt.Text),
                new XElement("codice_fiscale", cf_txt.Text),
                new XElement("indirizzo", ind_txt.Text),
                new XElement("cap", cap_txt.Text),
                new XElement("paese", paese_txt.Text),
                new XElement("prov", prov_txt.Text),
                new XElement("note", note_txt.Text)
                ));

            if (File.Exists(root + cli_txt.Text + ".xml") && Modifica != 1)
            {
                MessageBox.Show("Cliente già esistente");
                return;
            }
            else
            {
                doc_xml.Save(root + cli_txt.Text + ".xml");
                if (Modifica == 1 && oldcli != cli_txt.Text)
                    File.Delete(root + oldcli + ".xml");
            }
            var.ended = true;
            this.Close();
        }

        public string varCli { get; set; }
        public string varPiva { get; set; }
        public string varCf { get; set; }
        public string varInd { get; set; }
        public string varCap { get; set; }
        public string varPaese { get; set; }
        public string varProv { get; set; }
        public string varNote{ get; set; }
        public int Modifica { get; set; }

        private void Aggiungi_Cliente_Load(object sender, EventArgs e)
        {
            if (Modifica == 1)
            {
                this.Text = "Modifica cliente";
                oldcli = varCli;
                cli_txt.Text = varCli;
                piva_txt.Text = varPiva;
                cf_txt.Text = varCf;
                ind_txt.Text = varInd;
                cap_txt.Text = varCap;
                paese_txt.Text = varPaese;
                prov_txt.Text = varProv;    
                note_txt.Text = varNote;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void paese_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
