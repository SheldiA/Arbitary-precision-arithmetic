using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Arbitrary_precision_arithmetic
{
    public partial class FormMain : Form
    {
        private Operation operation;
        public FormMain()
        {
            InitializeComponent();
            operation = new Operation();
        }

        private byte[] ToByteArray(string str)
        {
            byte[] result = new byte[str.Length];
            /*while (str.Length < length)
                str = "0" + str;*/
            for (int i = 0; i < str.Length; ++i)
                result[i] = (byte)Char.GetNumericValue(str[i]);
            Array.Reverse(result);
            return result;
        }

        private void bt_calculate_Click(object sender, EventArgs e)
        {
            string leftOperand = tb_leftOperand.Text;
            string rightOperand = tb_rightOperand.Text;
            int length = Math.Max(leftOperand.Length,rightOperand.Length);
            byte[] result = {};
            Stopwatch sw = new Stopwatch();
            
            if (rb_addition.Checked)
            {
                if ((tb_leftSign.Text == "-") && (tb_rightSign.Text == "+"))
                {
                    result = operation.Substraction(ToByteArray(rightOperand), ToByteArray(leftOperand), 10);
                    tb_resultSign.Text = (result[result.Length - 1] == 2) ? "-" : "+";
                    Array.Resize(ref result, result.Length - 1);
                }
                else
                    if ((tb_rightSign.Text == "-") && (tb_leftSign.Text == "+"))
                    {
                        result = operation.Substraction(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                        tb_resultSign.Text = (result[result.Length - 1] == 2) ? "-" : "+";
                        Array.Resize(ref result,result.Length - 1);
                    }
                    else
                        result = operation.Add(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
            }
            if (rb_multiplication.Checked)
            {
                sw.Start();
                result = operation.Multiply(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                sw.Stop();
            }
            if(rb_dividing.Checked)
                result = operation.Divide(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
            if (rb_karatsubaMultiplication.Checked)
            {
                Karatsuba karatsuba = new Karatsuba();
                sw.Start();
                result = karatsuba.Multiply(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                sw.Stop();
            }
            
            lb_runningTime.Text = "Running time is " + sw.ElapsedMilliseconds + " milliseconds";
            Array.Reverse(result);
            tb_result.Text = "";
            for (int i = 0; i < result.Length; ++i)
                //if(!(i == 0 && result[i] == 0))
                    tb_result.Text += result[i];
        }

        public void RadioButton_Checked(object sender, System.EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (rb == rb_multiplication || rb == rb_karatsubaMultiplication)
                    lb_sign.Text = "*";
                if (rb == rb_addition)
                    lb_sign.Text = "+";
                if (rb == rb_dividing)
                    lb_sign.Text = "/";
            }
        }
    }
}
