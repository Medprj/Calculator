using System;
using System.Collections.Generic;
using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// Вычислить математическое выражение, записанное в обратной польской записи
    /// </summary>
    public class CalculateRpn : ICalculateRpn
    {
        private readonly IAction act;
        private readonly IOperation op;
        private readonly ITypeElement typeElem;

        /// <summary>
        /// Подставить классы реализующие интерфейсы
        /// </summary>
        /// <param name="act">для подключения сборки, содержащей методы соответствующие математическим операциям</param>
        /// <param name="op">для получения сведений о математической операции</param>
        /// <param name="typeElem">для определения типа символа</param>
        public CalculateRpn(IAction act, IOperation op, ITypeElement typeElem)
        {
            this.act = act;
            this.op = op;
            this.typeElem = typeElem;
        }

        /// <summary>
        /// Вычислить выражения в обратной польской записи
        /// </summary>
        /// <param name="mathExpressAsRpn">исходное выражение</param>
        /// <returns>результат вычислений</returns>
        public string Calculate(string[] mathExpressAsRpn)
        {
            var stack = new Stack<string>();
            
            foreach (var elem in mathExpressAsRpn)
            {
                Types typeCurrentSymbol;
                if (!Enum.TryParse(typeElem.GetType(elem), true, out typeCurrentSymbol))
                {
                    throw new Exception("Невозможно определить тип символа");
                }

                switch (typeCurrentSymbol)
                {
                    case Types.Number: //Если на вход подан операнд, он помещается на вершину стека
                        stack.Push(elem);
                        break;
                    case Types.Func:
                    case Types.Operation:
                        if (op.GetName(elem) != null)
                        {
                            var operands = new double[op.GetCountOperands(elem)];
                            for (var i = 0; i < operands.Length; i++)
                            {
                                operands[i] = Convert.ToDouble(stack.Pop());
                            }
                            try
                            {
                                stack.Push(ExecMathOperation(op.GetName(elem), operands, op.GetFileName(elem), op.GetType(elem)));
                            }
                            catch (Exception e)
                            {
                                throw new Exception(e.Message);
                            }
                        }
                        else
                        {
                            throw new Exception("Неизвестная функция: \"" + elem + "\""); // неизвестная функция
                        }
                        break;
                    case Types.Unknown:
                        throw new Exception("Недопустимый символ: \"" + elem + "\""); // недопустимый символ
                }
            }
            if (stack.Count != 0)
            {
                return stack.Pop();
            }
            throw new Exception("Неправильное математическое выражение");
        }
             
        /// <summary>
        /// Подключить сборку, содержащую методы соответствующие математическим операциям
        /// и выполнить математические вычисления
        /// </summary>
        /// <param name="nameMethodOperation">имя метода = имя функции</param>
        /// <param name="operands">операнды</param>
        /// <param name="fileName"> имя файла (*.dll)</param>
        /// <param name="fullTypeName">полное имя типа</param>
        /// <returns>результат вычисления</returns>
        public string ExecMathOperation(string nameMethodOperation, double[] operands, string fileName, string fullTypeName)
        {
            return act.Exec(nameMethodOperation, operands, fileName, fullTypeName);
        }
    }
}