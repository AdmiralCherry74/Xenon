using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles;

public class LapisGemsparkBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(129, 111, 211));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileLighted[Type] = true;
        TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[Type] = true;
        TileID.Sets.ForcedDirtMerging[Type] = true;
        TileID.Sets.GemsparkFramingTypes[Type] = Type;
        HitSound = SoundID.Dig;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 32.7f / 75;
        g = 2f / 75;
        b = 59.9f / 75;
    }
    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        Framing.SelfFrame8Way(i, j, Main.tile[i, j], resetFrame);
        return false;
    }
    public override void HitWire(int i, int j)
    {
        Tile tileSafely = Framing.GetTileSafely(i, j);
        if (!tileSafely.HasActuator)
        {
            tileSafely.TileType = (ushort)ModContent.TileType<LapisGemsparkBlockOff>();
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
        }
    }
}


    //public override void ChangeWaterfallStyle(ref int style)
    //{
    //    style = Mod.Find<ModWaterfallStyle>("PeridotWaterfallStyle").Slot;
    //}