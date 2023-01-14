using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using System;
using System.Linq;
using WarcraftLegacies.Source.GameLogic.GameEnd;

namespace MacroTools.VictorySystem.Conditions
{
  /// <summary>
  /// A <see cref="IVictoryCondition"/> based on the amount of <see cref="LegendaryHero"/>es killed 
  /// </summary>
  public class LegendaryHeroVictoryCondition : IVictoryCondition
  {
    /// <inheritdoc/>
    public int VictoryPoints { get; set; } = 5;

    /// <inheritdoc/>
    public int VictoryPointsWarning { get; set; } = 1;

    /// <inheritdoc/>
    public event EventHandler<VictoryConditionUpdatedEventArgs>? VictoryConditionUpdated;

    /// <summary>
    /// Default constructor that initializes the <see cref="LegendaryHeroVictoryCondition"/>
    /// </summary>
    public LegendaryHeroVictoryCondition()
    {
      foreach (var capital in LegendaryHeroManager.GetAll())
      {
        foreach (var faction in FactionManager.GetAllFactions())
        {
          capital.UnitDies += faction.OnLegendaryHeroKilled;
        }
        capital.UnitDies += OnUnitDies;
      }
    }

    /// <inheritdoc/>
    public int GetCurrentVictoryPoints(Team team) => team.GetAllFactions().Where(f => f.Player != null).Select(f => f.LegendaryHeroesKilled).Sum();

    private void OnUnitDies(object? sender, LegendDiesEventArgs legendDiesEventArgs)
    {
      VictoryConditionUpdated?.Invoke(this, new VictoryConditionUpdatedEventArgs(legendDiesEventArgs.KillingPlayer.GetTeam()));
    }
  }
}
