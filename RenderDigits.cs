using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using DICE_HAND = IEnumerable<int>;

   public partial class CDicePoker
   {
      /// <summary>
      /// Returns the dice hand.  Called by RenderPokerOrder
      /// </summary>
      private static Func<DICE_HAND, int> RenderDigits = dh =>
         int.Parse(new string(dh.ToLookup(k => k, v => v)
            .OrderByDescending(r => r.Key)
            .OrderByDescending(r => r.Count())
            .SelectMany(r => new string(r.Key.ToString()[0], r.Count()))
            .ToArray()));
   }
}