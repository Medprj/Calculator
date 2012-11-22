namespace BusinessLogic
{
    /// <summary>
    /// Сведений о математических операциях и функциях
    /// </summary>
    public interface IOperations
    {
        /// <summary>
        /// имя операции (имя метода)
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// операция
        /// </summary>
        string Value { get; set; }
        /// <summary>
        /// количество операндов
        /// </summary>
        int Operands { get; set; }
        /// <summary>
        /// приоритет
        /// </summary>
        int Priority { get; set; }
        /// <summary>
        /// имя сборки, где находится соответствующий метод
        /// </summary>
        string Placement { get; set; }
        /// <summary>
        /// полное имя типа
        /// </summary>
        string Type { get; set; }  
    }
}