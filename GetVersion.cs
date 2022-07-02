using System;
using System.Reflection;

namespace DicePoker
{
   public partial class CDicePoker
   {
      public static Func<string> GetVersion = () =>
      {
         AssemblyName assemName = Assembly.GetExecutingAssembly().GetName();
         Version ver = assemName.Version;
         return assemName.Name + " - " + ver.ToString();
      };
   }
}