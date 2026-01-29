using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Tiles.Furniture.CraftingStations;

namespace Xenon.Content.Items.Placeable.Furniture.Crafting
{
    public class CopperFurnace : ModItem
    {

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CopperFurnaceTile>());
            Item.width = 30;
            Item.height = 26;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 4, 50);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperBar, 20)
                .AddIngredient(ItemID.Furnace, 1)
                .AddTile(TileID.WorkBenches).Register();

            CreateRecipe() //This Will be removed later, just too lazy to make a Tin Furnace
                .AddIngredient(ItemID.TinBar, 20)
                .AddIngredient(ItemID.Furnace, 1)
                .AddTile(TileID.WorkBenches).Register();
        }
    }
}