/* Keegan Chan
 * 3 27 2018
 * U2KeeganOlFisingHole
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
            int TroutValue, PikeValue, PickerelValue, TotalValue;
            String strTrout, strPike, strPickerel, strTotal;
            string stringInput = txbInput.Text;
            Char charRange = '\r';

            int startNewLine = stringInput.IndexOf(charRange);
            int start2nd = stringInput.IndexOf(charRange) + 2;
            strTrout = txbInput.Text.Substring(0, txbInput.Text.IndexOf("\r"));
            int.TryParse(strTrout, out TroutValue);
            strPike = txbInput.Text.Substring(txbInput.Text.IndexOf("\r") + 2, 1);
            int.TryParse(strPike, out PikeValue);
            strPickerel = txbInput.Text.Substring(txbInput.Text.IndexOf("\r") + 5, 1);
            int.TryParse(strPickerel, out PickerelValue);
            strTotal = txbInput.Text.Substring(txbInput.Text.LastIndexOf("\r") + 2, 1);
            int.TryParse(strTotal, out TotalValue);
            MessageBox.Show(strTrout);
            MessageBox.Show(strPike);
            MessageBox.Show(strPickerel);
            MessageBox.Show(strTotal);

        }
    }
}
