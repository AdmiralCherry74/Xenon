using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Xenon.Content.Tiles.Bathtub
{
    public class RhyoliteBathtub : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2); //this style already takes care of direction for us
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AddMapEntry(new Color(144, 148, 144), Language.GetText("ItemName.Bathtub"));
            DustType = DustID.Copper;
        }
    }
}