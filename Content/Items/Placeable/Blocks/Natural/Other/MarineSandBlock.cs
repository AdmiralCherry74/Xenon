using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.OceanAndTheMarine;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Other;

public class MarineSandBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MarineSand>());
        Item.width = 12;
        Item.height = 12;
        Item.notAmmo = true;
    }
}
