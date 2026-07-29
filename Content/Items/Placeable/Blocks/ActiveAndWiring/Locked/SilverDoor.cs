using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Furniture.OreBasedFurniture;

namespace Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Locked;

public class SilverDoor : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<SilverDoorClosed>());
        Item.width = 28;
        Item.height = 48;
        Item.mech = true;
        Item.value = Item.sellPrice(silver: 1);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.SilverBar, 6)
            .AddIngredient(ItemID.Wire, 3)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}