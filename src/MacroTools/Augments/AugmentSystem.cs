using MacroTools.BookSystem.Augments;
using System;
using System.Collections.Generic;
using System.Linq;
using static War3Api.Common;

namespace MacroTools.Augments
{
  /// <summary>
  /// Manages all <see cref="Augment"/>s in the game, and can be used to retrieve random Augments.
  /// </summary>
  public static class AugmentSystem
  {
    private static readonly List<Augment> Augments = new();

    /// <summary>
    /// Gets a specific number of random <see cref="Augment"/>s.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<Augment> GetRandomAugments(player whichPlayer, int number)
    {
      return Augments.OrderBy(o => o.GetWeight(whichPlayer) * GetRandomReal(0, 1))
         .Skip(Math.Max(0, Augments.Count - number)).ToList();
    }

    /// <summary>
    /// Gets a random <see cref="Augment"/>.
    /// The result is weighted based on particular attributes of the provided player.
    /// </summary>
    public static Augment GetRandom(player whichPlayer)
    {
      return Augments[GetRandomInt(0, Augments.Count - 1)];
    }

    /// <summary>
    /// Registers an <see cref="Augment"/> to the <see cref="AugmentSystem"/>, allowing it to be provided as a
    /// random result from a pool.
    /// </summary>
    public static void Register(Augment augment)
    {
      Augments.Add(augment);
    }

    /// <summary>
    /// Show 3 randomly selected <see cref="Augment"/>s to the player/>
    /// </summary>
    public static void ShowAugmentPage()
    {
      ShowPage(GetTriggerPlayer());
    }

    /// <summary>
    /// Show 3 randomly selected <see cref="Augment"/>s to the player/>
    /// </summary>
    public static void ShowAugmentPage(player player)
    {
      ShowPage(player);
    }

    private static void ShowPage(player player)
    {
      var augmentSelectionWindow = new AugmentPage
      {
        Visible = true,
        Width = 0.5f,
        Height = 0.39f
      };
      augmentSelectionWindow.SetAbsPoint(FRAMEPOINT_CENTER, 0.4f, 0.36f);
      augmentSelectionWindow.AddAugments(GetRandomAugments(player, 3));
      augmentSelectionWindow.PageNumber = 1;
    }
  }
}