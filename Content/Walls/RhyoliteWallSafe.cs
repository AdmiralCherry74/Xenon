using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Walls
{
    public class RhyoliteWallSafe : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(86, 35, 35));
        }
    }
}