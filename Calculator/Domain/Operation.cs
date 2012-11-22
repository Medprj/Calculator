using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// Предоставляет сведения о математических операциях
    /// </summary>
    /// <typeparam name="T">класс для хранения сведений полученных из файла</typeparam>
    public class Operation<T> : IOperation where T : class, IOperations, new()
    {
        // файл для хранения списка математические операции и функции по умолчанию
        private const string defaultfile = @"Operations.xml";
        private List<T> Oprs;

        /// <summary>
        /// Если не указанно имя файла, подставить значение по умолчанию
        /// </summary>
        public Operation()
            : this(defaultfile)
        {
        }

        /// <summary>
        /// Открыть xml-файл и получить из него данные
        /// </summary>
        /// <param name="filename">имя xml-файла</param>
        /// <exception cref="Exception">Исключение вызывается, если не удалось открыть файл</exception>
        public Operation(string filename)
        {
            //var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (!File.Exists(filename))
            {
                throw new Exception("Файл \"" + filename + "\" отсутствует");
            }
          
            // Открыть файл, в котором указаны 
            // доступные математические операции и функции
            var doc = XDocument.Load(filename);

            // Прочитать данные из файла
            FillOperations(doc);
        }
 
        /// <summary>
        /// Получить перечень всех математических операций и функции из xml-файла
        /// </summary>
        /// <param name="doc">описание математических операций и функций</param>
        private void FillOperations(XContainer doc)
        {
            Oprs = new List<T>();

            try
            {
                foreach (var element in doc.Descendants("operation"))
                {
                    Oprs.Add(new T
                    {
                        Name = element.Attribute("name").Value,
                        Value = element.Attribute("value").Value,
                        Placement = element.Attribute("placement").Value,
                        Type = element.Attribute("type").Value,
                        Operands = (int)element.Attribute("operands"),
                        Priority = element.Attribute("priority") != null
                                      ? (int)element.Attribute("priority")
                                      : 0,
                    });
                }
            }
            catch
            {
                throw new Exception("Файл имеет неправильную структуру");
            }
        }

        /// <summary>
        /// узнать количество операндов необходимых для операции, функции
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>количество операндов</returns>
        public int GetCountOperands(string operation)
        {
            if (operation == null) return 0;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Operands : 0;
        }

        /// <summary>
        /// получить название метода соответствующий операции(функции)
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>название метода</returns>
        public string GetName(string operation)
        {
            if (operation == null) return null;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Name : null;
        }

        /// <summary>
        /// Узнать приоритет операции
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>приоритет</returns>
        public int GetPriority(string operation)
        {
            if (operation == null) return 0;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Priority : 0;
        }

        /// <summary>
        /// Получить имя файла, в котором размещен метод
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>имя файла</returns>
        public string GetFileName(string operation)
        {
            if (operation == null) return null;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Placement : null;
        }

        /// <summary>
        /// Получить Полное имя типа
        /// </summary>
        /// <param name="operation">операция(функция)</param>
        /// <returns>полное имя типа</returns>
        public string GetType(string operation)
        {
            if (operation == null) return null;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Type : null;
        }
    }
}