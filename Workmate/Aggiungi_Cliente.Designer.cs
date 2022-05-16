namespace Workmate
{
    partial class Aggiungi_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aggiungi_Cliente));
            this.add_btn = new FontAwesome.Sharp.IconButton();
            this.cancel_btn = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cli_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.piva_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cf_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ind_txt = new System.Windows.Forms.TextBox();
            this.note_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cap_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.paese_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.prov_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.add_btn.Location = new System.Drawing.Point(308, 440);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(64, 50);
            this.add_btn.TabIndex = 12;
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
            this.cancel_btn.Location = new System.Drawing.Point(382, 440);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(64, 50);
            this.cancel_btn.TabIndex = 11;
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cliente:";
            // 
            // cli_txt
            // 
            this.cli_txt.Location = new System.Drawing.Point(12, 48);
            this.cli_txt.Name = "cli_txt";
            this.cli_txt.Size = new System.Drawing.Size(188, 23);
            this.cli_txt.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "P.Iva:";
            // 
            // piva_txt
            // 
            this.piva_txt.Location = new System.Drawing.Point(12, 95);
            this.piva_txt.Name = "piva_txt";
            this.piva_txt.Size = new System.Drawing.Size(188, 23);
            this.piva_txt.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Codice fiscale:";
            // 
            // cf_txt
            // 
            this.cf_txt.Location = new System.Drawing.Point(12, 146);
            this.cf_txt.Name = "cf_txt";
            this.cf_txt.Size = new System.Drawing.Size(188, 23);
            this.cf_txt.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Indirizzo:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ind_txt
            // 
            this.ind_txt.Location = new System.Drawing.Point(12, 199);
            this.ind_txt.Name = "ind_txt";
            this.ind_txt.Size = new System.Drawing.Size(130, 23);
            this.ind_txt.TabIndex = 21;
            // 
            // note_txt
            // 
            this.note_txt.Location = new System.Drawing.Point(12, 253);
            this.note_txt.Multiline = true;
            this.note_txt.Name = "note_txt";
            this.note_txt.Size = new System.Drawing.Size(434, 181);
            this.note_txt.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Note:";
            // 
            // cap_txt
            // 
            this.cap_txt.Location = new System.Drawing.Point(252, 199);
            this.cap_txt.Name = "cap_txt";
            this.cap_txt.Size = new System.Drawing.Size(61, 23);
            this.cap_txt.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "CAP:";
            // 
            // paese_txt
            // 
            this.paese_txt.Location = new System.Drawing.Point(148, 199);
            this.paese_txt.Name = "paese_txt";
            this.paese_txt.Size = new System.Drawing.Size(98, 23);
            this.paese_txt.TabIndex = 27;
            this.paese_txt.TextChanged += new System.EventHandler(this.paese_txt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Paese:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // prov_txt
            // 
            this.prov_txt.Location = new System.Drawing.Point(319, 199);
            this.prov_txt.Name = "prov_txt";
            this.prov_txt.Size = new System.Drawing.Size(59, 23);
            this.prov_txt.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Provincia:";
            // 
            // Aggiungi_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 502);
            this.Controls.Add(this.prov_txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.paese_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cap_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.note_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ind_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cf_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.piva_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cli_txt);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.cancel_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Aggiungi_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aggiungi cliente";
            this.Load += new System.EventHandler(this.Aggiungi_Cliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton add_btn;
        private FontAwesome.Sharp.IconButton cancel_btn;
        private Label label1;
        private TextBox cli_txt;
        private Label label2;
        private TextBox piva_txt;
        private Label label3;
        private TextBox cf_txt;
        private Label label4;
        private TextBox ind_txt;
        private TextBox note_txt;
        private Label label5;
        private TextBox cap_txt;
        private Label label6;
        private TextBox paese_txt;
        private Label label7;
        private TextBox prov_txt;
        private Label label8;
    }
}