﻿using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <inheritdoc/>
  public sealed class QuestWestfallOutpost : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWestfallOutpost"/> class.
    /// </summary>
    public QuestWestfallOutpost(Rectangle questRect) : base("Westfall Outpost",
      "Stormwind faces the threat of annihilation at the hands of forces from beyond the Dark Portal, and they have called in our assistance. If we are to aid them, we must first establish a foothold on Westfall's coast.", "ReplaceableTextures\\CommandButtons\\BTNKultirasGryphonAviary.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H06R_GARRISON_KUL_TIRAS_BARRACKS, 2));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H07Q_SCHOOL_OF_THE_TIDES_KUL_TIRAS_MAGIC));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H062_TOWN_HALL_KUL_TIRAS_T1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H07P_WORKSHOP_KUL_TIRAS_SIEGE));
      ResearchId = Constants.UPGRADE_R06T_QUEST_COMPLETED_WESTFALL_OUTPOST;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Kul Tiran outpost in Westfall has been completed. In the mean time, the Ember Order has cleansed House Waycrest of their Drust influence. Meredith Waycrest has been released from her pact, and may now join the war effort.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Learn to build {Constants.UNIT_H093_ORDER_CHAPTER_HOUSE_KUL_TIRAS}s, and learn to train Meredith Waycrest from the {Constants.UNIT_H07M_ALTAR_OF_ADMIRALS_KUL_TIRAS_ALTAR}";
  }
}