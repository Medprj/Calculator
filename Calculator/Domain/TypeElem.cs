using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace Domain
{
    // ����� ��� ����������� ���� ��������(�������)
    public class TypeElem : ITypeElement
    {
        private static readonly List<char> Separators = new List<char> { ',', '.' };
        private static readonly List<char> Operations = new List<char> { '+', '-', '*', '/', '^' };
        // ����� ���������� ��� ��������(�������)
        // string elem - ������� �������
        public string GetType(string elem)
        {
            if (!string.IsNullOrEmpty(elem))
            {
                if (IsNumber(elem)) return "number";
                if (IsSeparator(elem)) return "separator";
                if (IsFunc(elem)) return "func";
                if (IsOperation(elem)) return "operation";
                if (IsOpeningParenthesis(elem)) return "openParenthesis";
                if (IsClosingParenthesis(elem)) return "closeParenthesis";
            }
            return "Unknown";
        }

        // �������� �� ������� ������
        private static bool IsNumber(string elem)
        {
            double tmp;
            return double.TryParse(elem, out tmp);
        }

        // �������� �� ������� ������ ����������
        private static bool IsSeparator(string elem)
        {
            return Separators.Contains(elem[0]);
        }

        // �������� �� ������� ��������
        private static bool IsFunc(string elem)
        {
            return elem.All(char.IsLetter);
        }

        // �������� �� ������� ���������
        private static bool IsOperation(string elem)
        {
            
            return Operations.Contains(elem[0]);
        }

        // �������� �� ������� ������������� �������
        private static bool IsOpeningParenthesis(string elem)
        {
            return elem == "(";
        }

        // �������� �� ������� ������������� �������
        private static bool IsClosingParenthesis(string elem)
        {
            return elem == ")";
        }
    }
}