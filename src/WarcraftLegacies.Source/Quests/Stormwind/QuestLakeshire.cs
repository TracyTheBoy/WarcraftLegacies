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
  public sealed class QuestLakeshire : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestLakeshire(Rectangle rescueRect, unit ogreLordToKill) : base("Marauding Ogres",
      "The town of Lakeshire is invaded by Ogres, wipe them out!",
      "ReplaceableTextures\\CommandButtons\\BTNOgreLord.blp")
    {
      AddObjective(new ObjectiveKillUnit(ogreLordToKill));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n011"))));
      AddObjective(new ObjectiveExpire(1427));
      AddObjective(new ObjectiveSelfExists());
      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
      Required = true;
    }

    //Todo: bad flavour
    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Lakeshire has been liberated, and its military is now free to assist Stormwind.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of all units in Lakeshire";

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