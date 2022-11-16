using System;

namespace GenericTypes
{
    public class Program
    {
        #region Generic Function
        //private static void Main(string[] args)
        //{
        //    int[] intArray = CreateArray(5, 6);
        //    string[] stringArray = CreateArray("tanga", "mo");
        //    Console.WriteLine(intArray.Length + " " + intArray[0] + " " + intArray[1]);
        //    Console.WriteLine(stringArray.Length + " " + stringArray[0] + " " + stringArray[1]);
        //}

        //private static T[] CreateArray<T>(T firstElement, T secondElement)
        //{
        //    return new T[] { firstElement, secondElement };
        //}
        #endregion

        #region Multiple Generic Function
        //private static void Main(string[] args)
        //{
        //    MultipleGeneric(1, "tekla");
        //}

        //private static void MultipleGeneric<T1, T2>(T1 t1, T2 t2)
        //{
        //    Console.WriteLine(t1.GetType());
        //    Console.WriteLine(t2.GetType());
        //}
        #endregion

        #region Multiple Generic Function
        private static void Main(string[] args)
        {
           //MyClass<Person> myPerson = new MyClass<Person>(new Person());
           //MyClass<Animal> myAnimal = new MyClass<Animal>(new Animal());


            IAction actPerson = new Person();
            actPerson.Create();

            IAction actAnimal = new Animal();
            actAnimal.Create();
        }
        #endregion
    }
}

//public class MyClass<T> where T : IAction
//{
//    public MyClass(T value)
//    {
//        value.Create();
//    }
//}

public interface IAction
{
    void Create();
} 

public class Person : IAction
{
    public void Create()
    {
        Console.WriteLine("Person Created");
    }
}

public class Animal : IAction
{
    public void Create()
    {
        Console.WriteLine("Animal Created");
    }
}
