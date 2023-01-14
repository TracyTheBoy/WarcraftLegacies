using System;
using System.Linq;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.GameLogic.GameEnd;

namespace MacroTools.VictorySystem.Conditions
{
  /// <summary>
  /// A <see cref="IVictoryCondition"/> based on the amount of <see cref="ControlPoint"/>s captured
  /// </summary>
  public class ControlPointVictoryCondition : IVictoryCondition
  {
    /// <inheritdoc/>
    public int VictoryPoints { get; set; } = 18;

    /// <inheritdoc/>
    public int VictoryPointsWarning { get; set; } = 15;

    /// <inheritdoc/>
    public event EventHandler<VictoryConditionUpdatedEventArgs>? VictoryConditionUpdated;

    /// <summary>
    /// Default constructor that initializes the <see cref="ControlPointVictoryCondition"/>
    /// </summary>
    public ControlPointVictoryCondition()
    {
      foreach (var controlPoint in ControlPointManager.Instance.GetAllControlPoints())
        controlPoint.ChangedOwner += ControlPointOwnerChanges;
    }

    /// <inheritdoc/>
    public int GetCurrentVictoryPoints(Team whichTeam) =>
      whichTeam.GetAllFactions().Where(faction => faction.Player != null).Sum(faction => faction.Player.GetControlPointCount() / 5);

    private void ControlPointOwnerChanges(object? sender,
      ControlPointOwnerChangeEventArgs controlPointOwnerChangeEventArgs)
    {
      var newOwnerTeam = controlPointOwnerChangeEventArgs.ControlPoint.Owner.GetTeam();
      var formerOwnerTeam = controlPointOwnerChangeEventArgs.FormerOwner.GetTeam();
      if (newOwnerTeam == null || newOwnerTeam == formerOwnerTeam) return;
      VictoryConditionUpdated?.Invoke(this, new VictoryConditionUpdatedEventArgs(newOwnerTeam));
    }
  }
}

