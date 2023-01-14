using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using System;
using System.Linq;
using WarcraftLegacies.Source.GameLogic.GameEnd;

namespace MacroTools.VictorySystem.Conditions
{
  /// <summary>
  /// A <see cref="IVictoryCondition"/> based on the amount of <see cref="Capital"/>s destroyed and owned 
  /// </summary>
  public class CapitalVictoryCondition : IVictoryCondition
  {
    /// <inheritdoc/>
    public int VictoryPoints { get; set; } = 5;

    /// <inheritdoc/>
    public int VictoryPointsWarning { get; set; } = 1;

    /// <inheritdoc/>
    public event EventHandler<VictoryConditionUpdatedEventArgs>? VictoryConditionUpdated;

    /// <summary>
    /// Default constructor that initializes the <see cref="CapitalVictoryCondition"/>
    /// </summary>
    public CapitalVictoryCondition()
    {
      foreach (var capital in CapitalManager.GetAll())
      {
        foreach (var faction in FactionManager.GetAllFactions())
        {
          capital.UnitDies += faction.OnCapitalDestroyed;
          capital.ChangedOwner += faction.OnCapitalOwnerChanged;
        }
        capital.UnitDies += OnUnitDies;
        capital.ChangedOwner += OnUnitChangeOwner;
      }
    }

    /// <inheritdoc/>
    public int GetCurrentVictoryPoints(Team team) => 
      team.GetAllFactions().Where(f => f.Player != null).Select(f => f.CaptialsDestroyed).Sum() 
      + team.GetAllFactions().Where(f => f.Player != null).Select(f => f.CapitalsOwned).Sum();

    private void OnUnitDies(object? sender, LegendDiesEventArgs legendDiesEventArgs)
    {
      VictoryConditionUpdated?.Invoke(this, new VictoryConditionUpdatedEventArgs(legendDiesEventArgs.KillingPlayer.GetTeam()));
    }

    private void OnUnitChangeOwner(object? sender, LegendChangeOwnerEventArgs legendChangeOwnerEventArgs)
    {
      VictoryConditionUpdated?.Invoke(this, new VictoryConditionUpdatedEventArgs(legendChangeOwnerEventArgs.Legend.OwningPlayer.GetTeam()));
    }
  }
}
