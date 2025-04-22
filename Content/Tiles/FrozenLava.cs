using Microsoft.Xna.Framework;
using Xenon.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles;
public class FrozenLava : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(134, 85, 77));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        DustType = ModContent.DustType<RhyoliteDust>();
        HitSound = SoundID.Item50;
        TileID.Sets.GeneralPlacementTiles[Type] = false;
    }
    public override bool IsTileDangerous(int i, int j, Player player)
	{
		return true;
	}
}