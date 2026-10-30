using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.Vanity.OreCrowns;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Items.Tools.CuttingAxes;
using Xenon.Content.Items.Tools.DriverHammers;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Melee.Shortswords;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class BasicGameplayChangesRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                if (ModContent.GetInstance<XenonConfig>().BasicProgressionChanges && !(ModContent.GetInstance<XenonConfig>().RequirePreviousOreTierForNext))
                {
                    //Copper
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

                    //Aluminum
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

                    //Tin
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
                    if (TinAxeChange.HasIngredient(ItemID.CopperBar) && TinAxeChange.HasIngredient(ItemID.Wood) && TinAxeChange.HasTile(TileID.Anvils) && TinAxeChange.HasResult(ItemID.TinAxe))
                    {
                        TinAxeChange.HasTile(TileID.WorkBenches);
                        TinAxeChange.RemoveTile(TileID.Anvils);
                    }
                    Recipe TinHammerChange = Main.recipe[i];
                    if (TinHammerChange.HasIngredient(ItemID.CopperBar) && TinHammerChange.HasIngredient(ItemID.Wood) && TinHammerChange.HasTile(TileID.Anvils) && TinHammerChange.HasResult(ItemID.TinHammer))
                    {
                        TinHammerChange.HasTile(TileID.WorkBenches);
                        TinHammerChange.RemoveTile(TileID.Anvils);
                    }
                }
            }
        }
    }
}
