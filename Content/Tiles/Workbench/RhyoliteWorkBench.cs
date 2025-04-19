using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Xenon.Content.Tiles.Workbench;

public class RhyoliteWorkBench : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        AddMapEntry(new Color(153, 102, 102));
        HitSound = SoundID.Dig;
        DustType = DustID.Copper;
        Main.tileTable[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true; // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.

        DustType = DustID.Copper;
        AdjTiles = new int[] { TileID.WorkBenches };

        // Placement
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.CoordinateHeights = new[] { 18 };
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.addTile(Type);

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        AddMapEntry(new Color(191, 142, 111), Language.GetText("ItemName.WorkBench"));
    }
}