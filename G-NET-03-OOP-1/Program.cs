using System;
using OOPAssignment;

namespace OOPAssignment
{
    public class PersonClass
    {
        public string Name { get; set; } = "";
    }

    public struct PersonStruct
    {
        public string Name { get; set; }
    }
}
class Program
    {
    static void Main(string[] args)
    {
        #region PART 01: THEORETICAL & FUNDAMENTALS

        #region Question 01: Class vs Struct Behavior
        // Q1: Explain with code example how class and struct behave differently.
        //
        // EXPLANATION:
        // - Class: Reference type stored on Heap. Copying copies memory pointer reference. Mutating copy affects original object.
        // - Struct: Value type stored on Stack. Copying creates independent value copy. Mutating copy does NOT affect original.

        PersonClass personClass1 = new PersonClass { Name = "Kayn" };
        PersonClass personClass2 = personClass1;
        personClass2.Name = "Ahmed"; // Both point to same object, personClass1.Name becomes "Ahmed"

        PersonStruct personStruct1 = new PersonStruct { Name = "Kayn" };
        PersonStruct personStruct2 = personStruct1;
        personStruct2.Name = "Ahmed"; // Independent copy, personStruct1.Name remains "Kayn"

        Console.WriteLine($"Q1 -> Class Reference Mutation: {personClass1.Name}");
        Console.WriteLine($"Q1 -> Struct Value Independence: {personStruct1.Name}");
        Console.WriteLine("\n" + new string('-', 70) + "\n");
        #endregion
        #endregion
    

    }
} 
