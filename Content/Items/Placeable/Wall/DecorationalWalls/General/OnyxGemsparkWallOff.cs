using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Placeable.Tile.Wiring.Lighting;

namespace Xenon.Content.Items.Placeable.Wall.DecorationalWalls.General;

public class OnyxGemsparkWallOff : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 400;
    }

    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.width = 32;
        Item.height = 32;
        Item.useTurn = true;
        Item.useTime = 15;
        Item.createWall = ModContent.WallType<Xenon.Content.Walls.DecorativeWalls.General.OnyxGemsparkWallOff>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe(4);

        recipe.AddIngredient(ModContent.ItemType<OnyxGemsparkBlock>(), 1);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}