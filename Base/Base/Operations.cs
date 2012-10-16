using System;

namespace Base
{
    public static class Operations
    {
        public static double Addition(double op1, double op2)
        {
            return op1 + op2;
        }

        public static double Subtraction(double op1, double op2)
        {
            return op2 - op1;
        }

        public static double Multiplication(double op1, double op2)
        {
            return op1 * op2;
        }

        public static double Division(double op1, double op2)
        {
            if(op1 == 0) throw new Exception("Деление на ноль");
            return op2 / op1;
        }
    }
}
