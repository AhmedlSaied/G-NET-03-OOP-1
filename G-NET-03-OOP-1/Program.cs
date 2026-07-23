using System;
using OOPAssignment;

namespace OOPAssignment
{
    #region PART 01: THEORETICAL & FUNDAMENTALS

    #region SUPPORTING TYPES & CLASSES

    public class PersonClass
    {
        public string Name { get; set; } = "";
    }

    public struct PersonStruct
    {
        public string Name { get; set; }
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

    public enum TicketType
    {
        Standard,
        VIP,
        IMAX
    }

    public struct SeatLocation
    {
        public char Row { get; set; }
        public int Number { get; set; }

        public SeatLocation(char row, int number)
        {
            Row = row;
            Number = number;
        }

        public override string ToString() => $"{Row}{Number}";
    }

    public class Ticket
    {
        public string MovieName { get; set; }
        public TicketType Type { get; set; }
        public SeatLocation Seat { get; set; }

        private double price;
        public double Price
        {
            get => price;
            private set => price = value;
        }

        public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
        {
            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }

        // Default constructor using Constructor Chaining
        public Ticket(string movieName)
            : this(movieName, TicketType.Standard, new SeatLocation('A', 1), 50.0)
        {
        }

        public double CalcTotal(double taxPercent)
        {
            return Price + (Price * (taxPercent / 100.0));
        }

        public void ApplyDiscount(ref double discountAmount)
        {
            if (discountAmount > 0 && discountAmount <= Price)
            {
                Price -= discountAmount;
                discountAmount = 0.0;
            }
        }

        public void PrintTicket(double taxPercent)
        {
            Console.WriteLine($"Movie        : {MovieName}");
            Console.WriteLine($"Type         : {Type}");
            Console.WriteLine($"Seat         : {Seat}");
            Console.WriteLine($"Price        : {Price:F2}");
            Console.WriteLine($"Total ({taxPercent:F0}% tax) : {CalcTotal(taxPercent):F2}");
        }
    }

    #endregion

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
            #region Question 03: Steps to Create and Use a Class Library
            // Q3: Describe the steps to create and use a class library in Visual Studio.
            //
            // STEPS:
            // 1. Open Visual Studio -> Create a new project.
            // 2. Select "Class Library (.NET Core / .NET Standard)" and click Next.
            // 3. Name project (e.g., "CinemaLibrary") and click Create.
            // 4. Add reusable classes/enums and Build project (generates compiled .dll file).
            // 5. In Console Application -> Right-click Dependencies/References -> Add Project Reference -> Select CinemaLibrary.
            // 6. Add 'using CinemaLibrary;' directive at top of C# file.

            Console.WriteLine("Q3 -> Class Library steps documented in code comments above.");
            Console.WriteLine("\n" + new string('-', 70) + "\n");
            #endregion
            #region Question 04: What is a Class Library & Why Use It?
            // Q4: What is a class library? Why do we use class libraries?
            //
            // EXPLANATION:
            // - What it is: A compiled assembly (.dll) containing reusable classes, interfaces, and methods without an executable entry point.
            // - Why use it:
            //   1. Code Reusability: Write logic once, share across Web, Mobile, Console apps.
            //   2. Maintainability: Modifying logic in library updates all referencing applications.
            //   3. Separation of Concerns: Decouples business logic from UI/Presentation layer.

            Console.WriteLine("Q4 -> Class Library definition & usage documented in code comments above.");
            Console.WriteLine("\n" + new string('-', 70) + "\n");
            #endregion

            #region PART 02: MOVIE TICKET BOOKING SYSTEM

            Console.Write("Enter Movie Name: ");
            string movieName = Console.ReadLine() ?? "Inception";

            Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
            int typeInput = int.Parse(Console.ReadLine() ?? "0");
            TicketType ticketType = (TicketType)typeInput;

            Console.Write("Enter Seat Row (A, B, C...): ");
            char row = char.Parse(Console.ReadLine() ?? "A");

            Console.Write("Enter Seat Number: ");
            int seatNum = int.Parse(Console.ReadLine() ?? "1");

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine() ?? "50");

            Console.Write("Enter Discount Amount: ");
            double discountAmount = double.Parse(Console.ReadLine() ?? "0");

            SeatLocation seat = new SeatLocation(row, seatNum);
            Ticket ticket = new Ticket(movieName, ticketType, seat, price);

            double taxPercent = 14.0;

            Console.WriteLine("\n===== Ticket Info =====");
            ticket.PrintTicket(taxPercent);

            double discountBefore = discountAmount;
            ticket.ApplyDiscount(ref discountAmount);

            Console.WriteLine("\n===== After Discount =====");
            Console.WriteLine($"Discount Before : {discountBefore:F2}");
            Console.WriteLine($"Discount After  : {discountAmount:F2}");
            ticket.PrintTicket(taxPercent);

            #endregion
        }
    }
}
#endregion









