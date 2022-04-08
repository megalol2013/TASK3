using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TASK3
{
    public class RulesClass
    {
        public static string Rules(string[] moves,int humanMove,int numbersOfMoves,int computerMove)
        {
            string[] temp=moves;
            temp = temp.Concat(moves).Concat(moves).ToArray();
            string[] winMoves = temp[(humanMove + numbersOfMoves / 2)..(humanMove+numbersOfMoves)];
            string[] loseMoves = temp[(humanMove+numbersOfMoves)..(humanMove + numbersOfMoves / 2+numbersOfMoves + 1)];
            if (computerMove == humanMove) return "Draw";
            else return (loseMoves.Contains(moves[computerMove]) ? "You lose" : "You win");
        }
    }
}
