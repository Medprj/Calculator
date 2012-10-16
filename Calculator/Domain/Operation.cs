using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using BusinessLogic;

namespace Domain
{
    public class Operation<T> : IOperation where T : class, IOperations, new()
    {
        // файл для хранения списка математические операции и функции по умолчанию
        private const string defaultfile = @"Operations.xml";
        private List<T> Oprs;

        public Operation()
            : this(defaultfile)
        {
        }

        public Operation(string filename)
        {
            //var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (!File.Exists(filename))
            {
                throw new Exception("Файл \"" + filename + "\" отсутствует");
            }
            var doc = new XmlDocument();
            // Открыть файл, в котором указаны 
            // доступные математические операции и функции
            doc.LoadXml(File.ReadAllText(filename));

            // Прочитать данные из файла
            FillOperations(doc);
        }

        // получить перечень всех доступных операций и функции
        private void FillOperations(XmlDocument doc)
        {
            Oprs = new List<T>();

            var elems = doc.GetElementsByTagName("operation");

            foreach (XmlNode x in elems)
            {
                try
                {
                    if (x.Attributes != null)
                    {
                        Oprs.Add(new T
                                     {
                                         Name = x.Attributes["name"].Value.ToLower(),
                                         Value = x.Attributes["value"].Value.ToLower(),
                                         Placement = x.Attributes["placement"].Value.ToLower(),
                                         Type = x.Attributes["type"].Value.ToLower(),

                                         Operands = int.Parse(x.Attributes["operands"].Value),
                                         Priority =
                                             int.Parse(x.Attributes.GetNamedItem("priority") != null
                                                           ? x.Attributes.GetNamedItem("priority").Value
                                                           : "0"),
                                     }
                            );
                    }
                }
                catch
                {
                    throw new Exception("Файл имеет неправильную структуру");
                }
            }
        }

        // узнать количество операндов необходимых для операции
        public int GetCountOperands(string operation)
        {
            if (operation == null) return 0;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Operands : 0;
        }

        // получить имя операции(функции)
        public string GetName(string operation)
        {
            if (operation == null) return null;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Name : null;
        }

        // узнать приоритет операции
        public int GetPriority(string operation)
        {
            if (operation == null) return 0;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Priority : 0;
        }

        // получить Имя файла, в котором размещен метод
        public string GetFileName(string operation)
        {
            if (operation == null) return null;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Placement : null;
        }

        // получить Полное имя типа
        public string GetType(string operation)
        {
            if (operation == null) return null;
            var res = Oprs.Find(op => op.Value.Equals(operation.ToLower()));
            return res != null ? res.Type : null;
        }
    }
}