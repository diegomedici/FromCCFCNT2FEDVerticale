using System;
using System.Text;

namespace FromCCFCNT2FEDVerticale
{
    public class TracciatoCCF2FED
    {
        public string Anno { get; set; }
        public string Mese { get; set; }
        private string CodiceTargatura;
        public string PrimoPezzo { get; set; }
        public int Counter { get; set; }
        public string OriginalKey { get; set; }

        public TracciatoCCF2FED(string line, int counter)
        {
            Counter = counter;
            PrimoPezzo = line.Substring(0, 39);
            Anno = line.Substring(12, 4);
            Mese = line.Substring(10, 2);
            CodiceTargatura = line.Substring(0, 10).Trim();
            OriginalKey = line.Substring(488, 10);
        }

        public string Chiave
        {
            get { return Anno + Mese + CodiceTargatura.PadLeft(5, '0') + Counter.ToString().PadLeft(5, '0'); }
        }

        public string ToFED()
        {
            StringBuilder str = new StringBuilder(506);
            str.Append(PrimoPezzo);
            str.Append(new string(' ', 443));
            str.Append(Chiave);
            str.Append("*");
            return str.ToString();
        }
    }
}