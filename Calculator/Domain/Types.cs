namespace Domain
{
    /// <summary>
    /// Тип символа
    /// </summary>
    public enum Types
    {
        /// <summary>
        /// неизвестный символ
        /// </summary>
        Unknown,        
        /// <summary>
        /// число
        /// </summary>
        Number,           
        /// <summary>
        /// знак пунктуации
        /// </summary>
        Separator,     
        /// <summary>
        /// функция
        /// </summary>
        Func,            
        /// <summary>
        /// математическая операция
        /// </summary>
        Operation,       
        /// <summary>
        /// открывающаяся круглая скобка 
        /// </summary>
        OpenParenthesis, 
        /// <summary>
        /// закрывающаяся круглая скобка
        /// </summary>
        CloseParenthesis,
    }
}