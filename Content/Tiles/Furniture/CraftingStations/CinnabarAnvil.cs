using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Xenon.Content.Tiles.Furniture.CraftingStations
{
    public class CinnabarAnvil : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(127, 77, 71), Language.GetText("MapObject.Anvil"));
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new[] { 18, 18 };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            Main.tileObsidianKill[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            //DustType = ModContent.DustType<Dusts.NickelDust>();
            AdjTiles = new int[] { TileID.Anvils };
        }
    }
}
