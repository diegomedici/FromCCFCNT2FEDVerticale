namespace FromCCFCNT2FEDVerticale
{
    public class TracciatoFED
    {
        public TracciatoFED(TracciatoCNT2FED cnt2Fed)
        {
            
        }


        private string codiceTargatura;
        private string periodoCompetenza;
        private string codiceRegionale;
        private string codiceRicetta;
        private int progressivoRicetta;
        private string provincia;
        private string minsan;
        private int quantita;
        private string prodotto;
        private string principioAttivo;
        private string atc;
        private int prezzoLordo;
        private int prezzoNetto;
        private int importoCompenso;
        private string codiceAssistito;
        private bool codiceAssistitoDaTesseraSanitaria;
        private decimal prezzoAcquisto;
        private DateTime dataChiusura;
        private string codiceFarmaciaAsl;
        private int percentualeCompenso;
        private int unitaPosologiche;
        private DateTime? dataPrescrizione;
        private int compensoPerPrezzo;
        private string terminatore = "*";

        public string CodiceTargatura
        {
            get { return codiceTargatura; }
            set { codiceTargatura = value.Trim(); }
        }
        public string PeriodoCompetenza
        {
            get { return periodoCompetenza; }
            set { periodoCompetenza = value.Trim(); }
        }
        public string CodiceRegionale
        {
            get { return codiceRegionale; }
            set { codiceRegionale = value.Trim(); }
        }
        public string CodiceRicetta
        {
            get { return codiceRicetta; }
            set { codiceRicetta = value.Trim(); }
        }
        public int ProgressivoRicetta
        {
            get { return progressivoRicetta; }
            set { progressivoRicetta = value; }
        }
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value.Trim(); }
        }
        public string Minsan
        {
            get { return minsan; }
            set { minsan = value.Trim(); }
        }
        public int Quantita
        {
            get { return quantita; }
            set { quantita = value; }
        }
        public string Prodotto
        {
            get
            {
                int maxLen = 60;
                if (prodotto.Length <= maxLen)
                {
                    return prodotto;
                }
                else
                {
                    return prodotto.Substring(0, maxLen);
                }
            }

            set
            {
                prodotto = value.Trim();
            }
        }
        public string PrincipioAttivo
        {
            get
            {
                int maxLen = 100;
                if (principioAttivo.Length <= maxLen)
                {
                    return principioAttivo;
                }
                else
                {
                    return principioAttivo.Substring(0, maxLen);
                }
            }
            set { principioAttivo = value.Trim(); }
        }
        public string Atc
        {
            get { return atc; }
            set { atc = value.Trim(); }
        }
        public int PrezzoLordo
        {
            get { return prezzoLordo; }
            set { prezzoLordo = value; }
        }
        public int PrezzoNetto
        {
            get { return prezzoNetto; }
            set { prezzoNetto = value; }
        }
        public int ImportoCompenso
        {
            get { return importoCompenso; }
            set { importoCompenso = value; }
        }
        public string CodiceAssistito
        {
            get
            {
                int maxLen = 16;
                if (CodiceAssistito.Length <= maxLen)
                {
                    return codiceAssistito;
                }
                else
                {
                    return codiceAssistito.Substring(0, maxLen);
                }
            }
            set { codiceAssistito = value; }
        }
        public bool CodiceAssistitoDaTesseraSanitaria
        {
            get { return codiceAssistitoDaTesseraSanitaria; }
            set { codiceAssistitoDaTesseraSanitaria = value; }
        }
        public decimal PrezzoAcquisto
        {
            get { return prezzoAcquisto; }
            set { prezzoAcquisto = value; }
        }
        public DateTime DataChiusura
        {
            get { return dataChiusura; }
            set { dataChiusura = value; }
        }
        public string CodiceFarmaciaAsl
        {
            get { return codiceFarmaciaAsl; }
            set { codiceFarmaciaAsl = value; }
        }
        public int PercentualeCompenso
        {
            get { return percentualeCompenso; }
            set { percentualeCompenso = value; }
        }
        public int UnitaPosologiche
        {
            get { return unitaPosologiche; }
            set { unitaPosologiche = value; }
        }
        public DateTime? DataPrescrizione
        {
            get { return this.dataPrescrizione; }
            set { this.dataPrescrizione = value; }
        }
        public int CompensoPerPezzo
        {
            get { return compensoPerPrezzo; }
            set { compensoPerPrezzo = value; }
        }

        public string ToString(string strChiaveRecord)
        {
            string str = "";

            string strDataPrescrizione = "        ";
            if (this.DataPrescrizione != null)
            {
                DateTime dtTemp = (DateTime)this.DataPrescrizione;
                strDataPrescrizione = dtTemp.ToString("yyyyMMdd");
            }

            str += CodiceTargatura.PadRight(10, ' ');
            str += PeriodoCompetenza.PadRight(6, ' ');
            str += CodiceRegionale.PadRight(10, ' ');
            str += CodiceRicetta.PadRight(10, ' ');
            str += ProgressivoRicetta.ToString("00000");
            str += Provincia.PadRight(2, ' ');
            str += Minsan.PadRight(9, ' ');
            str += Quantita.ToString("0000");
            str += Prodotto.PadRight(60, ' ');
            str += PrincipioAttivo.PadRight(100, ' ');
            str += Atc.PadRight(7, ' '); // 217 + 7
            str += PrezzoLordo.ToString("0000000000"); // 224 +10
            str += PrezzoNetto.ToString("0000000000"); // 234 +10
            str += ImportoCompenso.ToString("0000000000"); // 244 +10
            str += prezzoAcquisto.ToString("0000000000"); // 254 +10
            str += DataChiusura.ToString("yyyyMMdd");
            str += CodiceFarmaciaAsl.PadRight(10, ' '); // 272 + 10
            str += PercentualeCompenso.ToString("00000"); // 282 + 5
            str += UnitaPosologiche.ToString("00000");
            str += strDataPrescrizione; // 292 + 8
            str += CompensoPerPezzo.ToString("0000000000"); // 300 + 10 
            str += new string(' ', 179);
            str += strChiaveRecord.PadLeft(16, '0'); // 489+16 
            str += terminatore;

            return str;
        }

        public string ToStringDatiAssistito(string strChiaveRecord)
        {
            //Imposto la fonte del codice dell'assistito
            string strFonteCodiceAssistito = "R";
            if (codiceAssistitoDaTesseraSanitaria) { strFonteCodiceAssistito = "T"; }

            //Se non ho un codice assistito, non comunico neppure la provenienza del codice
            if (codiceAssistito.Equals(string.Empty)) { strFonteCodiceAssistito = ""; }

            string str = "";

            str += CodiceTargatura.PadRight(10, ' ');
            str += PeriodoCompetenza.PadRight(6, ' ');
            str += ProgressivoRicetta.ToString("00000");
            str += strFonteCodiceAssistito.PadRight(1, ' ');
            str += codiceAssistito.PadRight(30, ' ');
            str += new string(' ', 430);
            //str += NumRiga.ToString("0000000000");
            str += strChiaveRecord.PadLeft(16, '0');
            str += terminatore;

            return str;
        }
    }
}