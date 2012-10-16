using System;

namespace BusinessLogic
{
    public class Calculator
    {
        private readonly IConvertToArray convertToArr;
        private readonly IConvertToRpn convertToRpn;
        private readonly ICalculateRpn calculateRpn;

        public Calculator(IConvertToArray convertToArr, IConvertToRpn convertToRpn, ICalculateRpn calculateRpn)
        {
            this.convertToArr = convertToArr;
            this.convertToRpn = convertToRpn;
            this.calculateRpn = calculateRpn;
        }

        public string Calc(string mathExpress)
        {
            // преобразовать входное математическое выражение из сроки в массив 
            var mathExpressAsArr = convertToArr.ToArray(mathExpress);

            // конвертировать из инфиксной записи в постфиксную
            var mathExpressAsRpn = convertToRpn.ToRpn(mathExpressAsArr);

            // вычисление выражения
            return calculateRpn.Calculate(mathExpressAsRpn);
        }

        public string[] ConvertToArray(string str)
        {
            return convertToArr.ToArray(str);
        }

        public string[] ConvertToRpn(string[] arr)
        {
            return convertToRpn.ToRpn(arr);
        }

        public string CalculateRpn(string[] rpn)
        {
            return calculateRpn.Calculate(rpn);
        }
    }
}