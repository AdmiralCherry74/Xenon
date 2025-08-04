using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Tile;
using Xenon.Content.Rarities;
using Xenon.Content.Tiles;

namespace Xenon.Content.Items.Materials;

public class Bolus : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(0, 0, 21);
        Item.CommonMaxStack = 9999;
    }
}