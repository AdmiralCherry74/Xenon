using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Tiles.Bricks;

namespace Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;

public class FrozenLavaBrick : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }
    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
    {
        itemGroup = ContentSamples.CreativeHelper.ItemGroup.Blocks;
    }
    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<IceLavaBrick>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.useAnimation = 15;
        Item.height = 16;
    }
	public override void AddRecipes()
	{
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<FrozenLava>(), 2)
            .AddTile(TileID.WorkBenches)
            .Register();
	}
}
