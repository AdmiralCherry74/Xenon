using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Autumn
{
	public class ColonyBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;

			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;

			DustType = ModContent.DustType<AutumnDust>();
			AddMapEntry(new Color(97, 58, 53));
		}
	}
}