﻿using MacroTools.ArtifactSystem;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <inheritdoc/>
  public sealed class QuestFlameAndSorrow : QuestData
  {
    private readonly Artifact _skullofGuldan;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestFlameAndSorrow"/> class.
    /// </summary>
    public QuestFlameAndSorrow(Artifact skullofGuldan, LegendaryHero illidan) : base("A Destiny of Flame and Sorrow",
      "The Skull of Gul'dan is an artifact of immeasurable demonic power. It would grant Illidan the power he has always craved.",
      "ReplaceableTextures\\CommandButtons\\BTNEyeOfSargeras.blp")
    {
      _skullofGuldan = skullofGuldan;
      AddObjective(new ObjectiveLegendHasArtifact(illidan, skullofGuldan));
      ResearchId = Constants.UPGRADE_R095_QUEST_COMPLETED_A_DESTINY_OF_FLAME_AND_SORROW;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "With the Skull of Gul'dan finally in hand, Illidan breathes deep of its power. With one swift motion, he crushes it to dust, absorbing its phenomenal demonic energies for himself.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Illidan gains the ability to cast Metamorphosis, and the Skull of Gul'dan is destroyed";

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      ArtifactManager.Destroy(_skullofGuldan);
    }
  }
}