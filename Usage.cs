using System;

namespace DicePoker
{
   public partial class CDicePoker
   {
      private static Action<Action<string>> Usage =  display =>
         display(string.Format(
            "{0}\n\tRolls the dice for both players and" +
            " returns the result.\n\n\t[{1}]",
            Environment.GetCommandLineArgs()[0], GetVersion()));
   }
}