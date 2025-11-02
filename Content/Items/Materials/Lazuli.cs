using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials;

public class Lazuli : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.sellPrice(0, 17, 50);
        Item.maxStack = 9999;
    }
}