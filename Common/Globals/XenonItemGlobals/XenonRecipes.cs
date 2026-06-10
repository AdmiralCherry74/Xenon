using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Fish;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;

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

            Recipe.Create(ItemID.Hook)
            .AddRecipeGroup(RecipeGroupID.IronBar, 4)
            .AddRecipeGroup("CopperBar")
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.Chain)
            .Register();
        }
    }
}
