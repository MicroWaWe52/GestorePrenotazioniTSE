using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppGestorePrenotazioniTSE
{
    public partial class Form1 : Form
    {
        private Prenotazioni prenotazioni;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prenotazioni = Helper.GetPrenotazioni();
            var rawprenotazione = Helper.GetPrenotazioniString(prenotazioni);
            var prenotazioniArray = rawprenotazione.Split('/');
            Array.Resize(ref prenotazioniArray, prenotazioniArray.Length - 1);
            foreach (var prenotazione in prenotazioniArray)
            {
                listBoxPrenotazioni.Items.Add(prenotazione);
            }
        }
    }
}
