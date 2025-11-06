using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Placeable.Furniture.Rhyolite;

public class RhyolitePlatform : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        
        Item.autoReuse = true;
        Item.createTile = ModContent.TileType<Tiles.Furniture.Rhyolite.RhyolitePlatform>();
        Item.consumable = true;
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.scale = 1f;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
        Item.height = 16;
    }
    //public override bool? CanBurnInLava()
    //{
    //    return false;
    //}
    public override void AddRecipes()
    {
        CreateRecipe(2).AddIngredient(ModContent.ItemType<Tile.SmoothRhyoliteBlock>()).Register();
        Recipe.Create(ModContent.ItemType<Tile.SmoothRhyoliteBlock>()).AddIngredient(this, 2).Register();
    }
}
