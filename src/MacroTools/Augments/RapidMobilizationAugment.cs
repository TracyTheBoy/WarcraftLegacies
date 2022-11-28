﻿using MacroTools.FactionSystem;
using MacroTools.Powers;
using static War3Api.Common;

namespace MacroTools.Augments
{
  /// <summary>
  /// An <see cref="Augment"/> that sometimes copied units trained by the owning player.
  /// </summary>
  public sealed class RapidMobilizationAugment : Augment
  {
    private readonly float _chance;

    /// <summary>
    /// Initializes an instance of the <see cref="RapidMobilizationAugment"/> class.
    /// </summary>
    /// <param name="percentageChance">The chance for trained units to be copied.</param>
    public RapidMobilizationAugment(float percentageChance)
    {
      Category = Category.Strength;
      _chance = percentageChance;
      IconName = "Footman";
      Name = "Rapid Mobilization";
      Description = $"When you train a unit, you have a {percentageChance}% of instantly training an additional copy for free.";
    }

    /// <inheritdoc />
    public override float GetWeight(player whichPlayer) => 1;

    /// <inheritdoc />
    public override void OnAdd(Faction whichFaction)
    {
      whichFaction.AddPower(new RapidMobilization(_chance)
      {
        IconName = IconName,
        Name = Name
      });
    }
  }
}