using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Epibuffs.OreFruitBuffs;
using Xenon.Content.Items.Consumables.GlugGlugs;
using Xenon.Content.Items.Consumables.NomNoms;
using Xenon.Content.Items.Weapons.Magic.SplashPotions.NegativeEffects;
using Xenon.Content.Items.Weapons.Magic.SplashPotions.PositiveEffects;
using Xenon.Content.Items.Weapons.Melee.Broadswords;
using Xenon.Content.NPCs.RhyoliteMobs;
using Xenon.Content.Projectiles.Magic.SplashPotionProj.PositiveEffectsProj;

namespace Xenon.Common.Data
{
    [ReinitializeDuringResizeArrays]
    public static class BuffSets
    {
        public static readonly bool[] IsApecialFoodOrDrink = BuffID.Sets.Factory.CreateBoolSet(
            ModContent.BuffType<AluminumGrapefruitBuff>(),
            ModContent.BuffType<CopperGrapefruitBuff>(),
            ModContent.BuffType<TinGrapefruitBuff>()
            );
    }
}
