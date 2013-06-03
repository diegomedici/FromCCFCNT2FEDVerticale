using System;
using System.Text;

namespace FromCCFCNT2FEDVerticale
{
    public class TracciatoCNT2FED
    {
        public string Anno { get; set; }
        public string Mese { get; set; }
        private string CodiceTargatura;
        public string PrimoPezzo { get; set; }
        public string CodiceAslFarmacia { get; set; }
        public string PrezzoAcquisto { get; set; }
        public string DataChiusura { get; set; }
        public string DataPrescrizione { get; set; }
        public string UnitaPosologiche { get; set; }
        public int Counter { get; set; }

        public int Quantita { get; set; }

        public decimal ImportoCompenso { get { return Quantita*4.5M*1.21M * 100000M; } }

        public string Chiave
        {
            get { return Anno + Mese + CodiceTargatura.PadLeft(5, '0') + Counter.ToString().PadLeft(5, '0'); }
        }

        public TracciatoCNT2FED(string line, int counter)
        {
            Counter = counter;
            PrimoPezzo = line.Substring(0, 243);
            CodiceAslFarmacia = line.Substring(263, 10);
            PrezzoAcquisto = line.Substring(294, 10);
            DataPrescrizione = line.Substring(304, 8);
            DataChiusura = line.Substring(312, 8);
            UnitaPosologiche = line.Substring(325, 5);

            Quantita = Convert.ToInt32(line.Substring(52, 4));
            Anno = line.Substring(12, 4);
            Mese = line.Substring(10, 2);
            CodiceTargatura = line.Substring(0, 10).Trim();
        }

        public string ToFED()
        {
            StringBuilder str = new StringBuilder(506);
            str.Append(PrimoPezzo);
            str.Append(ImportoCompenso.ToString("0000000000"));
            str.Append(PrezzoAcquisto);
            str.Append(DataChiusura);
            str.Append(CodiceAslFarmacia);
            str.Append("00000"); //Percentuale Compenso
            str.Append(UnitaPosologiche);
            str.Append(DataPrescrizione);
            str.Append("0000450000"); //Compenso per pezzo
            str.Append(new string(' ', 179));
            str.Append(Chiave);
            str.Append("*");
            return str.ToString();
        }
    }
}