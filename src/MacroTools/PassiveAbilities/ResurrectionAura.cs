﻿using MacroTools.Buffs;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.PassiveAbilities
{
  public sealed class ResurrectionAura : PassiveAbility
  {
    public float ResurrectionChance { get; init; } = 0.35f;
    
    public ResurrectionAura(int unitTypeId) : base(unitTypeId)
    {
    }

    public override void OnCreated(unit createdUnit)
    {
      var aura = new ResurrectionAuraCaster(createdUnit, ResurrectionChance);
      AuraSystem.Add(aura);
    }
  }
}