/* Keegan Chan
 * 3 27 2018
 * U2KeeganOlFishingHole
 * Calculates all possible combination of fish when given point totals
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U2KeeganOlFishingHole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            //ints could have been created in the tryparses but it's more clear to have them listed here
            int TroutValue, PikeValue, PickerelValue, TotalValue;
            String strTrout, strPike, strPickerel, strTotal;
            string strInput = txbInput.Text;
            Char charRange = '\r';

            /* NIU
            MessageBox.Show((strInput.Length - txbInput.Text.LastIndexOf("\r") -2).ToString()); */

            int startNewLine = strInput.IndexOf(charRange);
            int start2nd = strInput.IndexOf(charRange) + 2;
            strTrout = txbInput.Text.Substring(0, txbInput.Text.IndexOf("\r"));
            int.TryParse(strTrout, out TroutValue);
            strPike = txbInput.Text.Substring(txbInput.Text.IndexOf("\r") + 2, txbInput.Text.IndexOf("\r", txbInput.Text.IndexOf("\r") + 1) - txbInput.Text.IndexOf("\r") );
            int.TryParse(strPike, out PikeValue);
            /* NIU
            MessageBox.Show((strTrout.Length + 1 + strPike.Length + 1).ToString());
            MessageBox.Show((txbInput.Text.LastIndexOf("\r")).ToString());
            */
            strPickerel = txbInput.Text.Substring(strTrout.Length + 1 + strPike.Length + 1, txbInput.Text.LastIndexOf("\r") - (strTrout.Length + 1 + strPike.Length + 1));
            int.TryParse(strPickerel, out PickerelValue);
            strTotal = txbInput.Text.Substring(txbInput.Text.LastIndexOf("\r") + 2, strInput.Length - (txbInput.Text.LastIndexOf("\r") + 2));
            int.TryParse(strTotal, out TotalValue);
            ///* NIU
            MessageBox.Show(strTrout);
            MessageBox.Show(strPike);
            MessageBox.Show(strPickerel);
            MessageBox.Show(strTotal);//*/

            int tempTotal = 0;
            int counter = 0;
            int possibleCombinations = 0;

            while(tempTotal != TotalValue)
            {
                counter++;

                tempTotal = TroutValue * counter;

                txbOutput.Text = txbOutput.Text + "\r\nTrout:" + counter + " Pike:0 Pickerel:0";
                possibleCombinations++;
            }
        }
    }
}
