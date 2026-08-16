using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Consumables.NomNoms;
using Xenon.Content.Items.Consumables.NomNoms.Veggies;
using Xenon.Content.Items.Weapons.Magic.SplashPotions.NegativeEffects;
using Xenon.Content.Items.Weapons.Magic.SplashPotions.PositiveEffects;
using Xenon.Content.Items.Weapons.Melee.Broadswords;
using Xenon.Content.NPCs.RhyoliteMobs;
using Xenon.Content.Projectiles.Magic.SplashPotionProj.PositiveEffectsProj;

namespace Xenon.Common.Data
{
    [ReinitializeDuringResizeArrays]
    public static class ItemSets
    {
        public static readonly bool[] BakersFood = ItemID.Sets.Factory.CreateBoolSet(
        #region Vanilla Food and eaten goods
        ItemID.Mushroom,
        ItemID.Apple,
        ItemID.Apricot,
        ItemID.Banana,
        ItemID.BlackCurrant,
        ItemID.BloodOrange,
        ItemID.Cherry,
        ItemID.Coconut,
        ItemID.Elderberry,
        ItemID.Grapefruit,
        ItemID.Lemon,
        ItemID.Mango,
        ItemID.Peach,
        ItemID.Pineapple,
        ItemID.Plum,
        ItemID.Pomegranate,
        ItemID.Rambutan,
        ItemID.SpicyPepper,
        ItemID.Dragonfruit,
        ItemID.Starfruit,
        ItemID.Grapes,
        #endregion

        #region Modded Food
        #region Fruit
        ModContent.ItemType<Lime>(),
        #endregion

        #region Veggies
        ModContent.ItemType<Beetroot>(),
        ModContent.ItemType<Broccoli>(),
        ModContent.ItemType<Cabbage>(),
        ModContent.ItemType<Garlic>(),
        ModContent.ItemType<Corn>(),
        ModContent.ItemType<Kohlrabi>(),
        ModContent.ItemType<Leek>(),
        ModContent.ItemType<Potato>(),
        ModContent.ItemType<Rhubarb>(),
        ModContent.ItemType<Spinach>()
        #endregion
        );
        #endregion

        public static readonly bool[] MechanicalToolReworkItemSet = ItemID.Sets.Factory.CreateBoolSet(
        ItemID.CobaltDrill,
        ItemID.PalladiumDrill,
        ItemID.MythrilDrill,
        ItemID.OrichalcumDrill,
        ItemID.AdamantiteDrill,
        ItemID.TitaniumDrill,
        ItemID.Drax,
        ItemID.ChlorophyteDrill,
        ItemID.LaserDrill,
        ItemID.VortexDrill,
        ItemID.SolarFlareDrill,
        ItemID.NebulaDrill,
        ItemID.StardustDrill,

        ItemID.CobaltChainsaw,
        ItemID.PalladiumChainsaw,
        ItemID.MythrilChainsaw,
        ItemID.OrichalcumChainsaw,
        ItemID.AdamantiteChainsaw,
        ItemID.TitaniumChainsaw,
        ItemID.ChlorophyteChainsaw,
        ItemID.ButchersChainsaw,

        ItemID.ChlorophyteJackhammer
        );

        public static readonly bool[] ItemsThatDefenseDecreaseWithoutSpecialBuffsFromXenonThatShouldGetLocalized = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.Rally,
            ModContent.ItemType<Scarlet>(),
            ModContent.ItemType<Greatsword>()
            );

        public static readonly bool[] SplashPotions = ItemID.Sets.Factory.CreateBoolSet(

        #region Good Effects
        ModContent.ItemType<AmmoReservationSplashPotion>(),
        ModContent.ItemType<ArcherySplashPotion>(),
        ModContent.ItemType<BattleSplashPotion>(),
        ModContent.ItemType<BiomeSightSplashPotion>(),
        ModContent.ItemType<BuilderSplashPotion>(),
        ModContent.ItemType<CalmingSplashPotion>(),
        ModContent.ItemType<CrateSplashPotion>(),
        ModContent.ItemType<DangersenseSplashPotion>(),
        ModContent.ItemType<EnduranceSplashPotion>(),
        ModContent.ItemType<FeatherfallSplashPotion>(),
        ModContent.ItemType<FishingSplashPotion>(),
        ModContent.ItemType<FlipperSplashPotion>(),
        ModContent.ItemType<GillsSplashPotion>(),
        ModContent.ItemType<GravitationSplashPotion>(),
        ModContent.ItemType<GreaterLuckSplashPotion>(),
        ModContent.ItemType<HeartreachSplashPotion>(),
        ModContent.ItemType<HunterSplashPotion>(),
        ModContent.ItemType<InfernoSplashPotion>(),
        ModContent.ItemType<InvisibilitySplashPotion>(),
        ModContent.ItemType<IronskinSplashPotion>(),
        ModContent.ItemType<LesserLuckSplashPotion>(),
        ModContent.ItemType<LifeforceSplashPotion>(),
        ModContent.ItemType<LuckSplashPotion>(),
        ModContent.ItemType<MagicPowerSplashPotion>(),
        ModContent.ItemType<ManaRegenerationSplashPotion>(),
        ModContent.ItemType<MiningSplashPotion>(),
        ModContent.ItemType<NightOwlSplashPotion>(),
        ModContent.ItemType<ObsidianskinSplashPotion>(),
        ModContent.ItemType<RageSplashPotion>(),
        ModContent.ItemType<RegenerationSplashPotion>(),
        ModContent.ItemType<ShineSplashPotion>(),
        ModContent.ItemType<SonarSplashPotion>(),
        ModContent.ItemType<SpelunkerSplashPotion>(),
        ModContent.ItemType<SummoningSplashPotion>(),
        ModContent.ItemType<SwiftnessSplashPotion>(),
        ModContent.ItemType<ThornsSplashPotion>(),
        ModContent.ItemType<TitanSplashPotion>(),
        ModContent.ItemType<WarmthSplashPotion>(),
        ModContent.ItemType<WaterwalkingSplashPotion>(),
        ModContent.ItemType<WraithSplashPotion>(),
        #endregion

        #region Bad effects
        ModContent.ItemType<DeathforceSplashPotion>(),
        ModContent.ItemType<PoisonSplashPotion>()
        #endregion
        );
    }
}
