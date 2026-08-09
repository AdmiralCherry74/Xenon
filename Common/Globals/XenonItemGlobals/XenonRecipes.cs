using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.Vanity.OreCrowns;
using Xenon.Content.Items.DeveloperItems.DeveloperItems;
using Xenon.Content.Items.Fish;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.Organic;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;
using Xenon.Content.Items.Tools.GardeningHoes;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class XenonRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup EvilFish = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Ebonkoi)}", ItemID.Ebonkoi, ItemID.Hemopiranha, ModContent.ItemType<Corrodoras>());
            RecipeGroup.RegisterGroup(nameof(ItemID.Ebonkoi), EvilFish);
            //Evil Fish recipe group

            RecipeGroup CopperBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar, ModContent.ItemType<AluminumBar>());
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), CopperBar);
            //Copper Bar recipe group

            RecipeGroup Thorns = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<ThornyBush>())}", ModContent.ItemType<JungleThornyBushItem>(), ModContent.ItemType<CorruptedThornyBushItem>(), ModContent.ItemType<CrimfiedThornyBushItem>(), ModContent.ItemType<CorrodedThornyBushItem>());
            RecipeGroup.RegisterGroup("Xenon:Thorns", Thorns);
            //Thorns recipe group 

            RecipeGroup EvilSouls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<EvilSouls>())}", ItemID.SoulofNight, ModContent.ItemType<SoulofSpite>(), ModContent.ItemType<SoulofBlight>());
            RecipeGroup.RegisterGroup("Xenon:EvilSouls", EvilSouls);
            //Evil Souls recipe group

            RecipeGroup HolySouls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<HolySouls>())}", ItemID.SoulofLight, ModContent.ItemType<SoulofTwilight>());
            RecipeGroup.RegisterGroup("Xenon:HolySouls", HolySouls);
            //Holy Souls recipe group

            //Wood recipe group
            RecipeGroup groupwood = RecipeGroup.recipeGroups[RecipeGroupID.Wood];
            groupwood.ValidItems.Add(ModContent.ItemType<BilewoodItem>());
            groupwood.ValidItems.Add(ModContent.ItemType<JacarandawoodItem>());

            //Iron recipe group
            RecipeGroup groupiron = RecipeGroup.recipeGroups[RecipeGroupID.IronBar];
            groupiron.ValidItems.Add(ModContent.ItemType<CinnabarBar>());
        }
        public override void AddRecipes()
        {
            Recipe.Create(ItemID.SpellTome)
                .AddIngredient(ItemID.Book)
                .AddIngredient(ItemID.ManaCrystal, 3)
                .AddTile(TileID.Bookcases)
                //.SortAfterFirstRecipesOf(ItemID.Titties)
                .Register();

            Recipe.Create(ItemID.SnowGlobe)
                .AddIngredient(ItemID.SnowBlock, 25)
                .AddIngredient(ItemID.Glass, 5)
                .AddIngredient(ItemID.Bone, 1)
                .AddTile(TileID.DemonAltar)
                .SortAfterFirstRecipesOf(ItemID.GoblinBattleStandard)
                .Register();

            Recipe.Create(ItemID.MechanicalSkull)
                .AddIngredient(ModContent.ItemType<Brain>(), 30)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddRecipeGroup("Xenon:HolySouls", 3)
                .AddRecipeGroup("Xenon:EvilSouls", 3)
                .AddIngredient(ModContent.ItemType<SoulOfRight>(), 3)
                .AddTile(TileID.MythrilAnvil)
                .SortAfterFirstRecipesOf(ItemID.MechanicalSkull)
                .Register();

            Recipe.Create(ItemID.MechanicalWorm)
                .AddIngredient(ModContent.ItemType<Bolus>(), 6)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddRecipeGroup("Xenon:EvilSouls", 6)
                .AddTile(TileID.MythrilAnvil)
                .SortAfterFirstRecipesOf(ItemID.MechanicalWorm)
                .Register();

            Recipe.Create(ItemID.Hook)
            .AddRecipeGroup(RecipeGroupID.IronBar, 4)
            .AddRecipeGroup("CopperBar")
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.Chain)
            .Register();


        }

        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe PlatinumCrownChange = Main.recipe[i];
                if (PlatinumCrownChange.HasIngredient(ItemID.PlatinumBar) && PlatinumCrownChange.HasIngredient(ItemID.Ruby) && PlatinumCrownChange.HasTile(TileID.Anvils) && PlatinumCrownChange.HasResult(ItemID.PlatinumCrown))
                {
                    PlatinumCrownChange.HasTile(TileID.DemonAltar);
                    PlatinumCrownChange.RemoveTile(TileID.Anvils);
                    PlatinumCrownChange.SortAfterFirstRecipesOf(ModContent.ItemType<PlatinumCrownModern>());
                }

                #region Replacing certain Soul based recipes with their respective recipe groups
                Recipe CoolWhipSwap = Main.recipe[i];
                if (CoolWhipSwap.HasIngredient(ItemID.SoulofLight) && CoolWhipSwap.HasIngredient(ItemID.SoulofNight) && CoolWhipSwap.HasIngredient(ItemID.FrostCore) && CoolWhipSwap.HasTile(TileID.MythrilAnvil) && CoolWhipSwap.HasResult(ItemID.CoolWhip))
                {
                    CoolWhipSwap.RemoveIngredient(ItemID.SoulofLight);
                    CoolWhipSwap.RemoveIngredient(ItemID.SoulofNight);
                    CoolWhipSwap.AddRecipeGroup("Xenon:HolySouls", 8);
                    CoolWhipSwap.AddRecipeGroup("Xenon:EvilSouls", 8);
                }
                Recipe DaySensorSwap = Main.recipe[i];
                if (DaySensorSwap.HasIngredient(ItemID.SoulofLight) && DaySensorSwap.HasRecipeGroup(RecipeGroupID.IronBar) && DaySensorSwap.HasIngredient(ItemID.Wire) && DaySensorSwap.HasTile(TileID.MythrilAnvil) && DaySensorSwap.HasResult(ItemID.LogicSensor_Sun))
                {
                    DaySensorSwap.RemoveIngredient(ItemID.SoulofLight);
                    DaySensorSwap.AddRecipeGroup("Xenon:HolySouls", 5);
                }
                Recipe MechanicalEyeSwap = Main.recipe[i];
                if (MechanicalEyeSwap.HasIngredient(ItemID.SoulofLight) && MechanicalEyeSwap.HasRecipeGroup(RecipeGroupID.IronBar) && MechanicalEyeSwap.HasIngredient(ItemID.Lens) && MechanicalEyeSwap.HasTile(TileID.MythrilAnvil) && MechanicalEyeSwap.HasResult(ItemID.LogicSensor_Sun))
                {
                    MechanicalEyeSwap.RemoveIngredient(ItemID.SoulofLight);
                    MechanicalEyeSwap.AddRecipeGroup("Xenon:HolySouls", 6);
                }
                Recipe MechanicalSkullChange = Main.recipe[i];
                if (MechanicalSkullChange.HasIngredient(ItemID.SoulofLight) && MechanicalSkullChange.HasIngredient(ItemID.SoulofNight) && MechanicalSkullChange.HasRecipeGroup(RecipeGroupID.IronBar) && MechanicalSkullChange.HasIngredient(ItemID.Bone) && MechanicalSkullChange.HasTile(TileID.MythrilAnvil) && MechanicalSkullChange.HasResult(ItemID.MechanicalSkull))
                {
                    MechanicalSkullChange.RemoveIngredient(ItemID.SoulofLight);
                    MechanicalSkullChange.RemoveIngredient(ItemID.SoulofNight);
                    MechanicalSkullChange.AddRecipeGroup("Xenon:HolySouls", 3);
                    MechanicalSkullChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                    MechanicalSkullChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                }
                Recipe MechanicalWormRottenChunkSwap = Main.recipe[i];
                if (MechanicalWormRottenChunkSwap.HasIngredient(ItemID.SoulofNight) && MechanicalWormRottenChunkSwap.HasIngredient(ItemID.RottenChunk) && MechanicalWormRottenChunkSwap.HasRecipeGroup(RecipeGroupID.IronBar) && MechanicalWormRottenChunkSwap.HasTile(TileID.MythrilAnvil) && MechanicalWormRottenChunkSwap.HasResult(ItemID.MechanicalWorm))
                {
                    MechanicalWormRottenChunkSwap.RemoveIngredient(ItemID.SoulofNight);
                    MechanicalWormRottenChunkSwap.AddRecipeGroup("Xenon:EvilSouls", 6);
                }
                Recipe MechanicalWormVertebraeSwap = Main.recipe[i];
                if (MechanicalWormVertebraeSwap.HasIngredient(ItemID.SoulofNight) && MechanicalWormVertebraeSwap.HasIngredient(ItemID.Vertebrae) && MechanicalWormVertebraeSwap.HasRecipeGroup(RecipeGroupID.IronBar) && MechanicalWormVertebraeSwap.HasTile(TileID.MythrilAnvil) && MechanicalWormVertebraeSwap.HasResult(ItemID.MechanicalWorm))
                {
                    MechanicalWormVertebraeSwap.RemoveIngredient(ItemID.SoulofNight);
                    MechanicalWormVertebraeSwap.AddRecipeGroup("Xenon:EvilSouls", 6);
                }
                Recipe MeteorStaffSwap = Main.recipe[i];
                if (MeteorStaffSwap.HasIngredient(ItemID.SoulofLight) && MeteorStaffSwap.HasIngredient(ItemID.MeteoriteBar) && MeteorStaffSwap.HasIngredient(ItemID.PixieDust) && MeteorStaffSwap.HasTile(TileID.MythrilAnvil) && MeteorStaffSwap.HasResult(ItemID.MeteorStaff))
                {
                    MeteorStaffSwap.RemoveIngredient(ItemID.SoulofLight);
                    MeteorStaffSwap.AddRecipeGroup("Xenon:HolySouls", 6);
                }
                Recipe SkyFractureSwap = Main.recipe[i];
                if (SkyFractureSwap.HasIngredient(ItemID.SoulofLight) && SkyFractureSwap.HasIngredient(ItemID.LightShard) && SkyFractureSwap.HasIngredient(ItemID.MagicMissile) && SkyFractureSwap.HasTile(TileID.MythrilAnvil) && SkyFractureSwap.HasResult(ItemID.SkyFracture))
                {
                    SkyFractureSwap.RemoveIngredient(ItemID.SoulofLight);
                    SkyFractureSwap.AddRecipeGroup("Xenon:HolySouls", 16);
                }
                Recipe FleshCloningVatSwap = Main.recipe[i];
                if (FleshCloningVatSwap.HasIngredient(ItemID.SoulofNight) && FleshCloningVatSwap.HasIngredient(ItemID.FleshCloningVaat) && FleshCloningVatSwap.HasCondition(Condition.InGraveyard) && FleshCloningVatSwap.HasTile(TileID.WorkBenches) && FleshCloningVatSwap.HasResult(ItemID.FleshCloningVaat))
                {
                    FleshCloningVatSwap.RemoveIngredient(ItemID.SoulofNight);
                    FleshCloningVatSwap.AddIngredient(ModContent.ItemType<SoulofSpite>(), 10);
                }
                Recipe NightSensorSwap = Main.recipe[i];
                if (NightSensorSwap.HasIngredient(ItemID.SoulofNight) && NightSensorSwap.HasRecipeGroup(RecipeGroupID.IronBar) && NightSensorSwap.HasIngredient(ItemID.Wire) && NightSensorSwap.HasTile(TileID.MythrilAnvil) && NightSensorSwap.HasResult(ItemID.LogicSensor_Moon))
                {
                    NightSensorSwap.RemoveIngredient(ItemID.SoulofNight);
                    NightSensorSwap.AddRecipeGroup("Xenon:EvilSouls", 5);
                }
                Recipe OnyxBlasterSwap = Main.recipe[i];
                if (OnyxBlasterSwap.HasIngredient(ItemID.SoulofNight) && OnyxBlasterSwap.HasIngredient(ItemID.DarkShard) && OnyxBlasterSwap.HasIngredient(ItemID.Shotgun) && OnyxBlasterSwap.HasTile(TileID.MythrilAnvil) && OnyxBlasterSwap.HasResult(ItemID.OnyxBlaster))
                {
                    OnyxBlasterSwap.RemoveIngredient(ItemID.SoulofNight);
                    OnyxBlasterSwap.AddRecipeGroup("Xenon:EvilSouls", 10);
                }
                Recipe SpiritFlameSwap = Main.recipe[i];
                if (SpiritFlameSwap.HasIngredient(ItemID.SoulofNight) && SpiritFlameSwap.HasIngredient(ItemID.AncientBattleArmorMaterial) && SpiritFlameSwap.HasIngredient(ItemID.DjinnLamp) && SpiritFlameSwap.HasTile(TileID.MythrilAnvil) && SpiritFlameSwap.HasResult(ItemID.SpiritFlame))
                {
                    SpiritFlameSwap.RemoveIngredient(ItemID.SoulofNight);
                    SpiritFlameSwap.AddRecipeGroup("Xenon:EvilSouls", 12);
                }
                #endregion

                #region Hardmode Ores
                #region Cobalt Recipes
                Recipe CobaltHelmetChange = Main.recipe[i];
                if (CobaltHelmetChange.HasIngredient(ItemID.CobaltBar) && CobaltHelmetChange.HasTile(TileID.Anvils) && CobaltHelmetChange.HasResult(ItemID.CobaltHelmet))
                {
                    CobaltHelmetChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                }
                Recipe CobaltMaskChange = Main.recipe[i];
                if (CobaltMaskChange.HasIngredient(ItemID.CobaltBar) && CobaltMaskChange.HasTile(TileID.Anvils) && CobaltMaskChange.HasResult(ItemID.CobaltMask))
                {
                    CobaltMaskChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                }
                Recipe CobaltHatChange = Main.recipe[i];
                if (CobaltHatChange.HasIngredient(ItemID.CobaltBar) && CobaltHatChange.HasTile(TileID.Anvils) && CobaltHatChange.HasResult(ItemID.CobaltHat))
                {
                    CobaltMaskChange.AddRecipeGroup("Xenon:HolySouls", 3);
                }

                Recipe CobaltBreastplateChange = Main.recipe[i];
                if (CobaltBreastplateChange.HasIngredient(ItemID.CobaltBar) && CobaltBreastplateChange.HasTile(TileID.Anvils) && CobaltBreastplateChange.HasResult(ItemID.CobaltBreastplate))
                {
                    CobaltBreastplateChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    CobaltBreastplateChange.AddRecipeGroup("Xenon:HolySouls");
                    CobaltBreastplateChange.AddRecipeGroup("Xenon:EvilSouls");
                }

                Recipe CobaltLeggingsChange = Main.recipe[i];
                if (CobaltLeggingsChange.HasIngredient(ItemID.CobaltBar) && CobaltLeggingsChange.HasTile(TileID.Anvils) && CobaltLeggingsChange.HasResult(ItemID.CobaltLeggings))
                {
                    CobaltLeggingsChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    CobaltLeggingsChange.AddRecipeGroup("Xenon:HolySouls");
                    CobaltLeggingsChange.AddRecipeGroup("Xenon:EvilSouls");
                }

                Recipe CobaltDrillChange = Main.recipe[i];
                if (CobaltDrillChange.HasIngredient(ItemID.CobaltBar) && CobaltDrillChange.HasTile(TileID.Anvils) && CobaltDrillChange.HasResult(ItemID.CobaltDrill))
                {
                    CobaltDrillChange.AddIngredient(ItemID.Wire, 3);
                    CobaltDrillChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    CobaltDrillChange.AddRecipeGroup("Xenon:HolySouls");
                    CobaltDrillChange.AddRecipeGroup("Xenon:EvilSouls");
                    CobaltDrillChange.AddIngredient(ItemID.Switch);
                }
                Recipe CobaltPickaxeChange = Main.recipe[i];
                if (CobaltPickaxeChange.HasIngredient(ItemID.CobaltBar) && CobaltPickaxeChange.HasTile(TileID.Anvils) && CobaltPickaxeChange.HasResult(ItemID.CobaltPickaxe))
                {
                    CobaltPickaxeChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    CobaltPickaxeChange.AddRecipeGroup("Xenon:HolySouls");
                    CobaltPickaxeChange.AddRecipeGroup("Xenon:EvilSouls");
                }
                Recipe CobaltChainsawChange = Main.recipe[i];
                if (CobaltChainsawChange.HasIngredient(ItemID.CobaltBar) && CobaltChainsawChange.HasTile(TileID.Anvils) && CobaltChainsawChange.HasResult(ItemID.CobaltChainsaw))
                {
                    CobaltChainsawChange.AddIngredient(ItemID.Wire, 3);
                    CobaltChainsawChange.AddIngredient(ItemID.Switch);
                }
                #endregion

                #region Palladium Recipes             
                Recipe PalladiumMaskChange = Main.recipe[i];
                if (PalladiumMaskChange.HasIngredient(ItemID.PalladiumBar) && PalladiumMaskChange.HasTile(TileID.Anvils) && PalladiumMaskChange.HasResult(ItemID.PalladiumMask))
                {
                    PalladiumMaskChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                }
                Recipe PalladiumHelmetChange = Main.recipe[i];
                if (PalladiumHelmetChange.HasIngredient(ItemID.PalladiumBar) && PalladiumHelmetChange.HasTile(TileID.Anvils) && PalladiumHelmetChange.HasResult(ItemID.PalladiumHelmet))
                {
                    PalladiumHelmetChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                }
                Recipe PalladiumHeadgearChange = Main.recipe[i];
                if (PalladiumHeadgearChange.HasIngredient(ItemID.PalladiumBar) && PalladiumHeadgearChange.HasTile(TileID.Anvils) && PalladiumHeadgearChange.HasResult(ItemID.PalladiumHeadgear))
                {
                    PalladiumHeadgearChange.AddRecipeGroup("Xenon:HolySouls", 3);
                }
                Recipe PalladiumBreastplateChange = Main.recipe[i];
                if (PalladiumBreastplateChange.HasIngredient(ItemID.PalladiumBar) && PalladiumBreastplateChange.HasTile(TileID.Anvils) && PalladiumBreastplateChange.HasResult(ItemID.PalladiumBreastplate))
                {
                    PalladiumBreastplateChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    PalladiumBreastplateChange.AddRecipeGroup("Xenon:HolySouls");
                    PalladiumBreastplateChange.AddRecipeGroup("Xenon:EvilSouls");
                }

                Recipe PalladiumLeggingsChange = Main.recipe[i];
                if (PalladiumLeggingsChange.HasIngredient(ItemID.PalladiumBar) && PalladiumLeggingsChange.HasTile(TileID.Anvils) && PalladiumLeggingsChange.HasResult(ItemID.PalladiumLeggings))
                {
                    PalladiumLeggingsChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    PalladiumLeggingsChange.AddRecipeGroup("Xenon:HolySouls");
                    PalladiumLeggingsChange.AddRecipeGroup("Xenon:EvilSouls");
                }

                Recipe PalladiumDrillChange = Main.recipe[i];
                if (PalladiumDrillChange.HasIngredient(ItemID.PalladiumBar) && PalladiumDrillChange.HasTile(TileID.Anvils) && PalladiumDrillChange.HasResult(ItemID.PalladiumDrill))
                {
                    PalladiumDrillChange.AddIngredient(ItemID.Wire, 4);
                    PalladiumDrillChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    PalladiumDrillChange.AddRecipeGroup("Xenon:HolySouls");
                    PalladiumDrillChange.AddRecipeGroup("Xenon:EvilSouls");
                    PalladiumDrillChange.AddIngredient(ItemID.Switch, 2);
                }
                Recipe PalladiumPickaxeChange = Main.recipe[i];
                if (PalladiumPickaxeChange.HasIngredient(ItemID.PalladiumBar) && PalladiumPickaxeChange.HasTile(TileID.Anvils) && PalladiumPickaxeChange.HasResult(ItemID.PalladiumPickaxe))
                {
                    PalladiumPickaxeChange.AddIngredient(ModContent.ItemType<SoulOfRight>());
                    PalladiumPickaxeChange.AddRecipeGroup("Xenon:HolySouls");
                    PalladiumPickaxeChange.AddRecipeGroup("Xenon:EvilSouls");
                }
                Recipe PalladiumChainsawChange = Main.recipe[i];
                if (PalladiumChainsawChange.HasIngredient(ItemID.PalladiumBar) && PalladiumChainsawChange.HasTile(TileID.Anvils) && PalladiumChainsawChange.HasResult(ItemID.PalladiumChainsaw))
                {
                    PalladiumChainsawChange.AddIngredient(ItemID.Wire, 4);
                    PalladiumChainsawChange.AddIngredient(ItemID.Switch, 2);
                }
                #endregion

                #region Mythril Recipes
                    Recipe MythrilHelmetChange = Main.recipe[i];
                    if (MythrilHelmetChange.HasIngredient(ItemID.MythrilBar) && MythrilHelmetChange.HasTile(TileID.MythrilAnvil) && MythrilHelmetChange.HasResult(ItemID.MythrilHelmet))
                    {
                        MythrilHelmetChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 6);
                    }
                    Recipe MythrilHatChange = Main.recipe[i];
                    if (MythrilHatChange.HasIngredient(ItemID.MythrilBar) && MythrilHatChange.HasTile(TileID.MythrilAnvil) && MythrilHatChange.HasResult(ItemID.MythrilHat))
                    {
                        MythrilHatChange.AddRecipeGroup("Xenon:EvilSouls", 6);
                    }
                    Recipe MythrilHoodChange = Main.recipe[i];
                    if (MythrilHoodChange.HasIngredient(ItemID.MythrilBar) && MythrilHoodChange.HasTile(TileID.MythrilAnvil) && MythrilHoodChange.HasResult(ItemID.MythrilHood))
                    {
                        MythrilHoodChange.AddRecipeGroup("Xenon:HolySouls", 6);
                    }

                    Recipe MythrilChainmailChange = Main.recipe[i];
                    if (MythrilChainmailChange.HasIngredient(ItemID.MythrilBar) && MythrilChainmailChange.HasTile(TileID.MythrilAnvil) && MythrilChainmailChange.HasResult(ItemID.MythrilChainmail))
                    {
                        MythrilChainmailChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        MythrilChainmailChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        MythrilChainmailChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                    }

                    Recipe MythrilGreavesChange = Main.recipe[i];
                    if (MythrilGreavesChange.HasIngredient(ItemID.MythrilBar) && MythrilGreavesChange.HasTile(TileID.MythrilAnvil) && MythrilGreavesChange.HasResult(ItemID.MythrilGreaves))
                    {
                        MythrilGreavesChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        MythrilGreavesChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        MythrilGreavesChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                    }

                    Recipe MythrilDrillChange = Main.recipe[i];
                    if (MythrilDrillChange.HasIngredient(ItemID.MythrilBar) && MythrilDrillChange.HasTile(TileID.MythrilAnvil) && MythrilDrillChange.HasResult(ItemID.MythrilDrill))
                    {
                        MythrilDrillChange.AddIngredient(ItemID.Wire, 5);
                        MythrilDrillChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        MythrilDrillChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        MythrilDrillChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                        MythrilDrillChange.AddIngredient(ItemID.Switch);
                    }
                    Recipe MythrilPickaxeChange = Main.recipe[i];
                    if (MythrilPickaxeChange.HasIngredient(ItemID.MythrilBar) && MythrilPickaxeChange.HasTile(TileID.MythrilAnvil) && MythrilPickaxeChange.HasResult(ItemID.MythrilPickaxe))
                    {
                        MythrilPickaxeChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        MythrilPickaxeChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        MythrilPickaxeChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                    }
                    Recipe MythrilChainsawChange = Main.recipe[i];
                    if (MythrilChainsawChange.HasIngredient(ItemID.MythrilBar) && MythrilChainsawChange.HasTile(TileID.MythrilAnvil) && MythrilChainsawChange.HasResult(ItemID.MythrilChainsaw))
                    {
                        MythrilChainsawChange.AddIngredient(ItemID.Wire, 5);
                        MythrilChainsawChange.AddIngredient(ItemID.Switch);
                    }
                    #endregion

                #region Orichalcum Recipes
                    Recipe OrichalcumMaskChange = Main.recipe[i];
                    if (OrichalcumMaskChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumMaskChange.HasTile(TileID.MythrilAnvil) && OrichalcumMaskChange.HasResult(ItemID.OrichalcumMask))
                    {
                        OrichalcumMaskChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 6);
                    }
                    Recipe OrichalcumHelmetChange = Main.recipe[i];
                    if (OrichalcumHelmetChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumHelmetChange.HasTile(TileID.MythrilAnvil) && OrichalcumHelmetChange.HasResult(ItemID.OrichalcumHelmet))
                    {
                        OrichalcumHelmetChange.AddRecipeGroup("Xenon:EvilSouls", 6);
                    }
                    Recipe OrichalcumHeadgearChange = Main.recipe[i];
                    if (OrichalcumHeadgearChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumHeadgearChange.HasTile(TileID.MythrilAnvil) && OrichalcumHeadgearChange.HasResult(ItemID.OrichalcumHeadgear))
                    {
                        OrichalcumHeadgearChange.AddRecipeGroup("Xenon:HolySouls", 6);
                    }

                    Recipe OrichalcumBreastplateChange = Main.recipe[i];
                    if (OrichalcumBreastplateChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumBreastplateChange.HasTile(TileID.MythrilAnvil) && OrichalcumBreastplateChange.HasResult(ItemID.OrichalcumBreastplate))
                    {
                        OrichalcumBreastplateChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        OrichalcumBreastplateChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        OrichalcumBreastplateChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                    }

                    Recipe OrichalcumLeggingsChange = Main.recipe[i];
                    if (OrichalcumLeggingsChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumLeggingsChange.HasTile(TileID.MythrilAnvil) && OrichalcumLeggingsChange.HasResult(ItemID.OrichalcumLeggings))
                    {
                        OrichalcumLeggingsChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        OrichalcumLeggingsChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        OrichalcumLeggingsChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                    }

                    Recipe OrichalcumDrillChange = Main.recipe[i];
                    if (OrichalcumDrillChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumDrillChange.HasTile(TileID.MythrilAnvil) && OrichalcumDrillChange.HasResult(ItemID.OrichalcumDrill))
                    {
                        OrichalcumDrillChange.AddIngredient(ItemID.Wire, 6);
                        OrichalcumDrillChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        OrichalcumDrillChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        OrichalcumDrillChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                        OrichalcumDrillChange.AddIngredient(ItemID.Switch, 2);
                    }
                    Recipe OrichalcumPickaxeChange = Main.recipe[i];
                    if (OrichalcumPickaxeChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumPickaxeChange.HasTile(TileID.MythrilAnvil) && OrichalcumPickaxeChange.HasResult(ItemID.OrichalcumPickaxe))
                    {
                        OrichalcumPickaxeChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 2);
                        OrichalcumPickaxeChange.AddRecipeGroup("Xenon:HolySouls", 2);
                        OrichalcumPickaxeChange.AddRecipeGroup("Xenon:EvilSouls", 2);
                    }
                    Recipe OrichalcumChainsawChange = Main.recipe[i];
                    if (OrichalcumChainsawChange.HasIngredient(ItemID.OrichalcumBar) && OrichalcumChainsawChange.HasTile(TileID.MythrilAnvil) && OrichalcumChainsawChange.HasResult(ItemID.OrichalcumChainsaw))
                    {
                        OrichalcumChainsawChange.AddIngredient(ItemID.Wire, 6);
                        OrichalcumChainsawChange.AddIngredient(ItemID.Switch, 2);
                    }
                    #endregion

                #region Adamantite Recipes
                    Recipe AdamantiteHelmetChange = Main.recipe[i];
                    if (AdamantiteHelmetChange.HasIngredient(ItemID.AdamantiteBar) && AdamantiteHelmetChange.HasTile(TileID.MythrilAnvil) && AdamantiteHelmetChange.HasResult(ItemID.AdamantiteHelmet))
                    {
                        AdamantiteHelmetChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 9);
                    }
                    Recipe AdamantiteMaskChange = Main.recipe[i];
                    if (AdamantiteMaskChange.HasIngredient(ItemID.AdamantiteBar) && AdamantiteMaskChange.HasTile(TileID.MythrilAnvil) && AdamantiteMaskChange.HasResult(ItemID.AdamantiteMask))
                    {
                        AdamantiteMaskChange.AddRecipeGroup("Xenon:EvilSouls", 9);
                    }
                    Recipe AdamantiteHeadgearChange = Main.recipe[i];
                    if (AdamantiteHeadgearChange.HasIngredient(ItemID.AdamantiteBar) && AdamantiteHeadgearChange.HasTile(TileID.MythrilAnvil) && AdamantiteHeadgearChange.HasResult(ItemID.AdamantiteHeadgear))
                    {
                        AdamantiteHeadgearChange.AddRecipeGroup("Xenon:HolySouls", 9);
                    }

                    Recipe AdamantiteBreastplateChange = Main.recipe[i];
                    if (AdamantiteBreastplateChange.HasIngredient(ItemID.AdamantiteBar) && AdamantiteBreastplateChange.HasTile(TileID.MythrilAnvil) && AdamantiteBreastplateChange.HasResult(ItemID.AdamantiteBreastplate))
                    {
                        AdamantiteBreastplateChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        AdamantiteBreastplateChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        AdamantiteBreastplateChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                    }

                    Recipe AdamantiteLeggingsChange = Main.recipe[i];
                    if (AdamantiteLeggingsChange.HasIngredient(ItemID.AdamantiteBar) && AdamantiteLeggingsChange.HasTile(TileID.MythrilAnvil) && AdamantiteLeggingsChange.HasResult(ItemID.AdamantiteLeggings))
                    {
                        AdamantiteLeggingsChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        AdamantiteLeggingsChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        AdamantiteLeggingsChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                    }

                    Recipe AdamantiteDrillChange = Main.recipe[i];
                    if (AdamantiteDrillChange.HasIngredient(ItemID.AdamantiteBar) && AdamantiteDrillChange.HasTile(TileID.MythrilAnvil) && AdamantiteDrillChange.HasResult(ItemID.AdamantiteDrill))
                    {
                        AdamantiteDrillChange.AddIngredient(ItemID.Wire, 7);
                        AdamantiteDrillChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        AdamantiteDrillChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        AdamantiteDrillChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                        AdamantiteDrillChange.AddIngredient(ItemID.Switch, 1);
                    }
                    Recipe AdamantitePickaxeChange = Main.recipe[i];
                    if (AdamantitePickaxeChange.HasIngredient(ItemID.AdamantiteBar) && AdamantitePickaxeChange.HasTile(TileID.MythrilAnvil) && AdamantitePickaxeChange.HasResult(ItemID.AdamantitePickaxe))
                    {
                        AdamantitePickaxeChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        AdamantitePickaxeChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        AdamantitePickaxeChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                    }
                    Recipe AdamantiteChainsawChange = Main.recipe[i];
                    if (AdamantiteChainsawChange.HasIngredient(ItemID.AdamantiteBar) && AdamantiteChainsawChange.HasTile(TileID.MythrilAnvil) && AdamantiteChainsawChange.HasResult(ItemID.AdamantiteChainsaw))
                    {
                        AdamantiteChainsawChange.AddIngredient(ItemID.Wire, 7);
                        AdamantiteChainsawChange.AddIngredient(ItemID.Switch, 1);
                    }
                    #endregion

                #region Titanium Recipes
                    Recipe TitaniumMaskChange = Main.recipe[i];
                    if (TitaniumMaskChange.HasIngredient(ItemID.TitaniumBar) && TitaniumMaskChange.HasTile(TileID.MythrilAnvil) && TitaniumMaskChange.HasResult(ItemID.TitaniumMask))
                    {
                        TitaniumMaskChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 9);
                    }
                    Recipe TitaniumHelmetChange = Main.recipe[i];
                    if (TitaniumHelmetChange.HasIngredient(ItemID.TitaniumBar) && TitaniumHelmetChange.HasTile(TileID.MythrilAnvil) && TitaniumHelmetChange.HasResult(ItemID.TitaniumHelmet))
                    {
                        TitaniumHelmetChange.AddRecipeGroup("Xenon:EvilSouls", 9);
                    }
                    Recipe TitaniumHeadgearChange = Main.recipe[i];
                    if (TitaniumHeadgearChange.HasIngredient(ItemID.TitaniumBar) && TitaniumHeadgearChange.HasTile(TileID.MythrilAnvil) && TitaniumHeadgearChange.HasResult(ItemID.TitaniumHeadgear))
                    {
                        TitaniumHeadgearChange.AddRecipeGroup("Xenon:HolySouls", 9);
                    }

                    Recipe TitaniumBreastplateChange = Main.recipe[i];
                    if (TitaniumBreastplateChange.HasIngredient(ItemID.TitaniumBar) && TitaniumBreastplateChange.HasTile(TileID.MythrilAnvil) && TitaniumBreastplateChange.HasResult(ItemID.TitaniumBreastplate))
                    {
                        TitaniumBreastplateChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        TitaniumBreastplateChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        TitaniumBreastplateChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                    }

                    Recipe TitaniumLeggingsChange = Main.recipe[i];
                    if (TitaniumLeggingsChange.HasIngredient(ItemID.TitaniumBar) && TitaniumLeggingsChange.HasTile(TileID.MythrilAnvil) && TitaniumLeggingsChange.HasResult(ItemID.TitaniumLeggings))
                    {
                        TitaniumLeggingsChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        TitaniumLeggingsChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        TitaniumLeggingsChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                    }

                    Recipe TitaniumDrillChange = Main.recipe[i];
                    if (TitaniumDrillChange.HasIngredient(ItemID.TitaniumBar) && TitaniumDrillChange.HasTile(TileID.MythrilAnvil) && TitaniumDrillChange.HasResult(ItemID.TitaniumDrill))
                    {
                        TitaniumDrillChange.AddIngredient(ItemID.Wire, 8);
                        TitaniumDrillChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        TitaniumDrillChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        TitaniumDrillChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                        TitaniumDrillChange.AddIngredient(ItemID.Switch, 2);
                    }
                    Recipe TitaniumPickaxeChange = Main.recipe[i];
                    if (TitaniumPickaxeChange.HasIngredient(ItemID.TitaniumBar) && TitaniumPickaxeChange.HasTile(TileID.MythrilAnvil) && TitaniumPickaxeChange.HasResult(ItemID.TitaniumPickaxe))
                    {
                        TitaniumPickaxeChange.AddIngredient(ModContent.ItemType<SoulOfRight>(), 3);
                        TitaniumPickaxeChange.AddRecipeGroup("Xenon:HolySouls", 3);
                        TitaniumPickaxeChange.AddRecipeGroup("Xenon:EvilSouls", 3);
                    }
                    Recipe TitaniumChainsawChange = Main.recipe[i];
                    if (TitaniumChainsawChange.HasIngredient(ItemID.TitaniumBar) && TitaniumChainsawChange.HasTile(TileID.MythrilAnvil) && TitaniumChainsawChange.HasResult(ItemID.TitaniumChainsaw))
                    {
                        TitaniumChainsawChange.AddIngredient(ItemID.Wire, 8);
                        TitaniumChainsawChange.AddIngredient(ItemID.Switch, 2);
                    }
                #endregion
                #endregion

            }
        }
    }
}