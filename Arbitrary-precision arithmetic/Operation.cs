using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

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

        public byte[] DeleteZero(byte[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; --i)
                if (arr[i] != 0)
                {
                    if (i != arr.Length - 1)
                    {
                        byte[] temp = new byte[i + 1];
                        Array.Copy(arr, temp, i + 1);
                        arr = temp;
                    }
                    break;
                }
            return arr;
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

            result = DeleteZero(result);
            return result;
        }

        public byte[] Substraction(byte[] left, byte[] right, byte numeralSystem)
        {
            int operandsLength = Math.Max(left.Length, right.Length);
            byte[] leftOperand = Add0ToEnd(left, operandsLength);
            byte[] rightOperand = Add0ToEnd(right, operandsLength);
            byte[] result = new byte[operandsLength];
            int currResult = 0;
            int sign = 1;//1 = + ; 2 = -
            BigInteger leftBig = new BigInteger(leftOperand);
            BigInteger rightBig = new BigInteger(rightOperand);
            if (BigInteger.Compare(leftBig, rightBig) < 0)
            {
                byte[] temp = leftOperand;
                leftOperand = rightOperand;
                rightOperand = temp;
                sign = 2;
            }
            
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

            result = DeleteZero(result);
            byte[] temp1 = new byte[result.Length + 1];            
            Array.Copy(result, temp1, result.Length);
            temp1[temp1.Length - 1] = (byte)sign;
            result = temp1;
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

            result = DeleteZero(result);
            return result;
        }

        public byte[] Divide(byte[] leftOperand, byte[] rightOperand, byte numeralSystem)
        {
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
                    if ((remainder < numeralSystem - 1) || (quotient * right[rightLength - 2] > numeralSystem * remainder + left[j + rightLength - 2]))
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
                
                if (left[left.Length - 1] == 2)
                {
                    flagNegative = true;
                }
                else
                    flagNegative = false;
                Array.Resize(ref left,left.Length  - 1);
                left = Add0ToEnd(left, leftLength);
             
                result[j] = quotient;
                if (flagNegative)
                {
                    tempRight = new byte[leftLength];
                    for (i = 0; i < j; ++i)
                        tempRight[i] = 0;
                    for (int k = 0; k < right.Length; ++i, ++k)
                        tempRight[i] = right[k];
                    for (; i < tempRight.Length; ++i)
                        tempRight[i] = 0;
                    left = Substraction(tempRight,left,numeralSystem);
                    Array.Resize(ref left, left.Length - 1);
                    left = Add0ToEnd(left, leftLength);
                    --result[j];
                }

            }

            result = DeleteZero(result);
            return result;
        }
    }
}
