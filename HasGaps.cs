using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using DICE_HAND = IEnumerable<int>;

   public partial class CDicePoker
   {
      /// <summary>
      /// Determines if a hand has gaps.
      /// Hands with gaps cannot be a straight flush
      /// </summary>
      /// <param name="dh"></param>
      /// <returns></returns>
      private static Predicate<DICE_HAND> HasGaps = dh =>
         (!dh.Distinct().Count().Equals(dh.Count())
            || !(dh.Max() - dh.Min()).Equals(dh.Count() - 1));
   }
}