namespace Workmate
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dock_pnl = new System.Windows.Forms.Panel();
            this.impostazioni_btn = new FontAwesome.Sharp.IconButton();
            this.ordini_btn = new FontAwesome.Sharp.IconButton();
            this.magazzino_btn = new FontAwesome.Sharp.IconButton();
            this.home_btn = new FontAwesome.Sharp.IconButton();
            this.logo_pnl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bars_btn = new FontAwesome.Sharp.IconButton();
            this.bar_pnl = new System.Windows.Forms.Panel();
            this.edit_btn = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.plus_btn = new FontAwesome.Sharp.IconButton();
            this.desktop_pnl = new System.Windows.Forms.Panel();
            this.ordini_data = new System.Windows.Forms.DataGridView();
            this.ordine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.magazzino_data = new System.Windows.Forms.DataGridView();
            this.codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantita_codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzo_codice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrizione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settings_pnl = new System.Windows.Forms.Panel();
            this.dock_pnl.SuspendLayout();
            this.logo_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bar_pnl.SuspendLayout();
            this.desktop_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordini_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazzino_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dock_pnl
            // 
            this.dock_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(133)))), ((int)(((byte)(181)))));
            this.dock_pnl.Controls.Add(this.impostazioni_btn);
            this.dock_pnl.Controls.Add(this.ordini_btn);
            this.dock_pnl.Controls.Add(this.magazzino_btn);
            this.dock_pnl.Controls.Add(this.home_btn);
            this.dock_pnl.Controls.Add(this.logo_pnl);
            this.dock_pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.dock_pnl.Location = new System.Drawing.Point(0, 0);
            this.dock_pnl.Name = "dock_pnl";
            this.dock_pnl.Size = new System.Drawing.Size(230, 592);
            this.dock_pnl.TabIndex = 0;
            // 
            // impostazioni_btn
            // 
            this.impostazioni_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.impostazioni_btn.FlatAppearance.BorderSize = 0;
            this.impostazioni_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.impostazioni_btn.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.impostazioni_btn.ForeColor = System.Drawing.Color.White;
            this.impostazioni_btn.IconChar = FontAwesome.Sharp.IconChar.SlidersH;
            this.impostazioni_btn.IconColor = System.Drawing.Color.White;
            this.impostazioni_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.impostazioni_btn.IconSize = 42;
            this.impostazioni_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.impostazioni_btn.Location = new System.Drawing.Point(0, 536);
            this.impostazioni_btn.Name = "impostazioni_btn";
            this.impostazioni_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.impostazioni_btn.Size = new System.Drawing.Size(230, 56);
            this.impostazioni_btn.TabIndex = 4;
            this.impostazioni_btn.Tag = "Impostazioni";
            this.impostazioni_btn.Text = "Impostazioni";
            this.impostazioni_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.impostazioni_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.impostazioni_btn.UseVisualStyleBackColor = true;
            this.impostazioni_btn.Click += new System.EventHandler(this.impostazioni_btn_Click);
            // 
            // ordini_btn
            // 
            this.ordini_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ordini_btn.FlatAppearance.BorderSize = 0;
            this.ordini_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordini_btn.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ordini_btn.ForeColor = System.Drawing.Color.White;
            this.ordini_btn.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            this.ordini_btn.IconColor = System.Drawing.Color.White;
            this.ordini_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ordini_btn.IconSize = 42;
            this.ordini_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordini_btn.Location = new System.Drawing.Point(0, 226);
            this.ordini_btn.Name = "ordini_btn";
            this.ordini_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ordini_btn.Size = new System.Drawing.Size(230, 56);
            this.ordini_btn.TabIndex = 3;
            this.ordini_btn.Tag = "Ordini";
            this.ordini_btn.Text = "Ordini";
            this.ordini_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordini_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ordini_btn.UseVisualStyleBackColor = true;
            this.ordini_btn.Click += new System.EventHandler(this.ordini_btn_Click);
            // 
            // magazzino_btn
            // 
            this.magazzino_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.magazzino_btn.FlatAppearance.BorderSize = 0;
            this.magazzino_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.magazzino_btn.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.magazzino_btn.ForeColor = System.Drawing.Color.White;
            this.magazzino_btn.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.magazzino_btn.IconColor = System.Drawing.Color.White;
            this.magazzino_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.magazzino_btn.IconSize = 42;
            this.magazzino_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.magazzino_btn.Location = new System.Drawing.Point(0, 170);
            this.magazzino_btn.Name = "magazzino_btn";
            this.magazzino_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.magazzino_btn.Size = new System.Drawing.Size(230, 56);
            this.magazzino_btn.TabIndex = 2;
            this.magazzino_btn.Tag = "Magazzino";
            this.magazzino_btn.Text = "Magazzino";
            this.magazzino_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.magazzino_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.magazzino_btn.UseVisualStyleBackColor = true;
            this.magazzino_btn.Click += new System.EventHandler(this.magazzino_btn_Click);
            // 
            // home_btn
            // 
            this.home_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.home_btn.FlatAppearance.BorderSize = 0;
            this.home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_btn.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.home_btn.ForeColor = System.Drawing.Color.White;
            this.home_btn.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.home_btn.IconColor = System.Drawing.Color.White;
            this.home_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.home_btn.IconSize = 42;
            this.home_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home_btn.Location = new System.Drawing.Point(0, 114);
            this.home_btn.Name = "home_btn";
            this.home_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.home_btn.Size = new System.Drawing.Size(230, 56);
            this.home_btn.TabIndex = 1;
            this.home_btn.Tag = "Home";
            this.home_btn.Text = "Home";
            this.home_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.home_btn.UseVisualStyleBackColor = true;
            this.home_btn.Click += new System.EventHandler(this.home_btn_Click);
            // 
            // logo_pnl
            // 
            this.logo_pnl.Controls.Add(this.pictureBox1);
            this.logo_pnl.Controls.Add(this.bars_btn);
            this.logo_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo_pnl.Location = new System.Drawing.Point(0, 0);
            this.logo_pnl.Name = "logo_pnl";
            this.logo_pnl.Size = new System.Drawing.Size(230, 114);
            this.logo_pnl.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Workmate.Properties.Resources.WORKMATE_word;
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bars_btn
            // 
            this.bars_btn.FlatAppearance.BorderSize = 0;
            this.bars_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bars_btn.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.bars_btn.IconColor = System.Drawing.Color.White;
            this.bars_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.bars_btn.IconSize = 40;
            this.bars_btn.Location = new System.Drawing.Point(171, 22);
            this.bars_btn.Name = "bars_btn";
            this.bars_btn.Size = new System.Drawing.Size(60, 60);
            this.bars_btn.TabIndex = 0;
            this.bars_btn.UseVisualStyleBackColor = true;
            this.bars_btn.Click += new System.EventHandler(this.bars_btn_Click);
            // 
            // bar_pnl
            // 
            this.bar_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.bar_pnl.Controls.Add(this.edit_btn);
            this.bar_pnl.Controls.Add(this.iconButton1);
            this.bar_pnl.Controls.Add(this.plus_btn);
            this.bar_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar_pnl.Location = new System.Drawing.Point(230, 0);
            this.bar_pnl.Name = "bar_pnl";
            this.bar_pnl.Size = new System.Drawing.Size(838, 60);
            this.bar_pnl.TabIndex = 1;
            // 
            // edit_btn
            // 
            this.edit_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.edit_btn.FlatAppearance.BorderSize = 0;
            this.edit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_btn.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.edit_btn.IconColor = System.Drawing.Color.Black;
            this.edit_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.edit_btn.IconSize = 40;
            this.edit_btn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.edit_btn.Location = new System.Drawing.Point(110, 0);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(55, 60);
            this.edit_btn.TabIndex = 2;
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click_1);
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton1.Location = new System.Drawing.Point(55, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(55, 60);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // plus_btn
            // 
            this.plus_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.plus_btn.FlatAppearance.BorderSize = 0;
            this.plus_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plus_btn.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.plus_btn.IconColor = System.Drawing.Color.Black;
            this.plus_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.plus_btn.IconSize = 40;
            this.plus_btn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.plus_btn.Location = new System.Drawing.Point(0, 0);
            this.plus_btn.Name = "plus_btn";
            this.plus_btn.Size = new System.Drawing.Size(55, 60);
            this.plus_btn.TabIndex = 0;
            this.plus_btn.UseVisualStyleBackColor = true;
            this.plus_btn.Click += new System.EventHandler(this.plus_btn_Click_1);
            // 
            // desktop_pnl
            // 
            this.desktop_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.desktop_pnl.Controls.Add(this.ordini_data);
            this.desktop_pnl.Controls.Add(this.magazzino_data);
            this.desktop_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktop_pnl.Location = new System.Drawing.Point(230, 60);
            this.desktop_pnl.Name = "desktop_pnl";
            this.desktop_pnl.Size = new System.Drawing.Size(838, 532);
            this.desktop_pnl.TabIndex = 2;
            // 
            // ordini_data
            // 
            this.ordini_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordini_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordine,
            this.cliente,
            this.prezzo,
            this.note});
            this.ordini_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordini_data.Location = new System.Drawing.Point(0, 0);
            this.ordini_data.Name = "ordini_data";
            this.ordini_data.RowTemplate.Height = 25;
            this.ordini_data.Size = new System.Drawing.Size(838, 532);
            this.ordini_data.TabIndex = 1;
            // 
            // ordine
            // 
            this.ordine.HeaderText = "Ordine";
            this.ordine.Name = "ordine";
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            // 
            // prezzo
            // 
            this.prezzo.HeaderText = "Prezzo";
            this.prezzo.Name = "prezzo";
            // 
            // note
            // 
            this.note.HeaderText = "Note";
            this.note.Name = "note";
            // 
            // magazzino_data
            // 
            this.magazzino_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.magazzino_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codice,
            this.quantita_codice,
            this.prezzo_codice,
            this.descrizione});
            this.magazzino_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.magazzino_data.Location = new System.Drawing.Point(0, 0);
            this.magazzino_data.Name = "magazzino_data";
            this.magazzino_data.RowTemplate.Height = 25;
            this.magazzino_data.Size = new System.Drawing.Size(838, 532);
            this.magazzino_data.TabIndex = 0;
            // 
            // codice
            // 
            this.codice.HeaderText = "Codice";
            this.codice.Name = "codice";
            // 
            // quantita_codice
            // 
            this.quantita_codice.HeaderText = "Quantità";
            this.quantita_codice.Name = "quantita_codice";
            // 
            // prezzo_codice
            // 
            this.prezzo_codice.HeaderText = "Prezzo";
            this.prezzo_codice.Name = "prezzo_codice";
            // 
            // descrizione
            // 
            this.descrizione.HeaderText = "Descrizione";
            this.descrizione.Name = "descrizione";
            // 
            // settings_pnl
            // 
            this.settings_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.settings_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settings_pnl.Location = new System.Drawing.Point(230, 60);
            this.settings_pnl.Name = "settings_pnl";
            this.settings_pnl.Size = new System.Drawing.Size(838, 532);
            this.settings_pnl.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 592);
            this.Controls.Add(this.settings_pnl);
            this.Controls.Add(this.desktop_pnl);
            this.Controls.Add(this.bar_pnl);
            this.Controls.Add(this.dock_pnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(716, 384);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Workmate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dock_pnl.ResumeLayout(false);
            this.logo_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bar_pnl.ResumeLayout(false);
            this.desktop_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ordini_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazzino_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel dock_pnl;
        private Panel logo_pnl;
        private Panel bar_pnl;
        private Panel desktop_pnl;
        private FontAwesome.Sharp.IconButton impostazioni_btn;
        private FontAwesome.Sharp.IconButton ordini_btn;
        private FontAwesome.Sharp.IconButton magazzino_btn;
        private FontAwesome.Sharp.IconButton home_btn;
        private FontAwesome.Sharp.IconButton bars_btn;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton plus_btn;
        private FontAwesome.Sharp.IconButton edit_btn;
        private DataGridView ordini_data;
        private DataGridView magazzino_data;
        private DataGridViewTextBoxColumn codice;
        private DataGridViewTextBoxColumn quantita_codice;
        private DataGridViewTextBoxColumn prezzo_codice;
        private DataGridViewTextBoxColumn descrizione;
        private DataGridViewTextBoxColumn ordine;
        private DataGridViewTextBoxColumn cliente;
        private DataGridViewTextBoxColumn prezzo;
        private DataGridViewTextBoxColumn note;
        private Panel settings_pnl;
    }
}