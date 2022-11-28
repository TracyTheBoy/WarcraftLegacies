using MacroTools.Extensions;
using MacroTools.FactionSystem;
using System;
using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;
namespace MacroTools.Powers
{
  /// <summary>
  /// 
  /// </summary>
  public class SecondWind : Power
  {
    private readonly float _percentageOfHitPoints;
    private readonly float _durationNoDamageTaken;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="percentageOfHitPoints"></param>
    /// <param name="durationNoDamageTaken"></param>
    public SecondWind(float percentageOfHitPoints, float durationNoDamageTaken)
    {
      _percentageOfHitPoints = percentageOfHitPoints;
      _durationNoDamageTaken = durationNoDamageTaken;
    }

    /// <inheritdoc/>
    public override void OnAdd(player whichPlayer)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDamaged, OnUnitTakesDamage, GetPlayerId(whichPlayer));
    }

    /// <inheritdoc/>
    public override void OnRemove(player whichPlayer)
    {
      PlayerUnitEvents.Unregister(CustomPlayerUnitEvents.PlayerUnitDamaged, GetPlayerId(whichPlayer));
    }

    private Dictionary<unit, List<timer>> UnitByTriggers = new();

    private void OnUnitTakesDamage()
    {
      Console.WriteLine("Entered handler");
      var triggerUnit = GetTriggerUnit();

      if (UnitByTriggers.ContainsKey(triggerUnit))
      {
        foreach (var timer in UnitByTriggers[triggerUnit])
          timer.Destroy();
        UnitByTriggers.Remove(triggerUnit);
      }
      var ot = CreateTimer();
      var ot2 = CreateTimer();
      UnitByTriggers.Add(triggerUnit, new List<timer> { ot, ot2 });

      ot.Start(_durationNoDamageTaken, false, () =>
      {
        ot2.Start(1, true, () =>
        {
          Console.WriteLine("unit regenerating " + _percentageOfHitPoints / 100 * BlzGetUnitMaxHP(triggerUnit) +" hp");
          SetUnitState(triggerUnit, UNIT_STATE_LIFE, GetUnitState(triggerUnit, UNIT_STATE_LIFE) +  _percentageOfHitPoints / 100 * BlzGetUnitMaxHP(triggerUnit));
          if (GetUnitState(triggerUnit, UNIT_STATE_LIFE) == BlzGetUnitMaxHP(triggerUnit))
          {
            Console.WriteLine("unit full");
            GetExpiredTimer().Destroy();
          }
        });
        GetExpiredTimer().Destroy();
      });
    }
  }
}
