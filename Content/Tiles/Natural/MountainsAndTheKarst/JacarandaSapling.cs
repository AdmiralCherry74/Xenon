using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;
using Xenon.ModSupport.Avalon.Content.Tiles;
using Xenon.ModSupport.Confection.Content.Tiles;

namespace Xenon.Content.Tiles.Natural.MountainsAndTheKarst;

public class JacarandaSapling : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileID.Sets.CommonSapling[Type] = true;
        TileID.Sets.TreeSapling[Type] = true;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.Origin = new Point16(0, 1);
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.CoordinateHeights = [16, 18];
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.AnchorValidTiles =
		[
			ModContent.TileType<MossyOuranoStone>(),
			ModContent.TileType<MossyAresStone>(),
			ModContent.TileType<MossyNyxStone>(),
			ModContent.TileType<MossyHelioStone>(),
			ModContent.TileType<MossyHephStone>(),
			ModContent.TileType<MossyPolloStone>(),
			ModContent.TileType<MossyHestiaStone>(),
			ModContent.TileType<OuranoStone>(),
			ModContent.TileType<AresStone>(),
			ModContent.TileType<NyxStone>(),
			ModContent.TileType<HelioStone>(),
			ModContent.TileType<HephStone>(),
			ModContent.TileType<PolloStone>(),
			ModContent.TileType<HestiaStone>()
		];
		TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.DrawFlipHorizontal = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.RandomStyleRange = 3;
        TileObjectData.addTile(Type);
        AddMapEntry(new Color(200, 200, 200));
        DustType = DustID.BorealWood;
        AdjTiles = [TileID.Saplings];
    }

    public override void RandomUpdate(int i, int j)
    {
        if (WorldGen.genRand.NextBool(20))
        {
            bool flag = WorldGen.PlayerLOS(i, j);
            if (WorldGen.GrowTree(i, j) && flag)
            {
                WorldGen.TreeGrowFXCheck(i, j);
            }
        }
    }

    public static bool AttemptToGrowContagionTreeFromSapling(int x, int y)
    {
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            return false;
        }
        if (!WorldGen.InWorld(x, y, 2))
        {
            return false;
        }
        Tile tile = Main.tile[x, y];
        if (tile == null || !tile.HasTile)
        {
            return false;
        }
        bool flag = WorldGen.PlayerLOS(x, y);
        if (WorldGen.GrowTree(x, y) && flag)
        {
            WorldGen.TreeGrowFXCheck(x, y);
        }
        return flag;
    }

    public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
    {
        if (i % 2 == 1)
        {
            effects = SpriteEffects.FlipHorizontally;
        }
    }
}
