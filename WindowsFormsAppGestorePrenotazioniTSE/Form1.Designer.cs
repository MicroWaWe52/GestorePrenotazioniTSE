namespace WindowsFormsAppGestorePrenotazioniTSE
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxPrenotazioni = new System.Windows.Forms.ListBox();
            this.buttonRifiuta = new System.Windows.Forms.Button();
            this.textBoxCerca = new System.Windows.Forms.TextBox();
            this.comboBoxSearchEventi = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listBoxPrenotazioni
            // 
            this.listBoxPrenotazioni.FormattingEnabled = true;
            this.listBoxPrenotazioni.Location = new System.Drawing.Point(13, 39);
            this.listBoxPrenotazioni.Name = "listBoxPrenotazioni";
            this.listBoxPrenotazioni.Size = new System.Drawing.Size(742, 277);
            this.listBoxPrenotazioni.TabIndex = 0;
            // 
            // buttonRifiuta
            // 
            this.buttonRifiuta.Location = new System.Drawing.Point(680, 322);
            this.buttonRifiuta.Name = "buttonRifiuta";
            this.buttonRifiuta.Size = new System.Drawing.Size(75, 23);
            this.buttonRifiuta.TabIndex = 2;
            this.buttonRifiuta.Text = "Rifiuta";
            this.buttonRifiuta.UseVisualStyleBackColor = true;
            this.buttonRifiuta.Click += new System.EventHandler(this.buttonRifiuta_Click);
            // 
            // textBoxCerca
            // 
            this.textBoxCerca.Location = new System.Drawing.Point(13, 13);
            this.textBoxCerca.Name = "textBoxCerca";
            this.textBoxCerca.Size = new System.Drawing.Size(160, 20);
            this.textBoxCerca.TabIndex = 3;
            this.textBoxCerca.TextChanged += new System.EventHandler(this.textBoxCerca_TextChanged);
            // 
            // comboBoxSearchEventi
            // 
            this.comboBoxSearchEventi.FormattingEnabled = true;
            this.comboBoxSearchEventi.Location = new System.Drawing.Point(633, 13);
            this.comboBoxSearchEventi.Name = "comboBoxSearchEventi";
            this.comboBoxSearchEventi.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSearchEventi.TabIndex = 4;
            this.comboBoxSearchEventi.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchEventi_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 357);
            this.Controls.Add(this.comboBoxSearchEventi);
            this.Controls.Add(this.textBoxCerca);
            this.Controls.Add(this.buttonRifiuta);
            this.Controls.Add(this.listBoxPrenotazioni);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPrenotazioni;
        private System.Windows.Forms.Button buttonRifiuta;
        private System.Windows.Forms.TextBox textBoxCerca;
        private System.Windows.Forms.ComboBox comboBoxSearchEventi;
    }
}

