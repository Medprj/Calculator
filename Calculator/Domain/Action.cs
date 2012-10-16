using System;
using System.Reflection;
using BusinessLogic;

namespace Domain
{
    public class Action : IAction
    {
        // метод для подключения *.dll с набором методов
        // string operation - операция (имя метода)
        // double[] parameters - операнды
        // string fileName - имя файла-сборки
        // string type - тип
        // метод возвращает 0 в случае успеха или номер ошибки
        public string Exec(string operation, double[] parameters, string fileName, string type)
        {
            // Подключаем файл сборки(в данном случаи *.dll)
            Assembly assembly; 
            try
            {
                assembly = Assembly.LoadFrom(fileName);
            }
            catch (Exception)
            {
                throw new Exception("Не удалось открыть файл: " + fileName);
            }

            //  получаем объект Type, предоставляющий указанный тип.
            Type assemblyClass;
            try
            {
                assemblyClass = assembly.GetType(type, false, true);
            }
            catch (Exception)
            {
                throw new Exception("Не удалось получить тип");
            }

            // Поиск метода с заданным именем (string operation)
            MethodInfo assembMethod;
            try
            {
                assembMethod = assemblyClass.GetMethod(operation, BindingFlags.Static | 
                                                                  BindingFlags.Public | 
                                                                  BindingFlags.Instance | 
                                                                  BindingFlags.IgnoreCase);
            }
            catch (Exception)
            {
                throw new Exception("Метод: \"" + operation + "\"");
            }

                        
            var paramaters = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++) { paramaters[i] = parameters[i]; }

            // Выполняем математическую операцию
            string result;
            try
            {

                result = assembMethod.Invoke(assemblyClass, paramaters).ToString();
            }
            catch(TargetInvocationException e)
            {
               throw new Exception(e.InnerException.Message);
            }
            // в случае успеха, возвращаем результат
            return result;
        }
    }
}