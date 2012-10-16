namespace Domain
{
    // тип символа
    public enum Types
    {
        Unknown,          // неизвестный символ
        Number,            // число
        Separator,      // знак пунктуации
        Func,             // функция
        Operation,        // математическая операция
        OpenParenthesis,  // открывающаяся круглая скобка 
        CloseParenthesis, // закрывающаяся круглая скобка
    }
}