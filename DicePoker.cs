////////////////////////////////////////////////////////////////////////////////
// 2012-05-22 for a user on DaniWeb.
// It eventually morphed beyond its original scope.
// No "if" statements, for-loops or while-loops, etc.
using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using DICE_HAND = IEnumerable<int>;

   public partial class CDicePoker
   {
      public enum E_DICE_POKER_HAND_VAL
      {
         HIGH_ROLL, ONE_PAIR, TWO_PAIR, THREE_OF_A_KIND,
         FULL_HOUSE, FOUR_OF_A_KIND, STRAIGHT_FLUSH, FIVE_CARD_CHARLIE
      };

      //////////////////////////////////////////////////////////////////////////
      // Since the rolling is simulated anyway, let the computer roll for both.
      private static DICE_HAND dhPlayerOne = CCheapRoller.GetRoll(5, 6); // Roll(1);
      private static DICE_HAND dhPlayerTwo = CCheapRoller.GetRoll(5, 6); // Roll(2);

      private static Action<string> Display = strData => Console.WriteLine(strData);
      
      static void Main(string[] args)
      {
         Dictionary<Predicate<int>, Action<Action<string>>> main = new Dictionary<Predicate<int>, Action<Action<string>>>
         {
            {(i => i.Equals(0)), PlayGame},
            {(i => true), Usage}
         };

         main[main.Keys.Where(m => m(args.Length)).FirstOrDefault()](Display);
      }
   }
}
