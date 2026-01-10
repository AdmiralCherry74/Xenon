using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Stone.Mossy;
using Xenon.Content.Tiles.Natural.Stone;

namespace Xenon.Content.Tiles.Natural.Mountains;

public class JacarandaTree : ModTree
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
        if (GrowsOnTileId == null)
        {
            GrowsOnTileId =
            [
                ModContent.TileType<MossyOuranoStone>(),
                ModContent.TileType<MossyAresStone>(),
                ModContent.TileType<MossyNyxStone>(),
                ModContent.TileType<MossyHelioStone>(),
                ModContent.TileType<MossyHephStone>(),
                ModContent.TileType<OuranoStone>(),
                ModContent.TileType<AresStone>(),
                ModContent.TileType<NyxStone>(),
                ModContent.TileType<HelioStone>(),
                ModContent.TileType<HephStone>()
            ];
        }
		texture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Mountains/JacarandaTree");
		branchesTexture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Mountains/JacarandaTreeBranches");
		topsTexture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Mountains/JacarandaTreeTops");
	}

    public override int CreateDust()
    {
        return DustID.BorealWood;
    }

    public override Asset<Texture2D> GetTexture()
    {
        return texture;
    }
    public override int TreeLeaf() => ModContent.GoreType<JacarandaTreeLeaf>();
    public override int SaplingGrowthType(ref int style)
    {
        style = 0;
        return ModContent.TileType<JacarandaSapling>();
    }

    public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
    {
        topTextureFrameHeight = 94;
        topTextureFrameWidth = 118;
        // This is where fancy code could go, but let's save that for an advanced example
    }

    // Branch Textures
    public override Asset<Texture2D> GetBranchTextures() => branchesTexture;

    // Top Textures
    public override Asset<Texture2D> GetTopTextures() => topsTexture;

    public override int DropWood()
    {
        return ModContent.ItemType<Items.Placeable.Tile.BuildingTiles.Wood.JacarandaWood>(); //ModContent.ItemType<Items.Placeable.Tile.BuildingTiles.Wood.JacarandaWood>();
    }
    public override bool CanDropAcorn()
    {
        return true;
    }
    public override bool Shake(int x, int y, ref bool createLeaves)
    {
        if (Main.getGoodWorld && Main.rand.NextBool(17))
        {
            Projectile.NewProjectile(new EntitySource_ShakeTree(x, y), x * 16, y * 16, Main.rand.Next(-100, 101) * 0.002f, 0f, ProjectileID.Bomb, 0, 0f, Main.myPlayer, 16f, 16f);
        }
        else if (Main.rand.NextBool(35) && Main.halloween)
        {
            Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ItemID.RottenEgg, Main.rand.Next(1, 3));
        }
        else if (Main.rand.NextBool(12))
        {
            Item.NewItem(new EntitySource_ShakeTree(x, y), x * 16, y * 16, 16, 16, ModContent.ItemType<Items.Placeable.Tile.BuildingTiles.Wood.JacarandaWood>(), Main.rand.Next(1, 4));
        }
        else if (Main.rand.NextBool(20))
        {
            int type = ItemID.CopperCoin;
            int chance = Main.rand.Next(50, 100);
            if (Main.rand.NextBool(30))
            {
                type = ItemID.GoldCoin;
                chance = 1;
                if (Main.rand.NextBool(5))
                {
                    chance++;
                }
                if (Main.rand.NextBool(10))
                {
                    chance++;
                }
            }
            else if (Main.rand.NextBool(10))
            {
                type = ItemID.SilverCoin;
                chance = Main.rand.Next(1, 21);
                if (Main.rand.NextBool(3))
                {
                    chance += Main.rand.Next(1, 21);
                }
                if (Main.rand.NextBool(4))
                {
                    chance += Main.rand.Next(1, 21);
                }
            }
            Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, type, chance);
        }
        //else if (Main.rand.NextBool(30))
        //{
        //    NPC.NewNPC(new EntitySource_ShakeTree(x, y), x * 16 + 8, (y - 1) * 16, ModContent.NPCType<Bactus>());
        //}
        //else if (Main.rand.NextBool(12))
        //{
        //    Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, (!Main.rand.NextBool(2)) ? ModContent.ItemType<Items.Food.Durian>() : ModContent.ItemType<Items.Food.Medlar>());
        //}
        return false;
    }
}
