using System;
using System.Collections.Generic;
using System.Linq;

namespace DicePoker
{
   using DICE_HAND = IEnumerable<int>;

   public partial class CDicePoker
   {
      /// <summary>
      /// Determines which hand the player has by comparing the 
      /// layout of the dice roll to known values in the dictionary.
      /// This one looks up its own key,
      /// then returns the value based on that key based on the 
      /// return from the embedded function that produces the key.
      /// </summary>
      /// <param name="dh"></param>
      /// <returns></returns>
      private static Func<DICE_HAND, E_DICE_POKER_HAND_VAL> GetHandEval = dh =>
         map_prd2dh2dphVal[map_prd2dh2dphVal.Keys.Where(enm2fn => enm2fn(dh)).First()];
   }
}