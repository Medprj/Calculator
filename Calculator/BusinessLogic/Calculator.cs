namespace BusinessLogic
{
    /// <summary>
    /// Вычислить математическое выражение
    /// </summary>
    public class Calculator
    {
        private readonly IConvertToArray convertToArr;
        private readonly IConvertToRpn convertToRpn;
        private readonly ICalculateRpn calculateRpn;

        /// <summary>
        /// Подставить классы реализующие интерфейсы
        /// </summary>
        /// <param name="convertToArr">для конвертации из строки в массив</param>
        /// <param name="convertToRpn">для конвертации из инфиксной записи в постфиксную</param>
        /// <param name="calculateRpn">для вычисления результата</param>
        public Calculator(IConvertToArray convertToArr, IConvertToRpn convertToRpn, ICalculateRpn calculateRpn)
        {
            this.convertToArr = convertToArr;
            this.convertToRpn = convertToRpn;
            this.calculateRpn = calculateRpn;
        }

        /// <summary>
        /// Вычислить математическое выражение
        /// </summary>
        /// <param name="mathExpress">исходное математическое выражение</param>
        /// <returns>результат вычислений</returns>
        public string Calc(string mathExpress)
        {
            // преобразовать входное математическое выражение из сроки в массив 
            var mathExpressAsArr = convertToArr.ToArray(mathExpress);

            // конвертировать из инфиксной записи в постфиксную
            var mathExpressAsRpn = convertToRpn.ToRpn(mathExpressAsArr);

            // вычисление выражения
            return calculateRpn.Calculate(mathExpressAsRpn);
        }

        /// <summary>
        /// Конвертировать из строки в массив
        /// </summary>
        /// <param name="str">исходная строка</param>
        /// <returns>массив, как результат конвертации</returns>
        public string[] ConvertToArray(string str)
        {
            return convertToArr.ToArray(str);
        }

        /// <summary>
        /// Конвертировать из инфиксной записи в постфиксную
        /// </summary>
        /// <param name="arr">исходный массив в инфиксной записи</param>
        /// <returns>массив преобразованный в постфиксную запись</returns>
        public string[] ConvertToRpn(string[] arr)
        {
            return convertToRpn.ToRpn(arr);
        }

        /// <summary>
        /// Вычислить математическое выражение
        /// </summary>
        /// <param name="rpn">математическое выражение как массив в постфиксной записи</param>
        /// <returns>результат вычислений</returns>
        public string CalculateRpn(string[] rpn)
        {
            return calculateRpn.Calculate(rpn);
        }
    }
}