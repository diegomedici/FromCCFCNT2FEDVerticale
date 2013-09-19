using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FromCCFCNT2FEDVerticale
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;

            string fileNameCNT = "201309030928420000090105.CNT"; //args[0];
            string fileNameCCF = "201309030933060000090105.CCF"; //args[1];
            // Read the file and display it line by line.

            Dictionary<string, string> mapsFromOriginalAndNewKey = new Dictionary<string, string>();

            //CCF
            StreamReader fileCCF =
               new StreamReader(@"c:\FED\" + fileNameCCF);
            counter = 0;
            string fileDatiAssistito = string.Empty;
            using (StreamWriter outfile =
            new StreamWriter(@"c:\FED\DatiAssistito.txt"))
            {
                while ((line = fileCCF.ReadLine()) != null)
                {
                    counter++;
                    TracciatoCCF2FED ccf2Fed = new TracciatoCCF2FED(line, counter);
                    mapsFromOriginalAndNewKey.Add(ccf2Fed.OriginalKey, ccf2Fed.Chiave);
                    string o = ccf2Fed.ToFED();
                    //Console.WriteLine(o);
                    outfile.WriteLine(o);

                    if (string.IsNullOrEmpty(fileDatiAssistito))
                    {
                        fileDatiAssistito = string.Format(@"c:\FED\DPC_{0}{1}_ASS_{2}.txt", ccf2Fed.Anno, ccf2Fed.Mese,
                                                            DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                    }
                }
            }

            fileCCF.Close();

            File.Move(@"c:\FED\DatiAssistito.txt", fileDatiAssistito);
            


            StreamReader fileCNT =
               new StreamReader(@"c:\FED\" + fileNameCNT);

            string fileNameDatiRicette = string.Empty;
            using (StreamWriter outfile =
            new StreamWriter(@"c:\FED\DatiRicette.txt"))
            {
                while ((line = fileCNT.ReadLine()) != null)
                {
                    //counter++;
                    TracciatoCNT2FED cnt2Fed = new TracciatoCNT2FED(line, counter);
                    string o = cnt2Fed.ToFED(mapsFromOriginalAndNewKey);
                    //Console.WriteLine(o);
                    outfile.WriteLine(o);

                    if(string.IsNullOrEmpty(fileNameDatiRicette))
                    {
                        fileNameDatiRicette = string.Format(@"c:\FED\DPC_{0}{1}_RIC_{2}.txt", cnt2Fed.Anno, cnt2Fed.Mese,
                                                            DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                    }
                }
            }

            fileCNT.Close();

            File.Move(@"c:\FED\DatiRicette.txt", fileNameDatiRicette);



            // Suspend the screen.
            Console.ReadLine();
        }
    }
}
