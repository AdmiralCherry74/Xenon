using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Natural.Corrosion
{
    public class ExpiredCactusDummyTile : ModTile
    {
        public override string Texture => "Xenon/Content/Tiles/Natural/Corrosion/ExpiredCactus";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = true;
            AddMapEntry(new Color(160, 129, 105));
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            return false;
        }
    }
}