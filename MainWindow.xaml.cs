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
            strPike = txbInput.Text.Substring(txbInput.Text.IndexOf("\r") + 2, txbInput.Text.IndexOf("\r", txbInput.Text.IndexOf("\r") + 1) - txbInput.Text.IndexOf("\r"));
            int.TryParse(strPike, out PikeValue);
            /* NIU
            MessageBox.Show((strTrout.Length + 1 + strPike.Length + 1).ToString());
            MessageBox.Show(txbInput.Text);
            MessageBox.Show((txbInput.Text.LastIndexOf("\r")).ToString());
            MessageBox.Show("Trout: " + strTrout); */

            strPickerel = txbInput.Text.Substring(strTrout.Length + 1 + strPike.Length + 1, txbInput.Text.LastIndexOf("\r") - (strTrout.Length + 1 + strPike.Length + 1));
            int.TryParse(strPickerel, out PickerelValue);
            strTotal = txbInput.Text.Substring(txbInput.Text.LastIndexOf("\r") + 2, strInput.Length - (txbInput.Text.LastIndexOf("\r") + 2));
            int.TryParse(strTotal, out TotalValue);
            /* NIU
            MessageBox.Show(strTrout);
            MessageBox.Show(strPike);
            MessageBox.Show(strPickerel);
            MessageBox.Show(strTotal);*/

            int tempTotal = 0;
            int counter = 0;
            int possibleCombinations = 0;

            //Find how much from only trout
            while (tempTotal < TotalValue)
            {
                counter++;

                tempTotal = TroutValue * counter;

                if (tempTotal > TotalValue)
                {
                    Console.WriteLine("exempted line");
                }
                else
                {
                    txbOutput.Text = txbOutput.Text + "\r\nTrout:" + counter + " Pike:0 Pickerel:0";
                    possibleCombinations++;
                }
            }

            //reset temp values
            tempTotal = 0;
            counter = 0;

            //Find how much from only pike
            while (tempTotal < TotalValue)
            {
                counter++;

                tempTotal = PikeValue * counter;

                if (tempTotal > TotalValue)
                {
                    Console.WriteLine("exempted line");
                }
                else
                {
                    txbOutput.Text = txbOutput.Text + "\r\nTrout:0 Pike:" + counter + " Pickerel:0";
                    possibleCombinations++;
                }
            }

            //reset temp values
            tempTotal = 0;
            counter = 0;

            //Find how much from only pickerel
            while (tempTotal < TotalValue)
            {
                counter++;

                tempTotal = PickerelValue * counter;

                if (tempTotal > TotalValue)
                {
                    Console.WriteLine("exempted line");
                }
                else
                {
                    txbOutput.Text = txbOutput.Text + "\r\nTrout:0 Pike:0 Pickerel:" + counter;
                    possibleCombinations++;
                }
            }

            //reset temp values
            tempTotal = 0;
            counter = -1;
            int counter2 = -1;
            int counter3 = -1;
            int tempTroutTotal = 0;
            int tempPikeTotal = 0;
            int tempPickerelTotal = 0;
            int tempTotal2 = 0;
            int tempTotal3 = 0;
            string strOutputText;
            string strNewLine;

            //combination trout then pike then pickerel
            while (tempTotal < TotalValue)
            {
                counter++;

                tempTroutTotal = TroutValue * counter;
                tempTotal = tempTroutTotal;

                //add pike
                while (tempTotal2 < TotalValue)
                {
                    counter2++;

                    tempPikeTotal = PikeValue * counter2;
                    tempTotal2 = tempTroutTotal + tempPikeTotal;

                    //add pickerel
                    while (tempTotal3 < TotalValue)
                    {
                        counter3++;

                        tempPickerelTotal = PickerelValue * counter3;
                        tempTotal3 = tempTroutTotal + tempPikeTotal + tempPickerelTotal;

                        //output a combination
                        if (tempTotal3 > TotalValue)
                        {
                            Console.WriteLine("exempted line");
                        }
                        else
                        {
                            strOutputText = txbOutput.Text;
                            strNewLine = "\r\nTrout:" + counter + " Pike:" + counter2 + " Pickerel:" + counter3;
                            //check that the line hasn't been entered before
                            if (strOutputText.Contains(strNewLine))
                            {
                                Console.WriteLine("exempted line");
                            }
                            else
                            {
                                txbOutput.Text = txbOutput.Text + strNewLine;
                                possibleCombinations++;
                            }
                        }
                    }

                    //output a combination
                    if (tempPikeTotal + tempTroutTotal + tempPickerelTotal > TotalValue)
                    {
                        Console.WriteLine("exempted line");
                    }
                    else
                    {
                        strOutputText = txbOutput.Text;
                        strNewLine = "\r\nTrout:" + counter + " Pike:" + counter2 + " Pickerel:" + counter3;
                        //check that the line hasn't been entered before
                        if (strOutputText.Contains(strNewLine))
                        {
                            Console.WriteLine("exempted line");
                        }
                        else
                        {
                            txbOutput.Text = txbOutput.Text + strNewLine;
                            possibleCombinations++;
                        }
                    }

                    //reset pickerel loop
                    counter3 = 0;
                    tempTotal3 = 0;
                }

                //output a combination
                if (tempPikeTotal + tempTroutTotal + tempPickerelTotal > TotalValue)
                {
                    Console.WriteLine("exempted line");
                }
                else
                {
                    txbOutput.Text = txbOutput.Text + "\r\nTrout:" + counter + " Pike:" + counter2 + " Pickerel:" + counter3;
                    possibleCombinations++;
                }

                //reset pike loop
                counter2 = 0;
                tempTotal2 = 0;
            }

            //reset temp values
            tempTotal = 0;
            counter = 0;
            counter2 = 0;
            counter3 = 0;
            tempTroutTotal = 0;
            tempPikeTotal = 0;
            tempPickerelTotal = 0;
            tempTotal2 = 0;
            tempTotal3 = 0;

            //Just Trout and Pickerel
            while (tempTotal < TotalValue)
            {
                counter++;

                tempTroutTotal = TroutValue * counter;
                tempTotal = tempTroutTotal;
                
                    //add pickerel
                    while (tempTotal3 < TotalValue)
                    {
                        counter3++;

                        tempPickerelTotal = PickerelValue * counter3;
                        tempTotal3 = tempTroutTotal + tempPickerelTotal;

                        //output a combination
                        if (tempTotal3 >= TotalValue)
                        {
                            Console.WriteLine("exempted line");
                        }
                        else
                        {
                            txbOutput.Text = txbOutput.Text + "\r\nTrout:" + counter + " Pike:" + counter2 + " Pickerel:" + counter3;
                            possibleCombinations++;
                        }
                    }
                    
                //output a combination
                if (tempTroutTotal + tempPickerelTotal > TotalValue)
                {
                    Console.WriteLine("exempted line");
                }
                else
                {
                    txbOutput.Text = txbOutput.Text + "\r\nTrout:" + counter + " Pike:" + counter2 + " Pickerel:" + counter3;
                    possibleCombinations++;
                }

                //reset pickerel loop
                counter3 = 0;
                tempTotal3 = 0;
            }
            
            //reset temp values
            tempTotal = 0;
            counter = 0;
            counter2 = 0;
            counter3 = 0;
            tempTroutTotal = 0;
            tempPikeTotal = 0;
            tempPickerelTotal = 0;
            tempTotal2 = 0;
            tempTotal3 = 0;

            //Just Trout and Pike
            while (tempTotal < TotalValue)
            {
                counter++;

                tempTroutTotal = TroutValue * counter;
                tempTotal = tempTroutTotal;

                //add pike
                while (tempTotal2 < TotalValue)
                {
                    counter2++;

                    tempPikeTotal = PikeValue * counter2;
                    tempTotal2 = tempTroutTotal + tempPikeTotal;

                    //output a combination
                    if (tempTotal2 >= TotalValue)
                    {
                        Console.WriteLine("exempted line");
                    }
                    else
                    {
                        txbOutput.Text = txbOutput.Text + "\r\nTrout:" + counter + " Pike:" + counter2 + " Pickerel:" + counter3;
                        possibleCombinations++;
                    }
                }

                //output a combination
                if (tempTroutTotal + tempPikeTotal > TotalValue)
                {
                    Console.WriteLine("exempted line");
                }
                else
                {
                    txbOutput.Text = txbOutput.Text + "\r\nTrout:" + counter + " Pike:" + counter2 + " Pickerel:" + counter3;
                    possibleCombinations++;
                }

                //reset pike loop
                counter2 = 0;
                tempTotal2 = 0;
            }

            MessageBox.Show(possibleCombinations.ToString() + " possible combinations");
        }
    }
}
