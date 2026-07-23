using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Natural.Other;

public class PlacedJade : ModTile
{
    const int TileHeight = 18;
    const int RandomStyleCount = 3;
    const int StyleHeight = TileHeight * RandomStyleCount;

    Color gemColor = new Color(53, 75, 33);

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileObsidianKill[Type] = true;
        Main.tileSpelunker[Type] = true;

        DustType = ModContent.DustType<JadeGemDust>();

        AddMapEntry(gemColor, CreateMapEntryName());
    }

    public override bool CanPlace(int i, int j)
    {
        if (WorldGen.SolidTile(i - 1, j, noDoors: true) || WorldGen.SolidTile(i + 1, j, noDoors: true) || WorldGen.SolidTile(i, j - 1) || WorldGen.SolidTile(i, j + 1))
            return true;

        return false;
    }

    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        Tile tile = Main.tile[i, j];
        Tile above = Main.tile[i, j - 1];
        Tile below = Main.tile[i, j + 1];
        Tile left = Main.tile[i - 1, j];
        Tile right = Main.tile[i + 1, j];
        int belowType = -1;
        int aboveType = -1;
        int leftType = -1;
        int rightType = -1;
        if (above != null && above.HasUnactuatedTile && !above.BottomSlope)
            aboveType = above.TileType;

        if (below != null && below.HasUnactuatedTile && !below.IsHalfBlock && !below.TopSlope)
            belowType = below.TileType;

        if (left != null && left.HasUnactuatedTile && !left.IsHalfBlock && !left.RightSlope)
            leftType = left.TileType;

        if (right != null && right.HasUnactuatedTile && !right.IsHalfBlock && !right.LeftSlope)
            rightType = right.TileType;

        if (TileLoader.IsClosedDoor(leftType))
            leftType = -1;

        if (TileLoader.IsClosedDoor(rightType))
            rightType = -1;

        short randomStyleOffset = (short)(WorldGen.genRand.Next(RandomStyleCount) * TileHeight);
        if (belowType >= 0 && Main.tileSolid[belowType] && !Main.tileSolidTop[belowType])
        {
            if (tile.TileFrameY < 0 || tile.TileFrameY >= StyleHeight)
                tile.TileFrameY = randomStyleOffset;

        }
        else if (leftType >= 0 && Main.tileSolid[leftType] && !Main.tileSolidTop[leftType])
        {
            if (tile.TileFrameY < StyleHeight * 2 || tile.TileFrameY >= StyleHeight * 3)
                tile.TileFrameY = (short)(StyleHeight * 2 + randomStyleOffset);

        }
        else if (rightType >= 0 && Main.tileSolid[rightType] && !Main.tileSolidTop[rightType])
        {
            if (tile.TileFrameY < StyleHeight * 3 || tile.TileFrameY >= StyleHeight * 4)
                tile.TileFrameY = (short)(StyleHeight * 3 + randomStyleOffset);

        }
        else if (aboveType >= 0 && Main.tileSolid[aboveType] && !Main.tileSolidTop[aboveType])
        {
            if (tile.TileFrameY < StyleHeight || tile.TileFrameY >= StyleHeight * 2)
                tile.TileFrameY = (short)(StyleHeight + randomStyleOffset);

        }
        else
            WorldGen.KillTile(i, j);

        return false;
    }

    public override void PlaceInWorld(int i, int j, Item item)
    {
        if (Main.tile[i, j].TileFrameY < StyleHeight)
            Main.tile[i, j].TileFrameY = (short)(WorldGen.genRand.Next(RandomStyleCount) * TileHeight);

    }

    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        if (tileFrameY < StyleHeight)
            offsetY = 2;

    }

    public override void EmitParticles(int i, int j, Tile tile, short tileFrameX, short tileFrameY, Color tileLight, bool visible)
    {
        if (!visible)
            return;

        if (tileLight.R <= 20 && tileLight.B <= 20 && tileLight.G <= 20)
            return;

        int lightValue = tileLight.R;
        if (tileLight.G > lightValue)
            lightValue = tileLight.G;

        if (tileLight.B > lightValue)
            lightValue = tileLight.B;

        lightValue /= 30;

        const int ParticleRate = 500;
        if (Main.rand.Next(ParticleRate) >= lightValue)
            return;

        Color dustColor = gemColor;
        int dust = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.TintableDustLighted, 0f, 0f, 254, dustColor, 0.5f);
        Main.dust[dust].velocity *= 0f;
    }

    public override bool CreateDust(int i, int j, ref int type)
    {
        int dust = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, type, 0f, 0f, 75, gemColor, 0.75f);
        Main.dust[dust].noLight = true;

        return false;
    }
}