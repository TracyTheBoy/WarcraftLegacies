﻿using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.Setup
{
  public static class TeamSetup{
    public static Team Legion { get; private set; }
    public static Team Alliance { get; private set; }
    public static Team NorthAlliance { get; private set; }
    public static Team SouthAlliance { get; private set; }
    public static Team Horde { get; private set; }
    public static Team NightElves { get; private set; }
    public static Team Illidari { get; private set; }
    public static Team Gilneas { get; private set; }
    public static Team ScarletCrusade { get; private set; }
    public static Team Forsaken { get; private set; }
    public static Team Scourge { get; private set; }
    public static Team Dragonmaw { get; private set; }
    public static Team Draenei { get; private set; }


    public static void Setup( ){
      Alliance = new Team("Alliance")
      {
        VictoryMusic = "HeroicVictory"
      };
      FactionManager.Register(Alliance);

      NorthAlliance = new Team("North Alliance")
      {
        VictoryMusic = "HeroicVictory"
      };
      FactionManager.Register(NorthAlliance);

      SouthAlliance = new Team("South Alliance")
      {
        VictoryMusic = "HeroicVictory"
      };
      FactionManager.Register(SouthAlliance);

      Legion = new Team("Burning Legion")
      {
        VictoryMusic = "DarkVictory"
      };
      FactionManager.Register(Legion);

      Horde = new Team("Horde")
      {
        VictoryMusic = "DarkVictory"
      };
      FactionManager.Register(Horde);
      
      NightElves = new Team("Night Elves")
      {
        VictoryMusic = "HeroicVictory"
      };
      FactionManager.Register(NightElves);

      Illidari = new Team("Illidari")
      {
        VictoryMusic = "DarkVictory"
      };
      FactionManager.Register(Illidari);
      
      Gilneas = new Team("Gilneas")
      {
        VictoryMusic = "HeroicVictory"
      };
      FactionManager.Register(Gilneas);
      
      ScarletCrusade = new Team("Scarlet Crusade")
      {
        VictoryMusic = "DarkVictory"
      };
      FactionManager.Register(ScarletCrusade);
      
      Forsaken = new Team("Forsaken")
      {
        VictoryMusic = "DarkVictory"
      };
      FactionManager.Register(Forsaken);
      
      Scourge = new Team("Northrend")
      {
        VictoryMusic = "DarkVictory"
      };
      FactionManager.Register(Scourge);

      Dragonmaw = new Team("Dragonmaw")
      {
        VictoryMusic = "DarkVictory"
      };
      FactionManager.Register(Dragonmaw);

      Draenei = new Team("Draenei")
      {
        VictoryMusic = "HeroicVictory"
      };
      FactionManager.Register(Draenei);
    }

  }
}
