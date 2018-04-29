using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppGestorePrenotazioniTSE
{
    class Helper
    {
        public static Prenotazioni GetPrenotazioni()
        {
            var stringPrenotazioni = ReadPrenotazioni();
            var rawPrenotazioni = stringPrenotazioni.Split('/');
            Array.Resize(ref rawPrenotazioni, rawPrenotazioni.Length - 1);
            var prenotazioni = new Prenotazioni { ListaPrenotazioni = new List<Prenotazione>() };
            foreach (var rawPrenotazione in rawPrenotazioni)
            {
                var infoPrenotazione = rawPrenotazione.Split(',');
                var prenotazione = new Prenotazione
                {
                    Evento = infoPrenotazione[0],
                    Nome = infoPrenotazione[1],
                    Cognome = infoPrenotazione[2],
                    Email = infoPrenotazione[3],
                    Numero = infoPrenotazione[4],
                    Posti = infoPrenotazione[6]

                };
                prenotazioni.ListaPrenotazioni.Add(prenotazione);
            }


            return prenotazioni;

        }

        private static string ReadPrenotazioni()
        {
            var request = (FtpWebRequest)WebRequest.Create("ftp://www.teatrotse.com/teatrotse.com/Biglietteria/prenotazioni.txt");
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("3835532@aruba.it", "Teatro09127");
            var response = (FtpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }

        private void WritePrenotazioni(Prenotazioni prenotazioni)
        {
            var request = (FtpWebRequest)WebRequest.Create("ftp://www.teatrotse.com/teatrotse.com/Biglietteria/prenotazioni.txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("3835532@aruba.it", "Teatro09127");
            var buffer = Encoding.UTF8.GetBytes(GetPrenotazioniString(prenotazioni));
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Close();
            }
        }

        public static string GetPrenotazioniString(Prenotazioni prenotazioni)
        {
            var rawPrenotazioni = "";
            foreach (var prenotazione in prenotazioni.ListaPrenotazioni)
            {
                rawPrenotazioni += $"{prenotazione.Evento},{prenotazione.Nome},{prenotazione.Cognome},{prenotazione.Email},{prenotazione.Numero},,{prenotazione.Posti}/";
            }
            return rawPrenotazioni;
        }
    }


}
