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

namespace CreditCard_Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regexCardNo = new Regex(@"[0-9]{16}");
            string CardNo = textBox1.Text;
            char[] array = CardNo.ToCharArray();
            int[] cardNoArray = new int[16];
            int evenSum = 0;
            int oddSum = 0;

            if(array.Length < 16) { MessageBox.Show("Missing character.Please enter sixteen characters !!!"); }
            else if (regexCardNo.IsMatch(CardNo))
            {
                for(int i = 0; i < array.Length; i++)
                {
                    cardNoArray[i] = Convert.ToInt32(array[i]);
                    if(i % 2 == 1)
                    {
                        evenSum += cardNoArray[i];
                    }
                    else
                    {
                        oddSum += (2 * cardNoArray[i]);
                    }
                }
                if ( ((evenSum + oddSum) % 10 == 0) && regexCardNo.IsMatch(CardNo) ) { MessageBox.Show("This is a real credit card number.."); }
                else { MessageBox.Show("This is not a credit card number.."); }
            }
            else { MessageBox.Show("Invalid character !!!"); }



        }
    }
}
