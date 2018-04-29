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

            string[] eventi = new string[prenotazioni.ListaPrenotazioni.Count];
            for (var index = 0; index < prenotazioni.ListaPrenotazioni.Count; index++)
            {
                var prenotazione = prenotazioni.ListaPrenotazioni[index];
                eventi[index] = prenotazione.Evento;
            }
            var q = eventi.Distinct().ToArray();
            comboBoxSearchEventi.Items.Clear();
            comboBoxSearchEventi.Items.Add("Tutti");
            foreach (var evento in q)
            {
                comboBoxSearchEventi.Items.Add(evento);
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
            var indexOf = int.MaxValue;
            var p = Helper.GetPrenotazioneString(listBoxPrenotazioni.Text);
            for (var i = 0; i < prenotazioni.ListaPrenotazioni.Count; i++)
            {
                if (p.Equals(prenotazioni.ListaPrenotazioni[i]))
                {
                    indexOf = i;
                    break;
                }
            }
            try
            {
                prenotazioni.ListaPrenotazioni.RemoveAt(indexOf);
                Helper.WritePrenotazioni(prenotazioni);
            }
            catch (Exception)
            {
                MessageBox.Show("Selezioina una prenotazione");
            }
            finally { Aggiorna(); }
        }

        private void textBoxCerca_TextChanged(object sender, EventArgs e)
        {
            comboBoxSearchEventi.Text = "Tutti";
            var searchPrenotazioni = new List<Prenotazione>();
            var i = 0;
            foreach (var prenotazione in prenotazioni.ListaPrenotazioni)
            {
                if (prenotazione.Nome.Contains(textBoxCerca.Text) || prenotazione.Cognome.Contains(textBoxCerca.Text))
                {
                    searchPrenotazioni.Add(prenotazione);
                    i++;
                }
            }
            listBoxPrenotazioni.Items.Clear();
            var p = new Prenotazioni { ListaPrenotazioni = searchPrenotazioni };
            var rawprenotazione = Helper.GetPrenotazioniString(p);
            var prenotazioniArray = rawprenotazione.Split('/');
            Array.Resize(ref prenotazioniArray, prenotazioniArray.Length - 1);
            foreach (var prenotazione in prenotazioniArray)
            {
                listBoxPrenotazioni.Items.Add(prenotazione);
            }
        }

        private void comboBoxSearchEventi_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBoxSearchEventi.Text == "Tutti")
            {
                Aggiorna();
            }
            else
            {
                textBoxCerca.Text = "";
                var searchPrenotazioni = new List<Prenotazione>();
                var i = 0;
                foreach (var prenotazione in prenotazioni.ListaPrenotazioni)
                {
                    if (prenotazione.Evento == comboBoxSearchEventi.Text)
                    {
                        searchPrenotazioni.Add(prenotazione);
                        i++;
                    }
                }
                listBoxPrenotazioni.Items.Clear();
                var p = new Prenotazioni { ListaPrenotazioni = searchPrenotazioni };
                var rawprenotazione = Helper.GetPrenotazioniString(p);
                var prenotazioniArray = rawprenotazione.Split('/');
                Array.Resize(ref prenotazioniArray, prenotazioniArray.Length - 1);
                foreach (var prenotazione in prenotazioniArray)
                {
                    listBoxPrenotazioni.Items.Add(prenotazione);
                }
            }

        }
    }
}
