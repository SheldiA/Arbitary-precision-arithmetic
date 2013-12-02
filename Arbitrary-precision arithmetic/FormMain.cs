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
            for (int i = 0; i < str.Length; ++i)
                result[i] = (byte)Char.GetNumericValue(str[i]);
            Array.Reverse(result);
            return result;
        }

        private string GetSign(string firstSign, string secondSign)
        {
            return (firstSign == secondSign) ? "+" : "-";
        }

        private void bt_calculate_Click(object sender, EventArgs e)
        {
            string leftOperand = tb_leftOperand.Text;
            string rightOperand = tb_rightOperand.Text;
            byte[] result = {};

            try
            {
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
                            Array.Resize(ref result, result.Length - 1);
                        }
                        else
                        {
                            result = operation.Add(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                            tb_resultSign.Text = (tb_rightSign.Text == "+") ? "+" : "-";
                        }
                }
                if (rb_multiplication.Checked)
                {
                    result = operation.Multiply(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                    tb_resultSign.Text = GetSign(tb_leftSign.Text, tb_rightSign.Text);
                }
                if (rb_dividing.Checked)
                {
                    if (rightOperand != "0")
                    {
                        if (rightOperand.Length > 1)
                        {
                            result = operation.Divide(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                            tb_resultSign.Text = GetSign(tb_leftSign.Text, tb_rightSign.Text);
                        }
                        else
                            MessageBox.Show("You can't divide by numbers less than 10");
                    }
                    else
                        MessageBox.Show("You mustn't divide by zero!");
                }
                if (rb_karatsubaMultiplication.Checked)
                {
                    Karatsuba karatsuba = new Karatsuba();
                    result = karatsuba.Multiply(ToByteArray(leftOperand), ToByteArray(rightOperand), 10);
                    tb_resultSign.Text = GetSign(tb_leftSign.Text, tb_rightSign.Text);
                }
                Array.Reverse(result);
                tb_result.Text = "";
                for (int i = 0; i < result.Length; ++i)
                    tb_result.Text += result[i];
            }
            catch
            {
                MessageBox.Show("Wrong data!");
            }
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
