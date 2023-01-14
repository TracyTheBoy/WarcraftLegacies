using MacroTools.FactionSystem;
using System;

namespace WarcraftLegacies.Source.GameLogic.GameEnd
{
  public class VictoryConditionUpdatedEventArgs: EventArgs
  {
    public Team Team { get; set; }
    public int VictoryPoints { get; set; }
    public VictoryConditionUpdatedEventArgs(Team team)
    {
      Team = team;
    }
  }
}
