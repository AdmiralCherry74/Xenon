using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.LargeGeode;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.LargeGeode;

public class TachyliteBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tachylite>());
    }
}