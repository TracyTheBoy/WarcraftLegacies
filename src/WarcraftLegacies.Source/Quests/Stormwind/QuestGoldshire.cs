using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Stormwind
{
  public sealed class QuestGoldshire : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestGoldshire(Rectangle rescueRect, unit hogger) : base("The Scourge of Elwynn",
      "Hogger and his pack have taken over Goldshire, clear them out!",
      "ReplaceableTextures\\CommandButtons\\BTNGnoll.blp")
    {
      AddObjective(new ObjectiveKillUnit(hogger)); //Hogger
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n00Z"))));
      AddObjective(new ObjectiveExpire(1335));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "The Gnolls have been defeated, Goldshire is safe.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in Goldshire";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player);
    }
  }
}