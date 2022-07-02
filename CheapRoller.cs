using System;
using System.Linq;

namespace DicePoker
{
   /// <summary>
   /// Class to perform a dice roll given number of dice and number of sides.
   /// </summary>
   public class CCheapRoller
   {
      private static Random _rnd = new Random((int)DateTime.Now.Ticks);
      public static Func<int, int, int[]> GetRoll = (intNumDice, intNumSides) =>
         Enumerable.Range(0, intNumDice)
            .Select(i => _rnd.Next(1, intNumSides)).ToArray();
   }
}