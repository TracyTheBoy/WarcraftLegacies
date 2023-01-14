using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.GameLogic.GameEnd
{
  public class VictoryConditionUpdatedEventArgs
  {
    public Team Team { get; set; }
    public int VictoryPoints { get; set; }
    public VictoryConditionUpdatedEventArgs(Team team)
    {
      Team = team;
    }
  }
}
