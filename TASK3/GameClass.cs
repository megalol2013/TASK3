using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace TASK3
{
    public class GameClass
    {
        
        static void Main(string[] args)
        {
           

            while(args.Length<2 || args.Length % 2 == 0)
            {
                Console.Write("Wrong Arguments.Input new arguments:");
                args = Console.ReadLine().Split(' ');
            }
            int computerMove = GameClass.ComputerMove(args.Length - 1);
            
            byte[] key = HashCreationClass.KeyCreation();
            Console.WriteLine("HMAC: " + HashCreationClass.HashCreation(key, args[computerMove]));
            Console.WriteLine("Available moves:");

            foreach (string i in args)
            {
                Console.WriteLine((Array.IndexOf(args, i, 0) + 1) + " - " + i);
            }

            Console.WriteLine("0 - exit\n? - help\n");
            Console.Write("Enter your move:");

            string temp = Console.ReadLine();

            if (temp == "0") return;

            while( temp == "?")
            {
                TableClass.DrawTable(args);
                Console.Write("\nEnter your move:");
                temp = Console.ReadLine();
            }

            int humanMove = Int32.Parse(temp) - 1;
            Console.WriteLine("Your move:" + args[humanMove] + "\nComputer move:" + args[computerMove]);
            Console.WriteLine(RulesClass.Rules(args, humanMove, args.Length - 1, computerMove));
            Console.WriteLine("HMAC key: "+BitConverter.ToString(key).Replace("-",""));         
            
        }

        public static int ComputerMove(int numberOfMoves)
        {
            return RandomNumberGenerator.GetInt32(0, numberOfMoves);
        }
    }

}
