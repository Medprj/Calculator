using System;
using System.Collections.Generic;
using BusinessLogic;

namespace Domain
{
    public class CalculateRpn : ICalculateRpn
    {
        private readonly IAction act;
        private readonly IOperation op;
        private readonly ITypeElement typeElem;

        public CalculateRpn(IAction act, IOperation op, ITypeElement typeElem)
        {
            this.act = act;
            this.op = op;
            this.typeElem = typeElem;
        }

        // вычисление выражения в обратной польской записи
        // string[] mathExpressAsRpn - входное выражение
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
    
        // Выполнить математическое операцию
        // string nameMethodOperation - имя метода = имя функции
        // double[] operands - операнды
        // string fileNameAssembly - имя файла *.dll
        // string fullTypeName - полное имя типа
        public string ExecMathOperation(string nameMethodOperation, double[] operands, string fileName, string fullTypeName)
        {
            return act.Exec(nameMethodOperation, operands, fileName, fullTypeName);
        }
    }
}