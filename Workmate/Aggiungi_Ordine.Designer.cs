namespace Workmate
{
    partial class Aggiungi_Ordine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aggiungi_Ordine));
            this.cancel_btn = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.note_txt = new System.Windows.Forms.TextBox();
            this.label_cliente = new System.Windows.Forms.Label();
            this.cliente_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.prz_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ord_txt = new System.Windows.Forms.TextBox();
            this.add_btn = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
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
            this.cancel_btn.TabIndex = 5;
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Note:";
            // 
            // note_txt
            // 
            this.note_txt.Location = new System.Drawing.Point(12, 218);
            this.note_txt.Multiline = true;
            this.note_txt.Name = "note_txt";
            this.note_txt.Size = new System.Drawing.Size(431, 216);
            this.note_txt.TabIndex = 3;
            // 
            // label_cliente
            // 
            this.label_cliente.AutoSize = true;
            this.label_cliente.Location = new System.Drawing.Point(12, 144);
            this.label_cliente.Name = "label_cliente";
            this.label_cliente.Size = new System.Drawing.Size(47, 15);
            this.label_cliente.TabIndex = 8;
            this.label_cliente.Text = "Cliente:";
            // 
            // cliente_txt
            // 
            this.cliente_txt.Location = new System.Drawing.Point(12, 162);
            this.cliente_txt.Name = "cliente_txt";
            this.cliente_txt.Size = new System.Drawing.Size(145, 23);
            this.cliente_txt.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ordine:";
            // 
            // ord_txt
            // 
            this.ord_txt.Location = new System.Drawing.Point(12, 48);
            this.ord_txt.Name = "ord_txt";
            this.ord_txt.Size = new System.Drawing.Size(145, 23);
            this.ord_txt.TabIndex = 0;
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
            this.add_btn.TabIndex = 4;
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // Aggiungi_Ordine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 502);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.note_txt);
            this.Controls.Add(this.label_cliente);
            this.Controls.Add(this.cliente_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prz_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ord_txt);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.add_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Aggiungi_Ordine";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aggiungi ordine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton cancel_btn;
        private Label label4;
        private TextBox note_txt;
        private Label label_cliente;
        private TextBox cliente_txt;
        private Label label2;
        private TextBox prz_txt;
        private Label label1;
        private TextBox ord_txt;
        private FontAwesome.Sharp.IconButton add_btn;
    }
}