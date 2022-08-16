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
            xml_doc.Load(var.db + "workmate.xml");
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
                XmlNode paese = xml_doc.DocumentElement.SelectSingleNode("/cliente/paese");
                XmlNode cap = xml_doc.DocumentElement.SelectSingleNode("/cliente/cap");
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

        private string creahtml()
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(var.db + "workmate.xml");
            XmlNode n = xml_doc.DocumentElement.SelectSingleNode("/workmate/bollaid");
            XmlNode azienda = xml_doc.DocumentElement.SelectSingleNode("/workmate/azienda");
            XmlNode indirizzo = xml_doc.DocumentElement.SelectSingleNode("/workmate/indirizzo");
            XmlNode paese = xml_doc.DocumentElement.SelectSingleNode("/workmate/paese");
            XmlNode cap = xml_doc.DocumentElement.SelectSingleNode("/workmate/cap");
            XmlNode prov = xml_doc.DocumentElement.SelectSingleNode("/workmate/prov");
            XmlNode piva = xml_doc.DocumentElement.SelectSingleNode("/workmate/piva");
            XmlNode codicefiscale = xml_doc.DocumentElement.SelectSingleNode("/workmate/codicefiscale");
            n.InnerText = (Convert.ToInt32(n.InnerText) + 1).ToString();
            xml_doc.Save(var.db + "workmate.xml");
            string result = "";
            #region html head

            result += "<!doctype html>" + Environment.NewLine;
            result += "<html lang=\"en\">" + Environment.NewLine;
            result += "  <head>" + Environment.NewLine;
            result += "    <meta charset=\"utf - 8\">" + Environment.NewLine;
            result += "    <meta name=\"viewport\" content=\"width = device - width, initial - scale = 1, shrink - to - fit = no\">" + Environment.NewLine;
            result += "    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css\" integrity=\"sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm\" crossorigin=\"anonymous\">" + Environment.NewLine;
            result += "    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css\">" + Environment.NewLine;
            result += "    <link rel=\"stylesheet\" href=\"https://workmate.info/ddtstyle.css\"" +  Environment.NewLine;
            result += "</head>" + Environment.NewLine;
            #endregion

            #region html intestaizione
            result += "<body>" + Environment.NewLine;
            result += "    <div>" + Environment.NewLine;
            result += "        <div>" + Environment.NewLine;
            result += "            <section class=\"top-content bb d-flex justify-content-between\">" + Environment.NewLine;
            result += "                <div class=\"logo\">" + Environment.NewLine;
            result += "                    <img src=\"" + var.db + var.nfotohome + "\"+ class=\"img-fluid\">" + Environment.NewLine;
            result += "                </div>" + Environment.NewLine;
            result += "                <div class=\"top-right\">" + Environment.NewLine;
            result += "                    <div class=\"position-relative\" style=\"text-align: right;\">" + Environment.NewLine;
            result += "                        <b>" + azienda.InnerText + "</b>" + Environment.NewLine;
            result += "                        <p>" + indirizzo.InnerText + "</p>" + Environment.NewLine;
            result += "                        <p>" + paese.InnerText + " " + cap.InnerText + " " + prov.InnerText + "</p>" + Environment.NewLine;
            result += "                        <p>P.Iva " + piva.InnerText + "</p>" + Environment.NewLine;
            result += "                        <p>Codice fiscale " + codicefiscale.InnerText + "</p>" + Environment.NewLine;
            result += "                        <p>Documento di trasporto N. <span>" + nbolla_txt.Text +"</span></p>" + Environment.NewLine;
            result += "                    </div>" + Environment.NewLine;
            result += "                </div>" + Environment.NewLine;
            result += "            </section>" + Environment.NewLine;
            #endregion

            #region html cliente
            result += "            <section class=\"customer mt-5\">" + Environment.NewLine;
            result += "                <div>" + Environment.NewLine;
            result += "                    <div class=\"row bb pb-3\" style=\"margin-top: -40px\">" + Environment.NewLine;
            result += "                        <div class=\"col-8\">" + Environment.NewLine;
            result += "                            <p>Luogo di destinazione</p>" + Environment.NewLine;
            result += "                            <h2>"+ des_txt.Text +"</h2>" + Environment.NewLine;
            result += "                            <p class=\"address\">" + destind_txt.Text + "<br>"+ paesedest_txt.Text + " " + capdest_txt.Text + " " + provdest_txt.Text + "</p>" + Environment.NewLine;
            result += "                        </div>" + Environment.NewLine;
            result += "                        <div class=\"col-3\">" + Environment.NewLine;
            result += "                            <p>Destinatario</p>" + Environment.NewLine;
            result += "                            <h2>" + clidest_txt.Text + "</h2>" + Environment.NewLine;
            result += "                            <p class=\"address\">" + clidestind_txt.Text + "<br>" + paeseclidest_txt.Text + " " + capclidest_txt.Text + " " + provclidest_txt.Text + "</p>" + Environment.NewLine;
            result += "                        </div>" + Environment.NewLine;
            result += "                    </div>" + Environment.NewLine;
            result += "                    <div class=\"row extra-info pt-3 bb\" style=\"margin-bottom: -4px; margin-top: -4px;\">" + Environment.NewLine;
            result += "                        <div class=\"col-8\">" + Environment.NewLine;
            result += "                            <p>P.Iva: <span>" + piva_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                            <p>Codice fiscale: <span>" + cf_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                            <br>" + Environment.NewLine;
            result += "                        </div>" + Environment.NewLine;
            result += "                    </div>" + Environment.NewLine;
            result += "                    <div class=\"row extra-info pt-3\">" + Environment.NewLine;
            result += "                        <div class=\"col-8\">" + Environment.NewLine;
            result += "                            <p>Data trasporto: <span>" + data_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                            <p>Ora trasporto: <span>" + ora_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                            <p>Aspetto esterno dei beni: <span class=\"text - nowrap\">" + asp_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                            <p>N colli: <span>" + ncolli_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                        </div>" + Environment.NewLine;
            result += "                        <div class=\"col-3\">" + Environment.NewLine;
            result += "                            <p>Trasporto a cura del: <span> " + trasp_txt.Text + " </span ></p>" + Environment.NewLine;
            result += "                            <p>Causale del trasporto: <span>" + causale_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                            <p>Vettore: <span>" + vet_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                            <p>Peso (Kg): <span>" + peso_txt.Text + "</span></p>" + Environment.NewLine;
            result += "                        </div>" + Environment.NewLine;
            result += "                    </div>" + Environment.NewLine;
            result += "                </div>" + Environment.NewLine;
            result += "            </section>" + Environment.NewLine;
            #endregion

            #region table
            result += "            <section class=\"product-area mt-4\">" + Environment.NewLine;
            result += "                <table class=\"table table-hover\" style=\"margin-top: -15px\">" + Environment.NewLine;
            result += "                    <thead>" + Environment.NewLine;
            result += "                        <tr>" + Environment.NewLine;
            result += "                            <td>Codice</td>" + Environment.NewLine;
            result += "                            <td>Descrizione</td>" + Environment.NewLine;
            result += "                            <td style=\"text-align: center;\">Quantità</td>" + Environment.NewLine;
            result += "                        </tr>" + Environment.NewLine;
            result += "                    </thead>" + Environment.NewLine;
            result += "                    <tbody>" + Environment.NewLine;

            int x = 0;
            for (int i= 0; i < nordini; i++)
            {
                while (prodotti.ElementAt(x) != "end")
                {
                    XmlDocument xml_fordescs = new XmlDocument();
                    xml_fordescs.Load(var.db + @"Prodotti\" + prodotti.ElementAt(x) + ".xml");
                    XmlNode desc = xml_fordescs.DocumentElement.SelectSingleNode("/Prodotto/descrizione");

                    result += "                     <tr>" + Environment.NewLine;
                    result += "                         <tr>" + Environment.NewLine;
                    result += "                            <td>" + Environment.NewLine;
                    result += "                               <div class=\"media\">" + Environment.NewLine;
                    result += "                                    <div class=\"media-body\">" + Environment.NewLine;
                    result += "                                        <b>" + prodotti.ElementAt(x) + "</b>" + Environment.NewLine;
                    result += "                                        <p>Ord. " + ordini[i] + "</p>" + Environment.NewLine;
                    result += "                                    </div>" + Environment.NewLine;
                    result += "                                </div>" + Environment.NewLine;
                    result += "                            </td>" + Environment.NewLine;
                    result += "                            <td>" + desc.InnerText + ".</td>" + Environment.NewLine;
                    result += "                            <td style=\"text-align: center;\">" + quantita.ElementAt(x) + "</td>" + Environment.NewLine;
                    result += "                        </tr>" + Environment.NewLine;
                    x++;
                }
                x++;
            }
            result += "                    </tbody>" + Environment.NewLine;
            result += "                </table>" + Environment.NewLine;
            result += "            </section>" + Environment.NewLine;
            #endregion

            #region end html

            result += "            <section class=\"customer mt-5\">" + Environment.NewLine;
            result += "                <div>" + Environment.NewLine;
            result += "                    <div class=\"row bb pb-3\" style=\"margin-top: -25px;\">" + Environment.NewLine;
            result += "                        <div class=\"col-8\">" + Environment.NewLine;
            result += "                            <p>Firma del conducente</p>" + Environment.NewLine;
            result += "                        </div>" + Environment.NewLine;
            result += "                        <div class=\"col-3\">" + Environment.NewLine;
            result += "                            <p>Firma del destinatario</p>" + Environment.NewLine;
            result += "                        </div>" + Environment.NewLine;
            result += "                        <br><br><br>" + Environment.NewLine;
            result += "                    </div>" + Environment.NewLine;
            result += "                </div>" + Environment.NewLine;
            result += "            </section>" + Environment.NewLine;
            result += "            <p>Generato con Workmate     " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "</p>" + Environment.NewLine;
            result += "        </div>" + Environment.NewLine;
            result += "    </div>" + Environment.NewLine;
            result += "</body></html>";
            #endregion
            return result;
        }

        List<string> prodotti = new List<string>();
        List<string> quantita = new List<string>();
        private void ok_btn_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(peso_txt.Text, @"^[0-9]+([.][0-9]+)?$") == false && peso_txt.Text.Length != 0)
            {
                MessageBox.Show("Controllare il peso (per la , inserire il .)");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(capdest_txt.Text, @"^[0-9]+$")==false || System.Text.RegularExpressions.Regex.IsMatch(capclidest_txt.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Controllare il cap!");
                return;
            }
            if(clidestind_txt.Text.Length == 0 || destind_txt.Text.Length == 0 || paeseclidest_txt.Text.Length == 0 || paesedest_txt.Text.Length == 0 || provclidest_txt.Text.Length == 0 || provdest_txt.Text.Length == 0 || capdest_txt.Text.Length == 0 || capclidest_txt.Text.Length == 0)
            {
                MessageBox.Show("Uno o più cambi indirizzo vuoti!");
                return;
            }
            if (des_txt.Text.Length==0)
            {
                MessageBox.Show("Il campo destinatario non può essere vuoto!");
                return;
            }
            if (clidest_txt.Text.Length == 0)
            {
                MessageBox.Show("Il campo cliente di destinazione non può essere vuoto!");
                return;
            }
            XmlDocument xml_doc = new XmlDocument();
            for (int x = 0; x < nordini; x++)
            {
                xml_doc.Load(var.db + @"ordini\" + ordini[x] + ".xml");
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
                if(prodotto1.InnerText != "")
                {
                    prodotti.Add(prodotto1.InnerText);
                    quantita.Add(qt1.InnerText);
                }
                if(prodotto2.InnerText != "")
                {
                    prodotti.Add(prodotto2.InnerText);
                    quantita.Add(qt2.InnerText);
                }
                if(prodotto3.InnerText != "")
                {
                    prodotti.Add(prodotto3.InnerText);
                    quantita.Add(qt3.InnerText);
                }
                if(prodotto4.InnerText != "")
                {
                    prodotti.Add(prodotto4.InnerText);
                    quantita.Add(qt4.InnerText);
                }
                if(prodotto5.InnerText != "")
                {
                    prodotti.Add(prodotto5.InnerText);
                    quantita.Add(qt5.InnerText);
                }
                if(prodotto6.InnerText != "")
                {
                    prodotti.Add(prodotto6.InnerText);
                    quantita.Add(qt6.InnerText);
                }
                if (prodotto7.InnerText != "")
                {
                    prodotti.Add(prodotto7.InnerText);
                    quantita.Add(qt7.InnerText);
                }
                if (prodotto8.InnerText != "")
                {
                    prodotti.Add(prodotto8.InnerText);
                    quantita.Add(qt8.InnerText);
                }
                if (prodotto9.InnerText != "")
                {
                    prodotti.Add(prodotto9.InnerText);
                    quantita.Add(qt9.InnerText);
                }
                if (prodotto10.InnerText != "")
                {
                    prodotti.Add(prodotto10.InnerText);
                    quantita.Add(qt10.InnerText);
                }
                prodotti.Add("end");
                quantita.Add("end");
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = nbolla_txt.Text+".html";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string html = "";
                    html = creahtml();
                    File.WriteAllText(saveFileDialog.FileName, html);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Impossibile creare la bolla!");
            }
        }
        public string[] ordini { get; set; }
        public int nordini { get; set; }
    }
}
