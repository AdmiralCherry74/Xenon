using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Tiles.Building.SyntheticNatural;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.Somnolent;

namespace Xenon.Content.Tiles.Natural.Ores.Gems.GemTrees;

public class JadeTree : ModTree
{
    private Asset<Texture2D> texture;
    private Asset<Texture2D> branchesTexture;
    private Asset<Texture2D> topsTexture;
    public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
    {
        UseSpecialGroups = true,
        SpecialGroupMinimalHueValue = 11f / 72f,
        SpecialGroupMaximumHueValue = 0.25f,
        SpecialGroupMinimumSaturationValue = 0.88f,
        SpecialGroupMaximumSaturationValue = 1f
    };

    public override void SetStaticDefaults()
    {
        GrowsOnTileId =
        [
            ModContent.TileType<OvergrownTurf>()
            //TileID.Stone,
            //TileID.Ebonstone,
            //TileID.Crimstone,
            //ModContent.TileType<Gutstone>(),
            //TileID.Pearlstone,
            //ModContent.TileType<Snoozestone>(),
            //TileID.GreenMoss,
            //TileID.BrownMoss,
            //TileID.RedMoss,
            //TileID.BlueMoss,
            //TileID.PurpleMoss,
            //TileID.LavaMoss,
            //TileID.KryptonMoss,
            //TileID.XenonMoss,
            //TileID.ArgonMoss,
            //TileID.VioletMoss,
            //TileID.RainbowMoss
        ];
        texture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Ores/Gems/GemTrees/JadeTree");
        branchesTexture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Ores/Gems/GemTrees/JadeTreeBranches");
        topsTexture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Ores/Gems/GemTrees/JadeTreeTops");
    }

    public override int CreateDust()
    {
        return ModContent.DustType<JadeGemDust>();
    }

    public override Asset<Texture2D> GetTexture()
    {
        return texture;
    }
    public override int TreeLeaf() => ModContent.GoreType<JadeTreeLeaf>();
    public override int SaplingGrowthType(ref int style)
    {
        style = 0;
        return ModContent.TileType<JadeSapling>();
    }

    public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
    {
        // This is where fancy code could go, but let's save that for an advanced example
    }

    // Branch Textures
    public override Asset<Texture2D> GetBranchTextures() => branchesTexture;

    // Top Textures
    public override Asset<Texture2D> GetTopTextures() => topsTexture;

    public override int DropWood()
    {
        return ModContent.ItemType<Jade>();
    }
    public override bool CanDropAcorn()
    {
        return false;
    }
}
