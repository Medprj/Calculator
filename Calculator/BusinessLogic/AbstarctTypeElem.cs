namespace BusinessLogic
{
    public abstract class AbstarctTypeElem 
    {
        public abstract TypesE GetType2(string element);

        // тип символа
        public enum TypesE
        {
            Unknown,          // неизвестный символ
            Digit,            // число
            Func,             // функция
            Operation,        // математическая операция
            OpenParenthesis,  // открывающаяся круглая скобка 
            CloseParenthesis, // закрывающаяся круглая скобка
        }
    }
}