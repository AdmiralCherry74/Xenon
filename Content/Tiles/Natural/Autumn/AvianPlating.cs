using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Autumn
{
	public class AvianPlating : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;

			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;

			DustType = DustID.Torch;
			AddMapEntry(new Color(97, 58, 53));
		}
	}
}