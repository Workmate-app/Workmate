namespace Workmate
{
    partial class Cambia_dirdb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cambia_dirdb));
            this.dir_txt = new System.Windows.Forms.TextBox();
            this.sfoglia_btn = new System.Windows.Forms.Button();
            this.no_btn = new FontAwesome.Sharp.IconButton();
            this.ok_btn = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.sfogliaCartelle_dlg = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // dir_txt
            // 
            this.dir_txt.Location = new System.Drawing.Point(12, 48);
            this.dir_txt.Name = "dir_txt";
            this.dir_txt.Size = new System.Drawing.Size(300, 23);
            this.dir_txt.TabIndex = 0;
            // 
            // sfoglia_btn
            // 
            this.sfoglia_btn.Location = new System.Drawing.Point(318, 48);
            this.sfoglia_btn.Name = "sfoglia_btn";
            this.sfoglia_btn.Size = new System.Drawing.Size(75, 23);
            this.sfoglia_btn.TabIndex = 1;
            this.sfoglia_btn.Text = "Sfoglia";
            this.sfoglia_btn.UseVisualStyleBackColor = true;
            this.sfoglia_btn.Click += new System.EventHandler(this.sfoglia_btn_Click);
            // 
            // no_btn
            // 
            this.no_btn.FlatAppearance.BorderSize = 0;
            this.no_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no_btn.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.no_btn.IconColor = System.Drawing.Color.Black;
            this.no_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.no_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.no_btn.Location = new System.Drawing.Point(329, 113);
            this.no_btn.Name = "no_btn";
            this.no_btn.Size = new System.Drawing.Size(64, 50);
            this.no_btn.TabIndex = 42;
            this.no_btn.UseVisualStyleBackColor = true;
            this.no_btn.Click += new System.EventHandler(this.no_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.FlatAppearance.BorderSize = 0;
            this.ok_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok_btn.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.ok_btn.IconColor = System.Drawing.Color.Black;
            this.ok_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ok_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ok_btn.Location = new System.Drawing.Point(259, 113);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(64, 50);
            this.ok_btn.TabIndex = 41;
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 43;
            this.label1.Text = "Percorso:";
            // 
            // Cambia_dirdb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 175);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.no_btn);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.sfoglia_btn);
            this.Controls.Add(this.dir_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cambia_dirdb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambia percorso database";
            this.Load += new System.EventHandler(this.Cambia_dirdb_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox dir_txt;
        private Button sfoglia_btn;
        private FontAwesome.Sharp.IconButton no_btn;
        private FontAwesome.Sharp.IconButton ok_btn;
        private Label label1;
        private FolderBrowserDialog sfogliaCartelle_dlg;
    }
}