using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.ActiveAndWiring.Lighting.OffState;

namespace Xenon.Content.Tiles.ActiveAndWiring.Lighting;

public class HeliumMossparkBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(255, 255, 255));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileLighted[Type] = true;
        TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[Type] = true;
        TileID.Sets.ForcedDirtMerging[Type] = true;
        TileID.Sets.GemsparkFramingTypes[Type] = Type;
        HitSound = SoundID.Dig;
    }

    public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
    {
        drawData.colorTint = Main.DiscoColor;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = Main.DiscoColor.R / 255f;
        g = Main.DiscoColor.G / 255f;
        b = Main.DiscoColor.B / 255f;
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
            tileSafely.TileType = (ushort)ModContent.TileType<HeliumMossparkBlockOff>();
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
        }
    }
}


//public override void ChangeWaterfallStyle(ref int style)
//{
//    style = Mod.Find<ModWaterfallStyle>("PeridotWaterfallStyle").Slot;
//}