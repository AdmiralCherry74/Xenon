using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.PreHardmode.Metal;
using Xenon.Content.Items.Armor.Vanity.OreCrowns;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Items.Tools.CuttingAxes;
using Xenon.Content.Items.Tools.DriverHammers;
using Xenon.Content.Items.Tools.GardeningHoes;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Magic.Staves;
using Xenon.Content.Items.Weapons.Melee.Battleaxes;
using Xenon.Content.Items.Weapons.Melee.Broadswords;
using Xenon.Content.Items.Weapons.Melee.Shortswords;
using Xenon.Content.Items.Weapons.Ranged.Bows;
using Xenon.Content.Items.Weapons.Ranged.Crossbows;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class BasicGameplayChangesRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            if (!ModContent.GetInstance<XenonConfig>().BasicGameplayChanges) return;
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                if ((ModContent.GetInstance<XenonConfig>().RequirePreviousOreTierForNext))
                {
                    #region Copper
                    Recipe CopperHoeChange = Main.recipe[i];
                    if (CopperHoeChange.HasIngredient(ItemID.CopperBar) && CopperHoeChange.HasIngredient(ItemID.Wood) && CopperHoeChange.HasTile(TileID.Anvils) && CopperHoeChange.HasResult(ModContent.ItemType<CopperHoe>()))
                    {
                        CopperHoeChange.HasTile(TileID.WorkBenches);
                        CopperHoeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperBattleaxeChange = Main.recipe[i];
                    if (CopperBattleaxeChange.HasIngredient(ItemID.CopperBar) && CopperBattleaxeChange.HasTile(TileID.Anvils) && CopperBattleaxeChange.HasResult(ModContent.ItemType<CopperBattleaxe>()))
                    {
                        CopperBattleaxeChange.HasTile(TileID.WorkBenches);
                        CopperBattleaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperCrossbowChange = Main.recipe[i];
                    if (CopperCrossbowChange.HasIngredient(ItemID.CopperBar) && CopperCrossbowChange.HasTile(TileID.Anvils) && CopperCrossbowChange.HasResult(ModContent.ItemType<CopperCrossbow>()))
                    {
                        CopperCrossbowChange.HasTile(TileID.WorkBenches);
                        CopperCrossbowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AmethystStaffChange = Main.recipe[i];
                    if (AmethystStaffChange.HasIngredient(ItemID.CopperBar) && AmethystStaffChange.HasIngredient(ItemID.Amethyst) && AmethystStaffChange.HasTile(TileID.Anvils) && AmethystStaffChange.HasResult(ItemID.AmethystStaff))
                    {
                        AmethystStaffChange.HasTile(TileID.WorkBenches);
                        AmethystStaffChange.RemoveTile(TileID.Anvils);
                    }
                    #endregion

                    #region Aluminum
                    Recipe AluminumHoeChange = Main.recipe[i];
                    if (AluminumHoeChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumHoeChange.HasIngredient(ItemID.Wood) && AluminumHoeChange.HasTile(TileID.Anvils) && AluminumHoeChange.HasResult(ModContent.ItemType<AluminumHoe>()))
                    {
                        AluminumHoeChange.HasTile(TileID.WorkBenches);
                        AluminumHoeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumBattleaxeChange = Main.recipe[i];
                    if (AluminumBattleaxeChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumBattleaxeChange.HasTile(TileID.Anvils) && AluminumBattleaxeChange.HasResult(ModContent.ItemType<AluminumBattleaxe>()))
                    {
                        AluminumBattleaxeChange.HasTile(TileID.WorkBenches);
                        AluminumBattleaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumCrossbowChange = Main.recipe[i];
                    if (AluminumCrossbowChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumCrossbowChange.HasTile(TileID.Anvils) && AluminumCrossbowChange.HasResult(ModContent.ItemType<AluminumCrossbow>()))
                    {
                        AluminumCrossbowChange.HasTile(TileID.WorkBenches);
                        AluminumCrossbowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe JadeStaffChange = Main.recipe[i];
                    if (JadeStaffChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && JadeStaffChange.HasIngredient(ModContent.ItemType<Jade>()) && JadeStaffChange.HasTile(TileID.Anvils) && JadeStaffChange.HasResult(ModContent.ItemType<JadeStaff>()))
                    {
                        JadeStaffChange.HasTile(TileID.WorkBenches);
                        JadeStaffChange.RemoveTile(TileID.Anvils);
                    }
                    #endregion

                    #region Tin
                    Recipe TinHoeChange = Main.recipe[i];
                    if (TinHoeChange.HasIngredient(ItemID.TinBar) && TinHoeChange.HasIngredient(ItemID.Wood) && TinHoeChange.HasTile(TileID.Anvils) && TinHoeChange.HasResult(ModContent.ItemType<TinHoe>()))
                    {
                        TinHoeChange.HasTile(TileID.WorkBenches);
                        TinHoeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinBattleaxeChange = Main.recipe[i];
                    if (TinBattleaxeChange.HasIngredient(ItemID.TinBar) && TinBattleaxeChange.HasTile(TileID.Anvils) && TinBattleaxeChange.HasResult(ModContent.ItemType<TinBattleaxe>()))
                    {
                        TinBattleaxeChange.HasTile(TileID.WorkBenches);
                        TinBattleaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinCrossbowChange = Main.recipe[i];
                    if (TinCrossbowChange.HasIngredient(ItemID.TinBar) && TinCrossbowChange.HasTile(TileID.Anvils) && TinCrossbowChange.HasResult(ModContent.ItemType<TinCrossbow>()))
                    {
                        TinCrossbowChange.HasTile(TileID.WorkBenches);
                        TinCrossbowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TopazStaffChange = Main.recipe[i];
                    if (TopazStaffChange.HasIngredient(ItemID.TinBar) && TopazStaffChange.HasIngredient(ItemID.Topaz) && TopazStaffChange.HasTile(TileID.Anvils) && TopazStaffChange.HasResult(ItemID.TopazStaff))
                    {
                        TopazStaffChange.HasTile(TileID.WorkBenches);
                        TopazStaffChange.RemoveTile(TileID.Anvils);
                    }
                    #endregion
                }
                else
                {
                    #region Copper
                    Recipe CopperShortswordChange = Main.recipe[i];
                    if (CopperShortswordChange.HasIngredient(ItemID.CopperBar) && CopperShortswordChange.HasTile(TileID.Anvils) && CopperShortswordChange.HasResult(ItemID.CopperShortsword))
                    {
                        CopperShortswordChange.HasTile(TileID.WorkBenches);
                        CopperShortswordChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperPickaxeChange = Main.recipe[i];
                    if (CopperPickaxeChange.HasIngredient(ItemID.CopperBar) && CopperPickaxeChange.HasIngredient(ItemID.Wood) && CopperPickaxeChange.HasTile(TileID.Anvils) && CopperPickaxeChange.HasResult(ItemID.CopperPickaxe))
                    {
                        CopperPickaxeChange.HasTile(TileID.WorkBenches);
                        CopperPickaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperAxeChange = Main.recipe[i];
                    if (CopperAxeChange.HasIngredient(ItemID.CopperBar) && CopperAxeChange.HasIngredient(ItemID.Wood) && CopperAxeChange.HasTile(TileID.Anvils) && CopperAxeChange.HasResult(ItemID.CopperAxe))
                    {
                        CopperAxeChange.HasTile(TileID.WorkBenches);
                        CopperAxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperHammerChange = Main.recipe[i];
                    if (CopperHammerChange.HasIngredient(ItemID.CopperBar) && CopperHammerChange.HasIngredient(ItemID.Wood) && CopperHammerChange.HasTile(TileID.Anvils) && CopperHammerChange.HasResult(ItemID.CopperHammer))
                    {
                        CopperHammerChange.HasTile(TileID.WorkBenches);
                        CopperHammerChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperHoeChange = Main.recipe[i];
                    if (CopperHoeChange.HasIngredient(ItemID.CopperBar) && CopperHoeChange.HasIngredient(ItemID.Wood) && CopperHoeChange.HasTile(TileID.Anvils) && CopperHoeChange.HasResult(ModContent.ItemType<CopperHoe>()))
                    {
                        CopperHoeChange.HasTile(TileID.WorkBenches);
                        CopperHoeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperBroadswordChange = Main.recipe[i];
                    if (CopperBroadswordChange.HasIngredient(ItemID.CopperBar) && CopperBroadswordChange.HasTile(TileID.Anvils) && CopperBroadswordChange.HasResult(ItemID.CopperBroadsword))
                    {
                        CopperBroadswordChange.HasTile(TileID.WorkBenches);
                        CopperBroadswordChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperBowChange = Main.recipe[i];
                    if (CopperBowChange.HasIngredient(ItemID.CopperBar) && CopperBowChange.HasTile(TileID.Anvils) && CopperBowChange.HasResult(ItemID.CopperBow))
                    {
                        CopperBowChange.HasTile(TileID.WorkBenches);
                        CopperBowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperBattleaxeChange = Main.recipe[i];
                    if (CopperBattleaxeChange.HasIngredient(ItemID.CopperBar) && CopperBattleaxeChange.HasTile(TileID.Anvils) && CopperBattleaxeChange.HasResult(ModContent.ItemType<CopperBattleaxe>()))
                    {
                        CopperBattleaxeChange.HasTile(TileID.WorkBenches);
                        CopperBattleaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperCrossbowChange = Main.recipe[i];
                    if (CopperCrossbowChange.HasIngredient(ItemID.CopperBar) && CopperCrossbowChange.HasTile(TileID.Anvils) && CopperCrossbowChange.HasResult(ModContent.ItemType<CopperCrossbow>()))
                    {
                        CopperCrossbowChange.HasTile(TileID.WorkBenches);
                        CopperCrossbowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AmethystStaffChange = Main.recipe[i];
                    if (AmethystStaffChange.HasIngredient(ItemID.CopperBar) && AmethystStaffChange.HasIngredient(ItemID.Amethyst) && AmethystStaffChange.HasTile(TileID.Anvils) && AmethystStaffChange.HasResult(ItemID.AmethystStaff))
                    {
                        AmethystStaffChange.HasTile(TileID.WorkBenches);
                        AmethystStaffChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperHelmetChange = Main.recipe[i];
                    if (CopperHelmetChange.HasIngredient(ItemID.CopperBar) && CopperHelmetChange.HasTile(TileID.Anvils) && CopperHelmetChange.HasResult(ItemID.CopperHelmet))
                    {
                        CopperHelmetChange.HasTile(TileID.WorkBenches);
                        CopperHelmetChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperChainmailChange = Main.recipe[i];
                    if (CopperChainmailChange.HasIngredient(ItemID.CopperBar) && CopperChainmailChange.HasTile(TileID.Anvils) && CopperChainmailChange.HasResult(ItemID.CopperChainmail))
                    {
                        CopperChainmailChange.HasTile(TileID.WorkBenches);
                        CopperChainmailChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe CopperGreavesChange = Main.recipe[i];
                    if (CopperGreavesChange.HasIngredient(ItemID.CopperBar) && CopperGreavesChange.HasTile(TileID.Anvils) && CopperGreavesChange.HasResult(ItemID.CopperGreaves))
                    {
                        CopperGreavesChange.HasTile(TileID.WorkBenches);
                        CopperGreavesChange.RemoveTile(TileID.Anvils);
                    }
                    #endregion

                    #region Aluminum
                    Recipe AluminumShortswordChange = Main.recipe[i];
                    if (AluminumShortswordChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumShortswordChange.HasTile(TileID.Anvils) && AluminumShortswordChange.HasResult(ModContent.ItemType<AluminumShortsword>()))
                    {
                        AluminumShortswordChange.HasTile(TileID.WorkBenches);
                        AluminumShortswordChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumPickaxeChange = Main.recipe[i];
                    if (AluminumPickaxeChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumPickaxeChange.HasIngredient(ItemID.Wood) && AluminumPickaxeChange.HasTile(TileID.Anvils) && AluminumPickaxeChange.HasResult(ModContent.ItemType<AluminumPickaxe>()))
                    {
                        AluminumPickaxeChange.HasTile(TileID.WorkBenches);
                        AluminumPickaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumAxeChange = Main.recipe[i];
                    if (AluminumPickaxeChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumAxeChange.HasIngredient(ItemID.Wood) && AluminumAxeChange.HasTile(TileID.Anvils) && AluminumAxeChange.HasResult(ModContent.ItemType<AluminumAxe>()))
                    {
                        AluminumAxeChange.HasTile(TileID.WorkBenches);
                        AluminumAxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumHammerChange = Main.recipe[i];
                    if (AluminumPickaxeChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumHammerChange.HasIngredient(ItemID.Wood) && AluminumHammerChange.HasTile(TileID.Anvils) && AluminumHammerChange.HasResult(ModContent.ItemType<AluminumHammer>()))
                    {
                        AluminumHammerChange.HasTile(TileID.WorkBenches);
                        AluminumHammerChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumHoeChange = Main.recipe[i];
                    if (AluminumHoeChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumHoeChange.HasIngredient(ItemID.Wood) && AluminumHoeChange.HasTile(TileID.Anvils) && AluminumHoeChange.HasResult(ModContent.ItemType<AluminumHoe>()))
                    {
                        AluminumHoeChange.HasTile(TileID.WorkBenches);
                        AluminumHoeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumBroadswordChange = Main.recipe[i];
                    if (AluminumBroadswordChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumBroadswordChange.HasTile(TileID.Anvils) && AluminumBroadswordChange.HasResult(ModContent.ItemType<AluminumBroadsword>()))
                    {
                        AluminumBroadswordChange.HasTile(TileID.WorkBenches);
                        AluminumBroadswordChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumBowChange = Main.recipe[i];
                    if (AluminumBowChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumBowChange.HasTile(TileID.Anvils) && AluminumBowChange.HasResult(ModContent.ItemType<AluminumBow>()))
                    {
                        AluminumBowChange.HasTile(TileID.WorkBenches);
                        AluminumBowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumBattleaxeChange = Main.recipe[i];
                    if (AluminumBattleaxeChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumBattleaxeChange.HasTile(TileID.Anvils) && AluminumBattleaxeChange.HasResult(ModContent.ItemType<AluminumBattleaxe>()))
                    {
                        AluminumBattleaxeChange.HasTile(TileID.WorkBenches);
                        AluminumBattleaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumCrossbowChange = Main.recipe[i];
                    if (AluminumCrossbowChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumCrossbowChange.HasTile(TileID.Anvils) && AluminumCrossbowChange.HasResult(ModContent.ItemType<AluminumCrossbow>()))
                    {
                        AluminumCrossbowChange.HasTile(TileID.WorkBenches);
                        AluminumCrossbowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe JadeStaffChange = Main.recipe[i];
                    if (JadeStaffChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && JadeStaffChange.HasIngredient(ModContent.ItemType<Jade>()) && JadeStaffChange.HasTile(TileID.Anvils) && JadeStaffChange.HasResult(ModContent.ItemType<JadeStaff>()))
                    {
                        JadeStaffChange.HasTile(TileID.WorkBenches);
                        JadeStaffChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumHelmetChange = Main.recipe[i];
                    if (AluminumHelmetChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumHelmetChange.HasTile(TileID.Anvils) && AluminumHelmetChange.HasResult(ModContent.ItemType<AluminumHelmet>()))
                    {
                        AluminumHelmetChange.HasTile(TileID.WorkBenches);
                        AluminumHelmetChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumChainmailChange = Main.recipe[i];
                    if (AluminumChainmailChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumChainmailChange.HasTile(TileID.Anvils) && AluminumChainmailChange.HasResult(ModContent.ItemType<AluminumChainmail>()))
                    {
                        AluminumChainmailChange.HasTile(TileID.WorkBenches);
                        AluminumChainmailChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe AluminumGreavesChange = Main.recipe[i];
                    if (AluminumGreavesChange.HasIngredient(ModContent.ItemType<AluminumBar>()) && AluminumGreavesChange.HasTile(TileID.Anvils) && AluminumGreavesChange.HasResult(ModContent.ItemType<AluminumGreaves>()))
                    {
                        AluminumGreavesChange.HasTile(TileID.WorkBenches);
                        AluminumGreavesChange.RemoveTile(TileID.Anvils);
                    }
                    #endregion

                    #region Tin
                    Recipe TinShortswordChange = Main.recipe[i];
                    if (TinShortswordChange.HasIngredient(ItemID.TinBar) && TinShortswordChange.HasTile(TileID.Anvils) && TinShortswordChange.HasResult(ItemID.TinShortsword))
                    {
                        TinShortswordChange.HasTile(TileID.WorkBenches);
                        TinShortswordChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinPickaxeChange = Main.recipe[i];
                    if (TinPickaxeChange.HasIngredient(ItemID.TinBar) && TinPickaxeChange.HasIngredient(ItemID.Wood) && TinPickaxeChange.HasTile(TileID.Anvils) && TinPickaxeChange.HasResult(ItemID.TinPickaxe))
                    {
                        TinPickaxeChange.HasTile(TileID.WorkBenches);
                        TinPickaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinAxeChange = Main.recipe[i];
                    if (TinAxeChange.HasIngredient(ItemID.TinBar) && TinAxeChange.HasIngredient(ItemID.Wood) && TinAxeChange.HasTile(TileID.Anvils) && TinAxeChange.HasResult(ItemID.TinAxe))
                    {
                        TinAxeChange.HasTile(TileID.WorkBenches);
                        TinAxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinHammerChange = Main.recipe[i];
                    if (TinHammerChange.HasIngredient(ItemID.TinBar) && TinHammerChange.HasIngredient(ItemID.Wood) && TinHammerChange.HasTile(TileID.Anvils) && TinHammerChange.HasResult(ItemID.TinHammer))
                    {
                        TinHammerChange.HasTile(TileID.WorkBenches);
                        TinHammerChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinHoeChange = Main.recipe[i];
                    if (TinHoeChange.HasIngredient(ItemID.TinBar) && TinHoeChange.HasIngredient(ItemID.Wood) && TinHoeChange.HasTile(TileID.Anvils) && TinHoeChange.HasResult(ModContent.ItemType<TinHoe>()))
                    {
                        TinHoeChange.HasTile(TileID.WorkBenches);
                        TinHoeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinBroadswordChange = Main.recipe[i];
                    if (TinBroadswordChange.HasIngredient(ItemID.TinBar) && TinBroadswordChange.HasTile(TileID.Anvils) && TinBroadswordChange.HasResult(ItemID.TinBroadsword))
                    {
                        TinBroadswordChange.HasTile(TileID.WorkBenches);
                        TinBroadswordChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinBowChange = Main.recipe[i];
                    if (TinBowChange.HasIngredient(ItemID.TinBar) && TinBowChange.HasTile(TileID.Anvils) && TinBowChange.HasResult(ItemID.TinBow))
                    {
                        TinBowChange.HasTile(TileID.WorkBenches);
                        TinBowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinBattleaxeChange = Main.recipe[i];
                    if (TinBattleaxeChange.HasIngredient(ItemID.TinBar) && TinBattleaxeChange.HasTile(TileID.Anvils) && TinBattleaxeChange.HasResult(ModContent.ItemType<TinBattleaxe>()))
                    {
                        TinBattleaxeChange.HasTile(TileID.WorkBenches);
                        TinBattleaxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinCrossbowChange = Main.recipe[i];
                    if (TinCrossbowChange.HasIngredient(ItemID.TinBar) && TinCrossbowChange.HasTile(TileID.Anvils) && TinCrossbowChange.HasResult(ModContent.ItemType<TinCrossbow>()))
                    {
                        TinCrossbowChange.HasTile(TileID.WorkBenches);
                        TinCrossbowChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TopazStaffChange = Main.recipe[i];
                    if (TopazStaffChange.HasIngredient(ItemID.TinBar) && TopazStaffChange.HasIngredient(ItemID.Topaz) && TopazStaffChange.HasTile(TileID.Anvils) && TopazStaffChange.HasResult(ItemID.TopazStaff))
                    {
                        TopazStaffChange.HasTile(TileID.WorkBenches);
                        TopazStaffChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinHelmetChange = Main.recipe[i];
                    if (TinHelmetChange.HasIngredient(ItemID.TinBar) && TinHelmetChange.HasTile(TileID.Anvils) && TinHelmetChange.HasResult(ItemID.TinHelmet))
                    {
                        TinHelmetChange.HasTile(TileID.WorkBenches);
                        TinHelmetChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinChainmailChange = Main.recipe[i];
                    if (TinChainmailChange.HasIngredient(ItemID.TinBar) && TinChainmailChange.HasTile(TileID.Anvils) && TinChainmailChange.HasResult(ItemID.TinChainmail))
                    {
                        TinChainmailChange.HasTile(TileID.WorkBenches);
                        TinChainmailChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinGreavesChange = Main.recipe[i];
                    if (TinGreavesChange.HasIngredient(ItemID.TinBar) && TinGreavesChange.HasTile(TileID.Anvils) && TinGreavesChange.HasResult(ItemID.TinGreaves))
                    {
                        TinGreavesChange.HasTile(TileID.WorkBenches);
                        TinGreavesChange.RemoveTile(TileID.Anvils);
                    }
                    #endregion
                }
            }
        }
    }
}