using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Lighting.OffState;

namespace Xenon.Content.Tiles.ActiveAndWiring.Lighting;

public class JadeGemsparkBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(108, 108, 108));
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
        r = 0.2f;
        g = 0.3f;
        b = 0.1f;
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
            tileSafely.TileType = (ushort)ModContent.TileType<JadeGemsparkBlockOff>();
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
        }
    }
}


    //public override void ChangeWaterfallStyle(ref int style)
    //{
    //    style = Mod.Find<ModWaterfallStyle>("PeridotWaterfallStyle").Slot;
    //}