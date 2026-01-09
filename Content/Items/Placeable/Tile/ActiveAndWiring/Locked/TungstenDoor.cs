using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Locked;

namespace Xenon.Content.Items.Placeable.Tile.ActiveAndWiring.Locked;

public class TungstenDoor : ModItem
{
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<TungstenDoorClosed>());
        Item.width = 28;
        Item.height = 48;
        Item.mech = true;
        Item.value = Item.sellPrice(silver: 1);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.TungstenBar, 6)
            .AddIngredient(ItemID.Wire, 3)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}