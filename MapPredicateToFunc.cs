using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using KVP_E2S = KeyValuePair<CDicePoker.E_DICE_POKER_HAND_VAL, string>;
   public partial class CDicePoker
   {
      /// <summary>
      /// Determines the winner of a tie (if possible).
      /// If one hand is better than another, the function returns the winner.
      /// If the hands are exactly equal, it will result in a tie.
      /// </summary>
      /// <param name="lst_kvp"></param>
      /// <returns></returns>
      private static Func<List<KVP_E2S>, string> PlayerTie = lst_kvp =>
         map_prd2fn.Skip(1)
            .Where(x => x.Key(RenderDigits(dhPlayerOne).CompareTo(RenderDigits(dhPlayerTwo))))
            .Select(s => s.Value)
            .First()(lst_kvp);

      /// <summary>
      /// Magical construction to determine the winner of given hand Key/Value.
      /// </summary>
      /// 
      private static Dictionary<Predicate<int>, Func<List<KVP_E2S>, string>>
         map_prd2fn = new Dictionary<Predicate<int>, Func<List<KVP_E2S>, string>>
      {
         {new Predicate<int>(i => i.Equals(0)), PlayerTie},//first tie

         {new Predicate<int>(i => i > 0),
            (m => string.Format("Player One wins\n1={0}({1})\n2={2}({3})",
               m[0].Key, m[0].Value, m[1].Key, m[1].Value))},

         {new Predicate<int>(i => i < 0),
            (m => string.Format("Player Two wins\n2={2}({3})\n1={0}({1})",
               m[0].Key, m[0].Value, m[1].Key, m[1].Value))},

         {new Predicate<int>(i => i.Equals(0)),
            (m => string.Format("Tie({0}) \n1={1}\n2={2}",
               m[0].Key, m[0].Value, m[1].Value))}
      };
   }
}