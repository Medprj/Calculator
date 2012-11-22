namespace BusinessLogic
{
    /// <summary>
    /// Предоставляет сведения о математических операциях
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// узнать количество операндов необходимых для операции, функции
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>количество операндов</returns>
        int GetCountOperands(string operation);
        
        /// <summary>
        /// получить название метода соответствующий операции(функции)
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>название метода</returns>
        string GetName(string operation);

        /// <summary>
        /// Узнать приоритет операции
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>приоритет</returns>
        int GetPriority(string operation);

        /// <summary>
        /// Получить имя файла, в котором размещен метод
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>имя файла</returns>
        string GetFileName(string operation);

        /// <summary>
        /// Получить Полное имя типа
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>полное имя типа</returns>
        string GetType(string operation);
    }
}