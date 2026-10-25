using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Consumables.GlugGlugs;
using Xenon.Content.Items.Consumables.NomNoms;
using Xenon.Content.Items.Consumables.NomNoms.OreFood;
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
        ModContent.ItemType<Bilimbi>(),

        ModContent.ItemType<CopperGrapefruit>(),
        ModContent.ItemType<AluminumGrapefruit>(),
        ModContent.ItemType<TinGrapefruit>(),
        ModContent.ItemType<IronLemon>(),
        ModContent.ItemType<CinnabarLemon>(),
        ModContent.ItemType<LeadLemon>(),
        ModContent.ItemType<SilverApricot>(),
        ModContent.ItemType<IndiumApricot>(),
        ModContent.ItemType<TungstenApricot>(),
        ModContent.ItemType<GoldApple>(),
        ModContent.ItemType<FluoriteApple>(),
        ModContent.ItemType<PlatinumApple>());

        #endregion
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
            );
        #endregion

        //not sure if ill use this set later, but i made it just incase i end up doing so
        public static readonly bool[] BuffPotions = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.AmmoReservationPotion,
            ItemID.ArcheryPotion,
            ItemID.BattlePotion,
            ItemID.BiomeSightPotion,
            ItemID.BuilderPotion,
            ItemID.CalmingPotion,
            ItemID.CratePotion,
            ItemID.TrapsightPotion,
            ItemID.EndurancePotion,
            ItemID.FeatherfallPotion,
            ItemID.FishingPotion,
            ItemID.FlipperPotion,
            ItemID.GillsPotion,
            ItemID.GravitationPotion,
            ItemID.HeartreachPotion,
            ItemID.HunterPotion,
            ItemID.InfernoPotion,
            ItemID.InvisibilityPotion,
            ItemID.IronskinPotion,
            ItemID.LuckPotionLesser,
            ItemID.LuckPotion,
            ItemID.LuckPotionGreater,
            ItemID.LifeforcePotion,
            ItemID.MagicPowerPotion,
            ItemID.ManaRegenerationPotion,
            ItemID.MiningPotion,
            ItemID.NightOwlPotion,
            ItemID.ObsidianSkinPotion,
            ItemID.RagePotion,
            ItemID.RegenerationPotion,
            ItemID.ShinePotion,
            ItemID.SonarPotion,
            ItemID.SpelunkerPotion,
            ItemID.SummoningPotion,
            ItemID.SwiftnessPotion,
            ItemID.ThornsPotion,
            ItemID.TitanPotion,
            ItemID.WarmthPotion,
            ItemID.WaterWalkingPotion,
            ItemID.WrathPotion,
            ModContent.ItemType<AngerPotion>(),
            ModContent.ItemType<DeathforcePotion>(),
            ModContent.ItemType<FrigerationPotion>(),
            ModContent.ItemType<Poison>()
            );

        //for nausea
        public static readonly bool[] FoodOrDrinkLikeConsumables = ItemID.Sets.Factory.CreateBoolSet(
        #region Recovery
            ItemID.Mushroom,
            ItemID.BottledHoney,
            ItemID.BottledWater,
            ItemID.GreaterHealingPotion,
            ItemID.HealingPotion,
            ItemID.LesserHealingPotion,
            ItemID.ManaPotion,
            ItemID.RestorationPotion,
            ItemID.SuperHealingPotion,
            ItemID.SuperManaPotion,
            ItemID.GreaterManaPotion,
            ItemID.LesserManaPotion,
            ItemID.Eggnog,
            ItemID.Honeyfin,
            ItemID.StrangeBrew,
        #endregion

        #region Food and Drinks
            ItemID.Ale,
            ItemID.Sake,
        #endregion

        #region Buff Potions
            ItemID.AmmoReservationPotion,
            ItemID.ArcheryPotion,
            ItemID.BattlePotion,
            ItemID.BiomeSightPotion,
            ItemID.BuilderPotion,
            ItemID.CalmingPotion,
            ItemID.CratePotion,
            ItemID.TrapsightPotion,
            ItemID.EndurancePotion,
            ItemID.FeatherfallPotion,
            ItemID.FishingPotion,
            ItemID.FlipperPotion,
            ItemID.GillsPotion,
            ItemID.GravitationPotion,
            ItemID.HeartreachPotion,
            ItemID.HunterPotion,
            ItemID.InfernoPotion,
            ItemID.InvisibilityPotion,
            ItemID.IronskinPotion,
            ItemID.LuckPotionLesser,
            ItemID.LuckPotion,
            ItemID.LuckPotionGreater,
            ItemID.LifeforcePotion,
            ItemID.MagicPowerPotion,
            ItemID.ManaRegenerationPotion,
            ItemID.MiningPotion,
            ItemID.NightOwlPotion,
            ItemID.ObsidianSkinPotion,
            ItemID.RagePotion,
            ItemID.RegenerationPotion,
            ItemID.ShinePotion,
            ItemID.SonarPotion,
            ItemID.SpelunkerPotion,
            ItemID.SummoningPotion,
            ItemID.SwiftnessPotion,
            ItemID.ThornsPotion,
            ItemID.TitanPotion,
            ItemID.WarmthPotion,
            ItemID.WaterWalkingPotion,
            ItemID.WrathPotion,
            ModContent.ItemType<AngerPotion>(),
            ModContent.ItemType<DeathforcePotion>(),
            ModContent.ItemType<FrigerationPotion>(),
            ModContent.ItemType<Poison>(),
        #endregion

        #region Other potions
            ItemID.GenderChangePotion,
            ItemID.PotionOfReturn,
            ItemID.RecallPotion,
            ItemID.TeleportationPotion,
            ItemID.WormholePotion,
            ItemID.RedPotion
        #endregion
            );
    }
}
