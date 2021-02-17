using System;
using System.Reflection;

namespace HomeworkGCLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. С помощью рефлексии получить список методов класса Console и вывести на экран.
            // 2.Описать класс с несколькими свойствами.Создать экземпляр класса и инициализировать его свойства.
            // С помощью рефлексии получить свойства и их значения из созданного экземпляра класса. Вывести полученные значения на экран

            Type type = typeof(Console);
            foreach(var item in type.Assembly.GetTypes())
            {
                if(type.Name == "Console" && type.IsClass)
                {
                    foreach(var method in type.GetMethods())
                    {
                        if(method is MethodInfo)
                        {
                            Console.WriteLine(method);
                        }
                    }
                }
            }
            Console.WriteLine("-------------------------------------------------");

            Car car = new Car()
            {
                Id = 1,
                Name = "BMW",
                Model = "X5",
                Price = 15000000

            };
            Type typeCar = typeof(Car);
            Console.WriteLine("Список свойств класса Car и его занчения:");
            PropertyInfo[] propertyInfos = typeCar.GetProperties();
            foreach(var item in propertyInfos)
            {
                if(item.GetIndexParameters().Length == 0)
                {
                    Console.WriteLine($"{item.Name} {item.PropertyType} = {item.GetValue(car,null)}");
                }
            }
            Console.ReadLine();

        }
    }
}
