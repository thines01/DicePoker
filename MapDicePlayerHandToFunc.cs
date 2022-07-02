using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using DICE_HAND = IEnumerable<int>;

   public partial class CDicePoker
   {
      /// <summary>
      /// Map containing the hand values with the determinations.
      /// A Dictionary was used to cut down on syntax and remove complication ;)
      /// </summary>
      private static Dictionary<Predicate<DICE_HAND>, E_DICE_POKER_HAND_VAL> map_prd2dh2dphVal = new Dictionary<Predicate<DICE_HAND>, E_DICE_POKER_HAND_VAL>()
      {
         {dh =>(dh.Count().Equals(5) && dh.Distinct().Count().Equals(1)),
            E_DICE_POKER_HAND_VAL.FIVE_CARD_CHARLIE},
         {dh =>(dh.Distinct().Count().Equals(dh.Count())) && (!HasGaps(dh.OrderBy(i => i))),
            E_DICE_POKER_HAND_VAL.STRAIGHT_FLUSH},
         {dh =>(dh.ToLookup(k => k, v => v).Any(r => r.Count().Equals(4))),
            E_DICE_POKER_HAND_VAL.FOUR_OF_A_KIND},
         {dh =>(dh.ToLookup(k => k, v => v).Any(r => r.Count().Equals(3)) && dh.ToLookup(k => k, v => v).Where(r => r.Count().Equals(2)).Select(r => new KeyValuePair<int, int>(r.Key, r.Key)).Count().Equals(1)),
            E_DICE_POKER_HAND_VAL.FULL_HOUSE},
         {dh =>(dh.ToLookup(k => k, v => v).Any(r => r.Count().Equals(3))),
            E_DICE_POKER_HAND_VAL.THREE_OF_A_KIND},
         {dh =>(dh.ToLookup(k => k, v => v).Where(r => r.Count().Equals(2)).Select(r => new KeyValuePair<int, int>(r.Key, r.Key)).Count().Equals(2)),
            E_DICE_POKER_HAND_VAL.TWO_PAIR},
         {dh =>(dh.ToLookup(k => k, v => v).Where(r => r.Count().Equals(2)).Select(r => new KeyValuePair<int, int>(r.Key, r.Key)).Count().Equals(1)),
            E_DICE_POKER_HAND_VAL.ONE_PAIR},
         {dh => true,
            E_DICE_POKER_HAND_VAL.HIGH_ROLL}
      };
   }
}