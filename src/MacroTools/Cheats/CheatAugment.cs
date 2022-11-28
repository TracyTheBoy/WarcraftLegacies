using System;
using MacroTools.Augments;
using MacroTools.BookSystem.Augments;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatAugment
  {
    private const string Command = "-augment";

    private static void Actions()
    {
      try
      {
        if (!TestMode.CheatCondition()) 
          return;
       
        AugmentSystem.ShowAugmentPage();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
      finally
      {
        DisplayTextToPlayer(GetTriggerPlayer(), 0, 0, "|cffD27575CHEAT:|r Attempted to display Augment selection window.");
      }
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}