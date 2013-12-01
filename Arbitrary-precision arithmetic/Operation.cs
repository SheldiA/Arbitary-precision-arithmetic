using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbitrary_precision_arithmetic
{
    class Operation
    {

        private byte[] Add0ToEnd(byte[] number, int length)
        {
            if (number.Length < length)
            {
                byte[] result = new byte[length];
                Array.Copy(number, result, number.Length);
                for (int i = number.Length; i < length; ++i)
                    result[i] = 0;
                return result;
            }
            else
                return number;
            
        }
        public byte[] Add(byte[] left,byte[] right,byte numeralSystem)
        {
            int operandsLength = Math.Max(left.Length,right.Length);
            byte[] leftOperand = Add0ToEnd(left, operandsLength);
            byte[] rightOperand = Add0ToEnd(right, operandsLength);
            byte[] result = new byte[operandsLength + 1];
            byte remainder = 0;            
            for (int i = 0; i < operandsLength; ++i)
                if ((result[i] = (byte)(leftOperand[i] + rightOperand[i] + remainder)) >= numeralSystem)
                {
                    result[i] -= numeralSystem;
                    remainder = 1;
                }
                else
                    remainder = 0;
            result[operandsLength] = remainder;

            for (int i = result.Length - 1; i >= 0; --i)
                if (result[i] != 0)
                {
                    if (i != result.Length - 1)
                    {
                        byte[] temp = new byte[i + 1];
                        Array.Copy(result, temp, i + 1);
                        result = temp;
                    }
                    break;
                }
            return result;
        }

        public byte[] Substraction(byte[] left, byte[] right, byte numeralSystem)
        {
            int operandsLength = Math.Max(left.Length, right.Length);
            byte[] leftOperand = Add0ToEnd(left, operandsLength);
            byte[] rightOperand = Add0ToEnd(right, operandsLength);
            byte[] result = new byte[operandsLength];
            int currResult = 0;
            for (int i = 0; i < operandsLength; ++i)
            {
                if ((currResult = leftOperand[i] - rightOperand[i]) < 0)
                {
                    int pos = i + 1;
                    while ((pos < operandsLength) && (leftOperand[pos] == 0))
                        ++pos;
                    --leftOperand[pos];
                    for (int j = pos - 1; j > i; --j)
                        leftOperand[j] = (byte)(numeralSystem - 1);
                    currResult += numeralSystem;
                }
                result[i] = (byte)currResult;
            }

            for (int i = result.Length - 1; i >= 0; --i)
                if (result[i] != 0)
                {
                    if (i != result.Length - 1)
                    {
                        byte[] temp = new byte[i + 1];
                        Array.Copy(result, temp, i + 1);
                        result = temp;
                    }
                    break;
                }
       
            return result;
        }

        public byte[] Multiply(byte[] leftOperand, byte[] rightOperand, byte numeralSystem)
        {
            int leftLength = leftOperand.Length;
            int rightLength = rightOperand.Length;
            byte[] result = new byte[leftLength + rightLength];
            byte remainder;

            for (int i = 0; i < leftLength; ++i)
                result[i] = 0;
            for (int j = 0; j < rightLength; ++j)
            {
                remainder = 0;
                for (int i = 0; i < leftLength; ++i)
                {
                    int sum = leftOperand[i] * rightOperand[j] + result[i + j] + remainder;
                    result[i + j] = (byte)(sum % numeralSystem);
                    remainder = (byte)(sum / numeralSystem);
                }
                result[j + leftLength] = remainder;
            }

            
            for (int i = result.Length - 1; i >= 0; --i)
                if (result[i] != 0)
                {
                    if (i != result.Length - 1)
                    {
                        byte[] temp = new byte[i + 1];
                        Array.Copy(result, temp, i + 1);
                        result = temp;
                    }
                    break;
                }
            return result;
        }

        public byte[] Divide(byte[] leftOperand, byte[] rightOperand, byte numeralSystem)
        {
            //byte[] leftOp = { 5, 4, 1, 8, 7, 6 };
            //byte[] rightOp = { 3, 2, 1 };
            int leftLength = leftOperand.Length;
            int rightLength = rightOperand.Length;
            byte[] coeff = new byte[1];
            coeff[0] = (byte)(numeralSystem / (rightOperand[rightOperand.Length - 1] + 1));
            byte[] left = Multiply(leftOperand, coeff, numeralSystem);
            byte[] right = Multiply(rightOperand, coeff, numeralSystem);
            if (left.Length == leftLength)
            {
                byte[] temp = new byte[leftLength + 1];
                Array.Copy(left,temp,leftLength);
                temp[leftLength] = 0;
                left = temp;
            }
            byte[] result = new byte[leftLength + 1];
            byte quotient, remainder;
            bool flagNegative = false;

            for (int j = (leftLength - rightLength); j >= 0; --j)
            {
                flagNegative = false;
                quotient = (byte)((left[j + rightLength] * numeralSystem + left[j + rightLength - 1]) / right[rightLength - 1]);
                remainder = (byte)((left[j + rightLength] * numeralSystem + left[j + rightLength - 1]) % right[rightLength - 1]);
                if ((quotient == numeralSystem) || (quotient * right[rightLength - 2] > numeralSystem * remainder + left[j + rightLength - 2]))
                {
                    --quotient;
                    remainder += right[rightLength - 2];
                    if ((remainder < numeralSystem) || (quotient * right[rightLength - 2] > numeralSystem * remainder + left[j + rightLength - 2]))
                    {
                        --quotient;
                        remainder += right[rightLength - 2];
                    }
                }                

                byte[] temp = { quotient};

                byte[] tempRight = Multiply(right, temp, numeralSystem);
                byte[] tempLeft = new byte[left.Length];
                int i = 0;
                for (; i < j;++i )
                    tempLeft[i] = 0;
                for (int k = 0; k < tempRight.Length; ++i, ++k)
                    tempLeft[i] = tempRight[k];
                for (; i < left.Length;++i )
                    tempLeft[i] = 0;
                left = Substraction(left, tempLeft, numeralSystem);
                /*for (int i = j,k = 0; i <= j + rightLength; ++i,++k)
                {
                    left[i] -= right[k];
                    if (left[i] < 0)
                        flagNegative = true;
                }*/
                result[j] = quotient;
                /*if (flagNegative)
                {
                    byte[] temp1 = {1,0};
                    byte[] temp2 = { 1, 0 };
                    for (int i = 0; i <= rightLength + 1; ++i)
                        temp2 = Multiply(temp2,temp1,numeralSystem);
                    left = Add(left,temp2,numeralSystem);
                    --result[j];

                }*/

            }

            return result;
        }
    }
}
