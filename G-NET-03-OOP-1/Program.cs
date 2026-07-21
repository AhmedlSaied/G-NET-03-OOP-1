using System;

namespace OOP_Diff
{
    //Q1: Explain with code example how class and struct behave differently

    // Class example 
    class Player
    {
        public int Score;
    }

    // Struct example 
    struct PlayerStats
    {
        public int Score;
    }

    class Program
    {
        static void Main()
        {
            // Test
            Player p1 = new Player { Score = 100 };
            Player p2 = p1;
            p2.Score = 200;
            
            Console.WriteLine(p1.Score); 

            PlayerStats s1 = new PlayerStats { Score = 100 };
            PlayerStats s2 = s1;
            s2.Score = 200;
            Console.WriteLine(s1.Score); 
        }
    }
}