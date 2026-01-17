using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;

namespace Xenon.Content.Items.Placeable.Wall.Natural.Stone;

public class RhyoliteWall : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 400;
    }

    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.createWall = ModContent.WallType<Walls.NaturalWalls.Stone.RhyoliteWall>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4).AddIngredient(ModContent.ItemType<RhyoliteBlock>()).AddTile(TileID.WorkBenches).Register();
        Recipe.Create(ModContent.ItemType<RhyoliteBlock>()).AddIngredient(this, 4).AddTile(TileID.WorkBenches).DisableDecraft().Register();
    }
}
