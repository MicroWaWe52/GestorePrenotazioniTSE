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

        private void Aggiorna()
        {
            listBoxPrenotazioni.Items.Clear();
            prenotazioni = Helper.GetPrenotazioni();
            var rawprenotazione = Helper.GetPrenotazioniString(prenotazioni);
            var prenotazioniArray = rawprenotazione.Split('/');
            Array.Resize(ref prenotazioniArray, prenotazioniArray.Length - 1);
            foreach (var prenotazione in prenotazioniArray)
            {
                listBoxPrenotazioni.Items.Add(prenotazione);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Aggiorna();
            var timer = new Timer
            {
                Enabled = true,
                Interval = 60000
                
            };
            timer.Tick += Timer_Tick;
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Aggiorna();
        }

        private void buttonRifiuta_Click(object sender, EventArgs e)
        {

            try
            {
                prenotazioni.ListaPrenotazioni.RemoveAt(listBoxPrenotazioni.SelectedIndex);
                Helper.WritePrenotazioni(prenotazioni);
            }
            catch (Exception)
            {
                MessageBox.Show("Selezioina una prenotazione");
            }finally{Aggiorna();}
        }
    }
}
