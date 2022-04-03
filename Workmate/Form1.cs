namespace Workmate
{
    public partial class Form1 : Form
    {
        private int borderSize = 2;
        public Form1()
        {
            InitializeComponent();
            Checkdirs();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(29, 133, 181);
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
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
                foreach(Button menuButton in dock_pnl.Controls.OfType<Button>())
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
                    menuButton.Text ="   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10,0,0,0);
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
        private void magazzino_btn_Click(object sender, EventArgs e)
        {
            bar_pnl.Visible = true;
            ordini_data.Visible = false;
            magazzino_data.Visible = true;
        }

        private void ordini_btn_Click(object sender, EventArgs e)
        {
            bar_pnl.Visible = true;
            ordini_data.Visible = true;
            magazzino_data.Visible = false;
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            bar_pnl.Visible = false;
            ordini_data.Visible = false;
            magazzino_data.Visible = false;
        }
    }
}