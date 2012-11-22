using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// Вариант создания объекта типа BusinessLogic.Calculator
    /// </summary>
    public class ImplStrategy : IStrategy
    {
        /// <summary>
        /// Открыть и получить данные из файла, в котором хранится перечень математических операций и их атрибуты.
        /// Создать класс для вычисления математического выражения
        /// </summary>
        /// <returns>вернуть класс, в котором выполняется вычисление</returns>
        public Calculator CreateCalc()
        {
            var operation = new Operation<Operations>();

            var typeElem = new TypeElem();

            return new Calculator(new MathExpressToArray(typeElem),
                                  new MathExpressToRpn(operation, typeElem),
                                  new CalculateRpn(new Action(), operation, typeElem));
        }
    }
}