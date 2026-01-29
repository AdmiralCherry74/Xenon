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
    public class CopperFurnaceTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(205, 125, 71), this.GetLocalization("MapEntry"));
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            Main.tileLighted[Type] = true;
            AdjTiles = new int[] { TileID.AdamantiteForge, TileID.Hellforge, TileID.Furnaces };
            DustType = DustID.Copper;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 230f / 255f;
            g = 155f / 255f;
            b = 115f / 255f;
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.NextBool(20) && Main.tile[i, j].TileFrameX == 18 && Main.tile[i, j].TileFrameY == 18)
            {
                int num56 = Dust.NewDust(new Vector2(i * 16 - 3, j * 16 - 5), 18, 6, DustID.Torch, 0f, 0f, 100, default, 1f);
                if (!Main.rand.NextBool(3))
                {
                    Main.dust[num56].noGravity = true;
                }
            }
        }
    }
}