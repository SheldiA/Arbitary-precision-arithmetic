using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            if (rb_addition.Checked)
            {
                if (tb_leftSign.Text == "-")
                    result = operation.Substraction(ToByteArray(rightOperand), ToByteArray(leftOperand), 10);
                else
                    if (tb_rightSign.Text == "-")
                        result = operation.Substraction(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                    else
                        result = operation.Add(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
            }
            if(rb_multiplication.Checked)
                result = operation.Multiply(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
            if(rb_dividing.Checked)
                result = operation.Divide(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
            if (rb_karatsubaMultiplication.Checked)
            {
                Karatsuba karatsuba = new Karatsuba();
                result = karatsuba.Multiply(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
            }
            Array.Reverse(result);
            tb_result.Text = "";
            for (int i = 0; i < result.Length; ++i)
                //if(!(i == 0 && result[i] == 0))
                    tb_result.Text += result[i];
        }
    }
}
