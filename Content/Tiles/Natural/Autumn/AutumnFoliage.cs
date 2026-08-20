using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Content.Tiles.Natural.Autumn;

public class AutumnFoliage : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.ReplaceTileBreakUp[Type] = true;
        TileID.Sets.SlowlyDiesInWater[Type] = true;
        TileID.Sets.SwaysInWindBasic[Type] = true;
        TileID.Sets.DrawFlipMode[Type] = 1;
        TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
        TileID.Sets.TileCutIgnore.Regrowth[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileCut[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileNoFail[Type] = true;
        DustType = ModContent.DustType<AutumnDust>();
        HitSound = SoundID.Grass;
        //TileSets.Conversion.ShortGrass[Type] = true;
        AddMapEntry(new Color(175, 64, 42));
    }

    //Todo, make these their own tiles for Conversion.

    public const int TreeStarFrameX = 18 * 8;
    public const int BeautifulLeafFrameX = 18 * 6;
    public const int JungleSporeFrameX = 18 * 7;

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (Main.tile[i, j].TileFrameX == TreeStarFrameX)
        {
            Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<TreeStar>());
        }
        if (Main.tile[i, j].TileFrameX == BeautifulLeafFrameX && Main.rand.NextBool(30))
        {
            Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.JungleRose); //Change to proper item later
        }
        if (Main.tile[i, j].TileFrameX == JungleSporeFrameX)
        {
            Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.JungleSpores, Main.rand.Next(2, 4)); //2-4 Spores
        }
    }
    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        WorldGen.PlantCheck(i, j);
        return false;
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        height = 20;
        offsetY = -2;
        tileFrameY = 0;
    }
    public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
    {
        //Flips the sprite if x coord is odd. Makes the tile more interesting
        if (i % 2 == 0)
            spriteEffects = SpriteEffects.FlipHorizontally;
    }
}
