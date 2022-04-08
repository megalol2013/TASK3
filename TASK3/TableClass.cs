using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace TASK3
{
    public class TableClass
    {
        public static void DrawTable(string[] moves)
        {
            
            var table =new ConsoleTable("Your move","Computer Move","Result");
            foreach(string i in moves)
            {
                foreach(string j in moves)
                {
                    table.AddRow(i, j, RulesClass.Rules(moves, Array.IndexOf(moves, i, 0), moves.Length, Array.IndexOf(moves, j, 0)));
                }
            }
            table.Write();
        }
    }
}
