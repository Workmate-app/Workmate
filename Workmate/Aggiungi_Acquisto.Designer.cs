namespace Workmate
{
    partial class Aggiungi_Acquisto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aggiungi_Acquisto));
            this.add_btn = new FontAwesome.Sharp.IconButton();
            this.cancel_btn = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.desc_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qt_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.prz_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cod_txt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.removeimg_btn = new FontAwesome.Sharp.IconButton();
            this.addimg_btn = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.data_txt = new System.Windows.Forms.MaskedTextBox();
            this.addphoto_dlg = new System.Windows.Forms.OpenFileDialog();
            this.arrivato_ckb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // add_btn
            // 
            this.add_btn.FlatAppearance.BorderSize = 0;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.add_btn.IconColor = System.Drawing.Color.Black;
            this.add_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.add_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.add_btn.Location = new System.Drawing.Point(307, 433);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(64, 50);
            this.add_btn.TabIndex = 5;
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.cancel_btn.IconColor = System.Drawing.Color.Black;
            this.cancel_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cancel_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancel_btn.Location = new System.Drawing.Point(381, 433);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(64, 50);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Descrizione:";
            // 
            // desc_txt
            // 
            this.desc_txt.Location = new System.Drawing.Point(14, 259);
            this.desc_txt.Multiline = true;
            this.desc_txt.Name = "desc_txt";
            this.desc_txt.Size = new System.Drawing.Size(431, 164);
            this.desc_txt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Quantità:";
            // 
            // qt_txt
            // 
            this.qt_txt.Location = new System.Drawing.Point(14, 151);
            this.qt_txt.Name = "qt_txt";
            this.qt_txt.Size = new System.Drawing.Size(145, 23);
            this.qt_txt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Prezzo:";
            // 
            // prz_txt
            // 
            this.prz_txt.Location = new System.Drawing.Point(14, 93);
            this.prz_txt.Name = "prz_txt";
            this.prz_txt.Size = new System.Drawing.Size(145, 23);
            this.prz_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Codice:";
            // 
            // cod_txt
            // 
            this.cod_txt.Location = new System.Drawing.Point(14, 37);
            this.cod_txt.Name = "cod_txt";
            this.cod_txt.Size = new System.Drawing.Size(145, 23);
            this.cod_txt.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Workmate.Properties.Resources.Workmate;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(262, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 111);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // removeimg_btn
            // 
            this.removeimg_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.removeimg_btn.IconColor = System.Drawing.Color.Black;
            this.removeimg_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.removeimg_btn.Location = new System.Drawing.Point(370, 154);
            this.removeimg_btn.Name = "removeimg_btn";
            this.removeimg_btn.Size = new System.Drawing.Size(75, 23);
            this.removeimg_btn.TabIndex = 23;
            this.removeimg_btn.Text = "Rimuovi";
            this.removeimg_btn.UseVisualStyleBackColor = true;
            // 
            // addimg_btn
            // 
            this.addimg_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.addimg_btn.IconColor = System.Drawing.Color.Black;
            this.addimg_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addimg_btn.Location = new System.Drawing.Point(289, 154);
            this.addimg_btn.Name = "addimg_btn";
            this.addimg_btn.Size = new System.Drawing.Size(75, 23);
            this.addimg_btn.TabIndex = 22;
            this.addimg_btn.Text = "Aggiungi";
            this.addimg_btn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Data di acquisto:";
            // 
            // data_txt
            // 
            this.data_txt.Location = new System.Drawing.Point(14, 205);
            this.data_txt.Mask = "00/00/0000";
            this.data_txt.Name = "data_txt";
            this.data_txt.Size = new System.Drawing.Size(145, 23);
            this.data_txt.TabIndex = 3;
            this.data_txt.ValidatingType = typeof(System.DateTime);
            // 
            // addphoto_dlg
            // 
            this.addphoto_dlg.FileName = "Foto_Acquisto";
            // 
            // arrivato_ckb
            // 
            this.arrivato_ckb.AutoSize = true;
            this.arrivato_ckb.Location = new System.Drawing.Point(262, 209);
            this.arrivato_ckb.Name = "arrivato_ckb";
            this.arrivato_ckb.Size = new System.Drawing.Size(68, 19);
            this.arrivato_ckb.TabIndex = 36;
            this.arrivato_ckb.Text = "Arrivato";
            this.arrivato_ckb.UseVisualStyleBackColor = true;
            // 
            // Aggiungi_Acquisto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 502);
            this.Controls.Add(this.arrivato_ckb);
            this.Controls.Add(this.data_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.removeimg_btn);
            this.Controls.Add(this.addimg_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.desc_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.qt_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prz_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cod_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Aggiungi_Acquisto";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aggiungi Acquisto";
            this.Load += new System.EventHandler(this.Aggiungi_Acquisto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton add_btn;
        private FontAwesome.Sharp.IconButton cancel_btn;
        private Label label4;
        private TextBox desc_txt;
        private Label label3;
        private TextBox qt_txt;
        private Label label2;
        private TextBox prz_txt;
        private Label label1;
        private TextBox cod_txt;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton removeimg_btn;
        private FontAwesome.Sharp.IconButton addimg_btn;
        private Label label5;
        private MaskedTextBox data_txt;
        private OpenFileDialog addphoto_dlg;
        private CheckBox arrivato_ckb;
    }
}