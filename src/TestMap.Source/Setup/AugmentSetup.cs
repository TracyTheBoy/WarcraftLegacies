﻿using MacroTools.Augments;
using MacroTools.FactionSystem;

namespace TestMap.Source.Setup
{
  public static class AugmentSetup
  {
    public static void Setup()
    {
      AugmentSystem.Register(new SecondWindAugment(2.5f, 6));
      AugmentSystem.Register(new TitanicStrengthAugment(2.5f));
      AugmentSystem.Register(new IncomePowerAugment(10));
      AugmentSystem.Register(new LumberIncomeAugment(1400));
      AugmentSystem.Register(new RapidMobilizationAugment(25));
      foreach (var legend in Legend.GetAllLegends())
      {
        AugmentSystem.Register(new HeroExperienceAugment(legend, 5000));
      }
    }
  }
}