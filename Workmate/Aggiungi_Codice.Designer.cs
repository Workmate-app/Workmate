namespace Workmate
{
    partial class Aggiungi_Codice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aggiungi_Codice));
            this.cod_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prz_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qt_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.desc_txt = new System.Windows.Forms.TextBox();
            this.cancel_btn = new FontAwesome.Sharp.IconButton();
            this.add_btn = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.qtmin_txt = new System.Windows.Forms.TextBox();
            this.imgcod = new System.Windows.Forms.PictureBox();
            this.addimg_btn = new FontAwesome.Sharp.IconButton();
            this.showimg_btn = new FontAwesome.Sharp.IconButton();
            this.addphoto_dlg = new System.Windows.Forms.OpenFileDialog();
            this.removeimg_btn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgcod)).BeginInit();
            this.SuspendLayout();
            // 
            // cod_txt
            // 
            this.cod_txt.Location = new System.Drawing.Point(12, 48);
            this.cod_txt.Name = "cod_txt";
            this.cod_txt.Size = new System.Drawing.Size(145, 23);
            this.cod_txt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Codice:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prezzo:";
            // 
            // prz_txt
            // 
            this.prz_txt.Location = new System.Drawing.Point(12, 104);
            this.prz_txt.Name = "prz_txt";
            this.prz_txt.Size = new System.Drawing.Size(145, 23);
            this.prz_txt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantità:";
            // 
            // qt_txt
            // 
            this.qt_txt.Location = new System.Drawing.Point(12, 162);
            this.qt_txt.Name = "qt_txt";
            this.qt_txt.Size = new System.Drawing.Size(145, 23);
            this.qt_txt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descrizione:";
            // 
            // desc_txt
            // 
            this.desc_txt.Location = new System.Drawing.Point(12, 218);
            this.desc_txt.Multiline = true;
            this.desc_txt.Name = "desc_txt";
            this.desc_txt.Size = new System.Drawing.Size(431, 216);
            this.desc_txt.TabIndex = 3;
            // 
            // cancel_btn
            // 
            this.cancel_btn.FlatAppearance.BorderSize = 0;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.cancel_btn.IconColor = System.Drawing.Color.Black;
            this.cancel_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cancel_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancel_btn.Location = new System.Drawing.Point(379, 444);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(64, 50);
            this.cancel_btn.TabIndex = 5;
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.FlatAppearance.BorderSize = 0;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.add_btn.IconColor = System.Drawing.Color.Black;
            this.add_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.add_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.add_btn.Location = new System.Drawing.Point(305, 444);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(64, 50);
            this.add_btn.TabIndex = 10;
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Quantità minima:";
            // 
            // qtmin_txt
            // 
            this.qtmin_txt.Location = new System.Drawing.Point(183, 162);
            this.qtmin_txt.Name = "qtmin_txt";
            this.qtmin_txt.Size = new System.Drawing.Size(145, 23);
            this.qtmin_txt.TabIndex = 11;
            this.qtmin_txt.Text = "0";
            // 
            // imgcod
            // 
            this.imgcod.BackgroundImage = global::Workmate.Properties.Resources.Workmate;
            this.imgcod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgcod.Location = new System.Drawing.Point(183, 46);
            this.imgcod.Name = "imgcod";
            this.imgcod.Size = new System.Drawing.Size(145, 81);
            this.imgcod.TabIndex = 13;
            this.imgcod.TabStop = false;
            // 
            // addimg_btn
            // 
            this.addimg_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.addimg_btn.IconColor = System.Drawing.Color.Black;
            this.addimg_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addimg_btn.Location = new System.Drawing.Point(339, 46);
            this.addimg_btn.Name = "addimg_btn";
            this.addimg_btn.Size = new System.Drawing.Size(75, 23);
            this.addimg_btn.TabIndex = 14;
            this.addimg_btn.Text = "Aggiungi";
            this.addimg_btn.UseVisualStyleBackColor = true;
            this.addimg_btn.Click += new System.EventHandler(this.addimg_btn_Click);
            // 
            // showimg_btn
            // 
            this.showimg_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.showimg_btn.IconColor = System.Drawing.Color.Black;
            this.showimg_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showimg_btn.Location = new System.Drawing.Point(339, 104);
            this.showimg_btn.Name = "showimg_btn";
            this.showimg_btn.Size = new System.Drawing.Size(75, 23);
            this.showimg_btn.TabIndex = 16;
            this.showimg_btn.Text = "Mostra";
            this.showimg_btn.UseVisualStyleBackColor = true;
            // 
            // addphoto_dlg
            // 
            this.addphoto_dlg.DefaultExt = "jpg";
            this.addphoto_dlg.FileName = "foto_codice";
            this.addphoto_dlg.Filter = "\"All Graphics Types|*.jpg;*.jpeg;*.png\"";
            // 
            // removeimg_btn
            // 
            this.removeimg_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.removeimg_btn.IconColor = System.Drawing.Color.Black;
            this.removeimg_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.removeimg_btn.Location = new System.Drawing.Point(339, 75);
            this.removeimg_btn.Name = "removeimg_btn";
            this.removeimg_btn.Size = new System.Drawing.Size(75, 23);
            this.removeimg_btn.TabIndex = 17;
            this.removeimg_btn.Text = "Rimuovi";
            this.removeimg_btn.UseVisualStyleBackColor = true;
            this.removeimg_btn.Click += new System.EventHandler(this.removeimg_btn_Click);
            // 
            // Aggiungi_Codice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 502);
            this.Controls.Add(this.removeimg_btn);
            this.Controls.Add(this.showimg_btn);
            this.Controls.Add(this.addimg_btn);
            this.Controls.Add(this.imgcod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.qtmin_txt);
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
            this.Name = "Aggiungi_Codice";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aggiungi codice";
            this.Load += new System.EventHandler(this.Aggiungi_Codice_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.imgcod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox cod_txt;
        private Label label1;
        private Label label2;
        private TextBox prz_txt;
        private Label label3;
        private TextBox qt_txt;
        private Label label4;
        private TextBox desc_txt;
        private FontAwesome.Sharp.IconButton cancel_btn;
        private FontAwesome.Sharp.IconButton add_btn;
        private Label label5;
        private TextBox qtmin_txt;
        private PictureBox imgcod;
        private FontAwesome.Sharp.IconButton addimg_btn;
        private FontAwesome.Sharp.IconButton showimg_btn;
        private OpenFileDialog addphoto_dlg;
        private FontAwesome.Sharp.IconButton removeimg_btn;
    }
}