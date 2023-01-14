using MacroTools.FactionSystem;
using System.Collections.Generic;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic.GameEnd
{
  public static class Victory
  {
    private const string VictoryColor = "|cff911499";
    private static bool _gameWon;
    private static int VictoryPoints { get; set; }
    private static int VictoryPointsWarning { get; set; }
    public static List<IVictoryCondition> VictoryConditions { get; set; }
    public static Dictionary<string, int> VictoryPointsByTeamNames { get; set; } = new();

    public static int GetRequiredVictoryPoints() => VictoryPoints;

    public static void Setup(List<IVictoryCondition> victoryConditions)
    {

      foreach (var victoryCondition in victoryConditions)
      {
        victoryCondition.VictoryConditionUpdated += OnVictoryConditionUpdated;
        VictoryPoints += victoryCondition.VictoryPoints;
        VictoryPointsWarning += victoryCondition.VictoryPointsWarning;
      }
      VictoryConditions = victoryConditions;
    }

    private static void OnVictoryConditionUpdated(object? sender, VictoryConditionUpdatedEventArgs victoryConditionUpdatedEventArgs)
    {
      if (_gameWon)
        return;
      var victoryPoints = 0;
      foreach (var victoryCondition in VictoryConditions)
      {
        victoryPoints += victoryCondition.GetCurrentVictoryPoints(victoryConditionUpdatedEventArgs.Team);
      }
      if (!ShowVictoryMessage(victoryConditionUpdatedEventArgs.Team, victoryPoints))
        return;

      if (victoryPoints >= VictoryPoints)
        TeamVictory(victoryConditionUpdatedEventArgs.Team);
      else if (victoryPoints > VictoryPointsWarning)
        TeamWarning(victoryConditionUpdatedEventArgs.Team, victoryPoints);
    }

    private static void TeamWarning(Team whichTeam, int victoryPoints) =>
  DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
    $"\n{VictoryColor}TEAM VICTORY IMMINENT|r\n{whichTeam.Name} has accumulated {victoryPoints} out of {VictoryPoints} Victory Points required to win the game!");

    private static void TeamVictory(Team whichTeam)
    {
      ClearTextMessages();
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
        $"{VictoryColor}\nTEAM VICTORY!|r\nThe {whichTeam.Name} has won the game! You may choose to continue playing.");
      PlayThematicMusic(whichTeam.VictoryMusic);
      _gameWon = true;
    }

    private static bool ShowVictoryMessage(Team team, int victoryPoints)
    {
      if (VictoryPointsByTeamNames.TryGetValue(team.Name, out var vps))
        if (vps == victoryPoints)
          return false;
        else
        {
          VictoryPointsByTeamNames[team.Name] = victoryPoints;
          return true;
        }
      else
        VictoryPointsByTeamNames.Add(team.Name, victoryPoints);
      return true;
    }
  }
}
