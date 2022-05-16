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
    public partial class Crea_Bolla : Form
    {
        public Crea_Bolla()
        {
            InitializeComponent();
        }

        private void Crea_Bolla_Load(object sender, EventArgs e)
        {
            cli_dlg.InitialDirectory = var.db + @"Clienti\";
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Workmate\\workmate.xml");
            XmlNode n = xml_doc.DocumentElement.SelectSingleNode("/workmate/bollaid");
            nbolla_txt.Text = Convert.ToInt32(n.InnerText).ToString();
            data_txt.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            ora_txt.Text = String.Format("{0:HH/mm}", DateTime.Now);
        }

        private void caricacliente(bool destinazione)
        {
            if(cli_dlg.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.Load(cli_dlg.FileName);
                XmlNode cliente = xml_doc.DocumentElement.SelectSingleNode("/cliente/cliente");
                XmlNode piva = xml_doc.DocumentElement.SelectSingleNode("/cliente/piva");
                XmlNode cf = xml_doc.DocumentElement.SelectSingleNode("/cliente/codice_fiscale");
                XmlNode indirizzo = xml_doc.DocumentElement.SelectSingleNode("/cliente/indirizzo");
                XmlNode cap = xml_doc.DocumentElement.SelectSingleNode("/cliente/cap");
                XmlNode paese = xml_doc.DocumentElement.SelectSingleNode("/cliente/paese");
                XmlNode prov = xml_doc.DocumentElement.SelectSingleNode("/cliente/prov");

                if (destinazione == false)
                {
                    des_txt.Text = cliente.InnerText;
                    destind_txt.Text = indirizzo.InnerText;
                    piva_txt.Text = piva.InnerText;
                    cf_txt.Text = cf.InnerText;
                    capdest_txt.Text=cap.InnerText;
                    paesedest_txt.Text=paese.InnerText;
                    provdest_txt.Text=prov.InnerText;
                }
                else
                {
                    clidest_txt.Text = cliente.InnerText;
                    clidestind_txt.Text = indirizzo.InnerText;
                    capclidest_txt.Text = cap.InnerText;
                    paeseclidest_txt.Text = paese.InnerText;
                    provclidest_txt.Text= prov.InnerText;
                }
            } 
        }

        private void selectcli_btn_Click(object sender, EventArgs e)
        {
            caricacliente(false);
        }

        private void selectdescli_btn_Click(object sender, EventArgs e)
        {
            caricacliente(true);
        }

        private void no_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
