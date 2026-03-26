using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Other;

namespace Xenon.Content.Items.Materials.Organic;

public class CorrodedThorns : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }
    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 12;
    }
}
