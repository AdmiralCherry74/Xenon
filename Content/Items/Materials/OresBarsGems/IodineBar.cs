using Humanizer;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile.Natural.OresAndGems;
using Xenon.Content.Rarities;
using Xenon.Content.Tiles.Natural.Ores;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Items.Materials.OresBarsGems;

public class IodineBar : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 25;
	}
	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.rare = ItemRarityID.Master;
		Item.value = Item.sellPrice(0, 0, 21);
	}

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<IodineOreBlock>(), 10)
            .AddTile(TileID.AdamantiteForge)
            .Register();
    }
}
