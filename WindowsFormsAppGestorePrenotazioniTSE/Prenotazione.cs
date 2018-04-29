using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppGestorePrenotazioniTSE
{
    class Prenotazione
    {
        public string Evento;
        public string Nome;
        public string Cognome;
        public string Email;
        public string Numero;
        public string Posti;

        public Prenotazione()
        {

        }

        public override bool Equals(object obj)
        {
            var prenotazione = obj as Prenotazione;
            return prenotazione != null &&
                   Evento == prenotazione.Evento &&
                   Nome == prenotazione.Nome &&
                   Cognome == prenotazione.Cognome &&
                   Email == prenotazione.Email &&
                   Numero == prenotazione.Numero &&
                   Posti == prenotazione.Posti;
        }
    }
}
