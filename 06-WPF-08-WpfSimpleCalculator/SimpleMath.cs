using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSimpleCalculator
{
    internal static class SimpleMath
    {
        public static double Add(double number1, double number2) => number1 + number2;
        public static double Subtract(double number1, double number2) => number1 - number2;
        public static double Multiply(double number1, double number2) => number1 * number2;
        public static double Divide(double number1, double number2) => number1 / number2;
        public static double Percent(double number) => number / 100;
    }
}
