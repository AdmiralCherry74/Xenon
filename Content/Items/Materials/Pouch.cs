using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class Pouch : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(0, 0, 21);
        Item.maxStack = 9999;
        Item.rare = ItemRarityID.Blue;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.Silk, 5)
        .AddTile(TileID.Tables)
        .AddTile(TileID.Chairs)
        .Register();
    }
}