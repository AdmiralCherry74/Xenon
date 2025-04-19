using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Walls
{
    public class RhyoliteWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(86, 35, 35));
        }
    }
}