using System;
using OOPAssignment;

namespace OOPAssignment
{
    #region PART 01: THEORETICAL & FUNDAMENTALS

    public class PersonClass
    {
        public string Name { get; set; } = "";
    }

    public struct PersonStruct
    {
        public string Name { get; set; }
    }
}
public class BankAccount
{
    public string OwnerName;
    private double balance;

    public BankAccount(string owner)
    {
        OwnerName = owner;
        balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount > 0) balance += amount;
    }

    public double GetBalance() => balance;
}

class Program
{
    static void Main(string[] args)
    {

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
       
            #region Question 02: Public vs Private Access Modifiers
            // Q2: Explain the difference between public and private access modifiers with an example.
            //
            // EXPLANATION:
            // - public: Member accessible from anywhere inside or outside defining class/assembly.
            // - private: Member accessible ONLY inside defining class scope. Protects internal data state (Encapsulation).

            BankAccount account = new BankAccount("Kayn");
            account.Deposit(500);
            // account.balance = 1000; // Compile Error: balance field is private
            Console.WriteLine($"Q2 -> Account Owner: {account.OwnerName}, Balance: {account.GetBalance()}");
            Console.WriteLine("\n" + new string('-', 70) + "\n");
            #endregion
        }
    }


#endregion
