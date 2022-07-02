using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using DICE_HAND = IEnumerable<int>;

   public partial class CDicePoker
   {
      /// <summary>
      /// Renders the DiceHand as a CSV string.
      /// </summary>
      private static Func<DICE_HAND, string> RenderPokerOrder = dh =>
         string.Join(",", RenderDigits(dh)
            .ToString().Select(c => c.ToString()).ToArray());
   }
}