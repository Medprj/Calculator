using System;
using System.Reflection;
using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// Подключить *.dll и вызывать метод соответствующий математической операции
    /// </summary>
    public class Action : IAction
    {
        /// <summary>
        /// Метод для подключения *.dll с набором математических операций
        /// </summary>
        /// <param name="operation">математическая операция (имя метода)</param>
        /// <param name="parameters">операнды</param>
        /// <param name="fileName">имя файла-сборки</param>
        /// <param name="type">тип (базовый класс)</param>
        /// <returns>результат вычисления</returns>
        public string Exec(string operation, double[] parameters, string fileName, string type)
        {
            // Подключить файл сборки(в данном случаи *.dll)
            Assembly assembly; 
            try
            {
                assembly = Assembly.LoadFrom(fileName);
            }
            catch (Exception)
            {
                throw new Exception("Не удалось открыть файл: " + fileName);
            }

            // Получить объект Type, предоставляющий указанный тип.
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

            // Выполнить математическую операцию
            string result;
            try
            {
                result = assembMethod.Invoke(assemblyClass, paramaters).ToString();
            }
            catch(TargetInvocationException e)
            {
               throw new Exception(e.InnerException.Message);
            }
            // В случае успеха, возвратить результат
            return result;
        }
    }
}