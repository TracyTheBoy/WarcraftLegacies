using MacroTools.FactionSystem;
using MacroTools.Powers;
using War3Api;

namespace MacroTools.Augments
{
  /// <summary>
  /// An <see cref="Augment"/> that causes units that are out of combat generate hp at a much faster rate.
  /// </summary>
  public class SecondWindAugment : Augment
  {
    private readonly float _percentageOfHitPoints;
    private readonly float _durationNoDamageTaken;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="percentageOfHitPoints"></param>
    /// <param name="durationNoDamageTaken"></param>
    public SecondWindAugment(float percentageOfHitPoints, float durationNoDamageTaken)
    {
      Category = Category.Strength;
      _percentageOfHitPoints = percentageOfHitPoints;
      _durationNoDamageTaken = durationNoDamageTaken;
      IconName = "Avatar";
      Name = "Second Wind";
      Description = $"Units that have not taken damage for {durationNoDamageTaken} seconds regenerate {percentageOfHitPoints}% of their maximum hit points per second.";
    }

    /// <inheritdoc/>
    public override float GetWeight(Common.player whichPlayer)
    {
      return 10;
    }

    /// <inheritdoc/>
    public override void OnAdd(Faction whichFaction)
    {
      whichFaction.AddPower(new SecondWind(_percentageOfHitPoints, _durationNoDamageTaken)
      {
        IconName = IconName,
        Name = Name
      });
    }
  }
}
