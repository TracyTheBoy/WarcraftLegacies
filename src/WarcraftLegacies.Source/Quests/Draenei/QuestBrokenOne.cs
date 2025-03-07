﻿using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Bring Velen to the Maelstrom to unlock Nobundo as a hero.
  /// </summary>
  public sealed class QuestBrokenOne : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBrokenOne"/> class.
    /// </summary>
    public QuestBrokenOne(LegendaryHero velen) : base("The Broken One",
      "The great shaman Nobundo lent his services to the Earthen Ring to help calm the raging elements of Azeroth. But now the Draenai require his aid once again. Velen must travel to the Maelstrom to reunite with his old friend.",
      "ReplaceableTextures\\CommandButtons\\BTNAkamanew.blp")
    {
      AddObjective(new ObjectiveLegendInRect(velen, Regions.MaelstromAmbient, "Maelstrom"));
      ResearchId = Constants.UPGRADE_R083_QUEST_COMPLETED_THE_BROKEN_ONE;
    }

    /// <inheritdoc />
    protected override string RewardFlavour => "Nobundo acts in service of the Draenai once again.";

    /// <inheritdoc />
    protected override string RewardDescription => "The hero Nobundo is now trainable at the altar.";
  }
}