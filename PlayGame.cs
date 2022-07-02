using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using KVP_E2S = KeyValuePair<CDicePoker.E_DICE_POKER_HAND_VAL, string>;

   public partial class CDicePoker
   {
      private static Action<Action<string>> PlayGame = display =>
      {
         List<KVP_E2S> lstDiceRollResults = new List<KVP_E2S>
         {
            new KVP_E2S(GetHandEval(dhPlayerOne), RenderPokerOrder(dhPlayerOne)),
            new KVP_E2S(GetHandEval(dhPlayerTwo), RenderPokerOrder(dhPlayerTwo))
         };
         //

         System.Diagnostics.Debug.Assert(null != lstDiceRollResults);

         display(string.Format(
            map_prd2fn.Take(3)
            .Where(x => x.Key(lstDiceRollResults[0].Key.CompareTo(lstDiceRollResults[1].Key)))
            .Select(s => s.Value).FirstOrDefault()(lstDiceRollResults)));
      };
   }
}