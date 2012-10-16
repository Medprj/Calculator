using BusinessLogic;

namespace Domain
{
    // структура для хранения сведений о математических операций и функциях
    public class Operations : IOperations
    {
        public string Name { get; set; } // имя операции (имя метода)
        public string Value { get; set; } // операция
        public int Operands { get; set; }  // количество операндов
        public int Priority { get; set; }  // приоритет
        public string Placement { get; set; } // имя сборки, где находится соответствующий метод
        public string Type { get; set; }  // полное имя типа
    }
}