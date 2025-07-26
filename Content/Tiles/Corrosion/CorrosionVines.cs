using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;

namespace Xenon.Content.Tiles.Corrosion;

public class CorrosionVines : ModTile
{
    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Xenon.CorrosionBiomeSightColor;
        return true;
    }
    public override void SetStaticDefaults()
    {
        TileID.Sets.TileCutIgnore.Regrowth[Type] = true;
        TileID.Sets.IsVine[Type] = true;
        TileID.Sets.ReplaceTileBreakDown[Type] = true;
        TileID.Sets.VineThreads[Type] = true;
        TileID.Sets.DrawFlipMode[Type] = 1;
        Main.tileCut[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileNoFail[Type] = true;
        HitSound = SoundID.Grass;
        DustType = ModContent.DustType<CorrosionDust>();
        AddMapEntry(new Color(142, 123, 0));
		//AltLibrarySupport.TryAddVine(Type, ModContent.TileType<CorrosionGrass>(), ModContent.TileType<CorrosionJungleGrass>());
	}

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        if (Main.LightingEveryFrame)
        {
            Main.instance.TilesRenderer.CrawlToTopOfVineAndAddSpecialPoint(j, i);
        }
        return false;
    }

    public static bool CanGrowFromTile(int tileType)
    {
        return tileType == ModContent.TileType<CorrosionGrass>() ||
               tileType == ModContent.TileType<CorrosionJungleGrass>() ||
               tileType == TileID.Grass || tileType == TileID.CrimsonGrass ||
               tileType == TileID.HallowedGrass || tileType == TileID.CorruptGrass ||
               tileType == TileID.JungleGrass || tileType == TileID.MushroomGrass;
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        offsetY = -2;
    }
    public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
    {
        if (i % 2 == 1)
        {
            effects = SpriteEffects.FlipHorizontally;
        }
    }
}
