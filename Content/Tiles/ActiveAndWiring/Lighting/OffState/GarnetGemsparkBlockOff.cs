using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.ActiveAndWiring.Lighting.OffState;

public class GarnetGemsparkBlockOff : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(255, 50, 141));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[Type] = true;
        TileID.Sets.ForcedDirtMerging[Type] = true;
        TileID.Sets.GemsparkFramingTypes[Type] = Type;
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Blocks.ActiveAndWiring.Lighting.GarnetGemsparkBlock>(), 1);
        HitSound = SoundID.Dig;
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
            tileSafely.TileType = (ushort)ModContent.TileType<GarnetGemsparkBlock>();
            WorldGen.SquareTileFrame(i, j);
            NetMessage.SendTileSquare(-1, i, j, 1);
        }
    }
}