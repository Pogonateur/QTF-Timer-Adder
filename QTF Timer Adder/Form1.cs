using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTF_Timer_Adder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            if (checkEntries())
            {
                result.Text = addEntries(entry1.Text, entry2.Text);
            }
        }

        private bool checkEntries()
        {
            string format = "\\d(:|\\.| )\\d\\d(:|\\.| )\\d\\d\\d";
            Regex rgex = new Regex(format);
            if (rgex.IsMatch(entry1.Text) && rgex.IsMatch(entry2.Text))
            {
                return true;
            }
            return false;
        }

        private string addEntries(string e1, string e2)
        {
            int totalmsE1 = 0;
            int totalmsE2 = 0;

            char[] delimiterChars = { ':', '.', ' ' };
            string[] wordsE1 = e1.Split(delimiterChars);
            string[] wordsE2 = e2.Split(delimiterChars);

            int minE1 = Int32.Parse(wordsE1[0]);
            int minE2 = Int32.Parse(wordsE2[0]);
            int secE1 = Int32.Parse(wordsE1[1]);
            int secE2 = Int32.Parse(wordsE2[1]);
            int msE1 = Int32.Parse(wordsE1[2]);
            int msE2 = Int32.Parse(wordsE2[2]);

            totalmsE1 = (minE1 * 60 * 1000) + (secE1 * 1000) + (msE1);
            totalmsE2 = (minE2 * 60 * 1000) + (secE2 * 1000) + (msE2);

            int msResult = 0;
            int secResult = 0;
            int minResult = 0;

            msResult = (totalmsE1 % 1000) + (totalmsE2 % 1000);
            if (msResult/1000>=1)
            {
                msResult = msResult % 1000;
                secResult += 1;
            }

            secResult += secE1 + secE2;
            if (secResult-59>=1)
            {
                secResult -= 60;
                minResult += 1;
            }

            minResult += minE1 + minE2;

            string msString = msResult.ToString();
            string secString = secResult.ToString();

            if (msResult-100<0)
            {
                msString = "0" + msString;
                if (msResult - 10 < 0)
                {
                    msString = "0" + msString;
                }
            }
            if (secResult - 10 < 0)
            {
                secString = "0" + secString;
            }

            string res = "" + minResult + ":" + secString + "." + msString;

            return res;
        }
    }
}
