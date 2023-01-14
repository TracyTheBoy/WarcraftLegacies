using MacroTools.FactionSystem;
using System;

namespace WarcraftLegacies.Source.GameLogic.GameEnd
{
  public interface IVictoryCondition
  {
    /// <summary>
    /// Amount needed to fulfill meet the <see cref="IVictoryCondition"/>
    /// </summary>
    public int VictoryPoints { get; set; }

    /// <summary>
    /// Amount needed to give a warning about the <see cref="IVictoryCondition"/>
    /// </summary>
    public int VictoryPointsWarning { get; set; }

    /// <summary>
    /// Returns the Amount of Victory Points currently accumulated by the specified <paramref name="team"/>  for this <see cref="IVictoryCondition"/>
    /// </summary>
    /// <param name="team"></param>
    /// <returns></returns>
    public int GetCurrentVictoryPoints(Team team);

    /// <summary>
    /// Fired when the VictoryCondition got updated
    /// </summary>

    public event EventHandler<VictoryConditionUpdatedEventArgs> VictoryConditionUpdated;
  }
}
