using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// Сведений о математических операциях и функциях
    /// </summary>
    public class Operations : IOperations
    {
        /// <summary>
        /// имя операции (имя метода)
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// операция
        /// </summary>
        public string Value { get; set; }  
        /// <summary>
        /// количество операндов
        /// </summary>
        public int Operands { get; set; }  
        /// <summary>
        /// приоритет
        /// </summary>
        public int Priority { get; set; }  
        /// <summary>
        /// имя сборки, где находится соответствующий метод
        /// </summary>
        public string Placement { get; set; }  
        /// <summary>
        /// полное имя типа
        /// </summary>
        public string Type { get; set; }  
    }
}