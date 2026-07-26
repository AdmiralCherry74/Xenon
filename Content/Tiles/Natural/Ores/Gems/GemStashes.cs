using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Tiles.Natural.Ores.Gems
{
    public class GemStashes : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16 };
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(42, 59, 26), this.GetLocalization("Jade"));
            AddMapEntry(new Color(148, 33, 115), this.GetLocalization("Garnet"));
            AddMapEntry(new Color(32, 35, 127), this.GetLocalization("Lapis"));
        }
        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].TileFrameX / 36);
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int toDrop = 0;
            switch (Main.tile[i, j].TileFrameX / 36)
            {
                case 0:
                    toDrop = ModContent.ItemType<Jade>();
                    break;
                case 1:
                    toDrop = ModContent.ItemType<Garnet>();
                    break;
                case 2:
                    toDrop = ModContent.ItemType<Lapis>();
                    break;
            }
            yield return new Item(toDrop, WorldGen.genRand.Next(3) + 1);
        }
    }
}