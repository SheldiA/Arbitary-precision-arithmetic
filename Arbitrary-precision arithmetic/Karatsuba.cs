using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbitrary_precision_arithmetic
{
    class Karatsuba
    {
        private Operation operation;
        private const byte minCountForMultyplying = 4;
        public Karatsuba()
        {
            operation = new Operation();
        }

        private byte[] UsualMultiply(byte[] a, byte[] b)
        {
            byte[] result = {};
                string left = "";
                string right = "";
                for (int i = a.Length - 1; i >= 0; --i)
                    left += a[i];
                for (int i = b.Length - 1; i >= 0; --i)
                    right += b[i];
                string strResult = Convert.ToString((Convert.ToInt32(left) * Convert.ToInt32(right)));
                result = new byte[strResult.Length];
                for (int i = 0; i < strResult.Length; ++i)
                    result[i] = (byte)Char.GetNumericValue(strResult[i]);
                Array.Reverse(result);
            return result;
        }

        private byte[] MultiplyByPowerOf10(byte[] number,Int64 power)
        {
            byte[] result = new byte[number.Length + power];

            int i = 0;
            for (; i < power; ++i)
                result[i] = 0;
            for (int j = 0; j < number.Length; ++j, ++i)
                result[i] = number[j];

            return result;
        }

        public byte[] Multiply(byte[] leftOperand, byte[] rightOperand, byte numeralSystem)
        {
            byte[] result = { };
            leftOperand = operation.Add0ToEnd(leftOperand,Math.Max(leftOperand.Length,rightOperand.Length));
            rightOperand = operation.Add0ToEnd(rightOperand, Math.Max(leftOperand.Length, rightOperand.Length));
            if (leftOperand.Length <= minCountForMultyplying && rightOperand.Length <= minCountForMultyplying)
            {
                if(leftOperand.Length > 0 && rightOperand.Length > 0)
                    result = UsualMultiply(leftOperand,rightOperand);
            }
            else
            {
                Int64 power = Math.Min(leftOperand.Length / 2, rightOperand.Length / 2);
                byte[] left0 = new byte[power];
                byte[] left1 = new byte[leftOperand.Length - power];
                Array.Copy(leftOperand, left0, power);
                Array.Copy(leftOperand, power, left1, 0, leftOperand.Length - power);
                byte[] right0 = new byte[power];
                byte[] right1 = new byte[rightOperand.Length - power];
                Array.Copy(rightOperand, right0, power);
                Array.Copy(rightOperand, power, right1, 0, rightOperand.Length - power);

                byte[] multiplying0 = Multiply(left0,right0,numeralSystem);
                byte[] multyplying1 = Multiply(left1,right1,numeralSystem);
                byte[] temp = Multiply(operation.Add(left0,left1,numeralSystem),operation.Add(right0,right1,numeralSystem),numeralSystem);
                byte[] temp1 = operation.Substraction(temp, multiplying0, numeralSystem);
                Array.Resize(ref temp1,temp1.Length - 1);
                byte[] temp4 = operation.Substraction(temp1, multyplying1, numeralSystem);
                Array.Resize(ref temp4,temp4.Length - 1);
                byte[] temp2 = MultiplyByPowerOf10(temp4,power);
                byte[] temp3 = operation.Add(temp2, MultiplyByPowerOf10(multyplying1, 2 * power), numeralSystem);
                result = operation.Add(multiplying0,temp3,numeralSystem);
            }
            



            return result;
        }
    }
}
