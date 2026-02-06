using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;

namespace Xenon.Content.Items.Placeable.Furniture.Catacombs;

public class PlatinumChest : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Catacombs.PlatinumChest>());
        Item.width = 26;
        Item.height = 22;
        Item.value = Item.sellPrice(silver: 10);
    }
}

//    public override void AddRecipes()
//    {
//        CreateRecipe()
//            .AddIngredient(ModContent.ItemType<OuranoStoneBlock>(), 8)
//            .AddRecipeGroup("IronBar", 2)
//            .AddTile(TileID.WorkBenches).Register();
//    }
//}
