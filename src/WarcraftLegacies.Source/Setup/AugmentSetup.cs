using MacroTools.Augments;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using System.Linq;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  public static class AugmentSetup
  {
    public static void Setup()
    {
      AugmentSystem.Register(new TitanicStrengthAugment(2.5f));
      AugmentSystem.Register(new IncomePowerAugment(10));
      AugmentSystem.Register(new LumberIncomeAugment(7));
      AugmentSystem.Register(new RapidMobilizationAugment(25));
      foreach (var legend in Legend.GetAllLegends().Where(l => IsHeroUnitId(l.Unit.GetTypeId())))
      {
        AugmentSystem.Register(new HeroExperienceAugment(legend, 5000));
      }
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, AugmentSystem.ShowAugmentPage, Constants.UPGRADE_R04R_FORTIFIED_HULLS_UNIVERSAL_UPGRADE);
    }
  }
}